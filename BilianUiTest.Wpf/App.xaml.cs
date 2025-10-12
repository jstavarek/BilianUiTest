namespace BilianUiTest.Wpf;

public partial class App
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var mainView = new MainView();
        mainView.Appear(null);
    }
}

