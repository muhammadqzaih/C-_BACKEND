namespace ConsoleApp1.LibraryManagement.UserClasses;

public class Librarian : User
{
   // Additional Method: AddBook(Book book), RemoveBook(Book book)

   public Librarian(string name, string userId) : base(name, userId, new List<Book>())
   {
   }  
   
   public void AddBook(Book book)
   {  
   }
   public void RemoveBook(Book book)
   {
   }


}