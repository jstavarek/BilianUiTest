namespace BilianUiTest.Wpf;

public partial class NonModalWindowView
{
    public NonModalWindowView(DialogViewModel model) : base(model)
    {
        DataContext = this;
        InitializeComponent();
    }
}
