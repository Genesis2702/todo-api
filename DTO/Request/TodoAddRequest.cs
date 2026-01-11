namespace TodoApi.DTO.Request
{
    public class TodoAddRequest
    {
        public required string Title { get; set; }
        public required bool IsCompleted { get; set; }
    }
}
