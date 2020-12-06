using System;

namespace API.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ApiResponse(int statusCode, string message=null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch{
                0=>"No Result Returned",                
                400=>"Bad Requet",
                401=> "Not Authorized",
                404=>"Not Found",
                500=>"Server Error" ,
                _=>null               
            };
        }
    }
}