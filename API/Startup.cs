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
            services.AddAutoMapper(typeof(MappingPrpfiles));
            services.AddControllers();
            services.AddDbContext<StoreContext>(c=>
            c.UseSqlite(_config.GetConnectionString("DefaultConnection")));
            
        }
        // middleware
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
