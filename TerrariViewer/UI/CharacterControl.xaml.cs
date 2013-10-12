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
using TerrariViewer.TerrariaObjects;

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
            Player player = this.DataContext as Player;
            if (player != null) player.Hair--;
        }

        private void hairPlus_Button_Click(object sender, RoutedEventArgs e)
        {
            Player player = this.DataContext as Player;
            if (player != null) player.Hair++;
        }

        private void Restore_Click(object sender, RoutedEventArgs e)
        {
            Player player = this.DataContext as Player;
            player.CurrentHealth = player.MaximumHealth;
            player.CurrentMana = player.MaximumMana;
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            string[] nums = { "D1", "D2", "D3", "D4", "D5", "D6", "D7", "D8", "D9", "D0",
                              "NumPad1", "NumPad2", "NumPad3", "NumPad4", "NumPad5", "NumPad6", "NumPad7", "NumPad8", "NumPad9", "NumPad0" };

            if (!nums.Contains(e.Key.ToString()))
                e.Handled = true;
        }

        private void Max_Click(object sender, RoutedEventArgs e)
        {
            Player player = this.DataContext as Player;
            player.MaximumHealth = 999;
            player.MaximumMana = 999;
        }

        private void Color_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle rectangle = sender as Rectangle;
            SolidColorBrush bg = rectangle.Fill as SolidColorBrush;

            System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();
            colorDialog.FullOpen = true;
            colorDialog.Color = System.Drawing.Color.FromArgb(bg.Color.R, bg.Color.G, bg.Color.B);

            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                rectangle.Fill = new SolidColorBrush(Color.FromRgb(colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B));
            }
        }
    }
}
