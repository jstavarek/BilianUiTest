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
        userInteractionsInvoker = InvokeUserInteraction;
        userInteractionsProvider = this.GetUserInteractionsProvider(false);
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

    protected virtual void InvokeUserInteraction(IUserInteraction userInteraction)
    {
        void ProvideUiThreadUserInteraction(IUserInteraction userInteraction)
        {
            if (userInteraction is ShowingView showingView)
            {
                var view = showingView.View ?? ((UiAbstractionApplication)Application.Current!).ViewBuilder.BuildView(showingView.ViewModel!);
                ShowView(view);
            }
            else if (userInteraction is HidingView)
                Disappear();
            else
                userInteractionsProvider.ProvideUserInteraction(userInteraction, this);
        }

        if (Dispatcher.IsDispatchRequired)
            ProvideUiThreadUserInteraction(userInteraction);
        else
            Dispatcher.Dispatch(() => ProvideUiThreadUserInteraction(userInteraction));
    }
}
