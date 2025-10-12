namespace BilianUiTest.Mvvm.Avalonia;

public class TestControl : TemplatedControlViewWithModel<CustomControlViewModel>
{
    public static readonly StyledProperty<string> TitleProperty = AvaloniaProperty.Register<TestControl, string>(nameof(Title));
    public string Title
    {
        get { return GetValue(TitleProperty); }
        set { SetValue(TitleProperty, value); }
    }
}