using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Tictactoe.Logic;

namespace Tictactoe
{
    class Display : FrameworkElement
    {
        private Size size;
        IGameModel model;
        public void Resize(Size size)
        {
            this.size = size;
            this.InvalidateVisual();
        }
        public void SetupModel(IGameModel model)
        {
            this.model = model;
        }
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if (model!=null)
            {
                int rectWidth = (int)size.Width / model.GameMatrix.GetLength(0);
                int rectHeight = (int)size.Height / model.GameMatrix.GetLength(1);


                for (int i = 0; i < model.GameMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < model.GameMatrix.GetLength(1); j++)
                    {
                        drawingContext.DrawRectangle(
                                new SolidColorBrush(Color.FromRgb((byte)220, (byte)220, (byte)220)),
                                new Pen(Brushes.Black, 2),
                                new Rect(j * rectWidth, i * rectHeight, rectWidth, rectHeight)
                                );

                        ImageBrush brush = new ImageBrush();
                        switch (model.GameMatrix[i, j])
                        {

                            case TictactoeLogic.GameItem.x:
                                brush = new ImageBrush
                                    (new BitmapImage(new Uri("x.png", UriKind.RelativeOrAbsolute)));
                                break;

                            case TictactoeLogic.GameItem.o:
                                brush = new ImageBrush
                                    (new BitmapImage(new Uri("o.png", UriKind.RelativeOrAbsolute)));
                                break;

                            default:
                                break;

                        }

                        drawingContext.DrawRectangle(brush
                                        , new Pen(Brushes.Black, 2),
                                        new Rect(j * rectWidth, i * rectHeight, rectWidth, rectHeight)
                                        );

                    }
                }
            }
            
        }      
    }
    
}
