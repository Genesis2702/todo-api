namespace TodoApi.DTO.Request
{
    public class TodoUpdateRequest
    {
        public required string Title { get; set; }
        public required bool IsCompleted { get; set; }
    }
}
