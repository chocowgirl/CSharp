using Microsoft.AspNetCore.Builder;

namespace Demo_ASP1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();


            // SOME CUSTOM ROUTES APPEAR UNDER.  ALWAYS GO FROM MOST SPECIFIC TO MOST GENERAL FOR ROUTING DEFINITIONS
            // NOTE THAT A ROUTE FOR A SPECIFIC FUNCTION SHOULD BE PLACED IN THE CLASS, A MORE GENERAL ROUTING PATTERN HERE

            //app.MapControllerRoute(
            //    name: "privacyRoute",
            //    pattern: "privacy"
            //    defaults: new {Controller = "Home", Action = "Privacy"}
            //    );
            ////This simplifies the URL form home/privacy to URL of privacy

            //app.MapControllerRoute(
            //    name: "privacyRouteFR",
            //    pattern: "conditions"
            //    defaults: new { Controller = "Home", Action = "Privacy" }
            //    );
            ////This simplifies the URL form home/privacy to URL of conditions

            //app.MapControllerRoute(
            //    name: "additionRoute",
            //    pattern: "Home/Addition/{nb1}/{nb2}", < --attn, the name of the params here must == the params in the method params
            //    defaults: new { Controller = "Home", Action = "Addition" }
            //    );

            //app.MapControllerRoute(
            //    name: "plusRoute",
            //    pattern: "{nb1}/plus/{nb2}",
            //    defaults: new { Controller = "Home", Action  = "Addition" }
            //    );

            app.MapControllerRoute(
                name: "messageRoute",
                pattern: "Home/Message/{text}",
                defaults: new { controller = "Home", Action = "Message" });


            app.MapControllerRoute(
                name: "AccueilRoute",
                pattern: "Accueil",
                defaults: new { Controller = "Home", Action = "Index" }
                );


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
