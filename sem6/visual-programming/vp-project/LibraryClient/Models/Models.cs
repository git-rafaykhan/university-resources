namespace LibraryClient.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int TotalStock { get; set; }
        public int AvailableStock { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        
        public string? CategoryName => Category?.Name;
        public string DisplayTitle => $"{Title} ({AvailableStock} available)";
        public int Issued => TotalStock - AvailableStock;
    }

    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime RegisteredOn { get; set; }
    }

    public class Transaction
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book? Book { get; set; }
        public int MemberId { get; set; }
        public Member? Member { get; set; }
        public DateTime IssuedOn { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnedOn { get; set; }
        public bool IsReturned { get; set; }

        public string? BookTitle => Book?.Title;
        public string? MemberName => Member?.Name;
        public string Status => IsReturned ? "Returned" : (DueDate < DateTime.Now ? "OVERDUE" : "Active");
        public int DaysOverdue => ReturnedOn == null && DueDate < DateTime.Now ? (int)(DateTime.Now.Date - DueDate.Date).TotalDays : 0;
    }
}
