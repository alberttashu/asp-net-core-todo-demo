// ReSharper disable CheckNamespace
using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.OpenApi.Models;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc($"todo-v1.0", new OpenApiInfo()
                {
                    Description = "Simple API example with tasklists and tasks",
                    Title = $"Todo API v1.0",
                    Version = "v1.0"
                });

                var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);
                options.IncludeXmlComments(xmlCommentsFullPath);
            });

            return services;
        }

        public static IServiceCollection AddAndConfigureControllers(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                //options.Filters.Add(new ProducesAttribute("application/json", "application/xml"));

                options.ReturnHttpNotAcceptable = true;

                options.InputFormatters.Add(
                    new XmlDataContractSerializerInputFormatter(options)
                );
                options.OutputFormatters.Add(
                    new XmlDataContractSerializerOutputFormatter()
                );
            });

            return services;
        }

    }
}
