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

        public GameItem[,] GameMatrix { get; set; }
        public int[] LastStep { get; set; }
        public GameItem LastItem { get; set; }
        LinkedList<int[,]> linkedListArray; //dfs

        public TictactoeLogic()
        {
            GameMatrix = new GameItem[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    GameMatrix[i, j]=GameItem.empty;
                }
            }

            
        }

        public void Step(int[] field)
        {
            GameMatrix[field[0], field[1]] = GameItem.x;
            LastStep = field;
            if (IsFinished())
            {

            }
            else
            {
                MachineStep();
                if (IsFinished())
                {

                }
            }
        }




        private bool IsFinished()
        {
            bool[,] used = new bool[GameMatrix.GetLength(0), GameMatrix.GetLength(1)];
            int i = LastStep[0];
            int j = LastStep[1];
            

        }

        private bool SearchUp(int[] coord, GameItem[,] gameMatrix, GameItem searched) 
        {
            int n = coord[0] ;
            
            while (n>-1)
            {
                
                if (n>-1&&gameMatrix[n,coord[1]]!= searched)
                {
                    n--;
                }
                
            }

            return n > -1;
        }
        private bool SearchDown(int[] coord, GameItem[,] gameMatrix, GameItem searched)
        {
            int n = coord[0];
            while (n < gameMatrix.GetLength(0)&& gameMatrix[n, coord[1]] != searched)
            {
                n++;
            }

            return n < gameMatrix.GetLength(0);
        }
        private bool SearchLeft(int[] coord, GameItem[,] gameMatrix, GameItem searched)
        {
            int n = coord[1];
            while (n > -1 && gameMatrix[coord[1],n] != searched)
            {
                n--;
            }

            return n > -1;
        }
        private bool SearchRight(int[] coord, GameItem[,] gameMatrix, GameItem searched)
        {
            int n = coord[1];
            while (n < gameMatrix.GetLength(1)&& gameMatrix[coord[1], n] != searched) 
            {
                n++;
            }

            return n < gameMatrix.GetLength(1);
        }
        private bool SearchLeftUp(int[] coord, GameItem[,] gameMatrix, GameItem searched)
        {
            int n = coord[0];
            int k = coord[1];
            while (n > -1 && k>-1 && gameMatrix[n, k] != searched)
            {
                n--;
                k--;
            }

            return n > -1 && k > -1;
        }
        private bool SearchRightUp(int[] coord, GameItem[,] gameMatrix, GameItem searched) 
        {
            int n = coord[0];
            int k = coord[1];
            while (n < gameMatrix.GetLength(1) && k>-1 && gameMatrix[n, k] != searched)
            {
                n++;
                k--;
            }

            return n < gameMatrix.GetLength(1) && k > -1;
        }
        private bool SearchRightDown(int[] coord, GameItem[,] gameMatrix, GameItem searched)
        {
            int n = coord[0];
            int k = coord[1];
            while (n < gameMatrix.GetLength(1) && k < gameMatrix.GetLength(1) && gameMatrix[n, k] != searched)
            {
                n++;
                k++;
            }

            return n < gameMatrix.GetLength(1) && k < gameMatrix.GetLength(1);
        }
        private bool SearchLeftDown(int[] coord, GameItem[,] gameMatrix, GameItem searched)
        {
            int n = coord[0];
            int k = coord[1];
            while (n > -1 && k < gameMatrix.GetLength(1) && gameMatrix[n, k] != searched)
            {
                n--;
                k++;
            }

            return n > -1 && k < gameMatrix.GetLength(1);
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
            int[] field= empty[r.Next(0, empty.Count)];
            GameMatrix[field[0], field[1]] = GameItem.o;
            LastStep = field;

        }
       

    }
}
