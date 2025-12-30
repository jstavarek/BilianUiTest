using System.Diagnostics;

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

    public override void OnViewActivated()
    {
        base.OnViewActivated();
        Debug.WriteLine($"{nameof(OnViewActivated)} {GetType().Name}");
    }

    public override void OnViewDeactivated()
    {
        base.OnViewDeactivated();
        Debug.WriteLine($"{nameof(OnViewDeactivated)} {GetType().Name}");
    }
}
