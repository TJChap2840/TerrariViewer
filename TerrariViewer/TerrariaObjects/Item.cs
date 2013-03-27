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
        #region ItemDictionary

        private static Dictionary<int, string> itemDictionary = new Dictionary<int, string>();
        public static Dictionary<int, string> ItemDictionary
        {
            get { return itemDictionary; }
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
        }

        #endregion

        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
            }
        }

        private string name;
        public string Name 
        {
            get { return name; }
            set
            {
                name = value;
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
                OnPropertyChanged("StackSize");
            }
        }

        private int prefix;
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
            id = 1;
            Name = "Pick Axe";
            StackSize = 12;
            Prefix = 0;
            ItemImage();
        }

        public void SetFromID(int id)
        {
            Id = id;
            Name = itemDictionary[id];

            OnPropertyChanged("Name");
            ItemImage();

        }

        private void ItemImage()
        {
            try
            {
                string uri;                
                uri = string.Format("/TerrariViewer;component/Images/Items/Item_{0}.png", id);                
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
