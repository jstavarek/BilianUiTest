namespace BilianUiTest.Wpf;

public partial class NonModalWindowView
{
    public NonModalWindowView()
    {
        SubmitCommand = new Command(Submit, () => string.IsNullOrEmpty(Text) == false);

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
            SubmitCommand.ChangeCanExecute();
        }
    }

    public Command SubmitCommand { get; }

    public void Submit()
    {
        userInteractionsInvoker.ShowConfirmedInformation($"Thank you for your text!", "Confirmation", userInteractionsInvoker.HideView);
    }
}
