using EF007.ConfigurationByConvention.Entities;
using EF007.ConfigurationUsingGroupingConfiguration.Data.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EF007.ConfigurationUsingGroupingConfiguration.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Tweet> Tweets { get; set; } = null!;
    public DbSet<Comment> Comments { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<User>());
        // new TweetEntityTypeConfiguration().Configure(modelBuilder.Entity<Tweet>());
        // new CommentEntityTypeConfiguration().Configure(modelBuilder.Entity<Comment>());
        
        // we can use ApplyConfigurationsFromAssembly Inested of above code ! : 
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserEntityTypeConfiguration).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();


        var connectionString = config.GetSection("constr").Value;

        optionsBuilder.UseSqlServer(connectionString);
    }
}