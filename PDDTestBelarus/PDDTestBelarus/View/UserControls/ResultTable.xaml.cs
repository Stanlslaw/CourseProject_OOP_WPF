using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
    public ResultTable(List<QuestionData> results)
    {
        InitializeComponent();
        this.results = results;
        FillTable();
        if (IsPassed(this.results))
        {
            TextResult.Text = "Экзамен сдан";
        }
        else
        {
            TextResult.Text = "Экзамен не сдан";
        }
        ShowStatictics();
    }

    public void FillTable()
    {
        for (int i = 0; i < 10; i++)
        {
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
                tb.Text = i.ToString();
                ug.Children.Add(tb);
            }

            Image img = new Image();
            BitmapImage bitmap;
            if ((bool)results[i].result)
            {
                bitmap = new BitmapImage(new Uri("pack://application:,,,/Images/right.png"));
            }
            else
            {
                 bitmap = new BitmapImage(new Uri("pack://application:,,,/Images/wrong.png"));
            }
          
           
            img.Source = bitmap;
            img.MaxWidth = 24;
            img.MaxHeight = 24;
            ug.Children.Add(img);
            TableAnswerRows.Children.Add(ug);
        }
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