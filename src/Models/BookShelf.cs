using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Models
{
    public class BookShelf
    {
        public int Id { get; set; }
        public ICollection<Book> Books { get; set; }

        public BookShelf(int id)
        {
            Books = new Collection<Book>();
        }
    }
}