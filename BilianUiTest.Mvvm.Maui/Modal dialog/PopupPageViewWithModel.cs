using System.Diagnostics;

namespace BilianUiTest.Mvvm.Maui;

public partial class PopupPageViewWithModel<TModel> : PopupPageView, IViewWithModel<TModel> where TModel : IViewModel
{
    private TModel model = default!;
    public TModel Model
    {
        get { return model; }
        private set
        {
            if (value == null)
                throw new Exception("Model must not be set to null");

            model = value;
            OnModelSet();
        }
    }

    public PopupPageViewWithModel()
    {
    }

    public PopupPageViewWithModel(TModel model) : this()
    {
        Model = model;
    }

    protected virtual void OnModelSet()
    {
    }

    protected override void OnAppeared()
    {
        base.OnAppeared();

        if (Model == null)
        {
            Debug.WriteLine("View model is not set");
            return;
        }

        Model.UserInteractionsInvoker = userInteractionsInvoker;
        Model?.OnViewAppeared();
    }

    protected override void OnDisappeared()
    {
        if (Model != null)
        {
            Model.OnViewDisappeared();
            Model.UserInteractionsInvoker = null;
        }

        base.OnDisappeared();
    }
}
