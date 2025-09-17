namespace BilianUiTest.Avalonia;

public partial class NonModalWindowView : WindowViewWithModel<DialogViewModel>
{
    public NonModalWindowView(DialogViewModel model) : base(model)
    {
        DataContext = this;
        InitializeComponent();
    }
}