using System;
using System.Collections.Generic;

#nullable disable

namespace PublishingApp
{
    public partial class BooksTable
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public byte[] Cover { get; set; }
        public int? Author { get; set; }
        public int? Genre { get; set; }
        public int? State { get; set; }

        public virtual AuthorsTable AuthorNavigation { get; set; }
        public virtual GenresTable GenreNavigation { get; set; }
        public virtual StateTable StateNavigation { get; set; }
    }
}
