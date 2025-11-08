namespace BilianUiTest.Mvvm.Wpf;

public partial class ModalDialogView
{
    public ModalDialogView(ModalDialogViewModel model) : base(model)
    {
        DataContext = this;
        InitializeComponent();
    }
}
