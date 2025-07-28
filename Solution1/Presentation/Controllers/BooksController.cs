using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BLL.Services;
using BLL.DTOs;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace Presentation.Controllers
{
    /// <summary>
    /// API controller for managing books.
    /// </summary>
    [ApiController]
    [Route("api/v1/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService) => _bookService = bookService;

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAllAsync() => Ok(await _bookService.GetAllBooksAsync());

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<BookDto>> GetByIdAsync(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddAsync([FromBody] BookDto bookDto)
        {
            await _bookService.AddBookAsync(bookDto);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = bookDto.Id }, bookDto);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAsync([FromBody] BookDto bookDto)
        {
            await _bookService.UpdateBookAsync(bookDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _bookService.DeleteBookAsync(id);
            return NoContent();
        }
    }
}
