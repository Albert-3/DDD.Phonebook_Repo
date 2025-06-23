
using Microsoft.EntityFrameworkCore;
using Phonebook.Domain.Entities;
using Phonebook.Infrastructure.Data;
using Phonebook.Infrastructure.Repositories;
using Phonebook.Api.Service;
using Phonebook.Api.Service.Abs;
using Phonebook.Domain.Interfaces;

namespace Phonebook.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddTransient<IPhoneBookService, PhonebookService>();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration["Data:PhonebookContact:Connectionstring"], b => b.MigrationsAssembly("Phonebook.Api")));
            builder.Services.AddTransient<IContactRepository, ContactRepository>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            MigrateDb(app);

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

        private static void MigrateDb(WebApplication app)
        {
            //using var scope = app.Services.CreateScope();
            //var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            //if (context.Database.IsSqlServer() && context.Database.GetPendingMigrations().Any())
            //{
            //    context.Database.Migrate();
            //}
            //else
            //{
            //    throw new Exception("Database is not SQL Server");
            //}
        }
    }
}
