namespace BilianUiTest;

public class ItemsViewModel : AdvancedViewModel
{
    public Command AddCommand { get; }

    public ItemsViewModel()
    {
        AddCommand = new Command(Add);    
    }

    private void Add()
    {
        ShowView(new ItemViewModel());
    }
}
