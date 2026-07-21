using System.Text.Json.Serialization;
using Backend.Database;
using Backend.Services;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

// Load .env from repo root when running locally — production uses real env vars.
var envPath = Path.Combine(Directory.GetCurrentDirectory(), "..", ".env");
if (File.Exists(envPath))
    Env.Load(envPath);

var builder = WebApplication.CreateBuilder(args);

var corsOrigin = builder.Configuration["CORS_ORIGIN"] ?? "http://localhost:3000";
builder.Services.AddCors(options =>
    options.AddDefaultPolicy(policy =>
        policy.WithOrigins(corsOrigin)
              .AllowAnyHeader()
              .AllowAnyMethod()));

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("ConnectionStrings:DefaultConnection is not configured.");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString)
           .ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning)));

var supabaseUrl = builder.Configuration["SUPABASE_URL"]
    ?? throw new InvalidOperationException("SUPABASE_URL is not configured.");

// Use Supabase's JWKS endpoint for token validation — no secret needed.
// The middleware fetches and caches the public signing keys automatically.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = $"{supabaseUrl}/auth/v1";
        options.TokenValidationParameters.ValidAudience = "authenticated";
    });

builder.Services.AddAuthorization();
builder.Services.AddScoped<ProfileService>();
builder.Services.AddScoped<PreferencesService>();
builder.Services.AddScoped<FavoritesService>();
builder.Services.AddScoped<SurfSessionService>();
builder.Services.AddScoped<RecommendationEngine>();
builder.Services.AddHttpClient<AvatarService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
if (!app.Environment.IsProduction())
    app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapGet("/health", async (AppDbContext db) =>
{
    await db.Database.ExecuteSqlRawAsync("SELECT 1");
    return Results.Ok(new { status = "ok" });
})
.WithName("Health");

app.Run();
