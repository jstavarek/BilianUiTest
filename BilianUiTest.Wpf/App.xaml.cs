namespace BilianUiTest.Wpf;

public partial class App
{
    public App()
    {
        Core.UserInteractionsProviderClass = typeof(CommonUserInteractionsProvider);
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var mainView = new MainView();
        mainView.Appear(null);
    }
}

