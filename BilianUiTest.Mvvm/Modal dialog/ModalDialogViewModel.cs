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
            SubmitCommand.ChangeCanExecute();
        }
    }

    public Command SubmitCommand { get; }
    public Command CancelCommand { get; }

    private readonly Action<string> onTextEnteredAction;

    private bool textConfirmed;

    public ModalDialogViewModel(Action<string> onTextEnteredAction)
    {
        this.onTextEnteredAction = onTextEnteredAction;
        SubmitCommand = new Command(() =>
            {
                textConfirmed = true;
                HideView();
            }
            , () => string.IsNullOrEmpty(Text) == false);
        CancelCommand = new Command(HideView);
    }

    public override void OnViewDeactivated()
    {
        base.OnViewDeactivated();
        if (textConfirmed)
            onTextEnteredAction?.Invoke(Text!);
    }
}
