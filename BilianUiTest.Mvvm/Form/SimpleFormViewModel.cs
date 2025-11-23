using System.Diagnostics;

namespace BilianUiTest.Mvvm;

public class SimpleFormViewModel : EnhancedViewModel
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

    public SimpleFormViewModel()
    {
        ConfirmCommand = new Command(() => ShowInformation($"You entered: {Text}", "Confirmation", null), () => string.IsNullOrEmpty(Text) == false);
    }

    public override void OnViewAppeared()
    {
        base.OnViewAppeared();
        Debug.WriteLine($"{nameof(OnViewAppeared)} {GetType().Name}");
    }

    public override void OnViewDisappeared()
    {
        base.OnViewDisappeared();
        Debug.WriteLine($"{nameof(OnViewDisappeared)} {GetType().Name}");
    }
}
