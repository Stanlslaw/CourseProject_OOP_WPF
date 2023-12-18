using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using PDDTestBelarus.Models;

namespace PDDTestBelarus.View.UserControls;

public partial class FastResult : UserControl
{
    int incorrect = 0;
    public FastResult(List<QuestionData> results)
    {
        InitializeComponent();
        if (IsPassed(results))
        {
            ShowPassed();
        }
        else
        {
            ShowUnPassed();
        }
        ShowStatictics();
    }

    public void ShowPassed()
    {
        ExamText.Foreground = Brushes.Green;
        
        ExamText.Text = "Экзамен";
        PassedText.Foreground = Brushes.Green;
    }

    public void ShowUnPassed()
    {
        ExamText.Foreground = Brushes.Red;
        ExamText.Text = "Экзамен не";
        PassedText.Foreground = Brushes.Red;
    }

    public void ShowStatictics()
    {
        NumOfCorrect.Text = (10 - incorrect).ToString();
        NumOfInCorrect.Text = incorrect.ToString();
    }

    public bool IsPassed(List<QuestionData> results)
    {
      
        foreach (var result in results)
        {
            if (!(result.result??false))
            {
                incorrect++;
            }
        }

        if (incorrect >= 2)
        {
            return false;
        }
        return true;
    }
}