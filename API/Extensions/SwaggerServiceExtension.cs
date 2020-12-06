using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace API.Extensions
{
    public static class SwaggerServiceExtension
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services){
                        services.AddApplicationServices();
            services.AddSwaggerGen(c=>c.SwaggerDoc(
                "v1", new OpenApiInfo{Title="Mojo Design Collection API",Version="v1"}
            ));
            return services;
        }
        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app){
            // Dev Endpoint Documentation :: https://localhost:5001/swagger/index.html
            app.UseSwagger();
            app.UseSwaggerUI(c=>
                {c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mojo Design Collection API v1");}
                );
                return app;
        }
    }
}