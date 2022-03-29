
using static Tictactoe.Logic.TictactoeLogic;

namespace Tictactoe.Logic
{
    public interface IGameModel
    {
        GameItem[,] GameMatrix { get; set; }
    }
}