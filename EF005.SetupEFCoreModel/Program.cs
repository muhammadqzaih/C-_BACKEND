using System.Collections.Immutable;
using Microsoft.Extensions.Configuration;

namespace EFCORE;

//In C#, the using statement is used to ensure that an object is disposed of properly after its usage.
//It works with types that implement the IDisposable interface,
//which typically involves objects that deal with unmanaged resources, such as file streams, database connections,
//or network connections. The using block creates a scope in which the object is used, and once the block is exited,
//the object's Dispose() method is automatically called, cleaning up resources.

internal class Program
{
    public static void Main(string[] args)
    {
        using (var context = new AppDbContext())
        {
            foreach (var wallet in context.Wallets) Console.WriteLine(wallet);
        }

        Console.WriteLine("Get wallet by id:");
        var walletId = 2;
        using (var context = new AppDbContext())
        {
            var wallet = context.Wallets.FirstOrDefault(x => x.Id == walletId);
            Console.WriteLine(wallet);
        }
        
        //----- insert data : 
        var newWallet = new Wallet
        {
            Balance = 12300,
            Holder = "muhammad qizh",
        };
        
        using (var context = new AppDbContext())
        {
            context.Wallets.Add(newWallet);
            context.SaveChanges();
        }
  
         // ---update data : 
         //update wallet with id 4: increase 1000 to the balance : 
         using (var context = new AppDbContext())
         {
             var wallet = context.Wallets.Single(x => x.Id == 2);
             wallet.Balance += 1000;
             context.SaveChanges();
         }
        
         using (var context = new AppDbContext())
         {
             var wallet = context.Wallets.Single(x => x.Id == 5);
             context.Wallets.Remove(wallet);
             context.SaveChanges();
         }
        
        Console.WriteLine("Get Wallets That have balance grrater than or equal 10000:");
        // query: 
        using (var context = new AppDbContext())
        {
            var result = context.Wallets.Where(x => x.Balance >= 10000);
            foreach (var wallet in result)
            {
                Console.WriteLine(wallet);
            }
        }
        
        //  make transaction : convert 500 form wallet Id 1 to wallet Id 3:
        using (var context = new AppDbContext())
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                var fromWallet = context.Wallets.FirstOrDefault(x => x.Id == 1);
                
                var toWallet = context.Wallets.FirstOrDefault(x => x.Id == 3);
                
                var ammountToWallet = 500m;

                if (fromWallet != null) fromWallet.Balance -= ammountToWallet;
                context.SaveChanges();

                if (toWallet != null) toWallet.Balance += ammountToWallet;
                context.SaveChanges();
                
                transaction.Commit();
            }
        }
    }
}