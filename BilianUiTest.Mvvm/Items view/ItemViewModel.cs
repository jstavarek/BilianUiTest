namespace BilianUiTest.Mvvm;

public class ItemViewModel : SimpleFormViewModel
{
    public Command RemoveCommand { get; }

    public ItemViewModel()
    {
        RemoveCommand = new Command(HideView);
    }
}
