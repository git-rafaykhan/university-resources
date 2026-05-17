namespace LibraryAPI.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int TotalStock { get; set; }
        public int AvailableStock { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
