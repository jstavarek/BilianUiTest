namespace BilianUiTest.Wpf;

public partial class NonModalWindowView
{
    public NonModalWindowView()
    {
        ConfirmCommand = new Command(Confirm, () => string.IsNullOrEmpty(Text) == false);

        DataContext = this;
        InitializeComponent();
    }

    private string? text;
    public string? Text
    {
        get { return text; }
        set
        {
            if (value != text)
            {
                text = value;
                NotifyPropertyChanged(nameof(Text));
                ConfirmCommand.ChangeCanExecute();
            }
        }
    }

    public Command ConfirmCommand { get; }

    public void Confirm()
    {
        userInteractionsInvoker.ShowInformation($"Thank you for your text!", "Confirmation", userInteractionsInvoker.HideView);
    }
}
