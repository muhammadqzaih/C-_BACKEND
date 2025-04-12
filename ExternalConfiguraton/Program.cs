using ExternalConfiguraton.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ExternalConfiguraton
{
    class Program
    {
        public static void Main(string[] args)
        {
            var config  = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config
                .GetSection("constr")
                .Value;

            var optionBuilder = new DbContextOptionsBuilder();
            optionBuilder.UseSqlServer(connectionString);
            
            var options = optionBuilder.Options;

            using (var context = new AppDbContext(options))
            {
                foreach (var wallet in context.Wallets)
                {
                    Console.WriteLine(wallet);
                }
            }
        }
    }
}