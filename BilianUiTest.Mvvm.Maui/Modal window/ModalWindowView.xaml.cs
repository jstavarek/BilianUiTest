namespace BilianUiTest.Mvvm.Maui;

public partial class ModalWindowView
{
    public ModalWindowView(ModalDialogViewModel model) : base(model)
    {
        BindingContext = this;
        InitializeComponent();
    }
}
