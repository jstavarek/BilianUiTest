namespace BilianUiTest.Mvvm.Wpf;

public partial class MainView
{
    public MainView(MainViewModel model) : base(model)
    {
        DataContext = this;
        InitializeComponent();
    }
}
