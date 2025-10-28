namespace BilianUiTest.Mvvm;

public class CustomUserInteractionExampleViewModel : EnhancedViewModel
{
    public Command GoCrazyCommand { get; }

    public CustomUserInteractionExampleViewModel()
    {
        GoCrazyCommand = new Command(GoCrazy);
    }

    private void GoCrazy()
    {
        Random random = new Random();
        UserInteractionsInvoker?.Invoke(new GoingCrazy(random.Next()));
    }
}
