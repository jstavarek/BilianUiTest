namespace BilianUiTest.Wpf;

public partial class ModalWindowView
{
    public ModalWindowView(ModalDialogViewModel model) : base(model)
    {
        DataContext = this;
        InitializeComponent();
    }
}
