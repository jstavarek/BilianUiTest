namespace BilianUiTest;

public class CustomAction : IUiAction
{
    public void Execute(Action<IUserInteraction> doUserInteraction)
    {
        doUserInteraction.ShowInformation("Text", "Title", null);
    }
}
