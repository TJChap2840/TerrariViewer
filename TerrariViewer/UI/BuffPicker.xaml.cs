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
    /// Interaction logic for BuffPicker.xaml
    /// </summary>
    public partial class BuffPicker : UserControl
    {
        private Buff buff = null;
        private Buff lastValidBuff = null;
        private static List<Buff> buffsSource = null;
        private static string filterText = "";
        private static string[] filterParts = { "" };

        public BuffPicker()
        {
            InitializeComponent();

            if (buffsSource == null)
            {
                SetNewBuffsSource();
            }
            else
            {
                Buff_List.ItemsSource = buffsSource;
            }
        }

        private void SetNewBuffsSource()
        {
            buffsSource = Buff.BuffDictionary.Values
                .Where(info => HandleFilter(info))
                .OrderBy(info => info.Name)
                .ToList();

            HandleItemsSourceChange();
        }

        private bool HandleFilter(Buff info)
        {
            string targetName = info.Name.ToLowerInvariant();

            foreach (string filterPart in filterParts)
            {
                if (targetName.IndexOf(filterPart, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return true;
                }
            }
            return false;
        }

        private void HandleItemsSourceChange()
        {
            object currentSelected = Buff_List.SelectedValue;
            if (currentSelected == null)
            {
                currentSelected = lastValidBuff;
            }
            else
            {
                lastValidBuff = currentSelected as Buff;
            }

            Buff_List.ItemsSource = buffsSource;
            Buff_List.SelectedValue = currentSelected;
        }

        private void BuffFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            filterText = Buff_Filter.Text;
            filterParts = filterText.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (filterParts.Length == 0)
            {
                filterParts = new string[] { "" };
            }

            SetNewBuffsSource();
        }

        private void BuffList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Buff_List.SelectedValue == null) return;

            Buff selected = Buff_List.SelectedValue as Buff;

            if (selected == null) return;

            if (selected.Id == 0)
            {
                buff.GameDuration = 0;
                buff.Name = "No Buff";
            }
            else
            {
                buff.GameDuration = Buff.BuffDictionary[selected.Id].MaxDuration;
                buff.Name = Buff.BuffDictionary[selected.Id].Name;
            }

            lastValidBuff = selected;
        }

        private void BuffStack_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Buff_Stack.Text == "")
            {
                buff.GameDuration = 0;
            }
            else
            {
                buff.GameDuration = int.Parse(Buff_Stack.Text);
            }
        }

        private void BuffStack_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            string[] nums = { "D1", "D2", "D3", "D4", "D5", "D6", "D7", "D8", "D9", "D0",
                              "NumPad1", "NumPad2", "NumPad3", "NumPad4", "NumPad5", "NumPad6", "NumPad7", "NumPad8", "NumPad9", "NumPad0", 
                              "Back" };

            if (!nums.Contains(e.Key.ToString()))
                e.Handled = true;
        }

        private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            buff = this.DataContext as Buff;
        }
    }
}
