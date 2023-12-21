using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using PDDTestBelarus.Models;

namespace PDDTestBelarus.View.UserControls;

public partial class ResultTable : UserControl
{
    public int incorrect = 0;
    private List<QuestionData> results;
    private List<int> userAnswers;
    public ResultTable(List<QuestionData> results,int elapsedTime,List<int>? userAnswers)
    {
        InitializeComponent();
        this.results = results;
        this.userAnswers = userAnswers;
        FillTable();
        if (IsPassed(this.results))
        {
            TextResult.Text = "Экзамен сдан";
        }
        else
        {
            TextResult.Text = "Экзамен не сдан";
        }
        ShowStatictics(elapsedTime);
    }

    public void FillTable()
    {
        if (results.Count == 0)
        {
            TextBlock tb = new TextBlock();
            tb.Text = "Нет ответов";
            tb.HorizontalAlignment = HorizontalAlignment.Center;
            tb.VerticalAlignment = VerticalAlignment.Center;
            TableAnswerRows.Rows = 1;
            TableAnswerRows.Children.Add(tb);
            return;
        }
        TableAnswerRows.Rows = 10;
        for (int i = 0; i < results.Count; i++)
        {
            int correctAnswerInd =results[i].asnwers.IndexOf(results[i].asnwers.FirstOrDefault(ans=>ans.IsCorrect==1));
            int[] rowData = {i+1,userAnswers[i],correctAnswerInd+1};
            UniformGrid ug = new UniformGrid();
            ug.Columns = 4;
            for (int j = 0; j < 3; j++)
            {
                TextBlock tb = new TextBlock();
                tb.VerticalAlignment = VerticalAlignment.Center;
                tb.HorizontalAlignment = HorizontalAlignment.Center;
                tb.FontSize = 12;
                tb.Foreground = Brushes.White;
                tb.FontWeight=FontWeights.DemiBold;
                tb.Text = rowData[j].ToString();
                ug.Children.Add(tb);
            }

            Image img = new Image();
            BitmapImage bitmap;
            if ((bool)results[i].result)
            {
                bitmap = new BitmapImage(new Uri("pack://application:,,,/Icons/right.png"));
            }
            else
            {
                 bitmap = new BitmapImage(new Uri("pack://application:,,,/Icons/wrong.png"));
            }
          
           
            img.Source = bitmap;
            img.MaxWidth = 24;
            img.MaxHeight = 24;
            ug.Children.Add(img);
            TableAnswerRows.Children.Add(ug);
        }
    }
    public void ShowStatictics(int elapsedTime)
    {
        NumOfCorrect.Text = (results.Count - incorrect).ToString();
        NumOfInCorrect.Text = incorrect.ToString();
        ElapsedTimeMinutes.Text = ((int)(15*60-elapsedTime) / 60).ToString("00");
       ElapsedTimeSeconds.Text = ((15*60-elapsedTime) % 60).ToString("00");
    }

    public bool IsPassed(List<QuestionData> results)
    {
        if (results.Count<9)
        {
            return false;
        }
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