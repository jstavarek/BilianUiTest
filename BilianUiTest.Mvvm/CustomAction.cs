namespace BilianUiTest.Mvvm;

public class CustomAction : IUiAction
{
    public void Execute(UserInteractionsInvoker? userInteractionsInvoker)
    {
        userInteractionsInvoker?.ShowInformation("UI action executed", "UI action example", null);
    }
}
