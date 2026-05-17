using System;
using System.Linq;
using LibraryAPI.Models;

namespace LibraryAPI.Data
{
    public static class DatabaseSeeder
    {
        public static void Seed(LibraryContext context)
        {
            if (context.Categories.Any())
            {
                return; // DB has been seeded
            }

            var categories = new Category[]
            {
                new Category { Name = "Fiction" },
                new Category { Name = "Science" },
                new Category { Name = "History" },
                new Category { Name = "Technology" }
            };

            context.Categories.AddRange(categories);
            context.SaveChanges();

            var books = new Book[]
            {
                new Book { Title = "The Great Gatsby",                   Author = "F. Scott Fitzgerald", TotalStock = 5,  AvailableStock = 5,  CategoryId = categories[0].Id },
                new Book { Title = "To Kill a Mockingbird",               Author = "Harper Lee",          TotalStock = 3,  AvailableStock = 3,  CategoryId = categories[0].Id },
                new Book { Title = "A Brief History of Time",             Author = "Stephen Hawking",     TotalStock = 4,  AvailableStock = 4,  CategoryId = categories[1].Id },
                new Book { Title = "The Selfish Gene",                    Author = "Richard Dawkins",     TotalStock = 3,  AvailableStock = 3,  CategoryId = categories[1].Id },
                new Book { Title = "Sapiens: A Brief History of Humankind", Author = "Yuval Noah Harari", TotalStock = 6, AvailableStock = 6,  CategoryId = categories[2].Id },
                new Book { Title = "Guns, Germs, and Steel",              Author = "Jared Diamond",       TotalStock = 5,  AvailableStock = 5,  CategoryId = categories[2].Id },
                new Book { Title = "Clean Code",                          Author = "Robert C. Martin",    TotalStock = 10, AvailableStock = 10, CategoryId = categories[3].Id },
                new Book { Title = "Design Patterns",                     Author = "Erich Gamma",         TotalStock = 7,  AvailableStock = 7,  CategoryId = categories[3].Id }
            };

            context.Books.AddRange(books);
            context.SaveChanges();

            var members = new Member[]
            {
                new Member { Name = "Ali Khan", Email = "ali.khan@example.pk", Phone = "+92 300 1234567", RegisteredOn = DateTime.Now.AddMonths(-2) },
                new Member { Name = "Fatima Ahmed", Email = "fatima.ahmed@example.pk", Phone = "+92 321 7654321", RegisteredOn = DateTime.Now.AddMonths(-1) },
                new Member { Name = "Usman Tariq", Email = "usman.tariq@example.pk", Phone = "+92 333 9876543", RegisteredOn = DateTime.Now.AddDays(-15) },
                new Member { Name = "Ayesha Malik", Email = "ayesha.malik@example.pk", Phone = "+92 345 5678901", RegisteredOn = DateTime.Now.AddDays(-10) },
                new Member { Name = "Zainab Shah", Email = "zainab.shah@example.pk", Phone = "+92 312 3456789", RegisteredOn = DateTime.Now.AddDays(-5) }
            };

            context.Members.AddRange(members);
            context.SaveChanges();

            // 4 Transactions: 2 active (issued today, due in 14 days), 1 overdue (issued 20 days ago, due 6 days ago, not returned), 1 returned
            var transactions = new Transaction[]
            {
                // Active 1
                new Transaction { BookId = books[0].Id, MemberId = members[0].Id, IssuedOn = DateTime.Now, DueDate = DateTime.Now.AddDays(14) },
                // Active 2
                new Transaction { BookId = books[1].Id, MemberId = members[1].Id, IssuedOn = DateTime.Now, DueDate = DateTime.Now.AddDays(14) },
                // Overdue
                new Transaction { BookId = books[2].Id, MemberId = members[2].Id, IssuedOn = DateTime.Now.AddDays(-20), DueDate = DateTime.Now.AddDays(-6) },
                // Returned
                new Transaction { BookId = books[3].Id, MemberId = members[3].Id, IssuedOn = DateTime.Now.AddDays(-30), DueDate = DateTime.Now.AddDays(-16), ReturnedOn = DateTime.Now.AddDays(-18) }
            };

            // Update available stock for the 3 books that are currently issued (not returned)
            books[0].AvailableStock--;
            books[1].AvailableStock--;
            books[2].AvailableStock--;

            context.Transactions.AddRange(transactions);
            context.SaveChanges();
        }
    }
}
