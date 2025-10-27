namespace BilianUiTest.Mvvm;

public class CustomUserInteractionExampleViewModel : ExtendedViewModel
{
    public Command GoCrazyCommand { get; }

    public CustomUserInteractionExampleViewModel()
    {
        GoCrazyCommand = new Command(GoCrazy);
    }

    private void GoCrazy()
    {
        Random random = new Random();
        userInteractionsInvoker(new GoingCrazy(random.Next()));
    }
}
