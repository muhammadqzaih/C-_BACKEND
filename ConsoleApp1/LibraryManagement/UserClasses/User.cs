namespace ConsoleApp1.LibraryManagement.UserClasses;

public class User
{
  //  Create a User class with:
  // Properties: Name, UserID, BorrowedBooks (List of Books)
  //  Methods: BorrowBook(Book book), ReturnBook(Book book), DisplayUserInfo()
  
  public string Name { get; private set; }
  public string UserId { get; private set; }
  public List<Book> Books { get; private set; }

  public User(string name, string userId, List<Book> books)
  {
    this.Name = name;
    this.UserId = userId;
    this.Books = books;
  }

  public User()
  {
    this.Books = new List<Book>();
  }

  public User(string name, string userId)
  {
    this.Name = name;
    this.UserId = userId;
  }

  public void BorrowBook(Book book)
  {
    if(book.IsAvailable)
        Books.Add(book);
    else
      Console.WriteLine("This book is already borrowed.!");
  }
  
  


}