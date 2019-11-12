//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: GameOfLifeLogic.cs
//
//--------------------------------------------------------------------------

using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using Microsoft.Drawing;

namespace GameOfLife
{
    /// <summary>Represents the game of life board.</summary>
    internal class GameBoard
    {
        /// <summary>Arrays used to store the current and next state of the game.</summary>
        private Color?[][,] _scratch;
        /// <summary>Index into the scratch arrays that represents the current stage of the game.</summary>
        private int _currentIndex;
        /// <summary>A pool of Bitmaps used for rendering.</summary>
        private ObjectPool<Bitmap> _pool;

        /// <summary>Initializes the game board.</summary>
        /// <param name="width">The width of the board.</param>
        /// <param name="height">The height of the board.</param>
        /// <param name="initialDensity">The initial population density to use to populate the board.</param>
        /// <param name="pool">The pool of Bitmaps to use.</param>
        public GameBoard(int width, int height, double initialDensity, ObjectPool<Bitmap> pool)
        {
            // Validate parameters
            if (width < 1) throw new ArgumentOutOfRangeException("width");
            if (height < 1) throw new ArgumentOutOfRangeException("height");
            if (pool == null) throw new ArgumentNullException("pool");
            if (initialDensity < 0 || initialDensity > 1) throw new ArgumentOutOfRangeException("initialDensity");

            // Store parameters
            _pool = pool;
            Width = width;
            Height = height;

            // Create the storage arrays
            _scratch = new Color?[2][,] { new Color?[width, height], new Color?[width, height] };

            // Populate the board randomly based on the provided initial density
            Random rand = new Random();
            for (int i = 0; i < width; i ++)
            {
                for (int j = 0; j < height; j++)
                {
                    _scratch[_currentIndex][i, j] = (rand.NextDouble() < initialDensity) ? Color.FromArgb(rand.Next()) : (Color?)null;
                }
            }
        }

        /// <summary>Moves to the next stage of the game, returning a Bitmap that represents the state of the board.</summary>
        /// <returns>A bitmap that represents the state of the board.</returns>
        /// <remarks>The returned Bitmap should be added back to the pool supplied to the constructor when usage of it is complete.</remarks>
        public Bitmap MoveNext()
        {
            // Get the current and next stage board arrays
            int nextIndex = (_currentIndex + 1) % 2;
            Color?[,] current = _scratch[_currentIndex];
            Color?[,] next = _scratch[nextIndex];
            Random rand = new Random();

            // Get a Bitmap from the pool to use
            var bmp = _pool.GetObject();
            using (FastBitmap fastBmp = new FastBitmap(bmp))
            {
                // For every row
                Action<int> body = i =>
                {
                    // For every column
                    for (int j = 0; j < Height; j++)
                    {
                        int count = 0;
                        int r = 0, g = 0, b = 0;

                        // Count neighbors
                        for (int x = i - 1; x <= i + 1; x++)
                        {
                            for (int y = j - 1; y <= j + 1; y++)
                            {
                                if ((x == i && j == y) || x < 0 || x >= Width || y < 0 || y >= Height) continue;
                                Color? c = current[x, y];
                                if (c.HasValue)
                                {
                                    count++;
                                    r += c.Value.R;
                                    g += c.Value.G;
                                    b += c.Value.B;
                                }
                            }
                        }

                        // Heuristic for alive or dead based on neighbor count and current state
                        if (count < 1 || count >= 4) next[i, j] = null;
                        else if (current[i, j].HasValue && (count == 2 || count == 3)) next[i, j] = current[i, j];
                        else if (!current[i, j].HasValue && count == 3) next[i, j] = Color.FromArgb(r / count, g / count, b / count);
                        else next[i, j] = null;

                        // Render the cell
                        fastBmp.SetColor(i, j, current[i, j] ?? Color.White);
                    }
                };

                // Process the rows serially or in parallel based on the RunParallel property setting
                if (RunParallel)
                {
                    Parallel.For(0, Width, 
                        body);
                }
                else
                {
                    for (int i = 0; i < Width; i++) 
                        body(i);
                }
            }

            // Update and return
            _currentIndex = nextIndex;
            return bmp;
        }

        /// <summary>Gets the width of the board.</summary>
        public int Width { get; private set; }
        /// <summary>Gets the height of the board.</summary>
        public int Height { get; private set; }
        /// <summary>Gets or sets whether to run in parallel.</summary>
        public bool RunParallel { get; set; }
    }
}