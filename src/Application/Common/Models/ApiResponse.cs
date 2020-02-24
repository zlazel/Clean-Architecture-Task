namespace Clean_Architecture_Task.Application.Common.Models
{
    public class ApiResponse<IRequest> 
    {
        public string Message { get; set; }
        public IRequest Data { get; set; }
        public int StatusCode { get; set; }
    }
}
