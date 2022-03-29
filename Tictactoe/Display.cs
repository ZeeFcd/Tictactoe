using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Tictactoe
{
    class Display : FrameworkElement
    {
        private Size size;
        
        public void Resize(Size size)
        {
            this.size = size;
            this.InvalidateVisual();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            int rectWidth = (int)size.Width / 3;
            int rectHeight = (int)size.Height / 3;
           

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    drawingContext.DrawRectangle(
                        new SolidColorBrush(Color.FromRgb((byte)220, (byte)220, (byte)220)),
                        new Pen(Brushes.Black, 2),
                        new Rect(j * rectWidth, i * rectHeight, rectWidth, rectHeight)
                        );
                }
            }

        }

       

    }
    
}
