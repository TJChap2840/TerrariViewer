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
    /// Interaction logic for EquipmentControl.xaml
    /// </summary>
    public partial class EquipmentControl : UserControl
    {
        public EquipmentControl()
        {
            InitializeComponent();

            for (int i = 0; i < vanity_Grid.RowDefinitions.Count; i++)
            {
                ItemControl itemControl = new ItemControl();
                itemControl.SetBinding(ItemControl.DataContextProperty, string.Format("Vanity[{0}]", i));

                Grid.SetRow(itemControl, i);
                vanity_Grid.Children.Add(itemControl);
            }

            for (int i = 0; i < armor_Grid.RowDefinitions.Count; i++)
            {
                ItemControl itemControl = new ItemControl();
                itemControl.SetBinding(ItemControl.DataContextProperty, string.Format("Armor[{0}]", i));

                Grid.SetRow(itemControl, i);
                armor_Grid.Children.Add(itemControl);
            }

            for (int i = 0; i < accessory_Grid.RowDefinitions.Count; i++)
            {
                ItemControl itemControl = new ItemControl();
                itemControl.SetBinding(ItemControl.DataContextProperty, string.Format("Accessories[{0}]", i));

                Grid.SetRow(itemControl, i);
                accessory_Grid.Children.Add(itemControl);
            }
        }
    }
}
