using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using PDDTestBelarus.Models;

namespace PDDTestBelarus.View.UserControls;

public partial class TopQuestionNumPanel : UserControl
{
    private List<QuestionData> results;
    private List<Grid> Elements = new();
    public TopQuestionNumPanel(int questionsNum,List<QuestionData>? results=null,int selected=-1)
    {
        InitializeComponent();
        FillPanelByElems(questionsNum);
        this.results = results;
        if (this.results != null)
        {
            FillColorAfterTest(selected);
        }
        
    }

    public void FillPanelByElems(int num)
    {
        for (int i = 0; i < num; i++)
        {
            NumPanel.Children.Add(CreatePanelElement(i));
        }
    }
    public Grid CreatePanelElement(int num)
    {
        Grid container = new Grid();
        container.Height = 60;
        container.Width = 60;
        container.Margin = new Thickness(4);
        container.Background = Brushes.LightGray;
        container.VerticalAlignment = VerticalAlignment.Center;
        TextBlock tb = new TextBlock();
        tb.VerticalAlignment = VerticalAlignment.Center;
        tb.HorizontalAlignment = HorizontalAlignment.Center;
        tb.FontSize = 16;
        tb.Text = (num+1).ToString();
        container.Children.Add(tb);
        Elements.Add(container);
        return container;
    }

    public void ChangeColor(int num,bool isRight)
    {
        Grid el= NumPanel.Children[num - 1] as Grid;
        if (isRight)
        {
            el.Background = Brushes.Green;
        }
        else
        {
            {
                el.Background = Brushes.Red;
            }
        }
    }

    private void FillColorAfterTest(int selected)
    {
            for (int i = 0; i < results.Count; i++)
            {
                ChangeColor(i+1,results[i].result??false);
                if (i == selected)
                {
                    SolidColorBrush scb;
                    if (results[i].result ?? false)
                    {
                        scb = new SolidColorBrush(Color.FromArgb(180, 0, 255, 0));
                      
                    }
                    else
                    {
                        scb = new SolidColorBrush(Color.FromArgb(180, 255, 0, 0));
                    }
                    ((Grid)NumPanel.Children[(int)selected]).Background=scb;
                    ((Grid)NumPanel.Children[(int)selected]).Margin = new Thickness(8);
                    ((TextBlock)((Grid)NumPanel.Children[(int)selected]).Children[0]).Foreground = Brushes.White;
                }
            }
    }
}