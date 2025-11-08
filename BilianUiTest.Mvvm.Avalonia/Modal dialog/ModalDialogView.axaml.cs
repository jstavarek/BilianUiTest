namespace BilianUiTest.Mvvm.Avalonia;

public partial class ModalDialogView : DialogWindowViewWithModel<ModalDialogViewModel>
{
    public ModalDialogView(ModalDialogViewModel model) : base(model)
    {
        DataContext = this;
        InitializeComponent();
    }
}