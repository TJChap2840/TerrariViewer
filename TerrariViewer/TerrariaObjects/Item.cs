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

        private static Dictionary<int, string> itemDictionary = new Dictionary<int, string>();
        public static Dictionary<int, string> ItemDictionary
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
            string uri = "/TerrariViewer;component/TerrariaObjects/Data/Items.txt";
            itemDictionary[0] = "";

            using (StreamReader reader = new StreamReader(Application.GetResourceStream(new Uri(uri, UriKind.RelativeOrAbsolute)).Stream))
            {
                while (!reader.EndOfStream)
                {
                    try
                    {
                        string line = reader.ReadLine();

                        string[] parts = line.Split('\t');
                        itemDictionary[int.Parse(parts[0])] = parts[1];
                    }
                    catch
                    {
                        continue;
                    }
                }
            }

            uri = "/TerrariViewer;component/TerrariaObjects/Data/ItemPrefixes.txt";

            using (StreamReader reader = new StreamReader(Application.GetResourceStream(new Uri(uri, UriKind.RelativeOrAbsolute)).Stream))
            {
                while (!reader.EndOfStream)
                {
                    try
                    {
                        string line = reader.ReadLine();

                        string[] parts = line.Split('\t');
                        prefixDictionary[int.Parse(parts[0])] = parts[1];
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
        }

        #endregion

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
                OnPropertyChanged("Name");
            }
        }
        
        private int stackSize = 0;
        public int StackSize
        {
            get { return stackSize; }
            set
            {
                stackSize = value;
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

        public Item()
        {
            ItemImage();
        }

        public void SetFromID(int id)
        {
            Name = itemDictionary[id];
            switch (id) 
            {
                case -1:
                    Id = 1;
                    break;

                case -2:
                    Id = 4;
                    break;

                case -3:
                    Id = 6;
                    break;

                case -4:
                    Id = 10;
                    break;

                case -5:
                    Id = 7;
                    break;

                case -6:
                    Id = 99;
                    break;

                case -7:
                    Id = 1;
                    break;

                case -8:
                    Id = 4;
                    break;

                case -9:
                    Id = 6;
                    break;

                case -10:
                    Id = 10;
                    break;

                case -11:
                    Id = 7;
                    break;

                case -12:
                    Id = 99;
                    break;

                case -13:
                    Id = 1;
                    break;

                case -14:
                    Id = 4;
                    break;

                case -15:
                    Id = 6;
                    break;

                case -16:
                    Id = 10;
                    break;

                case -17:
                    Id = 7;
                    break;

                case -18:
                    Id = 99;
                    break;

                case -19:
                    Id = 198;
                    break;

                case -20:
                    Id = 199;
                    break;

                case -21:
                    Id = 200;
                    break;

                case -22:
                    Id = 201;
                    break;

                case -23:
                    Id = 202;
                    break;

                case -24:
                    Id =203;
                    break;

                default:
                    Id = id;
                    break;
            }

            OnPropertyChanged("Name");
        }

        public void SetFromName(string name)
        {
            Name = name;
            Id = itemDictionary.FirstOrDefault(p => p.Value == Name).Key;

            OnPropertyChanged("Name");
        }
    
        private void ItemImage()
        {
            try
            {
                string uri;                
                uri = string.Format("/TerrariViewer;component/Images/Items/Item_{0}.png", Id);                
                image = new BitmapImage(new Uri(uri, UriKind.RelativeOrAbsolute));
            }
            catch
            {
                image = null;
            }

            OnPropertyChanged("Image");
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
