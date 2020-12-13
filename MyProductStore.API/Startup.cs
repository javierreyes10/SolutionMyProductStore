using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyProductStore.Application.Handlers;
using MyProductStore.Application.Mappings;
using MyProductStore.Application.Validators;
using MyProductStore.Core.Interfaces;
using MyProductStore.Infrastructure.Data;
using MyProductStore.Infrastructure.Interfaces;
using MyProductStore.Infrastructure.Repositories;
using MyProductStore.Infrastructure.Services;
using System.Reflection;

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

            services.AddSingleton<IEmailConfiguration>(Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>());
            services.AddTransient<IEmailService, EmailService>();

            //Automapper
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddMediatR(typeof(GetAllProductsHandler).GetTypeInfo().Assembly);

            services.AddMvc(options =>
            {
                options.Filters.Add<ValidationFilter>();
            }).AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblyContaining<ProductValidator>();
            });

            //HttpPatch
            services
                .AddControllersWithViews()
                .AddNewtonsoftJson();


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
