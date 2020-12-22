using System;
using System.Collections.Generic;

#nullable disable

namespace PublishingApp
{
    public partial class StateTable
    {
        public StateTable()
        {
            BooksTables = new HashSet<BooksTable>();
        }

        public int StateId { get; set; }
        public string State { get; set; }

        public virtual ICollection<BooksTable> BooksTables { get; set; }
    }
}
