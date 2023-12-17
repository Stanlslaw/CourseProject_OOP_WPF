using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using PDDTestBelarus.Models;
using PDDTestBelarus.View.UserControls;

namespace PDDTestBelarus.View;

public partial class ResultPage : Page
{
    private ResultTable table;
    private int _selectedItem = 0;
    private UniformGrid Menu;
    private List<UniformGrid> MenuItems;
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

    public ResultPage()
    {
        InitializeComponent();
        table = new ResultTable();
        Menu = table.TableAnswerRows;
        MenuItems = Menu.Children.OfType<UniformGrid>().ToList();
        TableContainer.Children.Add(table);
        ChangeStyleProperty(MenuItems[SelectedItem],true);
    }
    
    public async void OnArrowUpDown(object sender, KeyEventArgs e)
    {
       
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
    public void ChangeStyleProperty(UniformGrid elem, bool isRedo)
    {
        if (isRedo)
        {
            elem.Background=Brushes.White;
            foreach (TextBlock tb in elem.Children.OfType<TextBlock>())
            {
                tb.Foreground = Brushes.Black;
            }
        }
        else
        {
            elem.Background =new SolidColorBrush(Color.FromRgb(60, 99, 255)) ;
            foreach (TextBlock tb in elem.Children.OfType<TextBlock>())
            {
                tb.Foreground = Brushes.White;
            }
        }
    }
}