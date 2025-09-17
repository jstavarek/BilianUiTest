namespace BilianUiTest.Maui;

public partial class ModalWindowView
{
    public ModalWindowView(ModalDialogViewModel model) : base(model)
    {
        BindingContext = this;
        InitializeComponent();
    }
}
