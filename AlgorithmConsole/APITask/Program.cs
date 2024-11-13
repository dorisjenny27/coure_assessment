using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using APITask.AutoMapper;
using APITask.Data;
using APITask.Repository.Implementations;
using APITask.Repository.Interfaces;

namespace APITask
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("CountryDb"));
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api_Task", Version = "v1" });
            });
            builder.Services.AddScoped<ICountryRepository, CountryRepository>();
            builder.Services.AddAutoMapper(typeof(MapInitializer));

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API_Task v1"));
            }

            app.UseHttpsRedirection();

            // Seed initial data
            ApiSeeder.SeedData(app);
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}