namespace BilianUiTest.Wpf;

public partial class MainView
{
    public Command OpenDialogCommand { get; }

    public Command ShowMessageCommand { get; }
    public Command ShowErrorCommand { get; }
    public Command QueryUserCommand { get; }
    public Command PickFileCommand { get; }
    public Command SetFileNameCommand { get; }
    public Command PickFolderCommand { get; }

    public MainView()
    {
        OpenDialogCommand = new Command(OpenDialog);

        ShowMessageCommand = new Command(ShowMessage);
        ShowErrorCommand = new Command(InvokeException);
        QueryUserCommand = new Command(QueryUser);
        PickFileCommand = new Command(PickFile);
        SetFileNameCommand = new Command(SetFileName);
        PickFolderCommand = new Command(PickFolder);

        DataContext = this;
        InitializeComponent();
    }

    private void OpenDialog()
    {
        userInteractionsInvoker.ShowView(new NonModalWindowView());
    }

    private void ShowMessage()
    {
        userInteractionsInvoker.ShowInformation("Text", "Title", null);
    }

    private void QueryUser()
    {
        string userName = "Joe";
        userInteractionsInvoker.QueryUserYesNo($"Is your name {userName}?", "Verification",
            (result) =>
            {
                if (result == YesNoChoice.Yes)
                    userInteractionsInvoker.ShowInformation($"Hi {userName}!", "Greeting", null);
            }
        );
    }

    private void PickFile()
    {
        userInteractionsInvoker.PickFile("Pick file", null, "All files (*.*)|*.*", (filePath) =>
        {
            if (filePath != null)
                userInteractionsInvoker.ShowInformation($"File {filePath} was picked.", "File picking", null);
        });
    }

    private void SetFileName()
    {
        userInteractionsInvoker.ChooseFileName("Set file name", null, "All files (*.*)|*.*", ".txt", (filePath) =>
        {
            if (filePath != null)
                userInteractionsInvoker.ShowInformation($"File {filePath} was picked.", "File saving", null);
        });
    }

    private void PickFolder()
    {
        userInteractionsInvoker.PickFolder("Pick folder", null, (pickedFolder) =>
        {
            if (pickedFolder != null)
                userInteractionsInvoker.ShowInformation($"Folder {pickedFolder} was picked.", "Folder picking", null);
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
            userInteractionsInvoker.ShowError("Error description", "Error handling example", exception, null);
        }
    }
}