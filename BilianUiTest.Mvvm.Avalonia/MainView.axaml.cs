namespace BilianUiTest.Mvvm.Avalonia;

public partial class MainView : WindowViewWithModel<MainViewModel>
{
    public MainView(MainViewModel model) : base(model)
    {
        DataContext = this;
        InitializeComponent();
    }
}