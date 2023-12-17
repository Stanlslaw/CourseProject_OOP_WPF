using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PDDTestBelarus.View.UserControls;

public partial class ResultTable : UserControl
{
    public ResultTable()
    {
        InitializeComponent();
        FillTable();
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
            BitmapImage bitmap = new BitmapImage(new Uri("pack://application:,,,/Images/right.png"));
           
            img.Source = bitmap;
            img.MaxWidth = 24;
            img.MaxHeight = 24;
            ug.Children.Add(img);
            TableAnswerRows.Children.Add(ug);
        }
    }
}