using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryAPI.Data;
using LibraryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly LibraryContext _context;

        public TransactionsController(LibraryContext context)
        {
            _context = context;
        }

        public class IssueRequest
        {
            public int BookId { get; set; }
            public int MemberId { get; set; }
        }

        // POST: api/transactions/issue
        [HttpPost("issue")]
        public async Task<ActionResult<Transaction>> IssueBook([FromBody] IssueRequest request)
        {
            var book = await _context.Books.FindAsync(request.BookId);
            if (book == null)
            {
                return NotFound("Book not found.");
            }

            var member = await _context.Members.FindAsync(request.MemberId);
            if (member == null)
            {
                return NotFound("Member not found.");
            }

            if (book.AvailableStock <= 0)
            {
                return BadRequest("Book not available.");
            }

            book.AvailableStock -= 1;

            var transaction = new Transaction
            {
                BookId = request.BookId,
                MemberId = request.MemberId,
                IssuedOn = DateTime.Now,
                DueDate = DateTime.Now.AddDays(14)
            };

            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            return Ok(transaction);
        }

        // POST: api/transactions/return/5
        [HttpPost("return/{transactionId}")]
        public async Task<ActionResult<Transaction>> ReturnBook(int transactionId)
        {
            var transaction = await _context.Transactions
                .Include(t => t.Book)
                .FirstOrDefaultAsync(t => t.Id == transactionId);

            if (transaction == null)
            {
                return NotFound("Transaction not found.");
            }

            if (transaction.IsReturned)
            {
                return BadRequest("Book is already returned.");
            }

            transaction.ReturnedOn = DateTime.Now;
            
            if (transaction.Book != null)
            {
                transaction.Book.AvailableStock += 1;
            }
            else
            {
                var book = await _context.Books.FindAsync(transaction.BookId);
                if (book != null)
                {
                    book.AvailableStock += 1;
                }
            }

            await _context.SaveChangesAsync();

            return Ok(transaction);
        }

        // GET: api/transactions/overdue
        [HttpGet("overdue")]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetOverdueTransactions()
        {
            return await _context.Transactions
                .Include(t => t.Book)
                .Include(t => t.Member)
                .Where(t => t.ReturnedOn == null && t.DueDate < DateTime.Now)
                .ToListAsync();
        }

        // GET: api/transactions/active
        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetActiveTransactions()
        {
            return await _context.Transactions
                .Include(t => t.Book)
                .Include(t => t.Member)
                .Where(t => t.ReturnedOn == null)
                .ToListAsync();
        }

        // GET: api/transactions/history
        [HttpGet("history")]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactionHistory()
        {
            return await _context.Transactions
                .Include(t => t.Book)
                .Include(t => t.Member)
                .OrderByDescending(t => t.IssuedOn)
                .ToListAsync();
        }
    }
}
