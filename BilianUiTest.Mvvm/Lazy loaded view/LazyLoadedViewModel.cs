namespace BilianUiTest.Mvvm;

public class LazyLoadedViewModel : ExtendedViewModel
{
    bool messageHasBeenDisplayed;

    public override void OnViewAppeared()
    {
        base.OnViewAppeared();

        if (messageHasBeenDisplayed == false)
            ShowInformation("I was created and displayed for the first time now!", "Lazy loaded view", () => messageHasBeenDisplayed = true);
    }
}
