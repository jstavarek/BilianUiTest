using System.Diagnostics;

namespace BilianUiTest.Mvvm;

public class MainViewModel : EnhancedViewModel
{
    public Command ShowInformationCommand { get; }
    public Command ShowInformationWithConfirmationCommand { get; }
    public Command ShowInformationWithRequiredConfirmationCommand { get; }
    public Command ShowWarningCommand { get; }
    public Command ShowWarningWithConfirmationCommand { get; }
    public Command ShowWarningWithRequiredConfirmationCommand { get; }
    public Command ShowErrorCommand { get; }
    public Command ShowErrorWithConfirmationCommand { get; }
    public Command ShowErrorWithRequiredConfirmationCommand { get; }

    public Command QueryUserCommand { get; }
    public Command PickFileCommand { get; }
    public Command SetFileNameCommand { get; }
    public Command PickFolderCommand { get; }

    public Command OpenDialogCommand { get; }
    public Command OpenModalDialogCommand { get; }

    public Command DoActionCommand { get; }

    public SimpleFormViewModel ExampleControlViewModel { get; }
    public ItemsViewModel ItemsViewModel { get; }
    public CustomUserInteractionExampleViewModel CustomUserInteractionExampleViewModel { get; }
    public Func<IViewModel> GetLazyLoadedViewModel { get; }

    public string ValueElementTitle { get; } = "Animal";
    public ValueViewModel ValueViewModel { get; }

    public MainViewModel()
    {
        ShowInformationCommand = new Command(() => ShowInformation("Text", "Title"));
        ShowInformationWithConfirmationCommand = new Command(() => ShowConfirmedInformation("Text", "Title", () => Debug.WriteLine("Information confirmed"), false));
        ShowInformationWithRequiredConfirmationCommand = new Command(() => ShowConfirmedInformation("Text", "Title", () => Debug.WriteLine("Information confirmed")));
        ShowWarningCommand = new Command(() => ShowWarning("Text", "Title"));
        ShowWarningWithConfirmationCommand = new Command(() => ShowConfirmedWarning("Text", "Title", () => Debug.WriteLine("Warning confirmed"), false));
        ShowWarningWithRequiredConfirmationCommand = new Command(() => ShowConfirmedWarning("Text", "Title", () => Debug.WriteLine("Warning confirmed")));
        ShowErrorCommand = new Command(() => ShowError("Text", "Title", new Exception("Error happened")));
        ShowErrorWithConfirmationCommand = new Command(() => ShowConfirmedError("Text", "Title", new Exception("Error happened"), () => Debug.WriteLine("Error confirmed"), false));
        ShowErrorWithRequiredConfirmationCommand = new Command(() => ShowConfirmedError("Text", "Title", new Exception("Error happened"), () => Debug.WriteLine("Error confirmed")));

        QueryUserCommand = new Command(QueryUser);
        PickFileCommand = new Command(PickFile);
        SetFileNameCommand = new Command(SetFileName);
        PickFolderCommand = new Command(PickFolder);

        OpenDialogCommand = new Command(OpenDialog);
        OpenModalDialogCommand = new Command(OpenModalDialog);

        DoActionCommand = new Command(DoAction);

        ExampleControlViewModel = new SimpleFormViewModel();
        ItemsViewModel = new ItemsViewModel();
        CustomUserInteractionExampleViewModel = new CustomUserInteractionExampleViewModel();
        GetLazyLoadedViewModel = () => new LazyLoadedViewModel();
        ValueViewModel = new ValueViewModel() { Value = "Elephant" };
    }

    public override void OnViewAppeared()
    {
        base.OnViewAppeared();
        Debug.WriteLine($"{nameof(OnViewAppeared)} {GetType().Name}");
    }

    public override void OnViewDisappeared()
    {
        base.OnViewDisappeared();
        Debug.WriteLine($"OnViewDisappeared {GetType().Name}");
    }

    private void QueryUser()
    {
        string userName = "Joe";
        QueryUserYesNo($"Is your name {userName}?", "Verification",
            (result) =>
            {
                if (result == YesNoChoice.Yes)
                    ShowInformation($"Hi {userName}!", "Greeting");
            }
        );
    }

    private void OpenDialog()
    {
        ShowView(new DialogViewModel());
    }

    private void OpenModalDialog()
    {
        ShowView(new ModalDialogViewModel((text) => ShowConfirmedInformation(@$"You entered: {text}", "Summary", null, false)));
    }

    private void PickFile()
    {
        PickFile("Pick file", null, "All files (*.*)|*.*", (filePath) =>
        {
            if (filePath != null)
                ShowConfirmedInformation($"File {filePath} was picked.", "File picking", null);
        });
    }

    private void SetFileName()
    {
        ChooseFileName("Set file name", null, "All files (*.*)|*.*", ".txt", (filePath) =>
        {
            if (filePath != null)
                ShowConfirmedInformation($"File {filePath} was picked.", "File saving", null);
        });
    }

    private void PickFolder()
    {
        PickFolder("Pick folder", null, (pickedFolder) =>
        {
            if (pickedFolder != null)
                ShowConfirmedInformation($"Folder {pickedFolder} was picked.", "Folder picking", null);
        });
    }

    private void DoAction()
    {
        CustomAction customAction = new();
        customAction.Execute(UserInteractionsInvoker);
    }
}
