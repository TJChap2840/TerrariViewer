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
    /// Interaction logic for CharacterControl.xaml
    /// </summary>
    public partial class CharacterControl : UserControl
    {
        public CharacterControl()
        {
            InitializeComponent();
        }

        private void hairMinus_Button_Click(object sender, RoutedEventArgs e)
        {
            TerrariaObjects.Player player = this.DataContext as TerrariaObjects.Player;
            if (player != null) player.Hair--;
        }

        private void hairPlus_Button_Click(object sender, RoutedEventArgs e)
        {
            TerrariaObjects.Player player = this.DataContext as TerrariaObjects.Player;
            if (player != null) player.Hair++;
        }
    }
}
