using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace BilianUiTest.Mvvm.Avalonia;

public partial class App : UiAbstractionApplication
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);

        ViewCollection viewCollection = new();
        viewCollection.Add<MainViewModel, MainView>();
        viewCollection.Add<DialogViewModel, NonModalWindowView>();
        viewCollection.Add<ModalDialogViewModel, ModalWindowView>();
        viewCollection.Add<ItemViewModel, ItemView>();
        viewCollection.Add<LazyLoadedViewModel, LazyLoadedView>();
        ViewBuilder.RegisterViews(viewCollection);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        base.OnFrameworkInitializationCompleted();

        IView mainView = ViewBuilder.BuildView(new MainViewModel());
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            desktop.MainWindow = (Window)mainView;

        mainView.Appear(null);
    }
}