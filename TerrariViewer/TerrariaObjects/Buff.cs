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
        private static Dictionary<int, Buff> buffDictionary = new Dictionary<int, Buff>();
        public static Dictionary<int, Buff> BuffDictionary
        {
            get { return buffDictionary; }
        }

        static Buff()
        {
            Buff buff;

            string uri = "/TerrariViewer;component/TerrariaObjects/Data/Buffs.txt";

            using (StreamReader reader = new StreamReader(Application.GetResourceStream(new Uri(uri, UriKind.RelativeOrAbsolute)).Stream))
            {
                while (!reader.EndOfStream)
                {
                    try
                    {
                        buff = new Buff();
                        string line = reader.ReadLine();
                        string[] parts = line.Split('\t');

                        buff.Id = int.Parse(parts[0]);
                        buff.Name = parts[1];
                        buff.maxDuration = int.Parse(parts[3]);
                        buff.BuffImage();
                        BuffDictionary[int.Parse(parts[0])] = buff;
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
        }


        #region Properties

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
                BuffText = this.ToString();
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
                BuffText = this.ToString();
                OnPropertyChanged("GameDuration");
            }
        }

        private BitmapImage image;
        public BitmapImage Image 
        { 
            get { return image; } 
        }

        private string buffText;
        public string BuffText 
        {
            get { return buffText; }
            set
            {
                buffText = value;
                OnPropertyChanged("BuffText");
            }
        }

        private int maxDuration;
        public int MaxDuration 
        {
            get { return maxDuration; }
            set
            {
                maxDuration = value;
            }
        }

        #endregion

        public Buff()
        {
            BuffImage();
            Id = 0;
            GameDuration = 0;
            Name = "No Buff";
            BuffText = this.ToString();
        }

        public void SetFromID(int id, int duration)
        {
            this.Id = id;
            this.Name = BuffDictionary[id].Name;
            this.GameDuration = duration;
            OnPropertyChanged("Name");
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

        public override string ToString()
        {
            return string.Format("{0} [{1} Seconds]", Name, GameDuration);
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
