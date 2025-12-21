namespace BilianUiTest.Mvvm.WinUi;

public partial class MainView
{
    public MainView(MainViewModel model) : base(model)
    {
        InitializeComponent();
        (Content as FrameworkElement)!.DataContext = this;
    }
}
