using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using MyProductStore.API.Filters;
using MyProductStore.Core.Interfaces;
using MyProductStore.Infrastructure.Data;
using MyProductStore.Infrastructure.Interfaces;
using MyProductStore.Infrastructure.Repositories;
using MyProductStore.Infrastructure.Services;
using System;
using System.IO;
using System.Reflection;

namespace MyProductStore.API.Helpers
{
    public static class ServiceExtensions
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(doc =>
            {
                var description = $@"Tecnologies and patterns applied:
                - Net Core 3.1
                - EF Core and FluentAPI
                - FluentValidation
                - MailKit
                - Clean Architecture
                - Unit of Work and Repository Pattern
                - Mediator and CQRS pattern
                - and more ...";
                doc.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "My Product Store API Elaniin",
                    Version = "v1",
                    Description = description,
                    Contact = new OpenApiContact { Name = "Javier Reyes", Url = new Uri("https://www.linkedin.com/in/javier-reyes-06299678/") }
                });
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
                    Description = "JWT authorization header using the Bearer scheme. Token will expire after one hour. For getting a token please register a new user or authenticate an existing one"
                });

                doc.OperationFilter<AuthResponsesOperationFilter>();
            });

        }

        public static void AddDbConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProductStoreDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default"),
                x => x.MigrationsAssembly("MyProductStore.Infrastructure")), ServiceLifetime.Transient);

            services.BuildServiceProvider().GetService<ProductStoreDbContext>().Database.Migrate();
        }

        public static void AddMyProductStoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IEmailConfiguration>(configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>());
            services.AddTransient<IEmailService, EmailService>();
            services.AddSingleton<IJwtTokenBuilder, JwtTokenBuilder>();
        }
    }
}

