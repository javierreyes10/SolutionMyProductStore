using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MyProductStore.Application.Handlers.Products;
using MyProductStore.Application.JwtToken;
using MyProductStore.Application.Mappings;
using MyProductStore.Application.Middleware;
using MyProductStore.Application.Validators;
using MyProductStore.Core.Interfaces;
using MyProductStore.Infrastructure.Data;
using MyProductStore.Infrastructure.Interfaces;
using MyProductStore.Infrastructure.Middlewares;
using MyProductStore.Infrastructure.Repositories;
using MyProductStore.Infrastructure.Services;
using System;
using System.IO;
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

            services.BuildServiceProvider().GetService<ProductStoreDbContext>().Database.Migrate();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddSingleton<IEmailConfiguration>(Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>());
            services.AddTransient<IEmailService, EmailService>();
            services.AddSingleton<IJwtTokenBuilder, JwtTokenBuilder>();

            //Automapper
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddMediatR(typeof(GetAllProductsHandler).GetTypeInfo().Assembly);

            services.AddSwaggerGen(doc =>
            {
                doc.SwaggerDoc("v1", new OpenApiInfo { Title = "My Product Store API Elaniin", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                doc.IncludeXmlComments(xmlPath);

                doc.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT authorization header using the Bearer scheme."
                });

                doc.OperationFilter<AuthResponsesOperationFilter>();

                //doc.AddSecurityRequirement(new OpenApiSecurityRequirement {
                //    {
                //        new OpenApiSecurityScheme{
                //            Reference = new OpenApiReference{
                //                Type = ReferenceType.SecurityScheme,
                //                Id = "Bearer"
                //              }
                //            }, new String[]{ }
                //     }
                //});
            });

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

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "My Producto Store API Elaniin");
                options.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
