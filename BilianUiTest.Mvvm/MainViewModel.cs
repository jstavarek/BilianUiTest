using System.Diagnostics;

namespace BilianUiTest.Mvvm;

public class MainViewModel : ExtendedViewModel
{
    public Command OpenDialogCommand { get; }
    public Command OpenModalDialogCommand { get; }

    public Command ShowMessageCommand { get; }
    public Command InvokeExceptionCommand { get; }
    public Command QueryUserCommand { get; }
    public Command PickFileCommand { get; }
    public Command SetFileNameCommand { get; }
    public Command PickFolderCommand { get; }
    public Command DoActionCommand { get; }

    public FormViewModel ExampleControlViewModel { get; }
    public ItemsViewModel ItemsViewModel { get; }
    public CustomUserInteractionExampleViewModel CustomUserInteractionExampleViewModel { get; }
    public Func<IViewModel> GetLazyLoadedViewModel { get; }

    public string ValueElementTitle { get; } = "Animal";
    public CustomControlViewModel CustomControlViewModel { get; }

    public MainViewModel()
    {
        OpenDialogCommand = new Command(OpenDialog);
        OpenModalDialogCommand = new Command(OpenModalDialog);

        ShowMessageCommand = new Command(ShowMessage);
        InvokeExceptionCommand = new Command(InvokeException);
        QueryUserCommand = new Command(QueryUser);
        PickFileCommand = new Command(PickFile);
        SetFileNameCommand = new Command(SetFileName);
        PickFolderCommand = new Command(PickFolder);
        DoActionCommand = new Command(DoAction);

        ExampleControlViewModel = new FormViewModel();
        ItemsViewModel = new ItemsViewModel();
        CustomUserInteractionExampleViewModel = new CustomUserInteractionExampleViewModel();
        GetLazyLoadedViewModel = () => new LazyLoadedViewModel();
        CustomControlViewModel = new CustomControlViewModel() { Value = "Elephant" };
    }

    private void ShowMessage()
    {
        ShowInformation("Text", "Title", null);
    }

    private void QueryUser()
    {
        string userName = "Joe";
        QueryUserYesNo($"Is your name {userName}?", "Verification",
            (result) =>
            {
                if (result == YesNoChoice.Yes)
                    ShowInformation($"Hi {userName}!", "Greeting", null);
            }
        );
    }

    private void OpenDialog()
    {
        ShowView(new DialogViewModel());
    }

    private void OpenModalDialog()
    {
        ShowView(new ModalDialogViewModel((text) => ShowInformation(@$"You entered ""{text}""", "Summary", null)));
    }

    private void PickFile()
    {
        PickFile("Pick file", null, "All files (*.*)|*.*", (filePath) =>
        {
            if (filePath != null)
                ShowInformation($"File {filePath} was picked.", "File picking", null);
        });
    }

    private void SetFileName()
    {
        ChooseFileName("Set file name", null, "All files (*.*)|*.*", ".txt", (filePath) =>
        {
            if (filePath != null)
                ShowInformation($"File {filePath} was picked.", "File saving", null);
        });
    }

    private void PickFolder()
    {
        PickFolder("Pick folder", null, (pickedFolder) =>
        {
            if (pickedFolder != null)
                ShowInformation($"Folder {pickedFolder} was picked.", "Folder picking", null);
        });
    }

    private void InvokeException()
    {
        try
        {
            throw new Exception("Error happened");
        }
        catch (Exception exception)
        {
            ShowError("Error description", "Error handling example", exception, null);
        }
    }

    private void DoAction()
    {
        CustomAction customAction = new();
        customAction.Execute(userInteractionsInvoker);
    }

    public override void OnViewAppeared()
    {
        base.OnViewAppeared();
        Debug.WriteLine($"OnViewActivated {GetType().Name}");
    }

    public override void OnViewDisappeared()
    {
        base.OnViewDisappeared();
        Debug.WriteLine($"OnViewDeactivated {GetType().Name}");
    }
}
