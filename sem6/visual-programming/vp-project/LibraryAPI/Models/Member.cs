using System;

namespace LibraryAPI.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime RegisteredOn { get; set; } = DateTime.Now;
    }
}
