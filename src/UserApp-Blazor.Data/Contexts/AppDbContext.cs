using Microsoft.EntityFrameworkCore;
using UserApp_Blazor.Domain.Entities;

namespace UserApp_Blazor.Data.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
}