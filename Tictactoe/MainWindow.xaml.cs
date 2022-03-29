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
        TictactoeLogic logic;
        public MainWindow()
        {
            InitializeComponent();
            logic = new TictactoeLogic();
            logic.GameOver += Logic_GameOver;
            display.SetupModel(logic);
            controller = new GameController(logic);
        }

        private void Logic_GameOver(object sender, EventArgs e)
        {
            display.InvalidateVisual();
            MessageBox.Show(logic.Winner+" won!");
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
                int cellnumbery = y / (int)(display.ActualHeight / logic.GameMatrix.GetLength(0));
                int cellnumberx = x / (int)(display.ActualWidth /  logic.GameMatrix.GetLength(1));
                               
                int[] coord = { cellnumbery, cellnumberx };
                controller.MouseClicked(coord);
                display.InvalidateVisual();
                
            }

        }

    }
}
