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
            SubmitCommand.ChangeCanExecute();
        }
    }

    public Command SubmitCommand { get; }

    public SimpleFormViewModel()
    {
        SubmitCommand = new Command(() => ShowInformation($"You entered: {Text}", "Confirmation"), () => string.IsNullOrEmpty(Text) == false);
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
