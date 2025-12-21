using System.Windows.Controls;

namespace BilianUiTest.Mvvm.Wpf;

public partial class App
{
    public App()
    {
        Style style = new Style(typeof(Button));
        style.Setters.Add(new Setter(Button.PaddingProperty, new Thickness(10, 5, 10, 5)));
        style.Setters.Add(new Setter(Button.HorizontalAlignmentProperty, HorizontalAlignment.Left));
        style.Setters.Add(new Setter(Button.VerticalAlignmentProperty, VerticalAlignment.Top));
        style.Setters.Add(new Setter(Button.MinWidthProperty, 50.0));
        Resources.Add(typeof(Button), style);

        Core.UserInteractionsProviderClass = typeof(CommonUserInteractionsProvider);

        ViewCollection viewCollection = new();
        viewCollection.Add<MainViewModel, MainView>();
        viewCollection.Add<DialogViewModel, NonModalWindowView>();
        viewCollection.Add<ModalDialogViewModel, ModalDialogView>();
        viewCollection.Add<ItemViewModel, ItemView>();
        viewCollection.Add<LazyLoadedViewModel, LazyLoadedView>();
        Core.ViewBuilder.RegisterViews(viewCollection);
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var mainView = Core.ViewBuilder.BuildView(new MainViewModel());
        MainWindow = (Window)mainView;
        mainView.Appear(null);
    }
}
