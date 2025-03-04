using PokeBuilderMAUI.Web.Components;
using PokeBuilderMAUI.Shared.Models;
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

            //API calling
            builder.Services.AddScoped(sp =>
                new HttpClient
                {
                    BaseAddress = new Uri("https://pokeapi.co/api/v2/pokemon")
                });

            //Cascading values for Pokemon Partial
            builder.Services.AddCascadingValue(sp =>
                new Pokemon { Name = "test"}
            );

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