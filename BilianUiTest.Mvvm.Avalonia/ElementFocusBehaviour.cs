using System.Collections.Generic;
using System.Linq;

using Avalonia.Interactivity;
using Avalonia.LogicalTree;
using Avalonia.Xaml.Interactivity;

namespace BilianUiTest.Mvvm.Avalonia;

public class ElementFocusBehaviour : Behavior<Control>
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
            controlToFocusOn.Focus();
    }

    static Control? GetFirstControl(Control parentControl)
    {
        void AddControl(Control contentControl, List<Control> controls)
        {
            var logicals = contentControl.GetLogicalChildren();
            foreach (object logical in logicals)
            {
                if (logical is Control control)
                {
                    if (control.IsTabStop)
                        controls.Add(control);
                }

                if (logical is IChildIndexProvider panel)
                    if (logical is Control parentControl)
                        AddControl(parentControl, controls);
            }
        }

        List<Control> controls = new List<Control>();
        AddControl(parentControl, controls);
        return controls.OrderBy(e => e.TabIndex).FirstOrDefault();
    }
}
