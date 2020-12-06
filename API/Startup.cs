using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Core.Interfaces;
using API.Helpers;
using AutoMapper;
using API.Middlewear;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using API.Errors;
using Microsoft.OpenApi.Models;

namespace API
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup( IConfiguration config)
        {
            _config = config;
        }

        //public IConfiguration Configuration { get; }
        //service registration- Order not important
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Scoped:      Alive on time of request
            // Transient:   Individual nmetod :: too short 
            // Singleton:   Start on the time of application start > end on shutdown
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped(typeof(IGenericRepository<>),(typeof(GenericRepository<>)));
            services.AddAutoMapper(typeof(MappingProfiles));
            services.AddControllers();
            services.AddDbContext<StoreContext>(c=>
            c.UseSqlite(_config.GetConnectionString("DefaultConnection")));
            
            services.Configure<ApiBehaviorOptions>(options=>
            options.InvalidModelStateResponseFactory=ActionContext=>{
                var error = ActionContext.ModelState
                .Where(error=>error.Value.Errors.Count>0)
                .SelectMany(x=>x.Value.Errors)
                .Select(x=>x.ErrorMessage).ToArray();

                var errorResponse = new ApiValidationErrorResponse{Errors=error};
                return new BadRequestObjectResult(errorResponse);
            });
            services.AddSwaggerGen(c=>c.SwaggerDoc(
                "v1", new OpenApiInfo{Title="Mojo Design Collection API",Version="v1"}
            ));
            
  
        }
        // middleware
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //  Error page 
            app.UseStatusCodePagesWithReExecute("/errors/{0}");
            
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthorization();
            // Dev Endpoint Documentation :: https://localhost:5001/swagger/index.html
            app.UseSwagger();
            app.UseSwaggerUI(c=>
                {c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mojo Design Collection API v1");}
                );
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
