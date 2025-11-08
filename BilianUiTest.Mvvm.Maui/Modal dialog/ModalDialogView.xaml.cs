namespace BilianUiTest.Mvvm.Maui;

public partial class ModalDialogView
{
    public ModalDialogView(ModalDialogViewModel model) : base(model)
    {
        BindingContext = this;
        InitializeComponent();
    }
}
