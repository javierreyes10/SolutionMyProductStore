using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;

namespace MyProductStore.API
{
    public class AuthResponsesOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var filterDescriptor = context.ApiDescription.ActionDescriptor.FilterDescriptors;
            var isAuthorized = filterDescriptor.Select(filterInfo => filterInfo.Filter).Any(filter => filter is Microsoft.AspNetCore.Mvc.Filters.IAuthorizationFilter);
            var authorizationRequired = context.MethodInfo.CustomAttributes.Any(a => a.AttributeType.Name == "AuthorizeAttribute");

            if (isAuthorized && authorizationRequired)
            {
                var securityRequirement = new OpenApiSecurityRequirement()
                {
                    {
                    // Put here you own security scheme, this one is an example
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference{
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                              }
                            },
                        new List<string>()
                    }
            };
                operation.Security = new List<OpenApiSecurityRequirement> { securityRequirement };

            }
        }
    }
}
