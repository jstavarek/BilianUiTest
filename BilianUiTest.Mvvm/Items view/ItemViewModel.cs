namespace BilianUiTest.Mvvm;

public class ItemViewModel : AdvancedViewModel
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
                ConfirmEntriesCommand.ChangeCanExecute();
            }
        }
    }

    public Command ConfirmEntriesCommand { get; }
    public Command RemoveCommand { get; }

    public ItemViewModel()
    {
        ConfirmEntriesCommand = new Command(() => ShowInformation($"You entered \"{Text}\"", "Confirmation", null), () => string.IsNullOrEmpty(Text) == false);
        RemoveCommand = new Command(HideView);
    }
}
