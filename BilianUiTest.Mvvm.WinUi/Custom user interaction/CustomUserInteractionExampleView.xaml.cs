using Microsoft.UI;
using Microsoft.UI.Xaml.Media;

using Windows.UI;

namespace BilianUiTest.Mvvm.WinUi;

public partial class CustomUserInteractionExampleView : UserControlViewWithModel
{
    // This is an example of a property that is not present in the view model and still can be bound to in XAML
    public Brush PanelBackground
    {
        get { return field; }
        private set
        {
            if (value == field) return;

            field = value;
            NotifyPropertyChanged(nameof(PanelBackground));
        }
    } = new SolidColorBrush(Colors.Transparent);

    public CustomUserInteractionExampleView()
    {
        userInteractionsProvider.RegisterHandler<GoingCrazy>(HandleGoingCrazy);

        InitializeComponent();
    }

    protected override void OnModelSet()
    {
        DataContext = this;
    }

    private void HandleGoingCrazy(GoingCrazy goingCrazy)
    {
        PanelBackground = new SolidColorBrush(Color.FromArgb(0xFF, (byte)((goingCrazy.Level >> 16) & 0xFF), (byte)((goingCrazy.Level >> 8) & 0xFF), (byte)(goingCrazy.Level & 0xFF)));
    }
}
