namespace BilianUiTest.Mvvm.Avalonia;

public partial class LazyLoadedView : UserControlViewWithModel<LazyLoadedViewModel>
{
    public LazyLoadedView(LazyLoadedViewModel model) : base(model)
    {
        DataContext = this;
        InitializeComponent();
    }
}
