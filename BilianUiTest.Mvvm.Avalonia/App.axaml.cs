using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace BilianUiTest.Mvvm.Avalonia;

public partial class App : Application
{
    public App()
    {
        Core.UserInteractionsProviderClass = typeof(CommonUserInteractionsProvider);
    }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);

        ViewCollection viewCollection = new();
        viewCollection.Add<MainViewModel, MainView>();
        viewCollection.Add<DialogViewModel, NonModalWindowView>();
        viewCollection.Add<ModalDialogViewModel, ModalDialogView>();
        viewCollection.Add<ItemViewModel, ItemView>();
        viewCollection.Add<LazyLoadedViewModel, LazyLoadedView>();
        Core.ViewBuilder.RegisterViews(viewCollection);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        base.OnFrameworkInitializationCompleted();

        var mainView = Core.ViewBuilder.BuildView(new MainViewModel());

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            desktop.MainWindow = (Window)mainView;

        mainView.Activate();
    }
}