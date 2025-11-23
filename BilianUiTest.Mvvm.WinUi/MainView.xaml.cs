namespace BilianUiTest.Mvvm.WinUi;

public partial class MainView : WindowViewWithModel
{
    public MainView(MainViewModel model) : base(model)
    {
        InitializeComponent();
        (Content as FrameworkElement)!.DataContext = this;
    }
}
