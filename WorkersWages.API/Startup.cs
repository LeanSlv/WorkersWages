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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WorkersWages.API.Models;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.Reflection;
using System.IO;

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
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "WorkersWagesAPI", Version = "v1" });

                options.AddSecurityDefinition("jwt", new OpenApiSecurityScheme()
                {
                    Name = "JWT token",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Description = "Аутентификация от имени пользователя",
                    BearerFormat = "JWT"
                });

                // Define operationId for client generators
                options.CustomOperationIds(apiDesc =>
                {
                    var actionDescriptor = apiDesc.ActionDescriptor as ControllerActionDescriptor;
                    return actionDescriptor != null ? $"{actionDescriptor.ControllerName}{actionDescriptor.ActionName}" : null;
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
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

            // Adding Authentication  
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            // Adding Jwt Bearer  
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["AuthOptions:Audience"],
                    ValidIssuer = Configuration["AuthOptions:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["AuthOptions:SecretKey"]))
                };
            });

            // DB
            services.AddDbContext<DataContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DataContext"), x => x.MigrationsAssembly(typeof(DataContext).Assembly.FullName)));

            services.Configure<AuthOptions>(Configuration.GetSection("AuthOptions"));

            services.AddTransient<UserManager<User>>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WorkersWagesAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
