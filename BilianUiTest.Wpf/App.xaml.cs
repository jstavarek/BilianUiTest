using System.Windows.Controls;

namespace BilianUiTest.Wpf;

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

        ViewCollection viewCollection = new();
        viewCollection.Add<MainViewModel, MainView>();
        viewCollection.Add<DialogViewModel, NonModalWindowView>();
        viewCollection.Add<ModalDialogViewModel, ModalWindowView>();
        viewCollection.Add<ItemViewModel, ItemView>();
        viewCollection.Add<LazyLoadedViewModel, LazyLoadedView>();
        ViewBuilder.RegisterViews(viewCollection);
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        ShowMainView(new MainViewModel());
    }
}
