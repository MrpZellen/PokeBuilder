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

            //Dependency Injection
            builder.Services.AddSingleton<UserService>();
            //API STUFF KILL ME KILL ME KILL ME NOW
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //API calling
            builder.Services.AddScoped(sp =>
                new HttpClient
                {
                    BaseAddress = new Uri("https://pokeapi.co/api/v2/pokemon")
                });

            //Mongo DB Settings
            var mongoDBSettings = builder.Configuration.GetSection("MongoDBSettings").Get<MongoDBSettings>();
            builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDBSettings"));
            builder.Services.AddDbContext<UserStorageDBContext>(options =>
            options.UseMongoDB(mongoDBSettings.AtlasURI ?? "", mongoDBSettings.DatabaseName ?? ""));

            //Session
            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(1);
                //options.IdleTimeout = TimeSpan.FromMinutes(30);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error", createScopeForErrors: true);
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseRouting();
            app.UseAuthorization();
            app.MapControllers();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.UseSession();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddAdditionalAssemblies(typeof(PokeBuilderMAUI.Shared._Imports).Assembly);

            app.Run();

        }
    }
}