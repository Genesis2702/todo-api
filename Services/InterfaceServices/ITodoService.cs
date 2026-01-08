using TodoApi.Models;

namespace TodoApi.Services.InterfaceServices
{
    public interface ITodoService
    {
        public Task<List<TodoItem>> GetAllAsync();
        public Task<TodoItem> AddAsync(TodoItem item);
        public Task<TodoItem?> GetByIdAsync(int id);
        public Task<bool> UpdateAsync(TodoItem item, int id);
        public Task<bool> DeleteAsync(int id);
    }
}
