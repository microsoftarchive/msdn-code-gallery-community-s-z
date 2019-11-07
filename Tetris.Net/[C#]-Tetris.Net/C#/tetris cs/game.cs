using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tetris_cs
{
    /// <summary>
    /// Extended DataGridView 
    /// DoubleBuffered. Restricts user selection of cells.
    /// </summary>
    /// <remarks></remarks>
    class game : DataGridView
    {
        //constants used with Keypresses
        private const int WM_LBUTTONDOWN = 0x201;
        private const int WM_LBUTTONDBLCLK = 0x203;
        private const int WM_KEYDOWN = 0x100;
        private const int VK_LEFT = 0x25;
        private const int VK_RIGHT = 0x27;
        private const int VK_DOWN = 0x28;
        private const int VK_UP = 0x26;

        //custom events
        public delegate void IncrementScoreEventHandler(int newPoints);
        public event IncrementScoreEventHandler IncrementScore;
        public delegate void ShapeChangedEventHandler(Point[] shapePoints, string shapeColor);
        public event ShapeChangedEventHandler ShapeChanged;
        
        private int rowCounter = 0;

        //set up timer handlers
        public game()
	    {
		    this.DoubleBuffered = true;
            tmr.Tick += tmr_Tick;
            flashtmr.Tick += flashtmr_Tick;
        }

        /// <summary>
        /// OnRowPrePaint
        /// Avoid DGV cell focussing
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRowPrePaint(DataGridViewRowPrePaintEventArgs e)
        {
            int p = (int)e.PaintParts;
            p -= (int)DataGridViewPaintParts.Focus;
            e.PaintParts = (DataGridViewPaintParts)p;
            base.OnRowPrePaint(e);
        }

        /// <summary>
        /// WndProc
        /// Avoid DGV focussing, and catch Keypresses
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == WM_LBUTTONDBLCLK || m.Msg == WM_LBUTTONDOWN)
            {
                return;
            }
            else if (m.Msg == WM_KEYDOWN)
            {
                //System.Diagnostics.Debugger.Break();
                if (m.WParam.ToInt32() == VK_LEFT)
                {
                    moveLeft();
                }
                else if (m.WParam.ToInt32() == VK_RIGHT)
                {
                    moveRight();
                }
                else if (m.WParam.ToInt32() == VK_DOWN)
                {
                    moveDown();
                }
                else if (m.WParam.ToInt32() == VK_UP)
                {
                    rotateShape();
                }
                return;
            }
            base.WndProc(ref m);
        }

        //timers used in game play
        private Timer tmr = new Timer { Interval = 500 };
        private Timer flashtmr = new Timer { Interval = 125 };

        //variables used with flashtmr tick event
        private int flashCounter = 1;
        private int flashRow;
        private bool missATick = false;

        //variables holding cell colors and shapes
        private string[][] gameGrid;
        private Shape currentShape;
        private List<Shape> listShapes = new List<Shape>();

        private Random r = new Random();
        private int moveCounter = 0;

        //clears the game board and score and initiates a new game
        public void newGame()
        {
            tmr.Stop();
            tmr.Interval = 500;
            listShapes.Clear();
            moveCounter = 0;

            gameGrid = new string[30][];
            for (int x = 1; x <= 30; x++)
            {
                string[] row = new string[20];
                gameGrid[x - 1] = (string[])row.Clone();
            }
            newShape();
            currentShape = listShapes[0];
            if (ShapeChanged != null) { 
                ShapeChanged(currentShape.CurrentPoints, currentShape.ShapeColor);
            }
            rowCounter = 0;
            tmr.Start();
            flashtmr.Start();
        }

        //creates a new falling shape
        private void newShape()
        {
            string[] sc = { "R", "G", "B", "Y" };
            Shape ns = new Shape(r.Next(0, 7), sc[r.Next(0, 4)]);
            listShapes.Add(ns);
            //currentShape = ns
            ns.TouchDown += currentShape_TouchDown;
            HasChanged(gameGrid, false, -1);
        }

        //responds to LEFT arrow button keydown
        public void moveLeft()
        {
            if (currentShape == null)
            {
                return;
            }
            gameGrid = currentShape.moveLeft(gameGrid);
            HasChanged(gameGrid, false, -1);
        }

        //responds to RIGHT arrow button keydown
        public void moveRight()
        {
            if (currentShape == null)
            {
                return;
            }
            gameGrid = currentShape.moveRight(gameGrid);
            HasChanged(gameGrid, false, -1);
        }

        //responds to DOWN arrow button keydown
        public void moveDown()
        {
            do
            {
                for (int x = 0; x < listShapes.Count; x++)
                {
                    if (x > listShapes.Count - 1)
                    {
                        goto ContinueLabel1;
                    }
                    gameGrid = listShapes[x].moveDown(gameGrid);
                    HasChanged(gameGrid, false, -1);
                }
                break;
                ContinueLabel1:;
            } while (true);
            moveCounter += 1;
        }

        //responds to UP arrow button keydown
        public void rotateShape()
        {
            if (currentShape == null)
            {
                return;
            }
            gameGrid = currentShape.rotateShape(gameGrid);
            HasChanged(gameGrid, false, -1);
            if (ShapeChanged != null)
            {
                ShapeChanged(currentShape.CurrentPoints, currentShape.ShapeColor);
            }
        }

        //on tick, all shapes move down one row
        private void tmr_Tick(object sender, EventArgs e)
        {
            if (missATick)
            {
                return;
            }
            if (moveCounter >= 27)
            {
                moveCounter = 0;

                newShape();
                if (listShapes.Count == 1)
                {
                    currentShape = listShapes[0];
                    if (ShapeChanged != null)
                    {
                        ShapeChanged(currentShape.CurrentPoints, currentShape.ShapeColor);
                    }
                }
            }
            moveDown();
        }

        //responds to shape touchdown
        private void currentShape_TouchDown(Shape sender)
        {
            if (sender.CurrentPoints.Any((p) => p.Y < 0))
            {
                tmr.Stop();
            }
            currentShape.TouchDown -= currentShape_TouchDown;
            listShapes.Remove(sender);
            if (listShapes.Count < 1)
            {
                currentShape = null;
                moveCounter = 27;
            }
            else
            {
                currentShape = listShapes[0];
                if (ShapeChanged != null)
                {
                    ShapeChanged(currentShape.CurrentPoints, currentShape.ShapeColor);
                }
            }
        }

        //clears full rows as they occur
        private void flashtmr_Tick(object sender, EventArgs e)
        {
            switch (flashCounter)
            {
                case 1:
                    flashRow = findFullRow();
                    if (flashRow > -1)
                    {
                        flashCounter = 2;
                        HasChanged(gameGrid, true, flashRow);
                    }
                    break;
                case 2:
                    flashCounter = 3;
                    HasChanged(gameGrid, false, -1);
                    break;
                case 3:
                    flashCounter = 4;
                    HasChanged(gameGrid, true, flashRow);
                    break;
                case 4:
                    List<string[]> newGrid = new List<string[]>(gameGrid);
                    if (listShapes.Count == 0) { return; }
                    foreach (Point p in listShapes.Last().CurrentPoints)
                    {
                        if (p.Y > -1)
                        {
                            newGrid[p.Y][p.X] = "";
                        }
                    }
                    string[] newRow = new string[20];
                    newGrid.RemoveAt(flashRow);
                    newGrid.Insert(0, newRow);
                    missATick = true;
                    gameGrid = newGrid.ToArray();
                    flashCounter = 1;
                    moveDown();
                    HasChanged(gameGrid, false, -1);
                    missATick = false;
                    rowCounter += 1;
                    if (rowCounter % 10 == 0)
                    {
                        tmr.Interval -= 40;
                        if (IncrementScore != null)
                            IncrementScore(((int)((1000 - tmr.Interval) * 0.35)));
                    }
                    else if (rowCounter % 5 == 0)
                    {
                        tmr.Interval -= 20;
                        if (IncrementScore != null)
                            IncrementScore(((int)((1000 - tmr.Interval) * 0.25)));
                    }
                    else
                    {
                        if (IncrementScore != null)
                            IncrementScore(((int)((1000 - tmr.Interval) * 0.05)));
                    }
                    break;
            }
        }

        //finds full rows in DGV
        private int findFullRow()
        {
            for (int x = 29; x >= 0; x--)
            {
                if (gameGrid[x].All((s) => !string.IsNullOrEmpty(s)))
                {
                    return x;
                }
            }
            return -1;
        }

        //renders the colors in the DGV
        private void HasChanged(string[][] grid, bool flash, int flashRow)
        {
            Dictionary<string, Color> colors = new Dictionary<string, Color>()
        {
            {"R", Color.Red},
            {"G", Color.Green},
            {"B", Color.Blue},
            {"Y", Color.Yellow}
        };
            Dictionary<string, Color> flashColors = new Dictionary<string, Color>()
        {
            {"R", Color.FromArgb(255, 165, 165)},
            {"G", Color.FromArgb(165, 255, 165)},
            {"B", Color.FromArgb(165, 165, 255)},
            {"Y", Color.FromArgb(255, 255, 230)}
        };
            for (int y = 0; y <= 29; y++)
            {
                for (int x = 0; x <= 19; x++)
                {
                    if (string.IsNullOrEmpty(grid[y][x]))
                    {
                        this.Rows[y].Cells[x].Style.BackColor = Color.Black;
                    }
                    else
                    {
                        if (!flash || (flash && !(flashRow == y)))
                        {
                            this.Rows[y].Cells[x].Style.BackColor = colors[grid[y][x]];
                        }
                        else
                        {
                            this.Rows[y].Cells[x].Style.BackColor = flashColors[grid[y][x]];
                        }
                    }
                }
            }
        }


    }
}
