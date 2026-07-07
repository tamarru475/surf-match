using Backend.Data;
using Backend.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<UserEntity> Users => Set<UserEntity>();
    public DbSet<SurfSpotEntity> SurfSpots => Set<SurfSpotEntity>();
    public DbSet<UserPreferencesEntity> UserPreferences => Set<UserPreferencesEntity>();
    public DbSet<FavoriteEntity> Favorites => Set<FavoriteEntity>();
    public DbSet<SurfSessionEntity> SurfSessions => Set<SurfSessionEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // ── users ─────────────────────────────────────────────────────────────
        modelBuilder.Entity<UserEntity>(e =>
        {
            e.ToTable("users");
            e.HasKey(u => u.Id);
            e.Property(u => u.Email).IsRequired();
            e.HasIndex(u => u.Email).IsUnique();
            e.Property(u => u.CreatedAt).HasDefaultValueSql("now()");
            e.Property(u => u.UpdatedAt).HasDefaultValueSql("now()");
        });

        // ── surf_spots ────────────────────────────────────────────────────────
        modelBuilder.Entity<SurfSpotEntity>(e =>
        {
            e.ToTable("surf_spots");
            e.HasKey(s => s.Id);
            e.Property(s => s.SuitableBoardTypes).HasColumnType("text[]");
            e.Property(s => s.Facilities).HasColumnType("text[]");
            e.Property(s => s.CreatedAt).HasDefaultValueSql("now()");

            // Seed all spots from the existing catalog so the DB starts populated.
            e.HasData(SurfSpotCatalog.All.Select(s => new SurfSpotEntity
            {
                Id             = s.Id,
                Name           = s.Name,
                Region         = s.Region.ToString(),
                WaveType       = s.WaveType.ToString(),
                MinSkillLevel  = s.MinSkillLevel.ToString(),
                SuitableBoardTypes = s.SuitableBoardTypes.Select(b => b.ToString()).ToList(),
                Facilities     = s.Facilities.Select(f => f.ToString()).ToList(),
                TypicalCrowd   = s.TypicalCrowd.ToString(),
                MinWaveSize    = s.MinWaveSize.ToString(),
                MaxWaveSize    = s.MaxWaveSize.ToString(),
                CurrentWaveSize = s.CurrentWaveSize.ToString(),
                Description    = s.Description,
                CreatedAt      = new DateTime(2026, 7, 2, 0, 0, 0, DateTimeKind.Utc),
            }));
        });

        // ── user_preferences ──────────────────────────────────────────────────
        modelBuilder.Entity<UserPreferencesEntity>(e =>
        {
            e.ToTable("user_preferences");
            e.HasKey(p => p.Id);
            e.HasIndex(p => p.UserId).IsUnique();
            e.Property(p => p.BoardTypes).HasColumnType("text[]");
            e.Property(p => p.PreferredWaveTypes).HasColumnType("text[]");
            e.Property(p => p.PreferredWaveSizes).HasColumnType("text[]");
            e.Property(p => p.PreferredFacilities).HasColumnType("text[]");
            e.Property(p => p.UpdatedAt).HasDefaultValueSql("now()");
            e.HasOne(p => p.User)
             .WithOne(u => u.Preferences)
             .HasForeignKey<UserPreferencesEntity>(p => p.UserId)
             .OnDelete(DeleteBehavior.Cascade);
        });

        // ── favorites ─────────────────────────────────────────────────────────
        modelBuilder.Entity<FavoriteEntity>(e =>
        {
            e.ToTable("favorites");
            e.HasKey(f => f.Id);
            e.HasIndex(f => new { f.UserId, f.SpotId }).IsUnique();
            e.Property(f => f.CreatedAt).HasDefaultValueSql("now()");
            e.HasOne(f => f.User)
             .WithMany(u => u.Favorites)
             .HasForeignKey(f => f.UserId)
             .OnDelete(DeleteBehavior.Cascade);
            e.HasOne(f => f.Spot)
             .WithMany(s => s.Favorites)
             .HasForeignKey(f => f.SpotId)
             .OnDelete(DeleteBehavior.Cascade);
        });

        // ── surf_sessions ─────────────────────────────────────────────────────
        modelBuilder.Entity<SurfSessionEntity>(e =>
        {
            e.ToTable("surf_sessions");
            e.HasKey(s => s.Id);
            e.Property(s => s.CreatedAt).HasDefaultValueSql("now()");
            e.HasOne(s => s.User)
             .WithMany(u => u.SurfSessions)
             .HasForeignKey(s => s.UserId)
             .OnDelete(DeleteBehavior.Cascade);
            e.HasOne(s => s.Spot)
             .WithMany(sp => sp.SurfSessions)
             .HasForeignKey(s => s.SpotId)
             .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
