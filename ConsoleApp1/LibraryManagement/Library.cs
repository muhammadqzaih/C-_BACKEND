namespace ConsoleApp1.LibraryManagement;

public class Library
{ 
 // Create a Library class:
 // Properties: Books (List of Books)
 //  Methods: AddBook(Book book), RemoveBook(Book book), SearchBook(string title), DisplayAllBooks()

 public List<Book> Books { get; set; }

 public Library(List<Book> books )
 {
  this.Books = books;
 }
 public Library()
 {
  this.Books = new List<Book>();
 }

 public void AddBook(Book book)
 {
  this.Books.Add(book);
 }

 public void removeBook(Book book)
 {
  this.Books.Remove(book);
 }

 public void SearchBooks(string bookTitle)
 {
  
 }
}