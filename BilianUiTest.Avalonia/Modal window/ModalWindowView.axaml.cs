namespace BilianUiTest.Avalonia;

public partial class ModalWindowView : DialogWindowViewWithModel<ModalDialogViewModel>
{
    public ModalWindowView(ModalDialogViewModel model) : base(model)
    {
        DataContext = this;
        InitializeComponent();
    }
}