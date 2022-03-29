
using static Tictactoe.Logic.TictactoeLogic;

namespace Tictactoe.Logic
{
    internal interface IGameControl
    {
        void Step(int[] field);
        
    }
}