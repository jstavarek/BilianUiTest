namespace BilianUiTest.Mvvm;

public class CustomUserInteractionExampleViewModel : EnhancedViewModel
{
    public Command GoCrazyCommand { get; }
    private readonly Random random;

    public CustomUserInteractionExampleViewModel()
    {
        GoCrazyCommand = new Command(GoCrazy);
        random = new Random();
    }

    private void GoCrazy()
    {
        UserInteractionsInvoker?.Invoke(new GoingCrazy(random.Next()));
    }
}
