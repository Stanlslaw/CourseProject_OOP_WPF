using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using PDDTestBelarus.Models;
using PDDTestBelarus.ViewModel;

namespace PDDTestBelarus.View;

public partial class TopicsPage : Page
{
    private int _selectedItem=0;
    public int SelectedItem
    {
        get
        {
            return _selectedItem;
        }
        set
        {
            if (value > Menu.Children.Count-1)
            {
                _selectedItem = 0;
            }
            else if (value < 0)
            {
                _selectedItem = Menu.Children.Count-1;
            }
            else
            {
                _selectedItem = value;
            }
        }
    }
    public List<Border> MenuItems;
    public MainViewModel Context;
    public UniformGrid Menu;
    public List<Topic> topicsList;
    public TopicsPage(MainViewModel context)
    {
        Context = context;
        InitializeComponent();
        Menu = TopicsMenu;
        FillMenu(context.db);
        MenuItems = Menu.Children.OfType<Border>().ToList();
        ChangeStyleProperty(MenuItems[SelectedItem],true);
    }

    public void FillMenu(PddContext db)
    {
        topicsList = db.Topics.ToList();
        foreach (var topic in topicsList)
        {
            Border border = new Border();
            border.BorderThickness = new Thickness(10, 10, 10, 10);
            TextBlock tb = new TextBlock();
            tb.Foreground = Brushes.White;
            tb.VerticalAlignment = VerticalAlignment.Center;
            tb.HorizontalAlignment = HorizontalAlignment.Center;
            tb.FontWeight = FontWeights.Medium;
            tb.FontSize = 16;
            tb.Text = topic.TopicName;
            border.Child = tb;
            TopicsMenu.Children.Add(border);
        }
    }
    public void OnArrowUpDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
        }
        if (e.Key == Key.Up)
        {
            ChangeStyleProperty(MenuItems[SelectedItem],false);
            SelectedItem--;
            ChangeStyleProperty(MenuItems[SelectedItem],true);
        
        }

        if (e.Key == Key.Down)
        {
            ChangeStyleProperty(MenuItems[SelectedItem],false);
            SelectedItem++;
            ChangeStyleProperty(MenuItems[SelectedItem],true);
        }
    }
    public void ChangeStyleProperty(Border elem, bool isRedo)
    {
        if (isRedo)
        {
            elem.Background=Brushes.White;
            ((TextBlock)elem.Child).Foreground = Brushes.Black;
        }
        else
        {
            
            elem.Background =new SolidColorBrush(System.Windows.Media.Color.FromRgb(60, 99, 255)) ;
            ((TextBlock)elem.Child).Foreground = Brushes.White;
        }
    }
}