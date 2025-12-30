namespace BilianUiTest.Mvvm.Maui;

public partial class ItemsView : ContentViewViewWithModel<ItemsViewModel>
{
    public ItemsView()
    {
        InitializeComponent();
    }

    protected override void OnModelSet()
    {
        BindingContext = this;
    }

    protected override void ShowView(IView view)
    {
        if (view is ItemView itemView)
        {
            itemView.Activated += (sender, args) => itemsContainer.Children.Add(itemView);
            itemView.Deactivated += (sender, args) => itemsContainer.Children.Remove(itemView);
        }

        view.Activate(this);
    }
}
