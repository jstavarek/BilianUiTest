using System.Diagnostics;

namespace BilianUiTest.Wpf;

public partial class MainView
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

    public MainView()
    {
        ShowInformationCommand = new Command(() => userInteractionsInvoker.ShowInformation("Text", "Title"));
        ShowInformationWithConfirmationCommand = new Command(() => userInteractionsInvoker.ShowConfirmedInformation("Text", "Title", () => Debug.WriteLine("Information confirmed"), false));
        ShowInformationWithRequiredConfirmationCommand = new Command(() => userInteractionsInvoker.ShowConfirmedInformation("Text", "Title", () => Debug.WriteLine("Information confirmed")));
        ShowWarningCommand = new Command(() => userInteractionsInvoker.ShowWarning("Text", "Title"));
        ShowWarningWithConfirmationCommand = new Command(() => userInteractionsInvoker.ShowConfirmedWarning("Text", "Title", () => Debug.WriteLine("Warning confirmed"), false));
        ShowWarningWithRequiredConfirmationCommand = new Command(() => userInteractionsInvoker.ShowConfirmedWarning("Text", "Title", () => Debug.WriteLine("Warning confirmed")));
        ShowErrorCommand = new Command(() => userInteractionsInvoker.ShowError("Text", "Title", new Exception("Error happened")));
        ShowErrorWithConfirmationCommand = new Command(() => userInteractionsInvoker.ShowConfirmedError("Text", "Title", new Exception("Error happened"), () => Debug.WriteLine("Error confirmed"), false));
        ShowErrorWithRequiredConfirmationCommand = new Command(() => userInteractionsInvoker.ShowConfirmedError("Text", "Title", new Exception("Error happened"), () => Debug.WriteLine("Error confirmed")));

        QueryUserCommand = new Command(QueryUser);
        PickFileCommand = new Command(PickFile);
        SetFileNameCommand = new Command(SetFileName);
        PickFolderCommand = new Command(PickFolder);

        OpenDialogCommand = new Command(OpenDialog);

        DataContext = this;
        InitializeComponent();
    }

    private void QueryUser()
    {
        string userName = "Joe";
        userInteractionsInvoker.QueryUserYesNo($"Is your name {userName}?", "Verification",
            (result) =>
            {
                if (result == YesNoChoice.Yes)
                    userInteractionsInvoker.ShowInformation($"Hi {userName}!", "Greeting");
            }
        );
    }

    private void PickFile()
    {
        userInteractionsInvoker.PickFile("Pick file", null, "All files (*.*)|*.*", (filePath) =>
        {
            if (filePath != null)
                userInteractionsInvoker.ShowConfirmedInformation($"File {filePath} was picked.", "File picking", null);
        });
    }

    private void SetFileName()
    {
        userInteractionsInvoker.ChooseFileName("Set file name", null, "All files (*.*)|*.*", ".txt", (filePath) =>
        {
            if (filePath != null)
                userInteractionsInvoker.ShowConfirmedInformation($"File {filePath} was picked.", "File saving", null);
        });
    }

    private void PickFolder()
    {
        userInteractionsInvoker.PickFolder("Pick folder", null, (pickedFolder) =>
        {
            if (pickedFolder != null)
                userInteractionsInvoker.ShowConfirmedInformation($"Folder {pickedFolder} was picked.", "Folder picking", null);
        });
    }

    private void OpenDialog()
    {
        userInteractionsInvoker.ShowView(new NonModalWindowView());
    }
}