using System;

namespace LibraryAPI.Models
{
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

        public bool IsReturned => ReturnedOn.HasValue;
    }
}
