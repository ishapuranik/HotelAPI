using FluentValidation;
using MediatR;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Security.Principal;
using System.Text;

namespace HotelLocator.API
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
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                    .WithOrigins(Configuration.GetSection("ClientOriginUrls")
                        .AsEnumerable()
                        .Select(c => c.Value)
                        .ToArray())
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            ConfigureSwagger(services);
            services.AddMediatR(Assembly.GetExecutingAssembly());
            
            ConfigureApis(services);
            ConfigureAuthorization(services);
            ConfigureValidators(services);
            ConfigureSpecifications(services);
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
            services.AddScoped<HttpClient, HttpClient>();
        }

        private void ConfigureSpecifications(IServiceCollection services)
        {
            //services.AddScoped<IExistsClientCompanyContactSpecification, ExistsClientCompanyContactSpecification>();
            //services.AddScoped<IExistsClientCompanySpecification, ExistsClientCompanySpecification>();

        }

        private void ConfigureValidators(IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ConfigureAuthorization(IServiceCollection services)
        {
            
        }
    }
}
