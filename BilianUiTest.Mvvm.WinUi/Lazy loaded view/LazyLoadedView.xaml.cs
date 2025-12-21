namespace BilianUiTest.Mvvm.WinUi;

public partial class LazyLoadedView : UserControlViewWithModel
{
    public LazyLoadedView(LazyLoadedViewModel model) : base(model)
    {
        DataContext = this;
        InitializeComponent();
    }
}
