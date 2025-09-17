namespace BilianUiTest.Maui
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();

            ViewCollection viewCollection = new();
            viewCollection.Add<MainViewModel, MainView>();
            //viewCollection.Add<DialogViewModel, NonModalWindowView>();
            viewCollection.Add<ModalDialogViewModel, ModalWindowView>();
            viewCollection.Add<ItemViewModel, ItemView>();
            viewCollection.Add<LazyLoadedViewModel, LazyLoadedView>();
            ViewBuilder.RegisterViews(viewCollection);

            IView mainView = ViewBuilder.BuildView(new MainViewModel());
            MainPage = (Page)mainView;
        }
    }
}
