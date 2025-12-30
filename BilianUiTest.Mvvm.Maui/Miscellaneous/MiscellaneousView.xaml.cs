namespace BilianUiTest.Mvvm.Maui;

public partial class MiscellaneousView
{
    public MiscellaneousView()
    {
        InitializeComponent();
    }

    protected override void OnModelSet()
    {
        BindingContext = this;
    }
}
