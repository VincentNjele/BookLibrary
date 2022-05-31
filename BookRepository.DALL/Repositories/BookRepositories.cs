using BookService.DALL.Interfaces;
using BookWEBAPI.WEB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRepository.DALL.Repositories
{
    public class BookRepositories : IBookService
    {
        private readonly BookLibraryContext _context;

        public BookRepositories(BookLibraryContext context)
        {
            _context = context;
        }
        public Books Add(Books books)
        {
            Books book = new Books();

            book.BookDescription = books.BookDescription;
            book.BookReleaseDate = book.BookReleaseDate;
            book.BookTitle = books.BookTitle;
            book.BookAuthor = books.BookAuthor;

            _context.Books.Add(book);
            _context.SaveChanges();

            return book;
        }

        public void Delete(int id)
        {
            var delete = _context.Books.Where(v => v.BookId == id).FirstOrDefault();

            if(delete!=null)
            {
                _context.Books.Remove(delete);
                _context.SaveChanges();
            }
         
        }

        public Books? Get(int id)
        {
            
       
               var book = _context.Books.Where(x => x.BookId == id).FirstOrDefault();
        
                return book;
      
        }

        public List<Books> GetAll()
        {

            return _context.Books.ToList();
        }

        public void Update(int id, Books books)
        {
            Books? book = _context.Books.Where(x => x.BookId == id).FirstOrDefault();

            if(book!=null)
            {

              _context.Entry(book).CurrentValues.SetValues(books);
                _context.SaveChanges();
            }
        }
    }
}
