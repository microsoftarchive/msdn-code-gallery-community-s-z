using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tetris_cs
{
    class Shape
    {

        public delegate void TouchDownEventHandler(Shape sender);
        public event TouchDownEventHandler TouchDown;

        /// <summary>
        /// API function and Constants used to detect Shift keydown
        /// </summary>
        /// <param name="vkey"></param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImport("user32", EntryPoint = "GetAsyncKeyState", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private static extern short GetAsyncKeyState(int vkey);
        private const int VK_LSHIFT = 0xA0;
        private const int VK_RSHIFT = 0xA1;

        //0 - tShape, 1 - lShape, 2 - rlShape, 3 - zShape, 4 - rzShape, 5 - line, 6 - square
        private Point[][] shapeType =
        {
        new Point[]
        {
            new Point(10, -1),
            new Point(10, -2),
            new Point(10, -3),
            new Point(11, -2)
        },
        new Point[]
        {
            new Point(8, -1),
            new Point(8, -2),
            new Point(9, -2),
            new Point(10, -2)
        },
        new Point[]
        {
            new Point(8, -1),
            new Point(8, -2),
            new Point(9, -1),
            new Point(10, -1)
        },
        new Point[]
        {
            new Point(8, -2),
            new Point(9, -1),
            new Point(9, -2),
            new Point(10, -1)
        },
        new Point[]
        {
            new Point(8, -1),
            new Point(9, -1),
            new Point(9, -2),
            new Point(10, -2)
        },
        new Point[]
        {
            new Point(9, -1),
            new Point(9, -2),
            new Point(9, -3),
            new Point(9, -4)
        },
        new Point[]
        {
            new Point(9, -1),
            new Point(9, -2),
            new Point(10, -1),
            new Point(10, -2)
        }
    };

        private Dictionary<int, Point[][]> rotationOffsets = new Dictionary<int, Point[][]>();

        private int _xType;
        private string _shapeColor;
        private Point[] _currentPoints;
        private int _rotationIndex = 0;

        public Shape(int xType, string shapeColor)
	{
		this._xType = xType;
		this._shapeColor = shapeColor;
		this._currentPoints = shapeType[xType];
		rotationOffsets.Add(0, new[]
		{
			new Point[]
			{
				new Point(0, -1),
				new Point(1, 1),
				new Point(1, 1),
				new Point(1, 0)

            },
			new Point[]
			{
				new Point(0, 0),
				new Point(0, 0),
				new Point(0, 0),
				new Point(-1, -1)

            },
			new Point[]
			{
				new Point(0, 1),
				new Point(0, 0),
				new Point(0, 0),
				new Point(1, 2)
			},
			new Point[]
			{
				new Point(0, 0),
				new Point(-1, -1),
				new Point(-1, -1),
				new Point(-1, -1)
			}
		});
		rotationOffsets.Add(1, new[]
		{
			new Point[]
			{
				new Point(0, -2),
				new Point(1, -1),
				new Point(0, 0),
				new Point(-1, 1)
			},
			new Point[]
			{
				new Point(0, 2),
				new Point(0, 2),
				new Point(1, 1),
				new Point(1, -1)
			},
			new Point[]
			{
				new Point(0, 0),
				new Point(-1, -1),
				new Point(-2, -2),
				new Point(-1, 1)
			},
			new Point[]
			{
				new Point(0, 0),
				new Point(0, 0),
				new Point(1, 1),
				new Point(1, -1)
			}
		});
		rotationOffsets.Add(2, new[]
		{
			new Point[]
			{
				new Point(0, 0),
				new Point(0, 0),
				new Point(-1, -2),
				new Point(-1, -2)
			},
			new Point[]
			{
				new Point(0, -1),
				new Point(1, 0),
				new Point(2, 2),
				new Point(1, 1)
			},
			new Point[]
			{
				new Point(0, 1),
				new Point(0, 1),
				new Point(-1, -1),
				new Point(-1, -1)
			},
			new Point[]
			{
				new Point(0, 0),
				new Point(-1, -1),
				new Point(0, 1),
				new Point(1, 2)
			}
		});
		rotationOffsets.Add(3, new[]
		{
			new Point[]
			{
				new Point(0, 1),
				new Point(-1, -1),
				new Point(0, 0),
				new Point(-1, -2)
			},
			new Point[]
			{
				new Point(0, -1),
				new Point(1, 1),
				new Point(0, 0),
				new Point(1, 2)
			},
			new Point[]
			{
				new Point(0, 1),
				new Point(-1, -1),
				new Point(0, 0),
				new Point(-1, -2)
			},
			new Point[]
			{
				new Point(0, -1),
				new Point(1, 1),
				new Point(0, 0),
				new Point(1, 2)
			}
		});
		rotationOffsets.Add(4, new[]
		{
			new Point[]
			{
				new Point(0, -1),
				new Point(-1, -2),
				new Point(0, 1),
				new Point(-1, 0)
			},
			new Point[]
			{
				new Point(0, 1),
				new Point(1, 2),
				new Point(0, -1),
				new Point(1, 0)
			},
			new Point[]
			{
				new Point(0, -1),
				new Point(-1, -2),
				new Point(0, 1),
				new Point(-1, 0)
			},
			new Point[]
			{
				new Point(0, 1),
				new Point(1, 2),
				new Point(0, -1),
				new Point(1, 0)
			}
		});
		rotationOffsets.Add(5, new[]
		{
			new Point[]
			{
				new Point(0, 0),
				new Point(1, 1),
				new Point(2, 2),
				new Point(3, 3)
			},
			new Point[]
			{
				new Point(0, 0),
				new Point(-1, -1),
				new Point(-2, -2),
				new Point(-3, -3)
			},
			new Point[]
			{
				new Point(0, 0),
				new Point(1, 1),
				new Point(2, 2),
				new Point(3, 3)
			},
			new Point[]
			{
				new Point(0, 0),
				new Point(-1, -1),
				new Point(-2, -2),
				new Point(-3, -3)
			}
		});

	}

    //shape color accessor
    public string ShapeColor
    {
        get
        {
            return _shapeColor;
        }
    }

    //shape locations accessor
    public Point[] CurrentPoints
    {
        get
        {
            return _currentPoints;
        }
    }

    //shape current rotation accessor
    public int RotationIndex
    {
        get
        {
            return _rotationIndex;
        }
        set
        {
            _rotationIndex = value;
        }
    }

    //moves shape down
    public string[][] moveDown(string[][] grid)
    {
        Point[] pts = CurrentPoints;
        foreach (Point p in CurrentPoints)
        {
            if (p.Y >= 0)
            {
                grid[p.Y][p.X] = "";
            }
        }
        if (canMoveBelow(CurrentPoints, grid))
        {
            for (int x = 0; x < CurrentPoints.Count(); x++)
            {
                CurrentPoints[x].Y += 1;
                Point p = CurrentPoints[x];
                if (p.Y >= 0)
                {
                    grid[p.Y][p.X] = ShapeColor;
                }
            }
        }
        else
        {
            foreach (Point p in pts)
            {
                if (p.Y >= 0)
                {
                    grid[p.Y][p.X] = ShapeColor;
                }
            }
        }
        return grid;
    }

    //moves shape left
    public string[][] moveLeft(string[][] grid)
    {
        foreach (Point p in CurrentPoints)
        {
            if (p.Y >= 0)
            {
                grid[p.Y][p.X] = "";
            }
        }
        Point[] pts = CurrentPoints;
        if (canMoveLeft(CurrentPoints, grid))
        {
            for (int x = 0; x < CurrentPoints.Count(); x++)
            {
                if (CurrentPoints[x].X > 0)
                {
                    CurrentPoints[x].X -= 1;
                    Point p = CurrentPoints[x];
                    grid[p.Y][p.X] = ShapeColor;
                }
            }
        }
        else
        {
            foreach (Point p in pts)
            {
                if (p.Y >= 0)
                {
                    grid[p.Y][p.X] = ShapeColor;
                }
            }
        }
        return grid;
    }

    //moves shape right
    public string[][] moveRight(string[][] grid)
    {
        foreach (Point p in CurrentPoints)
        {
            if (p.Y >= 0)
            {
                grid[p.Y][p.X] = "";
            }
        }
        Point[] pts = CurrentPoints;
        if (canMoveRight(CurrentPoints, grid))
        {
            for (int x = 0; x < CurrentPoints.Count(); x++)
            {
                if (CurrentPoints[x].X < 19)
                {
                    CurrentPoints[x].X += 1;
                    Point p = CurrentPoints[x];
                    grid[p.Y][p.X] = ShapeColor;
                }
            }
        }
        else
        {
            foreach (Point p in pts)
            {
                if (p.Y >= 0)
                {
                    grid[p.Y][p.X] = ShapeColor;
                }
            }
        }
        return grid;
    }

    //rotates shape
    public string[][] rotateShape(string[][] grid)
    {
        if (_xType == 6)
        {
            return grid;
        }

        bool shifting = GetAsyncKeyState(VK_LSHIFT) < 0 || GetAsyncKeyState(VK_RSHIFT) < 0;

        foreach (Point p in CurrentPoints)
        {
            if (p.Y >= 0)
            {
                grid[p.Y][p.X] = "";
            }
        }
        if (RotationIndex == 4)
        {
            RotationIndex = 0;
        }
        Point[] pts = (Point[])CurrentPoints.Clone();
        if (!shifting)
        {
            for (int x = 0; x < pts.Count(); x++)
            {
                pts[x].Offset(rotationOffsets[_xType][RotationIndex][x]);
            }
            if (shapeIsClear(pts, grid))
            {
                _currentPoints = pts;
                RotationIndex += 1;
            }
        }
        else
        {
            if (RotationIndex == 0)
            {
                RotationIndex = 3;
            }
            else
            {
                RotationIndex -= 1;
            }
            for (int x = 0; x < pts.Count(); x++)
            {
                pts[x].Offset(negatePoint(rotationOffsets[_xType][RotationIndex][x]));
            }
            if (shapeIsClear(pts, grid))
            {
                _currentPoints = pts;
            }
        }
        foreach (Point p in CurrentPoints)
        {
            if (p.Y >= 0)
            {
                grid[p.Y][p.X] = ShapeColor;
            }
        }
        return grid;
    }

    //checks if shape can move to the left
    private bool canMoveLeft(Point[] pts, string[][] grid)
    {
        if (pts.Any((p) => p.Y == -1))
        {
            return false;
        }
        foreach (Point p in pts)
        {
            if (p.X - 1 < 0)
            {
                return false;
            }
            if (p.Y >= 0 && (p.X > 0 && p.X < 19))
            {
                if (!string.IsNullOrEmpty(grid[p.Y][p.X - 1]))
                {
                    return false;
                }
            }
            else if (p.X < 0 || p.X > 19)
            {
                return false;
            }
        }
        return true;
    }

    //checks if shape can move to the right
    private bool canMoveRight(Point[] pts, string[][] grid)
    {
        if (pts.Any((p) => p.Y == -1))
        {
            return false;
        }
        foreach (Point p in pts)
        {
            if (p.X + 1 > 19)
            {
                return false;
            }
            if (p.Y >= 0 && (p.X > 0 && p.X < 19))
            {
                if (!string.IsNullOrEmpty(grid[p.Y][p.X + 1]))
                {
                    return false;
                }
            }
            else if (p.X < 0 || p.X > 19)
            {
                return false;
            }
        }
        return true;
    }

    //checks if shape can move lower
    private bool canMoveBelow(Point[] pts, string[][] grid)
    {
        foreach (Point p in pts)
        {
            if (p.Y + 1 > 29)
            {
                if (TouchDown != null) { 
                    TouchDown(this);
                    return false;
                }
            }
            if (p.Y >= 0)
            {
                if (!string.IsNullOrEmpty(grid[p.Y + 1][p.X]))
                {
                    if (TouchDown != null)
                    {
                        TouchDown(this);
                        return false;
                    }
                }
            }
        }
        return true;
    }

    //checks if shape can rotate
    private bool shapeIsClear(Point[] pts, string[][] grid)
    {
        foreach (Point p in pts)
        {
            if (p.Y >= 0)
            {
                if (p.X < 0 || p.X > 19)
                {
                    return false;
                }
                if (!string.IsNullOrEmpty(grid[p.Y][p.X]))
                {
                    return false;
                }
            }
        }
        return true;
    }

    //negates a point
    private Point negatePoint(Point p)
    {
        return new Point(-p.X, -p.Y);
    }


    }
}
