namespace BilianUiTest.Mvvm;

public class LazyLoadedViewModel : EnhancedViewModel
{
    bool messageHasBeenDisplayed;

    public override void OnViewAppeared()
    {
        base.OnViewAppeared();

        if (messageHasBeenDisplayed == false)
            ShowInformation("View instantiated now!", "Lazy loaded view");

        messageHasBeenDisplayed = true;
    }
}
