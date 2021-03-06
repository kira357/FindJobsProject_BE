using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using FindJobsProject.Extends;
using FindJobsProject.HelperChat.Infrastructure;
using FindJobsProject.Hubs;
using FindJobsProject.Mapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FindJobsProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }
        public IContainer ApplicationContainer { get; private set; }

        public ILifetimeScope AutofacContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddOptions();
            services.AddConnectionDB(Configuration);
            services.AddConfigSwagger();
            services.AddConfigCors();
            services.AddConfigIdentity();
            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
            services.AddConfigScope();
            services.AddSignalR();
            services.AddConfigToken(Configuration);
            services.AddControllersWithViews().AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void ConfigureContainer(ContainerBuilder builder)
        {
            // Register your own things directly with Autofac here. Don't
            // call builder.Populate(), that happens in AutofacServiceProviderFactory
            // for you.
            builder.RegisterModule(new RepositoryAutofacModule1());
            builder.RegisterModule(new BusinessAutofacModule1());

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "Images")),
                RequestPath = "/Images"
            });
            app.UseCors("_poplicy");
            app.UseRouting();
            AutofacContainer = app.ApplicationServices.GetAutofacRoot();
            app.UseAuthentication();
            app.UseAuthorization();


            //app.UseSignalR(routes =>
            //{
               

            //});
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("/chat");
            });
        }
    }
}
