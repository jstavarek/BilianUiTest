namespace BilianUiTest.Wpf;

public partial class MainView
{
    public MainView(MainViewModel model) : base(model)
    {
        DataContext = this;
        InitializeComponent();
    }
}
