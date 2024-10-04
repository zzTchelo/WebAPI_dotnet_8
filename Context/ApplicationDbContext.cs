using Microsoft.EntityFrameworkCore;
using UC_WebApi.Controllers;

namespace UC_WebApi.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt){ }

    public DbSet<Client> Clients { get; set;}
}
