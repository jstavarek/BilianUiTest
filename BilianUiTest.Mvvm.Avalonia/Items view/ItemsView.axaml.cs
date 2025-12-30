namespace BilianUiTest.Mvvm.Avalonia;

public partial class ItemsView : UserControlViewWithModel<ItemsViewModel>
{
    public ItemsView()
    {
        InitializeComponent();
    }

    protected override void OnModelSet()
    {
        DataContext = this;
    }

    protected override void ShowView(IView view)
    {
        if (view is ItemView itemView)
        {
            itemView.Activated += (sender, args) => itemsStackPanel.Children.Add(itemView);
            itemView.Deactivated += (sender, args) => itemsStackPanel.Children.Remove(itemView);
        }

        view.Activate(this);
    }
}
