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
using Tictactoe.Controller;
using Tictactoe.Logic;

namespace Tictactoe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameController controller;
        public MainWindow()
        {
            InitializeComponent();
            TictactoeLogic logic = new TictactoeLogic();
            display.SetupModel(logic);
            controller = new GameController(logic);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {        
            
                display.Resize(new Size()
                {
                    Width = grid.ActualWidth,
                    Height = grid.ActualHeight
                });

        }
        


        private void display_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source.ToString() == "Tictactoe.Display")
            {
                
                int x = (int)e.GetPosition(grid).X;
                int y = (int)e.GetPosition(grid).Y;
                int cellnumbery = y / (int)(display.ActualHeight / 3);
                int cellnumberx = x / (int)(display.ActualWidth / 3);
               
                
                int[] coord = { cellnumbery, cellnumberx };
                //controller.MouseClicked(coord);
                //display.InvalidateVisual();
                //int centeri = (int)((cellnumbery) * display.ActualHeight / 3 - display.ActualHeight / 3 / 2);
                //int centerj= (int)((cellnumberx) * display.ActualWidth / 3 + display.ActualWidth / 3 / 2);

                //Line myLine = new Line();
                //myLine.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
                //myLine.X1 = centerj;
                //myLine.X2 = 0;
                //myLine.Y1 = centeri;
                //myLine.Y2 = 0;
                //myLine.HorizontalAlignment = HorizontalAlignment.Left;
                //myLine.VerticalAlignment = VerticalAlignment.Center;
                //myLine.StrokeThickness = 2;
                //grid.Children.Add(myLine);



            }

        }

    }
}
