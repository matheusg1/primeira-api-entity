using ApiMatheusGomes.Model;
using ApiMatheusGomes.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiMatheusGomes.Controllers
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

        [HttpGet("getAllBooks")]
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _bookRepository.Get();
        }

        [HttpGet("getBook/{id}")]
        public async Task<ActionResult<Book>> GetBooks(int id)
        {
            return await _bookRepository.Get(id);
        }

        [HttpPost("addBook")]
        public async Task<ActionResult<Book>> PostBook([FromBody] Book book)
        {
            var newBook = await _bookRepository.Create(book);
            return CreatedAtAction(nameof(GetBooks), new { id = newBook.Id }, newBook);
        }

        [HttpDelete("deleteBook/{id}")]
        public async Task<ActionResult<Book>> Delete(int id)
        {
            var bookToDelete = await _bookRepository.Get(id);
            if (bookToDelete != null)
            {
                await _bookRepository.Delete(bookToDelete.Id);
                return NoContent();
            }
            else
                return NotFound();
        }
        [HttpPut("editBook")]
        public async Task<ActionResult> PutBooks(int id, [FromBody] Book book)
        {
            if (id == book.Id)
            {
                await _bookRepository.Update(book);
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPatch("fixBook/{id}")]
        public async Task<ActionResult> PatchBook([FromRoute] int id, [FromBody] JsonPatchDocument bookModel)
        {
            await _bookRepository.Patch(id, bookModel);
            return NoContent();

        }
    }
}
