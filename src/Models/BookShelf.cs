using System.Collections.Generic;

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