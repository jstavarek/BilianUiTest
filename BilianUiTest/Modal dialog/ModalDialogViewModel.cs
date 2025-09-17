namespace BilianUiTest;

public class ModalDialogViewModel : AdvancedViewModel
{
    private string? text;
    public string? Text
    {
        get { return text; }
        set
        {
            if (value != text)
            {
                text = value;
                NotifyPropertyChanged(nameof(Text));
                ConfirmCommand.ChangeCanExecute();
            }
        }
    }

    public Command ConfirmCommand { get; }

    private readonly Action<string> onTextEnteredAction;

    private bool textHasBeenConfirmed;

    public ModalDialogViewModel(Action<string> onTextEnteredAction)
    {
        this.onTextEnteredAction = onTextEnteredAction;
        ConfirmCommand = new Command(Confirm, () => string.IsNullOrEmpty(Text) == false);
    }

    public void Confirm()
    {
        ShowInformation($"Thank you for your text!", "Confirmation",
            () =>
            {
                textHasBeenConfirmed = true;
                HideView();
            });
    }

    public override void OnViewDeactivated()
    {
        base.OnViewDeactivated();
        if (textHasBeenConfirmed)
            onTextEnteredAction?.Invoke(Text!);
    }
}
