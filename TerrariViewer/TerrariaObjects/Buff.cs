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
    public class Buff : INotifyPropertyChanged
    {
        private static Dictionary<int, string> buffDictionary = new Dictionary<int, string>();
        public static Dictionary<int, string> BuffDictionary
        {
            get { return buffDictionary; }
        }

        static Buff()
        {
            string uri = "/TerrariViewer;component/TerrariaObjects/Data/Buffs.txt";
            BuffDictionary[0] = "";

            using (StreamReader reader = new StreamReader(Application.GetResourceStream(new Uri(uri, UriKind.RelativeOrAbsolute)).Stream))
            {
                while (!reader.EndOfStream)
                {
                    try
                    {
                        string line = reader.ReadLine();
                        string[] parts = line.Split('\t');
                        BuffDictionary[int.Parse(parts[0])] = parts[1];
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
        }

        private int id = 0;
        public int Id 
        {
            get { return id; }
            set
            {
                id = value;
                BuffImage();
            }
        }

        private string name = "No Buff";
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private int gameDuration = 0;
        public int GameDuration
        {
            get { return gameDuration / 60; }
            set
            {
                try
                {
                    gameDuration = Math.Abs(value * 60);
                }
                catch
                {
                    gameDuration = int.MaxValue;
                }
                OnPropertyChanged("GameDuration");
            }
        }

        private BitmapImage image;
        public BitmapImage Image 
        { 
            get { return image; } 
        }

        public Buff()
        {
            BuffImage();
        }

        public void SetFromID(int id, int duration)
        {
            this.Id = id;
            this.Name = BuffDictionary[id];
            this.GameDuration = duration;            
        }

        private void BuffImage()
        {
            try
            {
                string uri = string.Format("/TerrariViewer;component/Images/Buffs/Buff_{0}.png", Id);
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
