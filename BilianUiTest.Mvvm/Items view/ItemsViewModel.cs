namespace BilianUiTest.Mvvm;

public class ItemsViewModel : EnhancedViewModel
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
