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
            itemView.Appeared += (sender, args) => itemsStackPanel.Children.Add(itemView);
            itemView.Disappeared += (sender, args) => itemsStackPanel.Children.Remove(itemView);
        }

        view.Appear(this);
    }
}
