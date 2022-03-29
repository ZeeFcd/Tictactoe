using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tictactoe.Logic

{
    public class TictactoeLogic : IGameModel, IGameControl
    {
        public enum GameItem
        {
            x,o,empty
        }

        static Random r = new Random();
        public string Winner { get; set; }

        public event EventHandler GameOver;
        public event EventHandler Draw;
        public GameItem[,] GameMatrix { get; set; }
        public int[] LastStep { get; set; }
        public GameItem LastItem { get; set; }
        

        public TictactoeLogic()
        {
            GameMatrix = new GameItem[3, 3];
            Mapreset();

        }

        public void Step(int[] field)
        {
            if (GameMatrix[field[0], field[1]] == GameItem.empty)
            {
                GameMatrix[field[0], field[1]] = GameItem.x;
                LastStep = field;
                LastItem = GameItem.x;
                if (IsFinished())
                {
                    Winner = "You";
                    GameOver?.Invoke(this, null);
                    Mapreset();
                }
                else
                {
                    if (IsEmptyMap())
                    {
                        Draw?.Invoke(this, null);
                        Mapreset();
                    }
                    else
                    {
                        MachineStep();
                        if (IsFinished())
                        {
                            Winner = "The game";
                            GameOver?.Invoke(this, null);
                            Mapreset();
                        }
                    }
                    
                }

            }

        }

        private bool IsFinished()
        {
            
            int i = LastStep[0];
            int j = LastStep[1];
            if (i==0)
            {
                if (j == 0)
                {
                    return SearchDown()||SearchRight() ||SearchRightDown();
                }
                else if (j == 1)
                {
                    return SearchDown() ||(SearchLeft()&&SearchRight());
                }
                else
                {
                    return SearchDown() || SearchLeft() || SearchLeftDown();
                }
            }
            else if (i==1)
            {
                if (j == 0)
                {
                    return (SearchUp()&&SearchDown()) ||SearchRight();
                }
                else if (j == 1)
                {
                    return (SearchUp() && SearchDown()) || (SearchLeft() && SearchRight())||(SearchLeftUp()&&SearchRightDown())||(SearchLeftDown()&&SearchRightUp());
                }
                else
                {
                    return (SearchUp() && SearchDown())|| SearchLeft();
                }
            }
            else
            {
                if (j == 0)
                {
                    return SearchUp()||SearchRight()||SearchRightUp() ;
                }
                else if (j == 1)
                {
                    return SearchUp() || (SearchLeft() && SearchRight());
                }
                else
                {
                    return SearchUp()||SearchLeft()||SearchLeftUp() ;
                }

            }

        }

        private bool SearchUp() 
        {
            int n = LastStep[0] ;
            
            while (n>-1 && GameMatrix[n, LastStep[1]] == LastItem)
            {                  
                    n--;   
            }

            return n <0;
        }
        private bool SearchDown()
        {
            int n = LastStep[0];
            while (n < GameMatrix.GetLength(0)&& GameMatrix[n, LastStep[1]] == LastItem)
            {
                n++;
            }

            return n == GameMatrix.GetLength(0);
        }
        private bool SearchLeft()
        {
            int n = LastStep[1];
            ;
            while (n > -1 && GameMatrix[LastStep[0],n] == LastItem)
            {
                n--;
            }

            return n<0;
        }
        private bool SearchRight()
        {
            int n = LastStep[1];
            while (n < GameMatrix.GetLength(1)&& GameMatrix[LastStep[0], n] == LastItem) 
            {
                n++;
            }

            return n == GameMatrix.GetLength(1);
        }
        private bool SearchLeftUp()
        {
            int n = LastStep[0];
            int k = LastStep[1];
            while (n > -1 && k>-1 && GameMatrix[n, k] == LastItem)
            {
                n--;
                k--;
            }

            return n < 0 || k < 0;
        }
        private bool SearchRightUp() 
        {
            int n = LastStep[0];
            int k = LastStep[1];
            while (n > -1 && k< GameMatrix.GetLength(1) && GameMatrix[n, k] == LastItem)
            {
                n--;
                k++;
            }

            return n <0 || k == GameMatrix.GetLength(1);
        }
        private bool SearchRightDown()
        {
            int n = LastStep[0];
            int k = LastStep[1];
            while (n < GameMatrix.GetLength(0) && k < GameMatrix.GetLength(1) && GameMatrix[n, k] == LastItem)
            {
                n++;
                k++;
            }

            return n == GameMatrix.GetLength(0) || k == GameMatrix.GetLength(1);
        }
        private bool SearchLeftDown()
        {
            int n = LastStep[0];
            int k = LastStep[1];
            while (n < GameMatrix.GetLength(0) && k > -1 && GameMatrix[n, k] == LastItem)
            {
                n++;
                k--;
            }

            return n == GameMatrix.GetLength(0) || k <0;
        }

        private void Mapreset() 
        {
            for (int i = 0; i < GameMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < GameMatrix.GetLength(1); j++)
                {
                    GameMatrix[i, j] = GameItem.empty;
                }
            }
        }

        private bool IsEmptyMap() 
        {
            int n = 0;
            int k = 0;

            while (n<GameMatrix.GetLength(0) && GameMatrix[n,k]!=GameItem.empty)
            {
                
                while (k < GameMatrix.GetLength(1) && GameMatrix[n, k] != GameItem.empty)
                {
                    k++;
                }
                if (k == GameMatrix.GetLength(1))
                {
                    n++;
                    k = 0;
                }

            }

            return n == GameMatrix.GetLength(0) ;
        }

        private List<int[]> EmptyFields() 
        {
            List<int[]> emptylist = new List<int[]>();
            
            for (int i = 0; i < GameMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < GameMatrix.GetLength(1); j++)
                {
                    if (GameMatrix[i,j]==GameItem.empty)
                    {
                        int[] temp = new int[2];
                        temp[0] = i;
                        temp[1] = j;
                        emptylist.Add(temp);
                    }
                }
            }

            return emptylist;
        }

        private void MachineStep() 
        {
            List<int[]> empty = EmptyFields();
            if (empty.Count>0)
            {
                int[] field = empty[r.Next(0, empty.Count)];
                GameMatrix[field[0], field[1]] = GameItem.o;
                LastStep = field;
                LastItem = GameItem.o;
            }
              
        }
       
    }
}
