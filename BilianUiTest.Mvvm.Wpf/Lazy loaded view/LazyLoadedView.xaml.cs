namespace BilianUiTest.Mvvm.Wpf;

public partial class LazyLoadedView
{
    public LazyLoadedView(LazyLoadedViewModel model) : base(model)
    {
        DataContext = this;
        InitializeComponent();
    }
}
