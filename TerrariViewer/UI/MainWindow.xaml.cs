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
        public static Player player;
        private string playerPath;
        // private string lastFileName = null;

        private const string dialogFilter = "Player Files (*.plr, *.plr.bak)|*.plr;*.plr.bak";

        public MainWindow()
        {
            InitializeComponent();

            player = new Player();
            this.DataContext = player;
            playerPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                + @"\My Games\Terraria\Players\";
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

        public static RoutedCommand FileSaveCommand = new RoutedCommand("FileSaveCommand", typeof(MainWindow),
            new InputGestureCollection()
            {
                new KeyGesture(Key.S, ModifierKeys.Control)
            });

        public static RoutedCommand FileSaveAsCommand = new RoutedCommand("FileSaveAsCommand", typeof(MainWindow),
            new InputGestureCollection()
            {
            });

        #endregion

        #region Command Functions

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
                Console.WriteLine(openFileDialog.FileName);
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

        private void FileSaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = dialogFilter;

            if (e.Command == FileSaveCommand && playerPath != Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\My Games\Terraria\Players\")
            {
                player.Save(playerPath);
            }
            else if (saveFileDialog.ShowDialog() == true)
            {
                player.Save(saveFileDialog.FileName);
                playerPath = saveFileDialog.FileName;
            }
            else
            {
                return;
            }
            string file = System.IO.Path.GetFileName(playerPath);
            MessageBox.Show("Saved " + file + "!", "File Saved");
        }

        private void FileSaveAsCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string path;
            string playerDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\My Games\Terraria\Players\";
            bool fileExists = Directory.Exists(playerDirectory);

            if (fileExists)
                path = playerDirectory;
            else
                path = System.Windows.Forms.Application.StartupPath;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = path;
            saveFileDialog.Filter = dialogFilter;

            if (saveFileDialog.ShowDialog() == true)
            {
                player.Save(saveFileDialog.FileName);
                playerPath = saveFileDialog.FileName;
                saveFileDialog.InitialDirectory = System.IO.Path.GetFullPath(playerPath);

                string file = System.IO.Path.GetFileName(playerPath);
                MessageBox.Show("Saved " + file + "!", "File Saved");
            }
        }

        private void Delete_Clicked(object sender, RoutedEventArgs e)
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

        private void Launch_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                string str = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86)
                    + @"\Steam\Steam.exe";
                if (!File.Exists(str))
                {
                    str = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)
                     + @"\Steam\Steam.exe";
                }
                string arg = "-applaunch 105600";
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

        private void Exit_Clicked(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Twitter_Clicked(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://twitter.com/#!/tjchap2840");
        }

        private void Donate_Clicked(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=74TENM4NF4DUN&lc=US&item_name=TerrariViewer&currency_code=USD&bn=PP%2dDonationsBF%3abtn_donate_LG%2egif%3aNonHosted");
        }

        #endregion

        private void Window_Deactivaged(object sender, EventArgs e)
        {
            ItemControl.CloseAllPopups();
            BuffPreview.CloseAllPopups();
        }

        private void About_Clicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("TerrariViewer\n" +
                            "Version 7.1\n" +
                            "Created by TJChap2840", "About TerrariViewer");
        }
    }
}
