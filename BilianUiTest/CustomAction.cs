namespace BilianUiTest;

public class CustomAction : IUiAction
{
    public void Execute(DoUserInteraction doUserInteraction)
    {
        doUserInteraction.ShowInformation("Text", "Title", null);
    }
}
