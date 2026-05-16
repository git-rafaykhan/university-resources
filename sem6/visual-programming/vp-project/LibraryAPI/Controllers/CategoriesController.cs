using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryAPI.Data;
using LibraryAPI.Models;
using System.Threading.Tasks;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly LibraryContext _db;
        public CategoriesController(LibraryContext db) => _db = db;

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _db.Categories.ToListAsync());

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            _db.Categories.Add(category);
            await _db.SaveChangesAsync();
            return Ok(category);
        }
    }
}
