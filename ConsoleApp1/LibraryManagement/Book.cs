namespace ConsoleApp1.LibraryManagement;

public class Book
{
    public string Title { get;  private set; }
    public string Author { get; private set; }
    public string ISBN { get; private set; }
    public bool IsAvailable { get; private  set; }

    public Book(string title, string author, string isbn)
    {
        this.Title = title;
        this.Author = author;
        this.ISBN = isbn;
        this.IsAvailable = true;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"📖 Title: {Title} | Author: {Author} | ISBN: {ISBN} | Available: {IsAvailable}");
    }
    
    public bool BorrowBook()
    {
        if (IsAvailable)
        {
            IsAvailable = false;
            Console.WriteLine($"✅ Book '{Title}' has been borrowed.");
            return true;
        }
        else
        {
            Console.WriteLine($"❌ Book '{Title}' is not available.");
            return false;
        }
    }
    
    public void ReturnBook()
    {
        IsAvailable = true;
        Console.WriteLine($"🔄 Book '{Title}' has been returned.");
    }
}