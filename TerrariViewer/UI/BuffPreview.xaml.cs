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
    /// Interaction logic for BuffPreview.xaml
    /// </summary>
    public partial class BuffPreview : UserControl
    {
        private static event Action PopupOpening;

        public BuffPreview()
        {
            InitializeComponent();
            PopupOpening += new Action(BuffControl_PopupOpening);
        }

        private void BuffControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CloseAllPopups();
            Pop_Up.IsOpen = true;
            Pop_Up.StaysOpen = true;
        }

        public static void CloseAllPopups()
        {
            if (PopupOpening != null)
            {
                PopupOpening();
            }
        }

        void BuffControl_PopupOpening()
        {
            Pop_Up.IsOpen = false;
        }

        private void BuffControl_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Pop_Up.StaysOpen = false;
        }

        private void PopUp_MouseEnter(object sender, MouseEventArgs e)
        {
            Pop_Up.StaysOpen = false;
        }
    }
}
