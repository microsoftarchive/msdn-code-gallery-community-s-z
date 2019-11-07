using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sudoku_cs
{
    public class Game
    {

        public event ShowCluesEventHandler ShowClues;
        public delegate void ShowCluesEventHandler(int[][] grid);
        public event ShowSolutionEventHandler ShowSolution;
        public delegate void ShowSolutionEventHandler(int[][] grid);

        private List<int>[] HRow = new List<int>[9];
        private List<int>[] VRow = new List<int>[9];
        private List<int>[] ThreeSquare = new List<int>[9];

        private int[][] grid = new int[9][];

        private Random r;
        public void NewGame(Random rn)
        {
            this.r = rn;
            createNewGame();
        }

        private void initializeLists()
        {
            for (int x = 0; x <= 8; x++)
            {
                HRow[x] = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
                VRow[x] = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
                ThreeSquare[x] = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
                int[] row = new int[9];
                grid[x] = row;
            }
        }

        private void createNewGame()
        {
            while (true)
            {
            break1:
                initializeLists();
                for (int y = 0; y <= 8; y++)
                {
                    for (int x = 0; x <= 8; x++)
                    {
                        int si = (y / 3) * 3 + (x / 3);
                        int[] useful = HRow[y].Intersect(VRow[x]).Intersect(ThreeSquare[si]).ToArray();
                        if (useful.Count() == 0)
                        {
                            goto break1;
                        }
                        int randomNumber = useful[this.r.Next(0, useful.Count())];
                        HRow[y].Remove(randomNumber);
                        VRow[x].Remove(randomNumber);
                        ThreeSquare[si].Remove(randomNumber);
                        grid[y][x] = randomNumber;
                        if (y == 8 & x == 8)
                        {
                            goto break2;
                        }
                    }                    
                }                                
            };
            break2:

            if (ShowClues != null)
            {
                ShowClues(grid);
            }

        }


        public void showGridSolution()
        {
            if (ShowSolution != null)
            {
                ShowSolution(grid);
            }

        }

    }
}
