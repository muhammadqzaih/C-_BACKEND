using EF007.ConfigurationByConvention.Data;

namespace EF007.ConfigurationByConvention
{
    // 📘 Configuration by Convention in EF Core
    // Table Naming Convention
    //
    // Class names are used as table names.
    //
    // Primary Key Convention
    //
    // Properties named Id or <EntityName>Id are considered primary keys.
    //
    // Foreign Key Convention
    //
    // Properties named <NavigationPropertyName>Id are treated as foreign keys.
    
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new AppDbContext();
            Console.WriteLine("-------- Users -----------");
            Console.WriteLine();
            foreach (var user in context.Users)
            {
                Console.WriteLine(user.Username);
            }
            Console.WriteLine();
            Console.WriteLine("-------- Tweets -----------");
            Console.WriteLine();
            foreach (var tweet in context.Tweets)
            {
                Console.WriteLine(tweet.TweetText);
            }
            Console.WriteLine();
            Console.WriteLine("-------- Comments -----------");
            Console.WriteLine();
            foreach (var comment in context.Comments)
            {
                Console.WriteLine(comment.CommentText);
            }
        }
    }
}