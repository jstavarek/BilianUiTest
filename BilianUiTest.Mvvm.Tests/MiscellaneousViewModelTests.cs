using Bilian.Ui;
using Bilian.Ui.Testing;

namespace BilianUiTest.Mvvm.Tests;

[TestClass]
public sealed class MiscellaneousViewModelTests
{
    [TestMethod]
    public void Text_is_processed()
    {
        var viewModel = new MiscellaneousViewModel(new TextProcessor());
        var bench = new ViewModelTestbench(viewModel);
        bench.Activate();

        Assert.IsNull(viewModel.InputText);
        Assert.IsNull(viewModel.Result);

        viewModel.InputText = "text1";
        Assert.AreEqual("text1", viewModel.InputText);
        Assert.IsNull(viewModel.Result);

        viewModel.ProcessTextCommand.Execute();
        Assert.AreEqual("TEXT1", viewModel.Result);
    }

    [TestMethod]
    public void Banned_word_handled()
    {
        var viewModel = new MiscellaneousViewModel(new TextProcessor());
        var bench = new ViewModelTestbench(viewModel);
        bench.Activate();

        viewModel.InputText = "abc";
        viewModel.ProcessTextCommand.Execute();

        var processText = () => viewModel.ProcessTextCommand.Execute();
        var showingConfirmedWarning = bench.CatchUserInteraction(processText) as ShowingConfirmedWarning;
        Assert.IsNotNull(showingConfirmedWarning, $"{nameof(ShowingConfirmedWarning)} expected");
        Assert.AreEqual("Processing text", showingConfirmedWarning.Title);
        Assert.AreEqual("This word cannot be processed", showingConfirmedWarning.Text);

        bench.InvokeUserInteraction(showingConfirmedWarning);
        Assert.AreEqual("banned word", viewModel.Result);
    }
}
