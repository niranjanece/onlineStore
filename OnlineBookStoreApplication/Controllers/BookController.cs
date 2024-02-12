using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBookStoreApplication.Models.DTOs;
using Newtonsoft.Json;
using OnlineBookStoreApplication.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using OnlineBookStoreApplication.Models;

namespace OnlineBookStoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("reactApp")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpPost("AddBook")]
        public ActionResult AddBook([FromForm] IFormCollection data)
        {
            IFormFile file = data.Files["image"];

            if (file != null && file.Length > 0)
            {
                string filename = file.FileName;
                string path = Path.Combine(@".\wwwroot\Images", filename);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            string json = data["json"];
            BookDTO bookDTO = JsonConvert.DeserializeObject<BookDTO>(json);
            bookDTO.Image = file;

            string message = string.Empty;
            var book = _bookService.AddBook(bookDTO);
            if(book != null)
            {
                return Ok(book);
            }
            return BadRequest("Could not add book");
        }

        [HttpGet("GetAll")]
        public ActionResult GetAll()
        {
            var book = _bookService.GetAllBook();
            if(book != null)
            {
                return Ok(book);
            }
            return BadRequest("No books available");
        }

        [HttpGet("GetByBookId")]
        public ActionResult GetById(int id)
        {
            var book = _bookService.GetById(id);
            if(book != null)
            {
                return Ok(book);
            }
            return BadRequest("Could not find book");
        }

        [HttpDelete("DeleteBook")]
        public ActionResult DeleteById(int id) {
            var result = _bookService.RemoveBook(id);
            if(result)
            {
                return Ok("Deleted Sucessfullt");
            }
            return BadRequest("Could not delete");
        }

        [HttpPut("UpdateBook")]
       // [Authorize(Roles = "Admin")]
        public ActionResult Update(int id, Book bookd)
        {
            var book = _bookService.UpdateBook(id, bookd);
            if( book != null)
            {
                return Ok(book);
            }
            return BadRequest("Could not update");

        }

        [HttpGet("GetByGenre")]
        public ActionResult GetGenre(string genre)
        {
            var book = _bookService.GetGenre(genre);
            if(book != null)
            {
                return Ok(book);
            }
            return BadRequest("No Books Available");
        }

        [HttpGet("GetByAuthor")]
        public ActionResult GetAuthor(string author)
        {
            var book = _bookService.GetAuthor(author);
            if (book != null)
            {
                return Ok(book);
            }
            return BadRequest("No Books Available");
        }

        [HttpGet("GetByTitle")]
        public ActionResult GetTitle(string title)
        {
            var book = _bookService.GetTitle(title);
            if (book != null)
            {
                return Ok(book);
            }
            return BadRequest("No Books Available");
        }
    }
}
