namespace TodoApi.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public bool IsCompleted { get; set; }
        public DateOnly CreatedAt { get; set; }
    }
}
