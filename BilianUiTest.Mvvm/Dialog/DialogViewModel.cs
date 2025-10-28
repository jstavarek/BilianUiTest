namespace BilianUiTest.Mvvm;

public class DialogViewModel : EnhancedViewModel
{
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

    public DialogViewModel()
    {
        ConfirmCommand = new Command(Confirm, () => string.IsNullOrEmpty(Text) == false);
    }

    public void Confirm()
    {
        ShowInformation($"Thank you for your text!", "Confirmation", HideView);
    }
}
