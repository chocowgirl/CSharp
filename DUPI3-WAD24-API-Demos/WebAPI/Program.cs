
using Common.Repositories;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            //Ajout de nos services provenant des projets BLL & DAL
            builder.Services.AddScoped<IUserRepository<DAL.Entities.User>,DAL.Services.UserService>();
            builder.Services.AddScoped<IUserRepository<BLL.Entities.User>,BLL.Services.UserService>();
            builder.Services.AddScoped<ICocktailRepository<DAL.Entities.Cocktail>, DAL.Services.CocktailService>();
            builder.Services.AddScoped<ICocktailRepository<BLL.Entities.Cocktail>, BLL.Services.CocktailService>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Soit définir un CORS par défaut : 
            builder.Services.AddCors(
                options =>
                {
                    options.AddDefaultPolicy(policy => {
                        policy
                            //.WithOrigins("http://127.0.0.1:5500")
                            //.WithHeaders(["Accept", "application/json"])
                            //.WithMethods("GET", "POST");
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
                });

            //Soit nommé les règles du CORS, pour une application plus sélective :
            /*builder.Services.AddCors(
                options =>
                {
                    options.AddPolicy("localPolicy", policy => {
                        policy
                            //.WithOrigins("http://127.0.0.1:5500")
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
                });*/

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //Si CORS par défaut :
            app.UseCors();
            //Si CORS nommé :
            //app.UseCors("localPolicy");

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
