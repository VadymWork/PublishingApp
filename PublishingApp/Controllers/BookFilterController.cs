using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PublishingApp.Models;
using Microsoft.Extensions.Logging;


namespace PublishingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookFilterController : ControllerBase
    {
        private PublishingDbContext db = new PublishingDbContext();

        private readonly ILogger<BookFilterController> _logger;

        public BookFilterController(ILogger<BookFilterController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<BooksTable> Get(AuthorsTable author, GenresTable genre, StateTable state)
        {
            List<BooksTable> books = null;
            if (author != null)
            {
                books = db.BooksTables.Where(b => b.Author == author.AuthorId).ToList();
            }
            if (genre != null)
            {
                if (books != null)
                {
                    books = books.Where(b => b.Genre == genre.GenreId).ToList();
                }
                else
                {
                    books = db.BooksTables.Where(b => b.Genre == genre.GenreId).ToList();
                }
            }
            if (state != null)
            {
                if (books != null)
                {
                    books = books.Where(b => b.State == state.StateId).ToList();
                }
                else
                {
                    books = db.BooksTables.Where(b => b.State == state.StateId).ToList();
                }
            }
            return books;
        }
    }
}
