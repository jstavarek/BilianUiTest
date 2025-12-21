namespace BilianUiTest.Mvvm.WinUi;

public partial class ModalDialogView
{
    public string? Message
    {
        get { return field; }
        private set
        {
            if (value == field) return;
            field = value;
            NotifyPropertyChanged(nameof(Message));
        }
    }

    public ModalDialogView(ModalDialogViewModel model) : base(model)
    {
        userInteractionsProvider.RegisterHandler<ShowingInformation>((showingInformation) => Message = showingInformation.Text);

        DataContext = this;
        InitializeComponent();
    }
}
