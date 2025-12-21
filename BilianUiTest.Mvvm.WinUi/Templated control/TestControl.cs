namespace BilianUiTest.Mvvm.WinUi;

public class TestControl : ControlViewWithModel
{
    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(nameof(Title), typeof(string), typeof(TestControl), null);
    public string Title
    {
        get { return (string)GetValue(TitleProperty); }
        set { SetValue(TitleProperty, value); }
    }

    private readonly static Style style;

    static TestControl()
    {
        var resources = new ResourceDictionary { Source = new Uri("ms-appx:///Templated control/TestControl.xaml") };
        style = (Style)resources["TestControlStyle"];
    }

    public TestControl()
    {
        Style = style;
    }
}
