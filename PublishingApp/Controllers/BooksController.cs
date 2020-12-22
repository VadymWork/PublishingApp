using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using PublishingApp.Models;

namespace PublishingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private PublishingDbContext db = new PublishingDbContext();

        private readonly ILogger<BooksController> _logger;

        public BooksController(ILogger<BooksController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        //Отримання всього переліку книг
        public IEnumerable<BooksTable> Get()
        {
            Console.WriteLine(db.BooksTables.FirstOrDefault().BookName);
            return db.BooksTables.ToList();

        }

        [HttpPost]
        public void Post(BooksTable book)
        {
            db.BooksTables.Add(book);
            db.SaveChanges();
        }
        //public IEnumerable<BooksTable> findBook(AuthorsTable author, GenresTable genre, StateTable state)
        //{
        //    List<BooksTable> books = new List<BooksTable>();
        //    if(author != null)
        //    {
        //        books = db.BooksTables.Where(b => b.Author == author.AuthorId).ToList();
        //    }           
        //    return books;

        //}
        [HttpPut]

        public void Put(int id, BooksTable newBook)
        {
            BooksTable oldBook = db.BooksTables.Find(id);
            if (newBook.BookName != null)
            {
                oldBook.BookName = newBook.BookName;
            }
            if (newBook.Author != null)
            {
                oldBook.Author = newBook.Author;
            }
            if (newBook.Genre != null)
            {
                oldBook.Genre = newBook.Genre;
            }
            if (newBook.State != null)
            {
                oldBook.State = newBook.State;
            }
        }
        [HttpDelete]
        public void Delete(int id)
        {
            db.BooksTables.Remove(db.BooksTables.Find(id));
            db.SaveChanges();
        }
    }
}
