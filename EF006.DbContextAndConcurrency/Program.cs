using EFCORE;
using ExternalConfiguraton.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EF006.DbContextAndConcurrency
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetSection("constr").Value;

            var services = new ServiceCollection();
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            var serviceProvider = services.BuildServiceProvider();

            var tasks = new[]
            {
                Jop1(serviceProvider),
                Jop2(serviceProvider)
            };

            await Task.WhenAll(tasks);

            Console.WriteLine("Jop1 and Jop2 execution succeeded.");
        }

        static async Task Jop1(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var w1 = new Wallet { Holder = "Marah Qzih", Balance = 90000m };
            dbContext.Wallets.Add(w1);
            await dbContext.SaveChangesAsync();
        }

        static async Task Jop2(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var w1 = new Wallet { Holder = "Ayman Qzih", Balance = 10000m };
            dbContext.Wallets.Add(w1);
            await dbContext.SaveChangesAsync();
        }
        
    }
}