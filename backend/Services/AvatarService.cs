using System.Net.Http.Headers;

namespace Backend.Services;

public class AvatarService(HttpClient http, IConfiguration config)
{
    private static readonly string[] AllowedTypes = ["image/jpeg", "image/jpg", "image/png", "image/webp"];
    private const long MaxBytes = 5 * 1024 * 1024;
    private const string Bucket = "avatars";

    public static (bool valid, string? error) Validate(IFormFile file)
    {
        if (file.Length == 0) return (false, "No file provided.");
        if (file.Length > MaxBytes) return (false, "File too large (max 5 MB).");
        if (!AllowedTypes.Contains(file.ContentType))
            return (false, $"Unsupported file type: {file.ContentType}. Must be JPEG, PNG, or WebP.");
        return (true, null);
    }

    public async Task<string> UploadAsync(Guid userId, IFormFile file, string userToken)
    {
        var supabaseUrl = config["SUPABASE_URL"]!;

        var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
        // Folder = userId so RLS can match auth.uid() to (storage.foldername(name))[1]
        var path = $"{userId}/avatar{ext}";

        using var content = new StreamContent(file.OpenReadStream());
        content.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

        var request = new HttpRequestMessage(HttpMethod.Post,
            $"{supabaseUrl}/storage/v1/object/{Bucket}/{path}")
        {
            Content = content,
        };
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", userToken);

        var response = await http.SendAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync();
            throw new InvalidOperationException($"Supabase Storage {(int)response.StatusCode}: {body}");
        }

        // Add cache-busting so the browser picks up the new image immediately
        var bust = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        return $"{supabaseUrl}/storage/v1/object/public/{Bucket}/{path}?t={bust}";
    }
}
