using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TerrariViewer.TerrariaObjects
{
    public class Item : INotifyPropertyChanged
    {
        #region Item Dictionaries

        private static List<string> categoryDictionary = new List<string> { "All", "Accessory", "Ammunition", "Armor/Vanity", "Buildable", "Consumable", "Miscellaneous", "Ore/Bar", "Tool", "Weapon" };
        public static List<string> CategoryDictionary
        {
            get { return categoryDictionary; }
        }

        private static Dictionary<int, Item> itemDictionary = new Dictionary<int, Item>();
        public static Dictionary<int, Item> ItemDictionary
        {
            get { return itemDictionary; }
        }

        private static Dictionary<int, string> prefixDictionary = new Dictionary<int, string>();
        public static Dictionary<int, string> PrefixDictionary
        {
            get { return prefixDictionary; }
        }

        static Item()
        {
            Item item;

            string uri = "/TerrariViewer;component/TerrariaObjects/Data/Items.txt";

            using (StreamReader reader = new StreamReader(Application.GetResourceStream(new Uri(uri, UriKind.RelativeOrAbsolute)).Stream))
            {
                while (!reader.EndOfStream)
                {
                    try
                    {
                        item = new Item();

                        string line = reader.ReadLine();

                        string[] parts = line.Split('\t');

                        item.Id = int.Parse(parts[0]);
                        item.Name = parts[1];
                        item.ItemImage();
                        if (parts.Length > 2)
                        {                            
                            item.Categories = parts[2].Split(',');
                        }
                        ItemDictionary[int.Parse(parts[0])] = item;
                    }
                    catch
                    {
                        continue;
                    }
                }
            }

            uri = "/TerrariViewer;component/TerrariaObjects/Data/ItemPrefixes.txt";
            PrefixDictionary[0] = "";

            using (StreamReader reader = new StreamReader(Application.GetResourceStream(new Uri(uri, UriKind.RelativeOrAbsolute)).Stream))
            {
                while (!reader.EndOfStream)
                {
                    try
                    {
                        string line = reader.ReadLine();

                        string[] parts = line.Split('\t');
                        PrefixDictionary[int.Parse(parts[0])] = parts[1];
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
        }

        #endregion

        #region Properties

        private int id = 0;
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                ItemImage();
            }
        }

        private string name = "No Item";
        public string Name 
        {
            get { return name; }
            set
            {
                name = value;
                ItemText = this.ToString();
                OnPropertyChanged("Name");                
            }
        }

        private int stackSize;
        public int StackSize
        {
            get { return stackSize; }
            set
            {
                stackSize = value;
                ItemText = this.ToString();
                OnPropertyChanged("StackSize");
            }
        }

        private int prefix = 0;
        public int Prefix
        {
            get { return prefix; }
            set
            {
                prefix = value;
                OnPropertyChanged("Prefix");
            }
        }

        private BitmapImage image;
        public BitmapImage Image
        {
            get { return image; }
        }

        private string itemText;
        public string ItemText
        {
            get { return itemText; }
            set
            {
                itemText = value;
                OnPropertyChanged("ItemText");
            }
        }

        #endregion

        public string[] Categories = { };

        public Item()
        {
            ItemImage();
            Id = 0;
            StackSize = 0;
            Name = "No Item";
            Prefix = 0;
            ItemText = this.ToString();
        }

        public void SetFromID(int id)
        {
            Name = itemDictionary[id].Name;
            //switch (id) 
            //{
            //    case -1:
            //        Id = 1;
            //        break;

            //    case -2:
            //        Id = 4;
            //        break;

            //    case -3:
            //        Id = 6;
            //        break;

            //    case -4:
            //        Id = 10;
            //        break;

            //    case -5:
            //        Id = 7;
            //        break;

            //    case -6:
            //        Id = 99;
            //        break;

            //    case -7:
            //        Id = 1;
            //        break;

            //    case -8:
            //        Id = 4;
            //        break;

            //    case -9:
            //        Id = 6;
            //        break;

            //    case -10:
            //        Id = 10;
            //        break;

            //    case -11:
            //        Id = 7;
            //        break;

            //    case -12:
            //        Id = 99;
            //        break;

            //    case -13:
            //        Id = 1;
            //        break;

            //    case -14:
            //        Id = 4;
            //        break;

            //    case -15:
            //        Id = 6;
            //        break;

            //    case -16:
            //        Id = 10;
            //        break;

            //    case -17:
            //        Id = 7;
            //        break;

            //    case -18:
            //        Id = 99;
            //        break;

            //    case -19:
            //        Id = 198;
            //        break;

            //    case -20:
            //        Id = 199;
            //        break;

            //    case -21:
            //        Id = 200;
            //        break;

            //    case -22:
            //        Id = 201;
            //        break;

            //    case -23:
            //        Id = 202;
            //        break;

            //    case -24:
            //        Id = 203;
            //        break;

            //    default:
            //        Id = id;
            //        break;
            //}
            Id = id;
            OnPropertyChanged("Name");
        }

        public void SetFromName(string name)
        {
            Name = name;
            //switch (ItemDictionary.FirstOrDefault(p => p.Value.Name == Name).Key)
            //{
            //    case -1:
            //        Id = 1;
            //        break;

            //    case -2:
            //        Id = 4;
            //        break;

            //    case -3:
            //        Id = 6;
            //        break;

            //    case -4:
            //        Id = 10;
            //        break;

            //    case -5:
            //        Id = 7;
            //        break;

            //    case -6:
            //        Id = 99;
            //        break;

            //    case -7:
            //        Id = 1;
            //        break;

            //    case -8:
            //        Id = 4;
            //        break;

            //    case -9:
            //        Id = 6;
            //        break;

            //    case -10:
            //        Id = 10;
            //        break;

            //    case -11:
            //        Id = 7;
            //        break;

            //    case -12:
            //        Id = 99;
            //        break;

            //    case -13:
            //        Id = 1;
            //        break;

            //    case -14:
            //        Id = 4;
            //        break;

            //    case -15:
            //        Id = 6;
            //        break;

            //    case -16:
            //        Id = 10;
            //        break;

            //    case -17:
            //        Id = 7;
            //        break;

            //    case -18:
            //        Id = 99;
            //        break;

            //    case -19:
            //        Id = 198;
            //        break;

            //    case -20:
            //        Id = 199;
            //        break;

            //    case -21:
            //        Id = 200;
            //        break;

            //    case -22:
            //        Id = 201;
            //        break;

            //    case -23:
            //        Id = 202;
            //        break;

            //    case -24:
            //        Id = 203;
            //        break;

            //    default:
            //        Id = ItemDictionary.FirstOrDefault(p => p.Value.Name == Name).Key;
            //        break;
            //}
            Id = ItemDictionary.FirstOrDefault(p => p.Value.Name == Name).Key;

            OnPropertyChanged("Name");
        }
    
        private void ItemImage()
        {
            try
            {
                string uri = string.Format("/TerrariViewer;component/Images/Items/Item_{0}.png", Id);                
                image = new BitmapImage(new Uri(uri, UriKind.RelativeOrAbsolute));
            }
            catch
            {
                image = null;
            }

            OnPropertyChanged("Image");
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", StackSize, Name);
        }

        #region PropertyChanged

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
