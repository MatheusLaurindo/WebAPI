using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Model;
using WebAPI.Repositories;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _bookRepository.GetBooks();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBooksById(long id)
        {
            return await _bookRepository.GetBooksById(id);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> PostBooks([FromBody] Book book)
        {
            var newBook = await _bookRepository.CreateBook(book);
            return newBook;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var bookToDelete = await _bookRepository.GetBooksById(id);
            if(bookToDelete == null)
            {
                return NotFound();
            }

            await _bookRepository.DeleteBook(bookToDelete.Id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutBooks(long id, [FromBody] Book book)
        {
            if (book == null)
                return BadRequest();

            await _bookRepository.UpdateBook(id, book);

            return NoContent();
        }

    }
}
