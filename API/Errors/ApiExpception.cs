namespace API.Errors
{
    public class ApiExpception : ApiResponse
    {
        public ApiExpception(int statusCode, string message = null,string details=null) : base(statusCode, message)
        {
            details =Details;
        }
        public string Details{get;set;}

    }
}