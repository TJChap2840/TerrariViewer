using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TerrariViewer.UI
{
    /// <summary>
    /// Interaction logic for UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {
        private string downloadLink;
        public UpdateWindow(string downloadLink)
        {
            this.downloadLink = downloadLink;
            InitializeComponent();
            SetTitle();
        }

        private void SetTitle()
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var assemblyAttributes = (System.Reflection.AssemblyTitleAttribute)
                                      System.Reflection.AssemblyTitleAttribute.GetCustomAttribute(assembly, typeof(System.Reflection.AssemblyTitleAttribute));
            this.Title = assemblyAttributes.Title + " v" + assembly.GetName().Version.ToString();
        }

        private void yesButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(downloadLink);
        }

        private void noButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
