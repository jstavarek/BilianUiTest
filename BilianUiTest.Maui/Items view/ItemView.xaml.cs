namespace BilianUiTest.Maui;

public partial class ItemView : ContentViewViewWithModel<ItemViewModel>
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

        BindingContext = this;
        InitializeComponent();
    }
}
