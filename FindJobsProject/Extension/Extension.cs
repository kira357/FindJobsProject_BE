using FindJobsProject.Data.Entities;
using FindJobsProject.Database;
using FindJobsProject.Database.Entities;
using FindJobsProject.DI;
using FindJobsProject.Models;
using FindJobsProject.ViewModels.VMChatRecruitment;
using FindJobsProject.ViewModels.VMMessage;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindJobsProject.Extends
{
    public static class Extension
    {
       public static IServiceCollection AddConnectionDB(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FindJobsContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("ConnectionDB")));
            return services;
        }

        public static IServiceCollection AddConfigSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ToDo API",
                });
            });
            return services;
        }
        public static IServiceCollection AddConfigCors(this IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy(name: "_poplicy",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200")
                               .AllowAnyHeader()
                               .AllowCredentials()
                               .AllowAnyMethod();
                    });
            });

            return services;
        } 
        public static IServiceCollection AddConfigIdentity(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1d);
                options.SignIn.RequireConfirmedAccount = false;
                options.Lockout.MaxFailedAccessAttempts = 5;
            })
                .AddEntityFrameworkStores<FindJobsContext>()
                .AddDefaultTokenProviders();
            return services;
        }

        public static IServiceCollection AddConfigScope(this IServiceCollection services)
        {
            //services.AddScoped<IReposityAutho, ReposityAutho>();
            //services.AddScoped<IReposityEmployee, ReposityEmployee>();
            services.AddScoped<IReposityUser, ReposityUser>();
            services.AddScoped<IReposityRole, ReposityRole>();
            services.AddScoped<IReposityMajor, ReposityMajor>();
            services.AddScoped<IReposityJob, ReposityJob>();
            services.AddScoped<IReposityUser, ReposityUser>();
            services.AddScoped<IReposityAuthen, ReposityAuthen>();
            services.AddScoped<IReposityRecruitment, ReposityRecruitment>();
            services.AddScoped<IReposityCandidate, ReposityCandidate>();
            services.AddScoped<IReposityBlog, ReposityBlog>();
            services.AddScoped<IReposityComment, ReposityComment>();
            services.AddScoped<IReposityFavourite, ReposityFavourite>();
            services.AddScoped<IReposityMessage, ReposityMessage>();

            //services.AddSingleton<IDictionary<string, VMCreateChatRecruitment>>(opt => new Dictionary<string, VMCreateChatRecruitment>());
            return services;
        }
    }
}
