namespace BilianUiTest.Mvvm.Maui;

public partial class MainView
{
    public MainView(MainViewModel model) : base(model)
    {
        BindingContext = this;
        InitializeComponent();
    }
}
