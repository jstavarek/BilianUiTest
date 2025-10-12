namespace BilianUiTest.Mvvm.Avalonia;

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
        userInteractionsProvider = this.GetUserInteractionsProvider(true);
        userInteractionsProvider.RegisterHandler<ShowingInformation>((view, showingInformation) => Message = showingInformation.Text);

        DataContext = this;
        InitializeComponent();
    }
}
