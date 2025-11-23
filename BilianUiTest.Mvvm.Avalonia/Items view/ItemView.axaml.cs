namespace BilianUiTest.Mvvm.Avalonia;

public partial class ItemView : UserControlViewWithModel<ItemViewModel>
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

    public ItemView(ItemViewModel model) : base(model)
    {
        userInteractionsProvider.RegisterHandler<ShowingInformation>((showingInformation) => Message = showingInformation.Text);

        DataContext = this;
        InitializeComponent();
    }
}
