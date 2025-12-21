namespace BilianUiTest.Mvvm.Maui;

public partial class App
{
    public App()
    {
        InitializeComponent();

        Core.UserInteractionsProviderClass = typeof(CommonUserInteractionsProvider);

        ViewCollection viewCollection = new();
        viewCollection.Add<MainViewModel, MainView>();
        //viewCollection.Add<DialogViewModel, NonModalWindowView>();
        viewCollection.Add<ModalDialogViewModel, ModalDialogView>();
        viewCollection.Add<ItemViewModel, ItemView>();
        viewCollection.Add<LazyLoadedViewModel, LazyLoadedView>();
        Core.ViewBuilder.RegisterViews(viewCollection);

        var mainView = Core.ViewBuilder.BuildView(new MainViewModel());
        MainPage = (Page)mainView;
    }
}
