using Common.Utility;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Common.DataLayer;

namespace CustomersAPIServices
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private IWebHostEnvironment HostingEnvironment { get; set; }

        public Startup(IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            HostingEnvironment = hostingEnvironment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // File should be ENVironment Specific
            IConfigurationBuilder builder = new ConfigurationBuilder()
                                    .AddJsonFile("appsettings.json") // This file will be overridden by below next line 
                                    .AddJsonFile($"appsettings.{HostingEnvironment.EnvironmentName}.json", optional: true); // Read ENV value for appsetting
            services.AddTransient<IConfig, Config>();
            services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.IgnoreNullValues = true);
            services.AddCors();
            services.Add(ServiceDescriptor.Singleton<IConfiguration>(Configuration));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);
            services.AddJwtAuthentication(HostingEnvironment, builder);
                //.AddJwtBearer(options => {
                //    options.TokenValidationParameters = new TokenValidationParameters
                //    {
                //        ValidateIssuerSigningKey = true,
                //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secretkeyWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6Ikpv")),
                //        ValidateIssuer = false,
                //        ValidateAudience = false,
                //    };

            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");

            app.UseRouting();
            app.UseCors(x => x
                .SetIsOriginAllowed(origin => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
