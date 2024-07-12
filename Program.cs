
using Microsoft.EntityFrameworkCore;

namespace IntroductionToEFCoreENG
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // option configuration design pattern , means yaha pe option object mai sab kuch aayega and hume connection string override krni hai 
            // Yeh dependency injection bhi ka kar raha hai , yaha pe woh depency wale interface ka object ban jaega and hum bs baki sb classes mai jo isse le rahi hai woh constructor ke through le rahi hai so changes apne aap waha paunch jaenge
         
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("name=DefaultConnection"));

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
