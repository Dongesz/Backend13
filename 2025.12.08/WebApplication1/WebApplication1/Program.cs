
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Models.Dto;
using WebApplication1.Services;
using WebApplication1.Services.Interfaces;
namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<DatabaseContext>(
                option =>
                {
                    var ConnectionString = builder.Configuration.GetConnectionString("MySql");
                    option.UseMySQL(ConnectionString);
                }
                );
            
            
            builder.Services.AddScoped<IRendeles, RendelesService>();
            builder.Services.AddScoped<ITermekek, TermekService>();
            builder.Services.AddScoped<IKapcsolo, KapcsoloServices>();
            builder.Services.AddScoped<ResponseDto>();

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
