namespace TodoApi.DTO.Request
{
    public class TodoPatchRequest
    {
        public string? Title { get; set; }
        public bool? IsCompleted { get; set; }
    }
}
