namespace BilianUiTest.Mvvm;

public record GoingCrazy(int level) : UserInteraction
{
    public int Level { get; } = level;
}
