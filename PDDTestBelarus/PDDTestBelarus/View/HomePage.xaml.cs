using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using DevExpress.Mvvm.UI;
using PDDTestBelarus.ViewModel;
using Color = System.Drawing.Color;
using ColorConverter = System.Drawing.ColorConverter;
using SystemColors = System.Drawing.SystemColors;

namespace PDDTestBelarus.View;

public partial class HomePage : Page
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

    public UniformGrid Menu;
    public HomePage(MainViewModel mainViewModel)
    {
        DataContext = mainViewModel;
        InitializeComponent();
        Menu = HomeMenu;
        MenuItems = Menu.Children.OfType<Border>().ToList();
        ChangeStyleProperty(MenuItems[SelectedItem],true);

    }

    public async void OnArrowUpDown(object sender, KeyEventArgs e)
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