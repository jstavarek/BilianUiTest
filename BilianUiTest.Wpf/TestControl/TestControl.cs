namespace BilianUiTest.Wpf;

public class TestControl : ControlViewWithModel<CustomControlViewModel>
{
    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(nameof(Title), typeof(string), typeof(TestControl));
    public string Title
    {
        get { return (string)GetValue(TitleProperty); }
        set { SetValue(TitleProperty, value); }
    }

    private readonly static Style style;

    static TestControl()
    {
        ResourceDictionary resources = (ResourceDictionary)Application.LoadComponent(new Uri(@"/BilianUiTest.Wpf;component/TestControl/TestControl.xaml", UriKind.Relative));
        style = (Style)resources["TestControlStyle"];
    }

    public TestControl()
    {
        Style = style;
    }
}
