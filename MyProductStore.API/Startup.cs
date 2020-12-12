using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyProductStore.Application.Mappings;
using MyProductStore.Core.Interfaces;
using MyProductStore.Infrastructure.Data;
using MyProductStore.Infrastructure.Repositories;

namespace MyProductStore.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<ProductStoreDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default"),
                x => x.MigrationsAssembly("MyProductStore.Infrastructure")), ServiceLifetime.Transient);

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            //Automapper
            services.AddAutoMapper(typeof(MappingProfile));

        }

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
