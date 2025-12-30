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

    public override void OnViewActivated()
    {
        base.OnViewActivated();
        Debug.WriteLine($"{nameof(OnViewActivated)} {GetType().Name}");
    }

    public override void OnViewDeactivated()
    {
        base.OnViewDeactivated();
        Debug.WriteLine($"{nameof(OnViewDeactivated)} {GetType().Name}");
    }
}
