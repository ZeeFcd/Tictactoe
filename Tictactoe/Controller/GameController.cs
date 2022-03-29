using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tictactoe.Logic;
using static Tictactoe.Logic.TictactoeLogic;

namespace Tictactoe.Controller
{
    internal class GameController
    {
        IGameControl control;

        public GameController(IGameControl control)
        {
            this.control = control;
        }

        public void MouseClicked(int[] field)
        {
            control.Step(field);
            
        }
    }
}
