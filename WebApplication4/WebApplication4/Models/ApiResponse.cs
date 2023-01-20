namespace WebApplication4.Models
{
    public class ApiResponse
    {
        public bool ApiStatus { get; internal set; }
        public bool Status { get; internal set; }
        public string Message { get; internal set; }
    }
}