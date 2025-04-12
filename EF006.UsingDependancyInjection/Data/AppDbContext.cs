using EFCORE;
using Microsoft.EntityFrameworkCore;

namespace ExternalConfiguraton.Data;

public class AppDbContext: DbContext
{
    public DbSet<Wallet> Wallets { get; set; } = null!;

    public AppDbContext(DbContextOptions options)
    :base(options)
    {
        
    }
}