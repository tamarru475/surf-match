using System.Text.Json.Serialization;
using Backend.Auth;
using Backend.Database;
using Backend.Database.Entities;
using Backend.Models;
using Backend.Models.Dtos;
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

builder.Services.ConfigureHttpJsonOptions(options =>
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter()));

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
builder.Services.AddScoped<RecommendationEngine>();

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

app.MapGet("/health", async (AppDbContext db) =>
{
    await db.Database.ExecuteSqlRawAsync("SELECT 1");
    return Results.Ok(new { status = "ok" });
})
.WithName("Health");

app.MapPost("/recommendations", async (UserPreferences prefs, RecommendationEngine engine) =>
    Results.Ok(await engine.GetRecommendationsAsync(prefs)))
    .WithName("GetRecommendations");

app.MapGet("/me", async (HttpContext ctx, ProfileService profiles) =>
{
    var user = await profiles.GetOrCreateAsync(ctx.User.GetUserId(), ctx.User.GetEmail());
    return Results.Ok(ToProfileResponse(user));
})
.RequireAuthorization()
.WithName("GetProfile");

app.MapPut("/me", async (HttpContext ctx, UpdateProfileRequest req, ProfileService profiles) =>
{
    var user = await profiles.UpdateAsync(ctx.User.GetUserId(), req);
    return user is null ? Results.NotFound() : Results.Ok(ToProfileResponse(user));
})
.RequireAuthorization()
.WithName("UpdateProfile");

static ProfileResponse ToProfileResponse(UserEntity u) =>
    new(u.Id, u.Email, u.DisplayName, u.AvatarUrl, u.Location, u.Bio, u.InstagramHandle, u.TikTokHandle);

app.MapGet("/me/preferences", async (HttpContext ctx, PreferencesService prefs) =>
{
    var result = await prefs.GetAsync(ctx.User.GetUserId());
    return result is null ? Results.NotFound() : Results.Ok(result);
})
.RequireAuthorization()
.WithName("GetPreferences");

app.MapPut("/me/preferences", async (HttpContext ctx, UserPreferences req, PreferencesService prefs, ProfileService profiles) =>
{
    // Ensure user row exists before inserting preferences (FK constraint).
    await profiles.GetOrCreateAsync(ctx.User.GetUserId(), ctx.User.GetEmail());
    var result = await prefs.UpsertAsync(ctx.User.GetUserId(), req);
    return Results.Ok(result);
})
.RequireAuthorization()
.WithName("UpsertPreferences");

app.Run();
