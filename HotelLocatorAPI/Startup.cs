using FluentValidation;
using HotelLocator.Services;
using MediatR;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using HotelLocator.Shared.Tools;
using System.IO;
using System;
using AutoMapper;
using HotelLocator.Shared.ResponseModels;

namespace HotelLocator.API
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                    .WithOrigins(Configuration.GetSection("ClientOriginUrls")
                        .AsEnumerable()
                        .Select(c => c.Value)
                        .Where(v => !v.IsNullOrEmpty())
                        .ToArray())
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            ConfigureSwagger(services);
            services.AddMediatR(Assembly.GetExecutingAssembly());

            ConfigureApis(services);
            ConfigureValidators(services);
            ConfigureAutoMapper(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Argentex.ClientCompany v1"));
            }

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private void ConfigureSwagger(IServiceCollection services)
        {
            if (Configuration["Swagger:Enable"] == "true")
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "HotelLocator.API", Version = "v1" });
                    c.IncludeXmlComments(xmlPath);
                });
            }
        }

        private void ConfigureApis(IServiceCollection services)
        {
            //services.AddScoped<HttpClient, HttpClient>();
            services.AddScoped<IHotelLocatorService, HotelLocatorService>();
            services.AddScoped<IJsonWrapper, JsonWrapper>();
        }

        private void ConfigureValidators(IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ConfigureAutoMapper(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new HotelSearchListModel());

            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

    }
}
