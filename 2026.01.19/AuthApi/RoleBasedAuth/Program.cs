
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RoleBasedAuth.Data;
using RoleBasedAuth.Models;
using RoleBasedAuth.Models.DTOs;
using RoleBasedAuth.Services;

namespace RoleBasedAuth
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<AppDbContext>(x =>
            {
                x.UseMySQL(builder.Configuration.GetConnectionString("MySql"));
            });
            builder.Services.AddScoped<IAuth, Auth>();
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
            builder.Services.AddScoped<ITokenGenerator, TokenGenerator>();
            builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("AuthSettings: JwtOptions"));
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
