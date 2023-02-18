using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Context;
using WebAPI.Model;

namespace WebAPI.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _context;

        public BookRepository(BookContext context)
        {
            _context = context;
        }

        public async Task<Book> CreateBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task DeleteBook(long id)
        {
            var bookToDelete = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
            _context.Books.Remove(bookToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetBooksById(long id)
        {
            return await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateBook(long id, Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
