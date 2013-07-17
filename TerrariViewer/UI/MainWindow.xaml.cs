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
                + @"My Games\Terraria\Players\";
        }

        #region Commands

        public static RoutedCommand FileOpenCommand = new RoutedCommand("FileOpenCommand", typeof(MainWindow),
            new InputGestureCollection()
            {
                new KeyGesture(Key.O, ModifierKeys.Control)
            });

        public static RoutedCommand FileNewCommand = new RoutedCommand("FileNewCommand", typeof(MainWindow),
            new InputGestureCollection()
            {
                new KeyGesture(Key.N, ModifierKeys.Control)
            });

        public static RoutedCommand FileDelCommand = new RoutedCommand("FileDelCommand", typeof(MainWindow),
            new InputGestureCollection()
            {
                new KeyGesture(Key.Delete)
            });

        public static RoutedCommand LaunchCommand = new RoutedCommand("LaunchCommand", typeof(MainWindow),
            new InputGestureCollection()
            {
                new KeyGesture(Key.L, ModifierKeys.Control)
            });

        #endregion

        private void FileOpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = dialogFilter;
            if (!string.IsNullOrEmpty(playerPath))
            {
                openFileDialog.InitialDirectory = playerPath;
            }

            //openFileDialog.FileName = "player1.plr";
            if (openFileDialog.ShowDialog() == true)
            {
                player.Load(openFileDialog.FileName);
                playerPath = openFileDialog.FileName;
            }
        }

        private void FileNewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            player = new Player();
            this.DataContext = player;
            playerPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                + @"My Games\Terraria\Players\";
        }

        private void FileDelCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (File.Exists(playerPath))
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete" +
                    "\n'" + System.IO.Path.GetFileName(playerPath) + "'?",
                    "Delete Player", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    File.Delete(playerPath);
                    MessageBox.Show("Player Deleted!", "Oh goodness...");

                    player = new Player();
                    this.DataContext = player;
                    playerPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                        + @"My Games\Terraria\Players\";
                }
            }
        }

        private void LaunchCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                //StringBuilder str = new StringBuilder("steam: \"");
                //str.AppendFormat("-applaunch {0}", 105600);
                //str.Append("\"");
                string str = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86)
                    + @"\Steam\Steam.exe";
                if (!File.Exists(str))
	            {
		           str = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)
                    + @"\Steam\Steam.exe"; 
	            }
                string arg = "-applaunch 105600";
                MessageBox.Show(str);
                if (File.Exists(str))
                {
                    System.Diagnostics.Process.Start(str, arg);    
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
