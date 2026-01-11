using Microsoft.AspNetCore.Mvc;
using TodoApi.Services.InterfaceServices;
using TodoApi.Models;
using TodoApi.DTO.Request;
using TodoApi.DTO.Response;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }
        [HttpGet]
        public async Task<ActionResult<List<TodoResponse>>> GetAll()
        {
            var todoList = await _todoService.GetAllAsync();
            var todoResponse = todoList.Select(item => new TodoResponse 
            { 
                Id = item.Id, 
                Title = item.Title, 
                IsCompleted = item.IsCompleted, 
                CreatedAt = item.CreatedAt 
            }).ToList();
            return Ok(todoResponse);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoResponse?>> GetById(int id)
        {
            var todoItem = await _todoService.GetByIdAsync(id);
            if (todoItem == null) return NotFound();
            var todoResponse = new TodoResponse 
            { 
                Id = todoItem.Id, 
                Title = todoItem.Title, 
                IsCompleted = todoItem.IsCompleted, 
                CreatedAt = todoItem.CreatedAt 
            };
            return Ok(todoResponse);
        }
        [HttpPost]
        public async Task<ActionResult<TodoResponse>> Add(TodoAddRequest todoAddRequest)
        {
            var item = new TodoItem
            {
                Title = todoAddRequest.Title,
                IsCompleted = todoAddRequest.IsCompleted
            };
            var todoItem = await _todoService.AddAsync(item);
            var todoResponse = new TodoResponse 
            { 
                Id = todoItem.Id, 
                Title = todoItem.Title, 
                IsCompleted = todoItem.IsCompleted, 
                CreatedAt = todoItem.CreatedAt 
            };
            return CreatedAtAction(nameof(GetById), new { id = todoResponse.Id }, todoResponse);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(TodoUpdateRequest todoUpdateRequest, int id)
        {
            var item = new TodoItem
            {
                Title = todoUpdateRequest.Title,
                IsCompleted = todoUpdateRequest.IsCompleted
            };
            var success = await _todoService.UpdateAsync(item, id);
            return success ? NoContent() : NotFound();
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, TodoPatchRequest todoPatchRequest)
        {
            var success = await _todoService.PatchAsync(id, todoPatchRequest.Title, todoPatchRequest.IsCompleted);
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
