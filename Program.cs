using CapitalPlacementProject.Data;
using Microsoft.Extensions.DependencyInjection;

namespace CapitalPlacementProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            // Inject CapitalPlacementDbContext
            builder.Services.AddSingleton<CapitalPlacementDbContext>();

            // Inject CosmosDbInitializer as Singleton
            builder.Services.AddSingleton<CosmosDbInitializer>();


            var app = builder.Build();

            var initializer = app.Services.GetRequiredService<CosmosDbInitializer>();
            initializer.Initialize();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
