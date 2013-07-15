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
    /// Interaction logic for BuffControl.xaml
    /// </summary>
    public partial class BuffControl : UserControl
    {
        public BuffControl()
        {
            InitializeComponent();

            for (int i = 0; i < main_Grid.RowDefinitions.Count; i++)
            {
                for (int j = 0; j < main_Grid.ColumnDefinitions.Count; j++)
                {
                    BuffPreview buffPreview = new BuffPreview();
                    buffPreview.SetBinding(BuffPreview.DataContextProperty, string.Format("Buffs[{0}]", i * (j + 1)));

                    Grid.SetRow(buffPreview, i);
                    Grid.SetColumn(buffPreview, j);
                    main_Grid.Children.Add(buffPreview);
                }
                //AccessoryControl accessoryControl = new AccessoryControl();
                //accessoryControl.SetBinding(AccessoryControl.DataContextProperty, string.Format("Vanity[{0}]", i));

                //Grid.SetRow(accessoryControl, i);
                //vanity_Grid.Children.Add(accessoryControl);
            }
        }
    }
}
