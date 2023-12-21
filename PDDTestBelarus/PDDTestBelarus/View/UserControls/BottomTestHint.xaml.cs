using System.Windows.Controls;

namespace PDDTestBelarus.View.UserControls;

public partial class BottomTestHint : UserControl
{
    public BottomTestHint()
    {
        InitializeComponent();
        ShowHowGiveAnswer();
    }

    public void ShowHowGiveAnswer()
    {
        TestHint.Text = "Чтобы дать ответ нажмите - ";
    }
    public void ShowHowGoNext()
    {
        TestHint.Text = "Чтобы перейти к следующему вопросу нажмите - ";
    }
    public void ShowHowEnd()
    {
        TestHint.Text = "Для завершения теста нажмите - ";
    }

    public void ShowHowOpen()
    {
        TestHint.Text = "Чтобы увидеть пояснения нажмите - ";
        KeyName.Text = "Пробел";
    }
    public void ShowHowClose()
    {
        TestHint.Text = "Чтобы скрыть пояснения нажмите -";
        KeyName.Text = "Пробел или ESC";
    }
}