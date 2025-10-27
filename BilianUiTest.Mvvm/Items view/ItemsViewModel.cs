namespace BilianUiTest.Mvvm;

public class ItemsViewModel : ExtendedViewModel
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
