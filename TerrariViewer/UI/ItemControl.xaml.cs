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
    /// Interaction logic for ItemControl.xaml
    /// </summary>
    public partial class ItemControl : UserControl
    {
        private static event Action PopupOpening;

        private int index;
        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        public ItemControl(int i)
        {
            InitializeComponent();
            Index = i;
            PopupOpening += new Action(ItemControl_PopupOpening);
        }

        private void ItemControl_MouseDown(object sender, MouseButtonEventArgs e)
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

        void ItemControl_PopupOpening()
        {
            Pop_Up.IsOpen = false;
        }

        private void ItemControl_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Pop_Up.StaysOpen = false;
        }

        private void PopUp_MouseEnter(object sender, MouseEventArgs e)
        {
            Pop_Up.StaysOpen = false;
        }
        
        //protected override void OnMouseMove(MouseEventArgs e)
        //{
        //    base.OnMouseMove(e);
        //    if (e.LeftButton == MouseButtonState.Pressed)
        //    {
        //        DataObject data = new DataObject();
        //        FrameworkElement parent = (FrameworkElement)this.Parent;
        //        string parent_name = parent.Name;
        //        if (parent_name == "inv_Grid" || parent_name == "coin_Grid" || parent_name == "ammo_Grid")
        //        {
        //            data.SetData("Item", MainWindow.player.Inventory[Index]);
        //        }
        //        else if (parent_name == "bank_Grid")
        //        {
        //            data.SetData("Item", MainWindow.player.Bank[Index]);
        //        }
        //        else if (parent_name == "safe_Grid")
        //        {
        //            data.SetData("Item", MainWindow.player.Safe[Index]);
        //        }                
        //        data.SetData("Object", this);

        //        DragDrop.DoDragDrop(this, data, DragDropEffects.Move);
        //    }
        //}

        //protected override void OnDrop(DragEventArgs e)
        //{
        //    base.OnDrop(e);
        //    if (e.Data.GetDataPresent("Item"))
        //    {
        //        ItemControl itemControl = e.Data.GetData("Object") as ItemControl;
        //        TerrariaObjects.Item item = e.Data.GetData("Item") as TerrariaObjects.Item;
                
        //        FrameworkElement parent = (FrameworkElement)this.Parent;
        //        string parent_name = parent.Name;
        //        if (parent_name == "inv_Grid" || parent_name == "coin_Grid" || parent_name == "ammo_Grid")
        //        {
        //            TerrariaObjects.Item tempItem = MainWindow.player.Inventory[Index];
        //            MainWindow.player.Inventory[Index] = item;
        //            MainWindow.player.Inventory[itemControl.Index] = tempItem;
        //            this.SetBinding(ItemControl.DataContextProperty, string.Format("Inventory[{0}]", Index));
        //            itemControl.SetBinding(ItemControl.DataContextProperty, string.Format("Inventory[{0}]", itemControl.Index));
        //        }
        //        else if (parent_name == "bank_Grid")
        //        {
        //            TerrariaObjects.Item tempItem = MainWindow.player.Bank[Index];
        //            MainWindow.player.Bank[Index] = item;
        //            MainWindow.player.Bank[itemControl.Index] = tempItem;
        //            this.SetBinding(ItemControl.DataContextProperty, string.Format("Bank[{0}]", Index));
        //            itemControl.SetBinding(ItemControl.DataContextProperty, string.Format("Bank[{0}]", itemControl.Index));
        //        }
        //        else if (parent_name == "safe_Grid")
        //        {
        //            TerrariaObjects.Item tempItem = MainWindow.player.Safe[Index];
        //            MainWindow.player.Safe[Index] = item;
        //            MainWindow.player.Safe[itemControl.Index] = tempItem;
        //            this.SetBinding(ItemControl.DataContextProperty, string.Format("Safe[{0}]", Index));
        //            itemControl.SetBinding(ItemControl.DataContextProperty, string.Format("Safe[{0}]", itemControl.Index));
        //        }                
        //        e.Effects = DragDropEffects.Move;
        //    }
        //    e.Handled = true;
        //}
    }
}
