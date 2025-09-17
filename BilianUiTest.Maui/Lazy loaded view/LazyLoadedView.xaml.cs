namespace BilianUiTest.Maui;

public partial class LazyLoadedView : ContentViewViewWithModel<LazyLoadedViewModel>
{
    public LazyLoadedView(LazyLoadedViewModel model) : base(model)
    {
        BindingContext = this;
        InitializeComponent();
    }
}