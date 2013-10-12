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
    /// Interaction logic for AccessoryControl.xaml
    /// </summary>
    public partial class AccessoryControl : UserControl
    {
        private static event Action PopupOpening;

        public AccessoryControl()
        {
            InitializeComponent();
            PopupOpening += new Action(AccessoryControl_PopupOpening);
        }

        private void AccessoryControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CloseAllPopups();
            Pop_Up.IsOpen = true;
            Pop_Up.StaysOpen = true;
        }

        private void AccessoryControl_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Pop_Up.StaysOpen = false;
        }

        public static void CloseAllPopups()
        {
            if (PopupOpening != null)
            {
                PopupOpening();
            }
        }

        private void PopUp_MouseEnter(object sender, MouseEventArgs e)
        {
            Pop_Up.StaysOpen = false;
        }

        void AccessoryControl_PopupOpening()
        {
            Pop_Up.IsOpen = false;
        }
    }
}
