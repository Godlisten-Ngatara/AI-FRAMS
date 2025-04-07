using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using AI_FRAMS.Services;
using AI_FRAMS.Data;
using Microsoft.EntityFrameworkCore;
namespace AI_FRAMS;

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
        builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true); // Fix the method call
        builder.Services.AddMauiBlazorWebView();

        // Build the service provider to get the configuration
        var serviceProvider = builder.Services.BuildServiceProvider();
        var configuration = serviceProvider.GetRequiredService<IConfiguration>();

        // Get the connection string from appsettings.json
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        // Register DbContext with the connection string
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));
        builder.Services.AddScoped<StudentService>();
#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
