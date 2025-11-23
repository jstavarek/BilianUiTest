namespace BilianUiTest.Mvvm.Wpf;

using System.Windows.Media;

public partial class CustomUserInteractionExampleView
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
    } = Brushes.Transparent;

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
