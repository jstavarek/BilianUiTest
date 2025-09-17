using System.Diagnostics;

namespace BilianUiTest;

public class FormViewModel : AdvancedViewModel
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

    public override void OnViewActivated()
    {
        base.OnViewActivated();
        Debug.WriteLine($"OnViewActivated {GetType().Name}");
    }

    public override void OnViewDeactivated()
    {
        base.OnViewDeactivated();
        Debug.WriteLine($"OnViewDeactivated {GetType().Name}");
    }
}
