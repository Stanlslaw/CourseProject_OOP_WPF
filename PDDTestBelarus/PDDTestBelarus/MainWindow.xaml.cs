using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using PDDTestBelarus.View;
using PDDTestBelarus.ViewModel;

namespace PDDTestBelarus;

public partial class MainWindow : Window
{

    MainViewModel viewModel;
    InputHandler inputHandler;
    public MainWindow()
    {
        InitializeComponent();
        viewModel=new MainViewModel();
        DataContext = viewModel;
        inputHandler = new InputHandler(viewModel);
        Mouse.OverrideCursor = Cursors.None;
        //Topmost = true;
    }

    public void OnKeyDown(object sender, KeyEventArgs e)
    {
        inputHandler.MainInputHandler(sender,e);
    }
}