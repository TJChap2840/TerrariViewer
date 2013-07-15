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

namespace TerrariViewer.UI
{
    /// <summary>
    /// Interaction logic for EquipmentControl.xaml
    /// </summary>
    public partial class EquipmentControl : UserControl
    {
        public EquipmentControl()
        {
            InitializeComponent();

            for (int i = 0; i < vanity_Grid.RowDefinitions.Count; i++)
            {
                AccessoryControl accessoryControl = new AccessoryControl();
                accessoryControl.SetBinding(AccessoryControl.DataContextProperty, string.Format("Vanity[{0}]", i));

                Grid.SetRow(accessoryControl, i);
                vanity_Grid.Children.Add(accessoryControl);
            }

            for (int i = 0; i < armor_Grid.RowDefinitions.Count; i++)
            {
                AccessoryControl accessoryControl = new AccessoryControl();
                accessoryControl.SetBinding(AccessoryControl.DataContextProperty, string.Format("Armor[{0}]", i));

                Grid.SetRow(accessoryControl, i);
                armor_Grid.Children.Add(accessoryControl);
            }

            for (int i = 0; i < accessory_Grid.ColumnDefinitions.Count; i++)
            {
                AccessoryControl accessoryControl = new AccessoryControl();
                accessoryControl.SetBinding(AccessoryControl.DataContextProperty, string.Format("Accessories[{0}]", i));

                Grid.SetColumn(accessoryControl, i);
                accessory_Grid.Children.Add(accessoryControl);
            }
        }

        private void Preivew_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            //System.Drawing.Bitmap helm;
            //System.Drawing.Bitmap chest;
            //System.Drawing.Bitmap legs;

            //string helmType = "";
            //string chestType = "";
            //string legType = "";

            //System.Drawing.Bitmap hair = DrawCharacter(new System.Drawing.Bitmap(Properties.Resources.Hair_1), System.Drawing.Color.Black, 130);

            //System.Drawing.Graphics g = e.Graphics;
            //g.DrawImage(hair, 25, 28);            
        }

        private System.Drawing.Color BrushToColor(Brush br)
        {
            SolidColorBrush brush = new SolidColorBrush();
            brush = (SolidColorBrush)br;
            return System.Drawing.Color.FromArgb(brush.Color.R, brush.Color.G, brush.Color.B);
        }

        private System.Drawing.Bitmap DrawCharacter(System.Drawing.Bitmap bmp, System.Drawing.Color color, int size)
        {
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    System.Drawing.Color pixel = bmp.GetPixel(x, y);

                    if (pixel != System.Drawing.Color.FromArgb(0, 0, 0, 0))
                    {
                        if (pixel == System.Drawing.Color.FromArgb(255, 249, 249, 249))
                            bmp.SetPixel(x, y, System.Drawing.Color.White);
                        else
                        {
                            int red = (pixel.R + color.R) / 2;
                            int green = (pixel.G + color.G) / 2;
                            int blue = (pixel.B + color.B) / 2;
                            bmp.SetPixel(x, y, System.Drawing.Color.FromArgb(red,
                                                                             green,
                                                                             blue));
                        }
                    }
                }
            }

            System.Drawing.Bitmap newImage = new System.Drawing.Bitmap(size, size);
            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(newImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.DrawImage(bmp, new System.Drawing.Rectangle(0, 0, size, size));
            }

            return newImage;
        }

        private System.Drawing.Bitmap DrawArmor(System.Drawing.Image bmp, int w, int h)
        {
            System.Drawing.Bitmap newImage = new System.Drawing.Bitmap(w, h);
            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(newImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.DrawImage(bmp, new System.Drawing.Rectangle(25, 25, w, h));
            }

            return newImage;
        }
    }
}
