using Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using API.Errors;
namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services){
                       // Scoped:      Alive on time of request
            // Transient:   Individual method :: too short 
            // Singleton:   Start on the time of application start > end on shutdown
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped(typeof(IGenericRepository<>),(typeof(GenericRepository<>)));
            services.Configure<ApiBehaviorOptions>(options=>
            options.InvalidModelStateResponseFactory=ActionContext=>{
                var error = ActionContext.ModelState
                .Where(error=>error.Value.Errors.Count>0)
                .SelectMany(x=>x.Value.Errors)
                .Select(x=>x.ErrorMessage).ToArray();

                var errorResponse = new ApiValidationErrorResponse{Errors=error};
                return new BadRequestObjectResult(errorResponse);
            });
            return services;
        }
    }
}