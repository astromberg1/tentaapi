using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyLibrary.Models;

namespace MyLibrary.Controllers
{
    public class BookController : ApiController
    {
        public static List<Book> books = new List<Book>();


        public BookController()
        {
            if (books.Count() < 5)
            {
                books.Add(new Book() {Author = "Sven", ISBN = 1, Price = 100, Title = "Bilbo"});
                books.Add(new Book() {Author = "Kalle", ISBN = 2, Price = 120, Title = "Frodo"});
                books.Add(new Book() {Author = "Per", ISBN = 3, Price = 120, Title = "Kalles vänner"});
                books.Add(new Book() {Author = "Hohan", ISBN = 4, Price = 120, Title = "Tarzan"});
            }
        }

        [Route("api/Book/GetAllBooks")]
        public IEnumerable<Book> GetAllBooks()
        {
            return books;
        }

        //[HttpGet]
        [Route("api/Book/GetBook/{id}")]
        public IHttpActionResult GetBook(int id)
        {
            Book result = books.FirstOrDefault(x => x.ISBN == id);
            if (result == null)
                return NotFound();
            else
            {
                return Ok(result);
            }
        }
    }
}
  

