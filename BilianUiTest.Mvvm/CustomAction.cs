namespace BilianUiTest.Mvvm;

public class CustomAction : IUiAction
{
    public void Execute(UserInteractionsInvoker userInteractionsInvoker)
    {
        userInteractionsInvoker.ShowInformation("Text", "Title", null);
    }
}
