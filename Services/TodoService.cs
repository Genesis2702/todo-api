using TodoApi.Models;

namespace TodoApi.Services
{
    public class TodoService
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
            exist.Title = item.Title; 
            exist.CreatedAt = item.CreatedAt;
            return Task.FromResult(true);
        }
        public Task<bool> RemoveAsync(int id)
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
