using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Model;

namespace WebAPI.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooks();
        Task<Book> GetBooksById(long id);
        Task<Book> CreateBook(Book book);
        Task UpdateBook(long id, Book book);
        Task DeleteBook(long id);
    }
}
