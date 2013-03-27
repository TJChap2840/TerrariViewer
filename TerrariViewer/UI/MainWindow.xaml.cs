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
using System.IO;
using Microsoft.Win32;

namespace TerrariViewer.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Player player;
        private string playerPath;
        //private string lastFileName = null;

        private const string dialogFilter = "Player Files (*.plr, *.plr.bak)|*.plr;*.plr.bak";

        public MainWindow()
        {
            InitializeComponent();

            player = new Player();
            this.DataContext = player;
            playerPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .TrimEnd('\\') + @"\My Games\Terraria\Players\";
        }

        //public void Load(string File)
        //{
        //    if (player.Load(File))
        //    {
        //        lastFileName = File;
        //    }
        //    else
        //    {
        //        MessageBox.Show(this, "An error occurred while trying to load.", "Loading error", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}

        #region Commands

        public static RoutedCommand FileOpenCommand = new RoutedCommand("FileOpenCommand", typeof(MainWindow),
            new InputGestureCollection()
            {
                new KeyGesture(Key.O, ModifierKeys.Control)
            });

        public static RoutedCommand FileSaveCommand = new RoutedCommand("FileSaveCommand", typeof(MainWindow),
            new InputGestureCollection()
            {
                new KeyGesture(Key.S, ModifierKeys.Control)
            });

        public static RoutedCommand FileSaveAsCommand = new RoutedCommand("FileSaveAsCommand", typeof(MainWindow));

        //public static RoutedCommand EditSpawnPositionsCommand = new RoutedCommand("EditSpawnPositionsCommand", typeof(MainWindow),
        //    new InputGestureCollection() 
        //    {
        //        new KeyGesture(Key.P, ModifierKeys.Control)
        //    });

        //public static RoutedCommand DirectoryOpenCommand = new RoutedCommand("DirectoryOpenCommand", typeof(MainWindow),
        //    new InputGestureCollection()
        //    {
        //        new KeyGesture(Key.D, ModifierKeys.Control)
        //    });

        #endregion

        private void FileOpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = dialogFilter;
            if (!string.IsNullOrEmpty(playerPath))
            {
                openFileDialog.InitialDirectory = playerPath;
            }

            openFileDialog.FileName = "player1.plr";
            if (openFileDialog.ShowDialog() == true)
            {
                player.Load(openFileDialog.FileName);
            }
        }

        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (tabControl.SelectedIndex)
            {
                case 0:
                    this.Width = 483;
                    this.Height = 456;
                    break;

                case 1:
                    this.Width = 483;
                    this.Height = 500;
                    break;
            }
        }
    }
}
