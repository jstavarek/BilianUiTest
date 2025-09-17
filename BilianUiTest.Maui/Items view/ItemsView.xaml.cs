namespace BilianUiTest.Maui;

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
            itemView.Appeared += (sender, args) => itemsContainer.Children.Add(itemView);
            itemView.Disappeared += (sender, args) => itemsContainer.Children.Remove(itemView);
        }

        view.Appear(this);
    }
}
