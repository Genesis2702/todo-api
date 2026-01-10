namespace TodoApi.DTO.Response
{
    public class TodoResponse
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public bool IsCompleted { get; set; }
        public DateOnly CreatedAt { get; set; }
    }
}
