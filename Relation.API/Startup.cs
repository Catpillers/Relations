using System;
using System.IO;
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Relations.API.Options;
using Relations.Bll.Interfaces;
using Relations.Bll.Services;
using Relations.Dal.Data;
using Relations.Dal.Interfaces;
using Relations.Dal.Models;
using Relations.Dal.Repository;

namespace Relations.API
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
            services.AddScoped(typeof(IAsyncRepository<>), typeof(AsyncRepository<>));
            services.AddScoped<IRelationRepository, RelationRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IAsyncRepository<Category>, CategoryRepository>();
            services.AddScoped<IAsyncRepository<Country>, CountryRepository>();
            services.AddScoped<IRelationService, RelationService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddDbContext<DataContext>(c =>
                c.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddSwaggerGen(_ =>
            {
                _.SwaggerDoc("v1", new OpenApiInfo {Title = "Relations Api", Version = "v1"});
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                _.IncludeXmlComments(xmlPath);
            });

            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder
                    .WithOrigins(new[] {"http://localhost:4200"})
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseRouting();
            
            var swaggerOptions = new SwaggerOptions();
            Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);
            app.UseSwagger(option => { option.RouteTemplate = swaggerOptions.JsonRoute; });
            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint(swaggerOptions.UiEndpoint, swaggerOptions.Description);
            });

            app.UseCors("CorsPolicy");
            app.UseAuthorization();


            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}