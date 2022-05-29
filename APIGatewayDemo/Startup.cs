using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using APIGatewayDemo.Routing;
using Microsoft.AspNetCore.Http;


namespace APIGatewayDemo
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Read json formated API configuration details
            Router router = new Router("routes.json"); 

            app.Run(async (context) =>
            {
                // Get all incoming request here
                var request = context.Request;
                // send this request for validation / authentication and other means
                var content = await router.RouteRequest(request);
                // returned response
                await context.Response.WriteAsync(await content.Content.ReadAsStringAsync());
            });
        }
    }
}
