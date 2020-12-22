using System;
using System.Collections.Generic;

#nullable disable

namespace PublishingApp
{
    public partial class AuthorsTable
    {
        public AuthorsTable()
        {
            BooksTables = new HashSet<BooksTable>();
        }

        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<BooksTable> BooksTables { get; set; }
    }
}
