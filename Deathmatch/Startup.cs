using AppConfiguration;
using BLL.Services;
using BLL.Services.Interface;
using CommandService;
using CommandService.CommandModels;
using DAL.Repositories;
using DAL.Repositories.Interface;
using DAL.Repositories.Logging;
using Database;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Models;
using QueryService;
using QueryService.QueryModels;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Deathmatch
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
            var appSettings = AppConfiguration.AppConfiguration.GetAppSettings(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"), Directory.GetCurrentDirectory());
            services.AddSingleton(x => appSettings);

            services.AddDbContext<DeathmatchDbContext>(options =>
                options.UseSqlServer(appSettings.ConnectionString));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<DeathmatchDbContext>();
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));

            services.RegisterCommandHandlers();
            services.RegisterQueryHandlers();

            services.AddScoped<ILogMessageManager<Location>, LogMessageManager<Location>>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<ILocationService, LocationService>();

            services.AddScoped<ILogMessageManager<User>, LogMessageManager<User>>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserValidationService, UserValidationService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<ILogMessageManager<Role>, LogMessageManager<Role>>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleService, RoleService>();

            services.AddScoped<ILogMessageManager<UserInSession>, LogMessageManager<UserInSession>>();
            services.AddScoped<IUserInSessionRepository, UserInSessionRepository>();
            services.AddScoped<IUserInSessionService, UserInSessionService>();

            services.AddScoped<ILogMessageManager<Session>, LogMessageManager<Session>>();
            services.AddScoped<ISessionRepository, SessionRepository>();
            services.AddScoped<ISessionService, SessionService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ToDo API",
                    Description = "A simple example ASP.NET Core Web API",
                });
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer", // must be lower case
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            securityScheme, Array.Empty<string>()
                        }
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSerilogRequestLogging();
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("swagger/v1/swagger.json", "API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
