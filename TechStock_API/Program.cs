
using Microsoft.EntityFrameworkCore;
using TechStock_API.Context;
using TechStock_API.Services;

namespace TechStock_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Adiciona a conex�o com o Db
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); // config da conex�o em appsettings.json
            });


            // Add services to the container.

            builder.Services.AddScoped<IProdutoService, ProdutoService>(); // avisa o container de inje��o de depend�ncia sobre a implementa��o da interface

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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
