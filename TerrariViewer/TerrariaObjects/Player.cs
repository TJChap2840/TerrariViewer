using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.IO;
using System.Security.Cryptography;
using System.ComponentModel;
using System.Reflection;

namespace TerrariViewer.TerrariaObjects
{
    public class Player : INotifyPropertyChanged
    {
        private const int CurrentRelease = 39;

        #region Properties

        private string name = "Name";
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private byte difficulty = 0;
        public byte Difficulty
        {
            get { return difficulty; }
            set
            {
                difficulty = value;
                OnPropertyChanged("Difficulty");
            }
        }

        private bool gender = true;
        public bool Gender
        {
            get { return gender; }
            set
            {
                gender = value;
                OnPropertyChanged("Gender");
            }
        }

        public const int HairMax = 35;

        private int hair = 0;
        public int Hair
        {
            get { return hair; }
            set
            {
                hair = value;
                if (hair < 0)
                {
                    hair = HairMax;
                }
                else if (hair > HairMax)
                {
                    hair = 0;
                }
                OnPropertyChanged("Hair");
            }
        }

        private int currentHealth = 200;
        public int CurrentHealth
        {
            get { return currentHealth; }
            set
            {
                currentHealth = value;
                OnPropertyChanged("CurrentHealth");
            }
        }

        private int maximumHealth = 200;
        public int MaximumHealth
        {
            get { return maximumHealth; }
            set
            {
                maximumHealth = value;
                if (maximumHealth < 0)
                {
                    maximumHealth = 0;
                }
                OnPropertyChanged("MaximumHealth");

                if (currentHealth > maximumHealth)
                {
                    CurrentHealth = maximumHealth;
                }
            }
        }

        private int currentMana = 0;
        public int CurrentMana
        {
            get { return currentMana; }
            set
            {
                currentMana = value;
                OnPropertyChanged("CurrentMana");
            }
        }

        private int maximumMana = 0;
        public int MaximumMana
        {
            get { return maximumMana; }
            set
            {
                maximumMana = value;
                if (maximumMana < 0)
                {
                    maximumMana = 0;
                }
                OnPropertyChanged("MaximumMana");
                if (currentMana > maximumMana)
                {
                    CurrentMana = maximumMana;
                }
            }
        }

        private Color hairColor = Color.FromRgb(215, 90, 55);
        public Color HairColor
        {
            get { return hairColor; }
            set
            {
                hairColor = value;
                OnPropertyChanged("HairColor");
            }
        }

        private Color skinColor = Color.FromRgb(255, 125, 90);
        public Color SkinColor
        {
            get { return skinColor; }
            set
            {
                skinColor = value;
                OnPropertyChanged("SkinColor");
            }
        }

        private Color eyeColor = Color.FromRgb(105, 90, 75);
        public Color EyeColor
        {
            get { return eyeColor; }
            set
            {
                eyeColor = value;
                OnPropertyChanged("EyeColor");
            }
        }

        private Color shirtColor = Color.FromRgb(175, 165, 140);
        public Color ShirtColor
        {
            get { return shirtColor; }
            set
            {
                shirtColor = value;
                OnPropertyChanged("ShirtColor");
            }
        }

        private Color underShirtColor = Color.FromRgb(160, 180, 215);
        public Color UnderShirtColor
        {
            get { return underShirtColor; }
            set
            {
                underShirtColor = value;
                OnPropertyChanged("UnderShirtColor");
            }
        }

        private Color pantsColor = Color.FromRgb(255, 230, 175);
        public Color PantsColor
        {
            get { return pantsColor; }
            set
            {
                pantsColor = value;
                OnPropertyChanged("PantsColor");
            }
        }

        private Color shoeColor = Color.FromRgb(160, 105, 60);
        public Color ShoeColor
        {
            get { return shoeColor; }
            set
            {
                shoeColor = value;
                OnPropertyChanged("ShoeColor");
            }
        }

        #endregion

        public Player()
        {
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
