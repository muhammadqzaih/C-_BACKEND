using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFCORE;

// A DbContext instance represents a session with the database and can be used to query and save instances of your entities.
// DbContext is a combination of the Unit Of Work and Repository patterns
internal class AppDbContext: DbContext
{

    // Represent the collection of all entities
    // for each table in the database should have a property
    
    public DbSet<Wallet> Wallets { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
            
        var constr = configuration.GetSection("constr").Value;
        optionsBuilder.UseSqlServer(constr);
    }
}