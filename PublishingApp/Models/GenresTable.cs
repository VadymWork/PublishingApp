using System;
using System.Collections.Generic;

#nullable disable

namespace PublishingApp.Models
{
    public partial class GenresTable
    {
        public GenresTable()
        {
            BooksTables = new HashSet<BooksTable>();
        }

        public int GenreId { get; set; }
        public string GenreName { get; set; }

        public virtual ICollection<BooksTable> BooksTables { get; set; }
    }
}
