using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WorkersWages.API.Storage;
using WorkersWages.API.Storage.Models;
using Microsoft.AspNetCore.Identity;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Text.Json.Serialization;

namespace WorkersWages.API
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WorkersWages.API", Version = "v1" });
            });

            services
                .AddControllers(options =>
                {
                    options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status200OK));
                    options.Filters.Add(new ProducesResponseTypeAttribute(typeof(Models.ApiErrorResponse), StatusCodes.Status400BadRequest));
                    options.Filters.Add(new Models.ApiErrorResponseFilter());
                    options.OutputFormatters.RemoveType<StringOutputFormatter>();
                })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    options.JsonSerializerOptions.Converters.Add(new Services.JsonElementsPresentedConverterFactory());
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                });

            services.AddIdentity<User, UserRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
            })
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();

            // DB
            services.AddDbContext<DataContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DataContext"), x => x.MigrationsAssembly(typeof(DataContext).Assembly.FullName)));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WorkersWages.API v1"));
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
