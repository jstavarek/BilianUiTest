namespace BilianUiTest.Avalonia;

public partial class ItemView : UserControlViewWithModel<ItemViewModel>
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

    public ItemView(ItemViewModel model) : base(model)
    {
        userInteractionsProvider = GetNewUserInteractionsProvider();
        userInteractionsProvider.RegisterHandler<ShowingInformation>((view, showingMessage) => Message = showingMessage.Text);

        DataContext = this;
        InitializeComponent();
    }
}
