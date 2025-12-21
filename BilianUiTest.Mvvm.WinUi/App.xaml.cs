namespace BilianUiTest.Mvvm.WinUi;

public partial class App : Application
{
    /// Initializes the singleton application object.  This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
        InitializeComponent();

        Core.UserInteractionsProviderClass = typeof(CommonUserInteractionsProvider);

        ViewCollection viewCollection = new();
        viewCollection.AddNonGeneric<MainViewModel, MainView>();
        viewCollection.AddNonGeneric<DialogViewModel, NonModalWindowView>();
        viewCollection.AddNonGeneric<ModalDialogViewModel, ModalDialogView>();
        viewCollection.AddNonGeneric<ItemViewModel, ItemView>();
        viewCollection.AddNonGeneric<LazyLoadedViewModel, LazyLoadedView>();
        Core.ViewBuilder.RegisterViews(viewCollection);
    }

    /// <summary>
    /// Invoked when the application is launched.
    /// </summary>
    /// <param name="args">Details about the launch request and process.</param>
    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        var mainView = Core.ViewBuilder.BuildView(new MainViewModel());
        mainView.Appear(null);
    }
}
