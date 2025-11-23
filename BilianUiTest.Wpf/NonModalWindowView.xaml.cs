namespace BilianUiTest.Wpf;

public partial class NonModalWindowView
{
    public NonModalWindowView()
    {
        ConfirmCommand = new Command(Confirm, () => string.IsNullOrEmpty(Text) == false);

        DataContext = this;
        InitializeComponent();
    }

    public string? Text
    {
        get { return field; }
        set
        {
            if (value == field) return;

            field = value;
            NotifyPropertyChanged(nameof(Text));
            ConfirmCommand.ChangeCanExecute();
        }
    }

    public Command ConfirmCommand { get; }

    public void Confirm()
    {
        userInteractionsInvoker.ShowInformation($"Thank you for your text!", "Confirmation", userInteractionsInvoker.HideView);
    }
}
