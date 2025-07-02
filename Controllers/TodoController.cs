using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Dtos;
using TodoApi.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private static readonly List<TodoItem> _tasks = new();
        private static int _idCounter = 1;
        private readonly AppDbContext _context;

        public TodoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => 
            Ok(await _context.TodoItems.ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _context.TodoItems.FindAsync(id);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TodoCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var item = new TodoItem
            {
                Title = dto.Title,
                IsCompleted = dto.IsCompleted
            };

            _context.TodoItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TodoUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var item = await _context.TodoItems.FindAsync(id);
            if (item is null) return NotFound();

            item.Title = dto.Title;
            item.IsCompleted = dto.IsCompleted;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.TodoItems.FindAsync(id);
            if (item is null) return NotFound();

            _context.TodoItems.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

