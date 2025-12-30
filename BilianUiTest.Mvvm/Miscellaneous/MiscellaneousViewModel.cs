namespace BilianUiTest.Mvvm;

public class MiscellaneousViewModel : EnhancedViewModel
{
    public string? InputText
    {
        get { return field; }
        set
        {
            if (value == field) return;
            field = value;
            NotifyPropertyChanged(nameof(InputText));
            ProcessTextCommand.ChangeCanExecute();
        }
    }

    public string? Result
    {
        get { return field; }
        private set
        {
            if (value == field) return;
            field = value;
            NotifyPropertyChanged(nameof(Result));
        }
    }

    public Command ProcessTextCommand { get; }

    private readonly ITextProcessor textProcessor;

    public MiscellaneousViewModel(ITextProcessor textProcessor)
    {
        this.textProcessor = textProcessor;

        ProcessTextCommand = new Command(ProcessText, () => string.IsNullOrEmpty(InputText) == false);
    }

    private void ProcessText()
    {
        try
        {
            Result = textProcessor.ProcessText(InputText);
        }
        catch (Exception)
        {
            ShowConfirmedWarning("This word cannot be processed", "Processing text", () => Result = "banned word");
        }
    }
}
