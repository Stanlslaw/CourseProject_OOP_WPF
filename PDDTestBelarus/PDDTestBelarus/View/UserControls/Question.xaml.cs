using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using PDDTestBelarus.Models;

namespace PDDTestBelarus.View.UserControls;

public partial class Question : UserControl
{

    public int? currentAnswer=null;
    public List<Answer> answers;
    public string ImagePath { get; set; }
  
    public Question(string questionText,List<Answer> an,string imagePath)
    {
        InitializeComponent();
        QuestionText.Text = questionText;
        answers = an;
        ImagePath = imagePath;
        QuestionImage.Source = new BitmapImage(new Uri(imagePath));
        CreateAnswerList(an);
    }


    public void CreateAnswerList(List<Answer> answers)
    {
        Shuffle(answers);

        foreach (var (answer, i) in answers.Select((a, index) => (a, index)))
        {
            var tb = new TextBlock();
            tb.Text = $"{i + 1}. {answer.AnswerText}";
            tb.Uid = answer.Id.ToString();
            tb.VerticalAlignment = VerticalAlignment.Center;
            AnswersContainer.Children.Add(tb);
        }
    }

    public bool? IsRightAnswer()
    {
        if (currentAnswer == null)
        {
            return null;
        }
        foreach (var (answer, i) in answers.Select((a, index) => (a, index)))
        {
            if (Convert.ToBoolean(answer.IsCorrect) && currentAnswer == i + 1)
            {
                AnswerInput.Background = Brushes.Green;
                return true;
            }
            AnswerInput.Background = Brushes.OrangeRed;
        }

        return false;
    }
    public void SetAnswer(int num,bool changeFlag=false)
    {
        if (!changeFlag)
        {
            currentAnswer = num;
            AnswerNumTB.Text = num.ToString();
        }
      
    }

    public void ResetAnswer()
    {
        currentAnswer = null;
        AnswerNumTB.Text = "_";
    }

    private void Shuffle<T>(List<T> list)
    {
        Random random = new Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}