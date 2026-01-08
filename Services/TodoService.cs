using TodoApi.Models;

namespace TodoApi.Services
{
    public interface ITodoService
    {
        public Task<List<TodoItem>> GetAllAsync();
        public Task<TodoItem> AddAsync(TodoItem item);
        public Task<TodoItem?> GetByIdAsync(int id);
        public Task<bool> UpdateAsync(TodoItem item, int id);
        public Task<bool> DeleteAsync(int id);
    }
    public class TodoService : ITodoService
    {
        private readonly List<TodoItem> _todoList = new();
        private int _nextId = 0;
        public Task<List<TodoItem>> GetAllAsync()
        {
            return Task.FromResult(_todoList.ToList());
        }
        public Task<TodoItem> AddAsync(TodoItem item)
        {
            item.Id = ++_nextId;
            item.IsCompleted = false;
            item.CreatedAt = DateOnly.FromDateTime(DateTime.Now);
            _todoList.Add(item);
            return Task.FromResult(item);
        }
        public Task<TodoItem?> GetByIdAsync(int id)
        {
            var item = _todoList.FirstOrDefault(t => t.Id == id);
            return Task.FromResult(item);
        }
        public Task<bool> UpdateAsync(TodoItem item, int id)
        {
            var exist = _todoList.FirstOrDefault(t => t.Id == id);
            if (exist == null)
            {
                return Task.FromResult(false);
            }
            exist.Id = id;
            exist.Title = item.Title; 
            exist.CreatedAt = item.CreatedAt;
            return Task.FromResult(true);
        }
        public Task<bool> DeleteAsync(int id)
        {
            var exist = _todoList.FirstOrDefault(t => t.Id == id);
            if (exist == null)
            {
                return Task.FromResult(false);
            }
            _todoList.Remove(exist);
            return Task.FromResult(true);
        }
    }
}
