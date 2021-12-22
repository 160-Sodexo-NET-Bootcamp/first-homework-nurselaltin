using BookWebAPI.Fn;
using BookWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BookWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public List<Book> _list;
        public BookController()
        {
            _list = new List<Book>() { 
                  new Book(){ID = 1, BookName = "Dune", BookSerialNo = "0061964360", Author = "Frank Herbert" },
                  new Book(){ID = 2, BookName = "Canlı Devre", BookSerialNo = "0051974380", Author = "David Eagleman" },
                  new Book(){ID = 3, BookName = "Sineklerin Tanrısı", BookSerialNo = "0051966368", Author = "William Golding" },
                  new Book(){ID = 4, BookName = "Saatleri Ayarlama Enstitüsü", BookSerialNo = "0051967308", Author = "Ahmet H. Tanpınar" },
                  new Book(){ID = 5, BookName = "Outfiers", BookSerialNo = "0021976368", Author = "Malcolm Gladwell" },
                  new Book(){ID = 6, BookName = "Satranç", BookSerialNo = "00218796368", Author = "Stefan Zweig" },
            };
        }

        /// <summary>
        /// Get all books.
        /// </summary>
        /// <returns></returns>
        [HttpPost("BookList")]
        public IActionResult Post()
        {
            return Ok(_list);
        }

        /// <summary>
        /// Get book of ID value.Get the id value with FromQuery.
        /// </summary>
        /// <param name="id"><param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetByID([FromQuery] int ID)
        {
            //Control id and book information
            var result = BookOperation.Handle(ID, _list);
            if (!result)
               return BadRequest("Something wrong!Check your book informations.");
            //Get book
            var book = _list.FirstOrDefault(x => x.ID == ID);

            return Ok(book);
        }

        /// <summary>
        /// Get book of ID value.Get the id value with FromRoute.
        /// </summary>
        /// <param name="id"><param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            //Control id and book information
            var result = BookOperation.Handle(id, _list);
            if (!result)
                return BadRequest("Something wrong!Check your book informations.");
            var book = _list.FirstOrDefault(x => x.ID == id);
            return Ok(book);
        }

        /// <summary>
        /// Add new book to the list.
        /// </summary>
        /// <param name="model">The model type is  Book model.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Book model)
        {
            //Control the new model
            if (model is null)
                return Ok("Please , input the book information.You can not send empty model.");

            //Is model exist?
            var isExist = _list.Where(x => x.ID == model.ID && x.BookName.ToLower() == model.BookName.ToLower());
            if (isExist.Count() != 0)
                return BadRequest("This book already added.");

            //Add new book
            _list.Add(model);

            return Ok(_list);
        }

        /// <summary>
        /// Update book of ID. Get the id value with FromRoute.
        /// </summary>
        /// <param name="model">The model type is  Book model.</param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Book model, int id)
        {
            //Control id and book information
            var result = BookOperation.Handle(id, _list);
            if (!result)
               return BadRequest("Something wrong!Check your book informations.");

            //Update book
            var book = _list.FirstOrDefault(x => x.ID == id);
            book.BookName = model.BookName;
            book.BookSerialNo = model.BookSerialNo;
            book.Author = model.Author;

            return Ok(book);
        }

        /// <summary>
        /// Delete book of id. Get the id value with FromRoute
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //Control id and book information
            var result = BookOperation.Handle(id,_list);
            if (!result)
               return  BadRequest("Something wrong!Check your book informations.");

            //Remove book
            var book = _list.FirstOrDefault(x => x.ID == id);
            _list.Remove(book);

            return Ok(_list);
        }
    }
}
