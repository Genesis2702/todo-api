using Microsoft.AspNetCore.Mvc;
using TodoApi.Services.InterfaceServices;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private ITodoService _todoService;
        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }
        [HttpGet]
        public async Task<ActionResult<List<TodoItem>>> GetAll()
        {
            var todoList = await _todoService.GetAllAsync();
            return Ok(todoList);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem?>> GetById(int id)
        {
            var todoItem = await _todoService.GetByIdAsync(id);
            return todoItem != null ? Ok(todoItem) : NotFound();
        }
        [HttpPost]
        public async Task<ActionResult<TodoItem>> Add(TodoItem item)
        {
            var todoItem = await _todoService.AddAsync(item);
            return CreatedAtAction(nameof(GetById), new { id = todoItem.Id }, todoItem);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(TodoItem item, int id)
        {
            var success = await _todoService.UpdateAsync(item, id);
            return success ? NoContent() : NotFound();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success =  await _todoService.DeleteAsync(id);
            return success ? NoContent() : NotFound(); 
        }
    }
}
