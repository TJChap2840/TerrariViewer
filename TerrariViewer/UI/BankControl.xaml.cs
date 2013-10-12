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
    /// Interaction logic for BankControl.xaml
    /// </summary>
    public partial class BankControl : UserControl
    {
        public BankControl()
        {
            InitializeComponent();

            for (int i = 0; i < bank_Grid.RowDefinitions.Count; i++)
            {
                for (int j = 0; j < bank_Grid.ColumnDefinitions.Count; j++)
                {
                    ItemControl itemControl = new ItemControl((i * 8) + j);
                    itemControl.SetBinding(ItemControl.DataContextProperty, string.Format("Bank[{0}]", itemControl.Index));

                    Grid.SetRow(itemControl, i);
                    Grid.SetColumn(itemControl, j);
                    bank_Grid.Children.Add(itemControl);
                }
            }

            for (int i = 0; i < safe_Grid.RowDefinitions.Count; i++)
            {
                for (int j = 0; j < safe_Grid.ColumnDefinitions.Count; j++)
                {
                    ItemControl itemControl = new ItemControl((i * 8) + j);
                    itemControl.SetBinding(ItemControl.DataContextProperty, string.Format("Safe[{0}]", itemControl.Index));

                    Grid.SetRow(itemControl, i);
                    Grid.SetColumn(itemControl, j);
                    safe_Grid.Children.Add(itemControl);
                }
            }
        }
    }
}
