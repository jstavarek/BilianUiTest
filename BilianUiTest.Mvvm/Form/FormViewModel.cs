using System.Diagnostics;

namespace BilianUiTest.Mvvm;

public class FormViewModel : ExtendedViewModel
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

    public FormViewModel()
    {
        ConfirmCommand = new Command(() => ShowInformation($"You entered \"{Text}\"", "Confirmation", null), () => string.IsNullOrEmpty(Text) == false);
    }

    public override void OnViewAppeared()
    {
        base.OnViewAppeared();
        Debug.WriteLine($"OnViewActivated {GetType().Name}");
    }

    public override void OnViewDisappeared()
    {
        base.OnViewDisappeared();
        Debug.WriteLine($"OnViewDeactivated {GetType().Name}");
    }
}
