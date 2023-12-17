using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace PDDTestBelarus.View.UserControls;

public partial class TopQuestionNumPanel : UserControl
{
    private List<Grid> Elements = new();
    public TopQuestionNumPanel(int questionsNum)
    {
        InitializeComponent();
        FillPanelByElems(questionsNum);
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
}