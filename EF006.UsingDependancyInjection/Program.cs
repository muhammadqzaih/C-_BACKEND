using ExternalConfiguraton.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EF006.UsingDependancyInjection
{
    class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config
                .GetSection("constr")
                .Value;

            var services = new ServiceCollection();

            IServiceProvider serviceProvider = services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString)
            ).BuildServiceProvider();

            using var context = serviceProvider.GetService<AppDbContext>();
            foreach (var wallet in context!.Wallets)
            {
                Console.WriteLine(wallet);
            }
        }
    }
}