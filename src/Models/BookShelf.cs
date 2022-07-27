using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Models
{
    public class BookShelf
    {
        public int Id { get; set; }
        public List<Book> Books { get; set; }

        public BookShelf(int id)
        {
            Books = new List<Book>();
        }
    }
}