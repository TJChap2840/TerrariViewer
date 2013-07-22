using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TerrariViewer.UI
{
    /// <summary>
    /// Interaction logic for InventoryControl.xaml
    /// </summary>
    public partial class InventoryControl : UserControl
    {
        public InventoryControl()
        {
            InitializeComponent();

            for (int i = 0; i < inv_Grid.RowDefinitions.Count; i++)
            {
                for (int j = 0; j < inv_Grid.ColumnDefinitions.Count; j++)
                {                    
                    ItemControl itemControl = new ItemControl((i * 10) + j);
                    itemControl.SetBinding(ItemControl.DataContextProperty, string.Format("Inventory[{0}]", itemControl.Index));

                    Grid.SetRow(itemControl, i);
                    Grid.SetColumn(itemControl, j);
                    inv_Grid.Children.Add(itemControl);
                }
            }

            for (int i = 0; i < coin_Grid.RowDefinitions.Count; i++)
            {
                ItemControl itemControl = new ItemControl(i);
                itemControl.SetBinding(ItemControl.DataContextProperty, string.Format("Coins[{0}]", itemControl.Index));

                Grid.SetRow(itemControl, i);
                coin_Grid.Children.Add(itemControl);
            }

            for (int i = 0; i < ammo_Grid.RowDefinitions.Count; i++)
            {
                ItemControl itemControl = new ItemControl(i);
                itemControl.SetBinding(ItemControl.DataContextProperty, string.Format("Ammo[{0}]", itemControl.Index));

                Grid.SetRow(itemControl, i);
                ammo_Grid.Children.Add(itemControl);
            }
        }
    }
}
