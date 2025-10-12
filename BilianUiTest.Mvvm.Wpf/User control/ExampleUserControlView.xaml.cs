namespace BilianUiTest.Mvvm.Wpf;

public partial class ExampleUserControlView
{
    private string? message;
    public string? Message
    {
        get { return message; }
        private set
        {
            if (value != message)
            {
                message = value;
                NotifyPropertyChanged(nameof(Message));
            }
        }
    }

    public ExampleUserControlView()
    {
        userInteractionsProvider = this.GetUserInteractionsProvider(true);
        userInteractionsProvider.RegisterHandler<ShowingInformation>((view, showingInformation) => Message = showingInformation.Text);

        InitializeComponent();
    }

    protected override void OnModelSet()
    {
        DataContext = this;
    }
}
