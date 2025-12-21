using CommunityToolkit.Maui;

using UraniumUI;

namespace BilianUiTest.Mvvm.Maui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit(
            config =>
            {
                config.SetShouldEnableSnackbarOnWindows(true);
            })
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .UseUraniumUI()
            .UseUraniumUIMaterial();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
