using Bilian.Ui;
using Bilian.Ui.Testing;

namespace BilianUiTest.Mvvm.Tests;

[TestClass]
public sealed class MiscellaneousViewModelTests
{
    [TestMethod]
    public void View_model_initialized()
    {
        var viewModel = new MiscellaneousViewModel(new TextProcessor());
        var bench = new ViewModelTestbench(viewModel);
        bench.Activate();

        Assert.IsNull(viewModel.InputText);
        Assert.IsNull(viewModel.Result);
    }

    [TestMethod]
    public void Text_is_processed()
    {
        var viewModel = new MiscellaneousViewModel(new TextProcessor());
        var bench = new ViewModelTestbench(viewModel);
        bench.Activate();

        viewModel.InputText = "text1";
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

        var showingConfirmedWarning = bench.UserInteractions.FirstOrDefault() as ShowingConfirmedWarning;
        Assert.IsNotNull(showingConfirmedWarning, $"{nameof(ShowingConfirmedWarning)} expected");
        Assert.AreEqual("Processing text", showingConfirmedWarning.Title);
        Assert.AreEqual("This word cannot be processed", showingConfirmedWarning.Text);
        Assert.AreEqual("banned word", viewModel.Result);
    }
}
