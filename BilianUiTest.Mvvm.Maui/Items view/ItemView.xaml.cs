namespace BilianUiTest.Mvvm.Maui;

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
        userInteractionsProvider = this.GetUserInteractionsProvider(true);
        userInteractionsProvider.RegisterHandler<ShowingInformation>((view, showingInformation) => Message = showingInformation.Text);

        BindingContext = this;
        InitializeComponent();
    }
}
