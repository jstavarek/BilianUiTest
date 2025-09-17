namespace BilianUiTest.Wpf;

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
        userInteractionsProvider = GetNewUserInteractionsProvider();
        userInteractionsProvider.RegisterHandler<ShowingInformation>((view, showingMessage) => Message = showingMessage.Text);

        InitializeComponent();
    }

    protected override void OnModelSet()
    {
        DataContext = this;
    }
}
