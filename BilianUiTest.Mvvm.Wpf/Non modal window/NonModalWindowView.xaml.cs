namespace BilianUiTest.Mvvm.Wpf;

public partial class NonModalWindowView
{
    public NonModalWindowView(DialogViewModel model) : base(model)
    {
        DataContext = this;
        InitializeComponent();
    }
}
