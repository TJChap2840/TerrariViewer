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
    /// Interaction logic for ItemPicker.xaml
    /// </summary>
    public partial class ItemPicker : UserControl
    {
        private Item item = null;
        private Item lastValidItem = null;
        private static List<Item> itemsSource = null;
        private static string filterText = "";
        private static string[] filterParts = { "" };

        public ItemPicker()
        {
            InitializeComponent();

            Prefix_List.ItemsSource = Item.PrefixDictionary;

            if (itemsSource == null)
            {
                SetNewItemsSource();
            }
            else
            {
                Item_List.ItemsSource = itemsSource;
            }
        }

        private void ItemFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            filterText = Item_Filter.Text;
            filterParts = filterText.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (filterParts.Length == 0)
            {
                filterParts = new string[] { "" };
            }

            SetNewItemsSource();
        }

        private void SetNewItemsSource()
        {   
            itemsSource = Item.ItemDictionary.Values
                .Where(info => HandleFilter(info))
                .OrderBy(info => info.Name)
                .ThenBy(info => info.Name)
                .ToList();

            HandleItemsSourceChange();
        }

        private void HandleItemsSourceChange()
        {
            object currentSelected = Item_List.SelectedValue;
            if (currentSelected == null)
            {
                currentSelected = lastValidItem;
            }
            else
            {
                lastValidItem = currentSelected as Item;
            }

            Item_List.ItemsSource = itemsSource;
            Item_List.SelectedValue = currentSelected;
        }

        private bool HandleFilter(Item item)
        {
            string targetName = item.Name.ToLowerInvariant();

            foreach (string filterPart in filterParts)
            {
                if (targetName.IndexOf(filterPart, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return true;
                }
            }
            return false;
        }

        private void ItemList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Item_List.SelectedValue == null) return;

            Item selected = Item_List.SelectedValue as Item;

            if (selected == null) return;

            if (selected.Id == 0)
            {
                item.StackSize = 0;
                item.Name = "No Item";
            }
            else
            {
                item.StackSize = 1;
                item.Name = Item.ItemDictionary[selected.Id].Name;
            }

            lastValidItem = selected;
        }

        private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            item = this.DataContext as Item;
        }

        private void ItemStack_TextChanged(object sender, TextChangedEventArgs e)
        {
            item.StackSize = int.Parse(Item_Stack.Text);
        }

        private void ItemStack_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            string[] nums = { "D1", "D2", "D3", "D4", "D5", "D6", "D7", "D8", "D9", "D0",
                              "NumPad1", "NumPad2", "NumPad3", "NumPad4", "NumPad5", "NumPad6", "NumPad7", "NumPad8", "NumPad9", "NumPad0", 
                              "Back" };

            if (!nums.Contains(e.Key.ToString()))
                e.Handled = true;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Item_List.SelectedValue = 0;
            Item item = this.DataContext as Item;
            item.Name = "No Item";
            item.StackSize = 0;
            item.Prefix = 0;
        }
    }
}
