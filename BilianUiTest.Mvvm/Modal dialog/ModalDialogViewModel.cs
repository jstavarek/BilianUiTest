namespace BilianUiTest.Mvvm;

public class ModalDialogViewModel : EnhancedViewModel
{
    public string? Text
    {
        get { return field; }
        set
        {
            if (value == field) return;

            field = value;
            NotifyPropertyChanged(nameof(Text));
            ConfirmCommand.ChangeCanExecute();
        }
    }

    public Command ConfirmCommand { get; }
    public Command CancelCommand { get; }

    private readonly Action<string> onTextEnteredAction;

    private bool textHasBeenConfirmed;

    public ModalDialogViewModel(Action<string> onTextEnteredAction)
    {
        this.onTextEnteredAction = onTextEnteredAction;
        ConfirmCommand = new Command(Confirm, () => string.IsNullOrEmpty(Text) == false);
        CancelCommand = new Command(HideView);
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

    public override void OnViewDisappeared()
    {
        base.OnViewDisappeared();
        if (textHasBeenConfirmed)
            onTextEnteredAction?.Invoke(Text!);
    }
}
