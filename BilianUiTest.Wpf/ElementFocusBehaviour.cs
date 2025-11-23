using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Microsoft.Xaml.Behaviors;

namespace BilianUiTest.Wpf;

public class ElementFocusBehaviour : Behavior<FrameworkElement>
{
    protected override void OnAttached()
    {
        AssociatedObject.Loaded += OnAssociatedObjectLoaded;
    }

    private void OnAssociatedObjectLoaded(object sender, RoutedEventArgs e)
    {
        AssociatedObject.Loaded -= OnAssociatedObjectLoaded;

        Control? controlToFocusOn = GetFirstControl(AssociatedObject);
        if (controlToFocusOn != null)
            Keyboard.Focus(controlToFocusOn);
    }

    private static Control? GetFirstControl(FrameworkElement frameworkElement)
    {
        static void AddControl(FrameworkElement contentControl, List<Control> controls)
        {
            var children = LogicalTreeHelper.GetChildren(contentControl);
            foreach (object child in children)
            {
                if (child is Control control)
                {
                    if (control is not TabItem && control.IsTabStop)
                        controls.Add(control);
                }

                if (child is IAddChild panel)
                    if (child is FrameworkElement frameworkElement)
                        AddControl(frameworkElement, controls);
            }
        }

        List<Control> controls = new List<Control>();
        AddControl(frameworkElement, controls);
        return controls.OrderBy(e => e.TabIndex).FirstOrDefault();
    }
}
