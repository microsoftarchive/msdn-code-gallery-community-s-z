//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: ReversiGame.cs
//
//--------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Reversi
{
    class ReversiGame : Minimax
    {
        public ReversiGame(int numRows, int numCols)
        {
            m_numRows = numRows;
            m_numCols = numCols;
            m_board = new MinimaxSpot[numRows, numCols];
            for (int i = 0; i < numRows; i++)
                for (int j = 0; j < numCols; j++)
                    m_board[i, j] = MinimaxSpot.Empty;

            m_board[3, 3] = MinimaxSpot.Light;
            m_board[4, 4] = MinimaxSpot.Light;
            m_board[4, 3] = MinimaxSpot.Dark;
            m_board[3, 4] = MinimaxSpot.Dark;

            m_isLightMove = false;
        }

        public void SetMinimaxKnobs(int maxDepth, TimeSpan timeLimit, int degOfParallelism)
        {
            m_depth = maxDepth;
            m_time = timeLimit;
            m_degPar = degOfParallelism;
        }

        /// <summary>
        /// Returns whether a move on the given row and column on the given state by the given player
        /// is valid.
        /// </summary>
        /// <param name="state">The state to consider.</param>
        /// <param name="isLightPlayer">The player ot move.</param>
        /// <param name="row">The move row.</param>
        /// <param name="col">The move column.</param>
        /// <returns></returns>
        private bool IsValidMove(MinimaxSpot[,] state, bool isLightPlayer, int row, int col)
        {
            if (state[row, col] != MinimaxSpot.Empty)
                return false;

            MinimaxSpot you = isLightPlayer ? MinimaxSpot.Light : MinimaxSpot.Dark;
            MinimaxSpot enemy = isLightPlayer ? MinimaxSpot.Dark : MinimaxSpot.Light;

            // Check above.
            if (row + 1 < m_numRows && state[row + 1, col] == enemy)
            {
                for (int r = row + 2; r < m_numRows; r++)
                {
                    if (state[r, col] == you)
                        return true;
                    if (state[r, col] == MinimaxSpot.Empty)
                        break;
                }
            }

            // Check below.
            if (row - 1 >= 0 && state[row - 1, col] == enemy)
            {
                for (int r = row - 2; r >= 0; r--)
                {
                    if (state[r, col] == you)
                        return true;
                    if (state[r, col] == MinimaxSpot.Empty)
                        break;
                }
            }

            // Check right.
            if (col + 1 < m_numCols && state[row, col + 1] == enemy)
            {
                for (int c = col + 2; c < m_numCols; c++)
                {
                    if (state[row, c] == you)
                        return true;
                    if (state[row, c] == MinimaxSpot.Empty)
                        break;
                }
            }

            // Check left.
            if (col - 1 >= 0 && state[row, col - 1] == enemy)
            {
                for (int c = col - 2; c >= 0; c--)
                {
                    if (state[row, c] == you)
                        return true;
                    if (state[row, c] == MinimaxSpot.Empty)
                        break;
                }
            }

            // Check above-right
            if (row + 1 < m_numRows && col + 1 < m_numCols && state[row + 1, col + 1] == enemy)
            {
                for (int r = row + 2, c = col + 2; r < m_numRows && c < m_numCols; r++, c++)
                {
                    if (state[r, c] == you)
                        return true;
                    if (state[r, c] == MinimaxSpot.Empty)
                        break;
                }
            }

            // Check above-left
            if (row + 1 < m_numRows && col - 1 >= 0 && state[row + 1, col - 1] == enemy)
            {
                for (int r = row + 2, c = col - 2; r < m_numRows && c >= 0; r++, c--)
                {
                    if (state[r, c] == you)
                        return true;
                    if (state[r, c] == MinimaxSpot.Empty)
                        break;
                }
            }

            // Check below-right
            if (row - 1 >= 0 && col + 1 < m_numCols && state[row - 1, col + 1] == enemy)
            {
                for (int r = row - 2, c = col + 2; r >= 0 && c < m_numCols; r--, c++)
                {
                    if (state[r, c] == you)
                        return true;
                    if (state[r, c] == MinimaxSpot.Empty)
                        break;
                }
            }

            // Check below-left
            if (row - 1 >= 0 && col - 1 >= 0 && state[row - 1, col - 1] == enemy)
            {
                for (int r = row - 2, c = col - 2; r >= 0 && c >= 0; r--, c--)
                {
                    if (state[r, c] == you)
                        return true;
                    if (state[r, c] == MinimaxSpot.Empty)
                        break;
                }
            }

            return false;
        }

        /// <summary>
        /// Returns the valid moves for the state maintained by this ReversiGame
        /// (delegates to another overload).
        /// </summary>
        /// <returns>The valid moves.</returns>
        public IEnumerable<MinimaxMove> GetValidMoves()
        {
            return GetValidMoves(m_board, m_isLightMove);
        }

        /// <summary>
        /// Makes a move on the given row and column.
        /// </summary>
        /// <param name="row">The move row</param>
        /// <param name="col">The move column</param>
        /// <returns>Whether or not the operation succeeded.</returns>
        public bool MakeMove(int row, int col)
        {
            if (!IsValidMove(m_board, m_isLightMove, row, col))
            {
                return false;
            }

            MinimaxSpot you = m_isLightMove ? MinimaxSpot.Light : MinimaxSpot.Dark;
            MinimaxSpot enemy = m_isLightMove ? MinimaxSpot.Dark : MinimaxSpot.Light;

            var backup = new MinimaxSpot[8, 8];
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    backup[i, j] = m_board[i, j];

            m_board[row, col] = you;

            // Conquer above.
            if (row + 1 < m_numRows && m_board[row + 1, col] == enemy)
            {
                bool b = false;
                for (int r = row + 2; r < m_numRows; r++)
                {
                    if (m_board[r, col] == MinimaxSpot.Empty)
                        break;
                    if (m_board[r, col] == you)
                        b = true;
                }
                if (b)
                {
                    for (int r = row + 1; m_board[r, col] != you; r++)
                        m_board[r, col] = you;
                }
            }

            // Conquer below.
            if (row - 1 >= 0 && m_board[row - 1, col] == enemy)
            {
                bool b = false;
                for (int r = row - 2; r >= 0; r--)
                {
                    if (m_board[r, col] == MinimaxSpot.Empty)
                        break;
                    if (m_board[r, col] == you)
                        b = true;
                }
                if (b)
                {
                    for (int r = row - 1; m_board[r, col] != you; r--)
                        m_board[r, col] = you;
                }
            }

            // Conquer right.
            if (col + 1 < m_numCols && m_board[row, col + 1] == enemy)
            {
                bool b = false;
                for (int c = col + 2; c < m_numCols; c++)
                {
                    if (m_board[row, c] == MinimaxSpot.Empty)
                        break;
                    if (m_board[row, c] == you)
                        b = true;
                }
                if (b)
                {
                    for (int c = col + 1; m_board[row, c] != you; c++)
                        m_board[row, c] = you;
                }
            }

            // Conquer left.
            if (col - 1 >= 0 && m_board[row, col - 1] == enemy)
            {
                bool b = false;
                for (int c = col - 2; c >= 0; c--)
                {
                    if (m_board[row, c] == MinimaxSpot.Empty)
                        break;
                    if (m_board[row, c] == you)
                        b = true;
                }
                if (b)
                {
                    for (int c = col - 1; m_board[row, c] != you; c--)
                        m_board[row, c] = you;
                }
            }

            // Conquer above-right
            if (row + 1 < m_numRows && col + 1 < m_numCols && m_board[row + 1, col + 1] == enemy)
            {
                bool b = false;
                for (int r = row + 2, c = col + 2; r < m_numRows && c < m_numCols; r++, c++)
                {
                    if (m_board[r, c] == MinimaxSpot.Empty)
                        break;
                    if (m_board[r, c] == you)
                        b = true;
                }
                if (b)
                {
                    for (int r = row + 1, c = col + 1; m_board[r, c] != you; r++, c++)
                        m_board[r, c] = you;
                }
            }

            // Conquer above-left
            if (row + 1 < m_numRows && col - 1 >= 0 && m_board[row + 1, col - 1] == enemy)
            {
                bool b = false;
                for (int r = row + 2, c = col - 2; r < m_numRows && c >= 0; r++, c--)
                {
                    if (m_board[r, c] == MinimaxSpot.Empty)
                        break;
                    if (m_board[r, c] == you)
                        b = true;
                }
                if (b)
                {
                    for (int r = row + 1, c = col - 1; m_board[r, c] != you; r++, c--)
                        m_board[r, c] = you;
                }
            }

            // Conquer below-right
            if (row - 1 >= 0 && col + 1 < m_numCols && m_board[row - 1, col + 1] == enemy)
            {
                bool b = false;
                for (int r = row - 2, c = col + 2; r >= 0 && c < m_numCols; r--, c++)
                {
                    if (m_board[r, c] == MinimaxSpot.Empty)
                        break;
                    if (m_board[r, c] == you)
                        b = true;
                }
                if (b)
                {
                    for (int r = row - 1, c = col + 1; m_board[r, c] != you; r--, c++)
                        m_board[r, c] = you;
                }
            }

            // Conquer below-left
            if (row - 1 >= 0 && col - 1 >= 0 && m_board[row - 1, col - 1] == enemy)
            {
                bool b = false;
                for (int r = row - 2, c = col - 2; r >= 0 && c >= 0; r--, c--)
                {
                    if (m_board[r, c] == MinimaxSpot.Empty)
                        break;
                    if (m_board[r, c] == you)
                        b = true;
                }
                if (b)
                {
                    for (int r = row - 1, c = col - 1; m_board[r, c] != you; r--, c--)
                        m_board[r, c] = you;
                }
            }

            m_isLightMove = !m_isLightMove;

            return true;
        }

        /// <summary>
        /// Passes on the current player's move.
        /// </summary>
        public void PassMove()
        {
            m_isLightMove = !m_isLightMove;
        }

        /// <summary>
        /// Returns the game result.
        /// </summary>
        /// <returns>The game result</returns>
        public ReversiGameResult GetGameResult()
        {
            ReversiGameResult gr = new ReversiGameResult();

            for (int i = 0; i < m_numRows; i++)
            {
                for (int j = 0; j < m_numCols; j++)
                {
                    if (m_board[i, j] == MinimaxSpot.Light)
                        gr.NumLightPieces++;
                    if (m_board[i, j] == MinimaxSpot.Dark)
                        gr.NumDarkPieces++;
                }
            }

            if (TerminalTest(m_board))
            {
                if (gr.NumLightPieces > gr.NumDarkPieces)
                    gr.GameState = ReversiGameState.LightWon;
                else if (gr.NumLightPieces < gr.NumDarkPieces)
                    gr.GameState = ReversiGameState.DarkWon;
                else
                    gr.GameState = ReversiGameState.Draw;
            }
            else
                gr.GameState = ReversiGameState.Ongoing;

            return gr;
        }

        public MinimaxMove GetAIMove(bool inParallel)
        {
            return Search(m_board, m_isLightMove, inParallel);
        }

        #region Minimax_routines
        public override int MaxDepth
        {
            get { return m_depth; }
        }

        public override TimeSpan TimeLimit
        {
            get { return m_time; }
        }

        public override int DegreeOfParallelism
        {
            get { return m_degPar; }
        }

        protected override bool TerminalTest(MinimaxSpot[,] state)
        {
            int n = GetValidMoves(state, true).Count();
            // Can either player move?
            if (GetValidMoves(state, true).Count() == 0 && GetValidMoves(state, false).Count() == 0)
                return true;
            return false;
        }

        protected override int EvaluateHeuristic(MinimaxSpot[,] state)
        {
            int boardValue = 0;

            // +1 for light pieces, -1 for dark pieces
            for (int i = 0; i < m_numRows; i++)
            {
                for (int j = 0; j < m_numCols; j++)
                {
                    if (state[i, j] == MinimaxSpot.Light)
                        boardValue++;
                    if (state[i, j] == MinimaxSpot.Dark)
                        boardValue--;
                }
            }

            // +-X for corner pieces
            int cornerPieceValue = 13;
            if (state[0, 0] == MinimaxSpot.Light)
                boardValue += cornerPieceValue;
            if (state[0, 0] == MinimaxSpot.Dark)
                boardValue -= cornerPieceValue;
            if (state[0, 7] == MinimaxSpot.Light)
                boardValue += cornerPieceValue;
            if (state[0, 7] == MinimaxSpot.Dark)
                boardValue -= cornerPieceValue;
            if (state[7, 0] == MinimaxSpot.Light)
                boardValue += cornerPieceValue;
            if (state[7, 0] == MinimaxSpot.Dark)
                boardValue -= cornerPieceValue;
            if (state[7, 7] == MinimaxSpot.Light)
                boardValue += cornerPieceValue;
            if (state[7, 7] == MinimaxSpot.Dark)
                boardValue -= cornerPieceValue;

            // +-X for edge pieces
            int edgePieceValue = 9;
            for (int i = 0; i < m_numRows; i++)
            {
                if (state[i, 0] == MinimaxSpot.Light)
                    boardValue += edgePieceValue;
                if (state[i, 0] == MinimaxSpot.Dark)
                    boardValue -= edgePieceValue;
                if (state[i, m_numCols - 1] == MinimaxSpot.Light)
                    boardValue += edgePieceValue;
                if (state[i, m_numCols - 1] == MinimaxSpot.Dark)
                    boardValue -= edgePieceValue;
            }
            for (int i = 0; i < m_numCols; i++)
            {
                if (state[0, i] == MinimaxSpot.Light)
                    boardValue += edgePieceValue;
                if (state[0, 0] == MinimaxSpot.Dark)
                    boardValue -= edgePieceValue;
                if (state[m_numRows - 1, i] == MinimaxSpot.Light)
                    boardValue += edgePieceValue;
                if (state[m_numRows - 1, i] == MinimaxSpot.Dark)
                    boardValue -= edgePieceValue;
            }

            return boardValue;
        }

        protected override IEnumerable<MinimaxMove> GetValidMoves(MinimaxSpot[,] state, bool isLightPlayer)
        {
            for (int i = 0; i < m_numRows; i++)
            {
                for (int j = 0; j < m_numCols; j++)
                {
                    if (IsValidMove(state, isLightPlayer, i, j))
                        yield return new MinimaxMove(i, j);
                }
            }
        }

        protected override MinimaxSpot[,] GetInsight(MinimaxSpot[,] state, MinimaxMove move, bool isLightPlayer)
        {
            MinimaxSpot[,] insightState = new MinimaxSpot[m_numRows, m_numCols];
            for (int i = 0; i < m_numRows; i++)
                for (int j = 0; j < m_numCols; j++)
                    insightState[i, j] = state[i, j];
            insightState[move.Row, move.Col] = isLightPlayer ? MinimaxSpot.Light : MinimaxSpot.Dark;
            return insightState;
        }
        #endregion

        #region DEBUG_ROUTINES
        private void ReadDump()
        {
            var sr = new StreamReader("./dump.txt");

            string s = sr.ReadLine();
            int r = 7;
            while (s != null)
            {
                char[] line = s.ToCharArray();
                for (int c = 0; c < 8; c++)
                {
                    if (line[c] == 'w')
                        m_board[r, c] = MinimaxSpot.Light;
                    if (line[c] == 'b')
                        m_board[r, c] = MinimaxSpot.Dark;
                }
                r--;
                s = sr.ReadLine();
            }
            sr.Close();
        }

        public void Dump(string msg)
        {
            var sw = new StreamWriter("./dump.txt");
            for (int i = 7; i >= 0; i--)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (m_board[i, j] == MinimaxSpot.Light)
                        sw.Write('w');
                    else if (m_board[i, j] == MinimaxSpot.Dark)
                        sw.Write('b');
                    else
                        sw.Write('-');
                }
                sw.WriteLine();
            }
            sw.WriteLine(msg);
            sw.Close();
        }
        #endregion

        private int m_numRows, m_numCols;
        private MinimaxSpot[,] m_board;
        private int m_depth, m_degPar;
        private TimeSpan m_time;
        private bool m_isLightMove;

        public MinimaxSpot[,] Board
        {
            get { return m_board; }
        }

        public bool IsLightMove
        {
            get { return m_isLightMove; }
        }
    }

    public struct ReversiGameResult
    {
        public ReversiGameState GameState;
        public int NumLightPieces, NumDarkPieces;
    }

    public enum ReversiGameState
    {
        Ongoing = 42,
        LightWon = 1,
        DarkWon = -1,
        Draw = 0
    }
}
