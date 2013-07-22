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
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DataObject data = new DataObject();
                data.SetData("Item", MainWindow.player.Inventory[Index]);
                data.SetData("Object", this);

                DragDrop.DoDragDrop(this, data, DragDropEffects.Move);
            }
        }

        protected override void OnDrop(DragEventArgs e)
        {
            base.OnDrop(e);
            if (e.Data.GetDataPresent("Item"))
            {
                ItemControl itemControl = e.Data.GetData("Object") as ItemControl;
                TerrariaObjects.Item item = e.Data.GetData("Item") as TerrariaObjects.Item;
                TerrariaObjects.Item tempItem = MainWindow.player.Inventory[Index];

                MainWindow.player.Inventory[Index] = item;
                MainWindow.player.Inventory[itemControl.Index] = tempItem;
                this.SetBinding(ItemControl.DataContextProperty, string.Format("Inventory[{0}]", Index));
                itemControl.SetBinding(ItemControl.DataContextProperty, string.Format("Inventory[{0}]", itemControl.Index));
                e.Effects = DragDropEffects.Move;
            }
            e.Handled = true;
        }
    }
}
