namespace BilianUiTest.Mvvm;

public class TextProcessor : ITextProcessor
{
    private const string BannedWord = "abc";
    public string? ProcessText(string? text)
    {
        if (text == null)
            return null;

        if (text == BannedWord)
            throw new Exception($"Text: {BannedWord} is banned! ");

        return text.ToUpper(); 
    }
}
