
using Microsoft.EntityFrameworkCore;
using Phonebook.Application.Service;
using Phonebook.Domain.Entities;
using Phonebook.Infrastructure.Data;
using Phonebook.Infrastructure.Repositories;
using Phonebook.Infrastructure.Interfaces;
namespace DDD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddTransient<PhonebookService>();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration["Data:PhonebookContact:Connectionstring"], b => b.MigrationsAssembly("Phonebook.Api")));
            builder.Services.AddTransient<IContactRepository, ContactRepository>();

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
