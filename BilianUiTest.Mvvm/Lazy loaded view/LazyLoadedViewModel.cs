namespace BilianUiTest.Mvvm;

public class LazyLoadedViewModel : EnhancedViewModel
{
    bool messageHasBeenDisplayed;

    public override void OnViewActivated()
    {
        base.OnViewActivated();

        if (messageHasBeenDisplayed == false)
            ShowInformation("View instantiated now!", "Lazy loaded view");

        messageHasBeenDisplayed = true;
    }
}
