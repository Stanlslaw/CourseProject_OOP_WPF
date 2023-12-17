using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace PDDTestBelarus.View;

public partial class ExitPage : Page
{
    private int _selectedItem = 0;
    public int SelectedItem
    {
        get
        {
            return _selectedItem;
        }
        set
        {
            if (value > Menu.Children.Count - 1)
            {
                _selectedItem = 0;
            }
            else if (value < 0)
            {
                _selectedItem = Menu.Children.Count - 1;
            }
            else
            {
                _selectedItem = value;
            }
        }
    }

    public List<Border> MenuItems;
    public UniformGrid Menu;
    public ExitPage()
    {
        InitializeComponent();
        Menu = ExitMenu;
        MenuItems = Menu.Children.OfType<Border>().ToList();
        ChangeStyleProperty(MenuItems[SelectedItem], true);
    }

    public void OnArrowUpDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
        }
        if (e.Key == Key.Up)
        {
            ChangeStyleProperty(MenuItems[SelectedItem], false);
            SelectedItem--;
            ChangeStyleProperty(MenuItems[SelectedItem], true);

        }

        if (e.Key == Key.Down)
        {
            ChangeStyleProperty(MenuItems[SelectedItem], false);
            SelectedItem++;
            ChangeStyleProperty(MenuItems[SelectedItem], true);
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

            elem.Background = Brushes.Orange;
            ((TextBlock)elem.Child).Foreground = Brushes.White;
        }
    }
}