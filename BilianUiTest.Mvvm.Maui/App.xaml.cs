namespace BilianUiTest.Mvvm.Maui;

public partial class App
{
    public App()
    {
        InitializeComponent();

        ViewCollection viewCollection = new();
        viewCollection.Add<MainViewModel, MainView>();
        //viewCollection.Add<DialogViewModel, NonModalWindowView>();
        viewCollection.Add<ModalDialogViewModel, ModalDialogView>();
        viewCollection.Add<ItemViewModel, ItemView>();
        viewCollection.Add<LazyLoadedViewModel, LazyLoadedView>();
        ViewBuilder.RegisterViews(viewCollection);

        IView mainView = ViewBuilder.BuildView(new MainViewModel());
        //Windows[0].Page = (Page)mainView;
        MainPage = (Page)mainView;
        //mainView.Appear(null);
    }
}
