namespace BilianUiTest.Mvvm.WinUi;

public partial class App : Application
{
    private WindowView? _window;

    /// <summary>
    /// Initializes the singleton application object.  This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
        InitializeComponent();

        Core.UserInteractionsProviderClass = typeof(CommonUserInteractionsProvider);
    }

    /// <summary>
    /// Invoked when the application is launched.
    /// </summary>
    /// <param name="args">Details about the launch request and process.</param>
    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        _window = new MainView(new MainViewModel());
        _window.Appear(null);
    }
}
