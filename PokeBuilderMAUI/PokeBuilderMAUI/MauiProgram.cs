using Microsoft.Extensions.Logging;

namespace PokeBuilderMAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });
            builder.Services.AddMauiBlazorWebView();

            //test API calling
            builder.Services.AddScoped(sp =>
                new HttpClient
                {
                    BaseAddress = new Uri("https://pokeapi.co/api/v2/pokemon")
                });
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
