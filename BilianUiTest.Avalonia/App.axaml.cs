using Avalonia.Markup.Xaml;

namespace BilianUiTest.Avalonia;

public partial class App : MvvmApplication
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
        ShowMainView(new MainViewModel());
    }
}