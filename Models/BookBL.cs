using Microsoft.AspNetCore.Mvc;

namespace LibraryInventory.Models
{
    public class BookBL
    {
        
        private readonly Context _context = new Context();
        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }
        public void RemoveBook(int id)
        {
            var book = _context.Books.FirstOrDefault(e => e.Id == id);
            if (book != null)   
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }

        public Book? GetBook(int id)
        {
          Book  book= _context.Books.FirstOrDefault(e => e.Id == id);
            return book;
        }

        public void UpdateBook(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }

        public List<Book>GetAllBooks()
        {
            return _context.Books.ToList();
        }
    }
}
