namespace BilianUiTest;

public class CustomUserInteractionExampleViewModel : AdvancedViewModel
{
    public Command GoCrazyCommand { get; }

    public CustomUserInteractionExampleViewModel()
    {
        GoCrazyCommand = new Command(GoCrazy);
    }

    private void GoCrazy()
    {
        Random random = new Random();
        DoUserInteraction(new GoingCrazy(random.Next()));
    }
}
