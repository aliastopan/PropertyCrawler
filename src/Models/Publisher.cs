namespace Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Publisher(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}