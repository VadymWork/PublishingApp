using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PublishingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublishingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SingleBookController : ControllerBase
    {
        private PublishingDbContext db = new PublishingDbContext();

        private readonly ILogger<SingleBookController> _logger;

        public SingleBookController(ILogger<SingleBookController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public BooksTable GetOne(string name)
        {
            return db.BooksTables.Where(b => b.BookName == name).FirstOrDefault();
        }
    }
}
