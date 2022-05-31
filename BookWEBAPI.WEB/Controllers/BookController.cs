using BookService.DALL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookWEBAPI.WEB.Controllers
{
  
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;

        public BookController(IBookService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("api/[controller]")]

        public List<Books> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]

        public Books? GetById(int id)
        {
            var book = _service.Get(id);

            return book;
        }

        [HttpPost]
        [Route("api/[controller]")]

        public Books Add(Books books)
        {
            return _service.Add(books);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]

        public IActionResult Delete(int id)
        {
             _service.Delete(id);

            return Ok("Book deleted successfully");
        }

        [HttpPut]
        [Route("api/[controller]/{id}")]

        public IActionResult Update(int id,Books books )
        {
            _service.Update(id, books);

            return Ok("successfully");
        }
    }
}
