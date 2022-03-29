using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tictactoe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (grid.ActualWidth > 0 && grid.ActualHeight > 0)
            {
                display.Resize(new Size()
                {
                    Width = ActualWidth,
                    Height = ActualHeight
                });
            }
        }
        


        private void display_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source.ToString() == "Tictactoe.Display")
            {
                int cellnumberx = 0;
                int cellnumbery = 0;
                int x = (int)e.GetPosition(grid).X;
                int y = (int)e.GetPosition(grid).Y;

                cellnumberx = x / (int)(display.ActualWidth / 3);
                cellnumbery = y / (int)(display.ActualHeight / 3);

               

                int midx = ((int)(display.ActualHeight / 3) / 2) * (cellnumberx + 1);
                int midy = ((int)(display.ActualWidth / 3) / 2) * (cellnumbery + 1);

                Line myLine = new Line();
                myLine.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
                myLine.X1 = midx;
                myLine.X2 = 0;
                myLine.Y1 = midy;
                myLine.Y2 = 0;
                myLine.HorizontalAlignment = HorizontalAlignment.Left;
                myLine.VerticalAlignment = VerticalAlignment.Center;
                myLine.StrokeThickness = 2;
                grid.Children.Add(myLine);
            }



        }




    }
}
