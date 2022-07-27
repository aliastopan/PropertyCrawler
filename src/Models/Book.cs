namespace Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        public string Content { get; set; }

        public Book(int id, string title, string genre, Author author)
        {
            Id = id;
            Title = title;
            Author = author;
            Content = "Lorem ipsum dolor sit amet.";
        }
    }
}