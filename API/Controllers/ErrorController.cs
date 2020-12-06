using API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("errors/{code}")]
    // get away with Actions require an explicit HttpMethod binding for Swagger/OpenAPI 3.0
    // because looking for the http method (get/post/...) > so ignore it as an endpoint
    [ApiExplorerSettings(IgnoreApi=true)]
    public class ErrorController:BaseApiController
    {
        public IActionResult Error(int statusCode){
            return new ObjectResult(new ApiResponse(statusCode));
        }
    }
}