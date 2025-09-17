namespace BilianUiTest.Maui;

public partial class MainView
{
    public MainView(MainViewModel model) : base(model)
    {
        BindingContext = this;
        InitializeComponent();
    }
}
