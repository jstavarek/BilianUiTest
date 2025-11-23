namespace BilianUiTest.Mvvm.Maui;

public partial class ExampleUserControlView
{
    public string? Message
    {
        get { return field; }
        private set
        {
            if (value == field) return;

            field = value;
            NotifyPropertyChanged(nameof(Message));
        }
    }

    public ExampleUserControlView()
    {
        userInteractionsProvider.RegisterHandler<ShowingInformation>((showingInformation) => Message = showingInformation.Text);

        InitializeComponent();
    }

    protected override void OnModelSet()
    {
        BindingContext = this;
    }
}
