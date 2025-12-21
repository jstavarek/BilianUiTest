namespace BilianUiTest.Mvvm.WinUi;

public partial class NonModalWindowView
{
    public NonModalWindowView(DialogViewModel model) : base(model)
    {
        InitializeComponent();
        (Content as FrameworkElement)!.DataContext = this;
    }
}
