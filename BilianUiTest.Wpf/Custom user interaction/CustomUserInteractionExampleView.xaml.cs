namespace BilianUiTest.Wpf;

using System.Windows.Media;

public partial class CustomUserInteractionExampleView
{
    // This is an example of a property that is not present in the view model and still can be bound to in XAML
    private Brush panelBackground = Brushes.Transparent;
    public Brush PanelBackground
    {
        get { return panelBackground; }
        private set
        {
            if (value != panelBackground)
            {
                panelBackground = value;
                NotifyPropertyChanged(nameof(PanelBackground));
            }
        }
    }

    public CustomUserInteractionExampleView()
    {
        userInteractionsProvider = GetNewUserInteractionsProvider();
        userInteractionsProvider.RegisterHandler<GoingCrazy>(HandleGoingCrazy);

        InitializeComponent();
    }

    protected override void OnModelSet()
    {
        DataContext = this;
    }

    private void HandleGoingCrazy(IView view, GoingCrazy goingCrazy)
    {
        PanelBackground = new SolidColorBrush(Color.FromArgb(0xFF, (byte)((goingCrazy.Level >> 16) & 0xFF), (byte)((goingCrazy.Level >> 8) & 0xFF), (byte)(goingCrazy.Level & 0xFF)));
    }
}
