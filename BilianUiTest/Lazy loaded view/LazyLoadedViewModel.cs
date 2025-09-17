namespace BilianUiTest;

public class LazyLoadedViewModel : AdvancedViewModel
{
    bool messageHasBeenDisplayed;

    public override void OnViewActivated()
    {
        base.OnViewActivated();

        if (messageHasBeenDisplayed == false)
            ShowInformation("I was created and displayed for the first time now!", "Lazy loaded view", () => messageHasBeenDisplayed = true);
    }
}
