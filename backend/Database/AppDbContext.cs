using Microsoft.EntityFrameworkCore;

namespace Backend.Database;

// Entity sets will be added here as tables are introduced in subsequent tickets.
// For now this exists to verify the Supabase connection and provide the
// EF Core infrastructure that the rest of V2 will build on.
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
}
