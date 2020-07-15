using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Todo.Api
{
    public class Startup
    {
        public Startup(IHostEnvironment environment)
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                //options.Filters.Add(new ProducesAttribute("application/json", "application/xml"));

                //options.ReturnHttpNotAcceptable = true;
                
                // options.InputFormatters.Add(
                //     new XmlDataContractSerializerInputFormatter(options)
                // );
                // options.OutputFormatters.Add(
                //     new XmlDataContractSerializerOutputFormatter()
                // );
            });

#region Swagger
            // services.AddSwaggerGen(options =>
            // {
            //     options.SwaggerDoc($"todo-v1.0", new OpenApiInfo()
            //     {
            //         Description = "Simple API example with tasklists and tasks",
            //         Title = $"Todo API v1.0",
            //         Version = "v1.0"
            //     });

            //     var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //     var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);
            //     options.IncludeXmlComments(xmlCommentsFullPath);
            // });
#endregion
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

#region Swagger 
            // app.UseSwagger();
            // app.UseSwaggerUI(options =>
            // {
            //     options.SwaggerEndpoint($"/swagger/books-v1.0/swagger.json", $"books-v1.0");
            //     options.RoutePrefix = "";
            //     options.EnableDeepLinking();
            //     options.DisplayOperationId();
            // });
#endregion 

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
