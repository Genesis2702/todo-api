using TodoApi.Services.InterfaceServices;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using TodoApi.Data;

namespace TodoApi.Services.ImplementationServices
{
    public class TodoService : ITodoService
    {
        private readonly TodoDbContext _todoContext;

        public TodoService(TodoDbContext todoContext)
        {
            _todoContext = todoContext;
        }

        public async Task<List<TodoItem>> GetAllAsync()
        {
            return await _todoContext.TodoItems.AsNoTracking().ToListAsync();
        }
        public async Task<TodoItem> AddAsync(TodoItem item)
        {
            item.IsCompleted = false;
            item.CreatedAt = DateOnly.FromDateTime(DateTime.Now);
            await _todoContext.TodoItems.AddAsync(item);
            await _todoContext.SaveChangesAsync(); 
            return item;
        }
        public async Task<TodoItem?> GetByIdAsync(int id)
        {
            return await _todoContext.TodoItems.AsNoTracking().FirstOrDefaultAsync(item => item.Id == id);
        }
        public async Task<bool> UpdateAsync(TodoItem item, int id)
        {
            var exist = await _todoContext.TodoItems.FirstOrDefaultAsync(item => item.Id == id);
            if (exist == null)
            {
                return false;
            }
            exist.Title = item.Title;
            exist.IsCompleted = item.IsCompleted;
            await _todoContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var exist = await _todoContext.TodoItems.FirstOrDefaultAsync(item => item.Id == id);
            if (exist == null)
            {
                return false;
            }
            _todoContext.TodoItems.Remove(exist);
            await _todoContext.SaveChangesAsync();
            return true;
        }
    }
}
