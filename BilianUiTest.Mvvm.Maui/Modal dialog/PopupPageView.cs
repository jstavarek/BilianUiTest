using System.ComponentModel;

using RGPopup.Maui.Pages;
using RGPopup.Maui.Services;

namespace BilianUiTest.Mvvm.Maui;

public partial class PopupPageView : PopupPage, IView, INotifyPropertyChanged
{
    public new event PropertyChangedEventHandler? PropertyChanged;

    protected UserInteractionsInvoker userInteractionsInvoker;
    protected IUserInteractionsProvider userInteractionsProvider;

    public PopupPageView()
    {
        userInteractionsProvider = Core.GetUserInteractionsProvider(this);
        userInteractionsProvider.RegisterHandler<ShowingView>((showingView) => ShowView(showingView.View ?? Core.ViewBuilder.BuildView(showingView.ViewModel!)));
        userInteractionsProvider.RegisterHandler<HidingView>((hidingView) => Disappear());
        userInteractionsInvoker = userInteractionsProvider.InvokeUserInteraction;

        CloseWhenBackgroundIsClicked = false;
    }

    public virtual void Appear(IView? parentView)
    {
        PopupNavigation.Instance.PushAsync(this, true, parentView as Page);
    }

    protected virtual void Disappear()
    {
        PopupNavigation.Instance.PopAsync();
    }

    protected virtual void OnAppeared()
    {
    }

    protected virtual void OnDisappeared()
    {
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        OnAppeared();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        OnDisappeared();
    }

    protected virtual void ShowView(IView view)
    {
        view.Appear(this);
    }

    protected void NotifyPropertyChanged(string? propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
