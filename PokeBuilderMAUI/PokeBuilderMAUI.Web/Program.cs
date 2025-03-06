using PokeBuilderMAUI.Web.Components;
using PokeBuilderMAUI.Shared.Models;
using Microsoft.EntityFrameworkCore;
using PokeBuilderMAUI.Shared.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
namespace PokeBuilderMAUI.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddTransient<IUserService, UserService>();

            //API calling
            builder.Services.AddScoped(sp =>
                new HttpClient
                {
                    BaseAddress = new Uri("https://pokeapi.co/api/v2/pokemon")
                });

            //Cascading values for Pokemon Partial
            builder.Services.AddCascadingValue( sp => 
                new Pokemon { Name = "initialized"}
            );
            var mongoDBSettings = builder.Configuration.GetSection("MongoDBSettings").Get<MongoDBSettings>();
            builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDBSettings"));
            builder.Services.AddDbContext<UserStorageDBContext>(options =>
            options.UseMongoDB(mongoDBSettings.AtlasURI ?? "", mongoDBSettings.DatabaseName ?? ""));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error", createScopeForErrors: true);
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddAdditionalAssemblies(typeof(PokeBuilderMAUI.Shared._Imports).Assembly);

            app.Run();

        }
    }
}