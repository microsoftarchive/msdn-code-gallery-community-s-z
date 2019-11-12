//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: Minimax.cs
//
//--------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Reversi
{
    public abstract class Minimax
    {
        #region ABSTRACT
        /// <summary>
        /// Returns the max depth that Minimax should search to.  A value 
        /// of -1 indicates an uncapped search depth.
        /// </summary>
        public abstract int MaxDepth { get; }

        /// <summary>
        /// Returns the time limit after which Minimax should stop searching.
        /// </summary>
        public abstract TimeSpan TimeLimit { get; }

        /// <summary>
        /// Returns the soft cap for the number of concurrent Tasks that Minimax
        /// should use.
        /// </summary>
        public abstract int DegreeOfParallelism { get; }

        /// <summary>
        /// Returns whether the given state represents a finished game.
        /// Must be thread-safe.
        /// </summary>
        /// <param name="state">The game state to check.</param>
        /// <returns>True if the state represents a finished game, 
        /// false otherwise.</returns>
        protected abstract bool TerminalTest(MinimaxSpot[,] state);

        /// <summary>
        /// Returns the value of the given state, where a positive value indicates
        /// an advantage for the light player.
        /// Must be thread-safe.
        /// </summary>
        /// <param name="state">The game state to evaluate.</param>
        /// <returns>A number representing the value of the given state.</returns>
        protected abstract int EvaluateHeuristic(MinimaxSpot[,] state);

        /// <summary>
        /// Returns a collection containing the valid moves for 
        /// the given player on the given game state.
        /// Must be thread-safe.
        /// </summary>
        /// <param name="state">The game state to consider.</param>
        /// <param name="isLightPlayer">The bool indicating which player.</param>
        /// <returns>An enumerable of MinimaxMove, representing the valid moves.</returns>
        protected abstract IEnumerable<MinimaxMove> GetValidMoves(MinimaxSpot[,] state, bool isLightPlayer);

        /// <summary>
        /// Returns the game state that results when the given player plays the given move on the given
        /// state.  If the move is invalid, the new state should be the same as the old state.
        /// Must be thread-safe.
        /// </summary>
        /// <param name="state">The state to play a move on.</param>
        /// <param name="move">The move to play.</param>
        /// <param name="isLightPlayer">The player to play the move.</param>
        /// <returns>A MinimaxSpot matrix that represents the insight state.</returns>
        protected abstract MinimaxSpot[,] GetInsight(MinimaxSpot[,] state, MinimaxMove move, bool isLightPlayer);
        #endregion

        /// <summary>
        /// Should only be called through the public Search method.
        /// </summary>
        /// <param name="state">The game state to consider.</param>
        /// <param name="isLightPlayer">The player to move.</param>
        /// <param name="alpha">The alpha pruning value.</param>
        /// <param name="beta">The beta pruning value.</param>
        /// <param name="depth">The current search depth.</param>
        /// <returns>A MinimaxMove that represents the best move found.</returns>
        /// <remarks>
        /// The initial alpha value should be Int32.MinValue, the initial beta value 
        /// should be Int32.MaxValue, and the initial depth value should be 0.
        /// 
        /// The search will terminate ASAP if the m_ct cancellation token is signaled.
        /// 
        /// This method is thread-safe.
        /// </remarks>
        private MinimaxMove InternalSearch(MinimaxSpot[,] state, bool isLightPlayer, int alpha, int beta, int depth)
        {
            // Stop the search if...
            if (TerminalTest(state) || depth >= m_maxDepth || m_ct.IsCancellationRequested)
            {
                m_movesConsidered++;
                return new MinimaxMove(EvaluateHeuristic(state));
            }

            // Initialize the best move for this recursive call.
            MinimaxMove bestMove = new MinimaxMove(isLightPlayer ? Int32.MinValue : Int32.MaxValue);

            // Get the valid moves for this recursive call.
            IEnumerable<MinimaxMove> validMoves = GetValidMoves(state, isLightPlayer);

            // If there are valid moves, recurse on each.
            bool consideredLocalMoves = false;
            foreach (MinimaxMove move in validMoves)
            {
                consideredLocalMoves = true;

                MinimaxMove curMove = move;
                curMove.Value = InternalSearch(GetInsight(state, curMove, isLightPlayer), !isLightPlayer, alpha, beta, depth + 1).Value;
                if (isLightPlayer)
                {
                    if (curMove.Value > bestMove.Value) bestMove = curMove;
                    if (bestMove.Value >= beta) break;
                    alpha = Math.Max(alpha, bestMove.Value.Value);
                }
                else
                {
                    if (curMove.Value < bestMove.Value) bestMove = curMove;
                    if (bestMove.Value <= alpha) break;
                    beta = Math.Min(beta, bestMove.Value.Value);
                }
            }

            // If there were no valid moves, still calculate the value.
            if (!consideredLocalMoves)
            {
                bestMove.Value = InternalSearch(state, !isLightPlayer, alpha, beta, depth + 1).Value;
            }

            return bestMove;
        }

        /// <summary>
        /// Should only be called through the public Search method.
        /// </summary>
        /// <param name="state">The game state to consider.</param>
        /// <param name="isLightPlayer">The player to move.</param>
        /// <param name="alpha">The alpha pruning value.</param>
        /// <param name="beta">The beta pruning value.</param>
        /// <param name="depth">The current search depth.</param>
        /// <param name="token">The pruning token.</param>
        /// <returns>A MinimaxMove that represents the best move found.</returns>
        /// <remarks>
        /// The initial alpha value should be Int32.MinValue, the initial beta value 
        /// should be Int32.MaxValue, the initial depth value should be 0, and the 
        /// initial token should be a non-settable token.
        /// 
        /// The search will terminate ASAP if the m_ct cancellation token is signaled.
        /// 
        /// This method is thread-safe.
        /// </remarks>
        private MinimaxMove InternalSearchTPL(MinimaxSpot[,] state, bool isLightPlayer, int alpha, int beta, int depth, CancellationToken token)
        {
            // Stop the search if...
            if (TerminalTest(state) || depth >= m_maxDepth || m_ct.IsCancellationRequested)
            {
                m_movesConsidered++; // NOTE: this is racy and may be lower than the actual count, but it only needs to be an appx
                return new MinimaxMove(EvaluateHeuristic(state));
            }

            // Initialize the best move for this recursive call.
            MinimaxMove bestMove = new MinimaxMove(isLightPlayer ? Int32.MinValue : Int32.MaxValue);

            // Get the valid moves for this recursive call.
            IEnumerable<MinimaxMove> validMoves = GetValidMoves(state, isLightPlayer);

            bool consideredLocalMoves = false;
            Queue<Task> workers = new Queue<Task>();
            object bigLock = new object();
            CancellationTokenSource cts = new CancellationTokenSource();
            foreach (MinimaxMove move in validMoves)
            {
                // SHARED STATE
                //     The local variables (bestMove, alpha, beta) are protected by a lock.
                //     The non-local variables (m_taskCount) are modified using Interlocked
                consideredLocalMoves = true;

                // If the pruning token is signaled, stop this loop.
                if (token.IsCancellationRequested)
                {
                    cts.Cancel();
                    break;
                }

                MinimaxMove curMove = move;
                if (m_taskCount < m_degOfParallelism && depth <= m_maxDepth - 1)
                {
                    Interlocked.Increment(ref m_taskCount);
                    workers.Enqueue(Task.Factory.StartNew(() =>
                    {
                        curMove.Value = InternalSearchTPL(GetInsight(state, curMove, isLightPlayer), !isLightPlayer, alpha, beta, depth + 1, cts.Token).Value;
                        lock (bigLock)
                        {
                            if (isLightPlayer)
                            {
                                if (curMove.Value > bestMove.Value) bestMove = curMove;
                                if (bestMove.Value >= beta) cts.Cancel();
                                alpha = Math.Max(alpha, bestMove.Value.Value);
                            }
                            else
                            {
                                if (curMove.Value < bestMove.Value) bestMove = curMove;
                                if (bestMove.Value <= alpha) cts.Cancel();
                                beta = Math.Min(beta, bestMove.Value.Value);
                            }
                        }
                        Interlocked.Decrement(ref m_taskCount);
                    }));
                }
                else
                {
                    bool isPruning = false;
                    curMove.Value = InternalSearchTPL(GetInsight(state, curMove, isLightPlayer), !isLightPlayer, alpha, beta, depth + 1, cts.Token).Value;

                    // If there are no tasks, no need to lock.
                    bool lockTaken = false;
                    try
                    {
                        if (workers.Count > 0) Monitor.Enter(bigLock, ref lockTaken);
                        if (isLightPlayer)
                        {
                            if (curMove.Value > bestMove.Value) bestMove = curMove;
                            if (bestMove.Value >= beta) isPruning = true;
                            alpha = Math.Max(alpha, bestMove.Value.Value);
                        }
                        else
                        {
                            if (curMove.Value < bestMove.Value) bestMove = curMove;
                            if (bestMove.Value <= alpha) isPruning = true;
                            beta = Math.Min(beta, bestMove.Value.Value);
                        }
                    }
                    finally { if (lockTaken) Monitor.Exit(bigLock); }

                    if (isPruning)
                    {
                        cts.Cancel();
                        break;
                    }
                }
            }

            Task.WaitAll(workers.ToArray());

            // If there were no valid moves, still calculate the value.
            if (!consideredLocalMoves)
            {
                bestMove.Value = InternalSearchTPL(state, !isLightPlayer, alpha, beta, depth + 1, token).Value;
            }

            return bestMove;
        }

        /// <summary>
        /// Returns the best move resulting from a Minimax, alpha-beta pruning search on the given state.
        /// </summary>
        /// <param name="state">The state to consider.</param>
        /// <param name="isLightPlayer">The player to move.</param>
        /// <param name="inParallel">A boolean indicating whether to use the parallel algorithm.</param>
        /// <returns>A MinimaxMove that represents the best move found.</returns>
        /// <remarks>
        /// This method will only return a MinimaxMove(-1...) if there are no valid moves.
        /// </remarks>
        public MinimaxMove Search(MinimaxSpot[,] state, bool isLightPlayer, bool inParallel)
        {
            // Initialize a bunch of state.
            m_maxDepth = MaxDepth == -1 ? Int32.MaxValue : MaxDepth;
            m_degOfParallelism = DegreeOfParallelism;
            m_timeLimit = TimeLimit;
            m_taskCount = 0;
            m_movesConsidered = 0;
            var curCts = m_cts = new CancellationTokenSource();
            m_ct = m_cts.Token;

            MinimaxMove aiMove = new MinimaxMove(-1, -1, null);

            // Start the timeout timer.  Done using a dedicated thread to minimize delay 
            // in cancellation due to lack of threads in the pool to run the callback.
            var timeoutTask = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(m_timeLimit);
                curCts.Cancel();
            }, TaskCreationOptions.LongRunning);

            // Do the search
            aiMove = inParallel ?
                InternalSearchTPL(state, isLightPlayer, Int32.MinValue, Int32.MaxValue, 0, CancellationToken.None) :
                InternalSearch(state, isLightPlayer, Int32.MinValue, Int32.MaxValue, 0);

            // Make sure that MinimaxMove(-1...) is only returned if there are no valid moves, because
            // InternalSearch* may return MinimaxMove(-1...) if none of the valid moves beats Int32.Min/Max.
            if (aiMove.Row == -1)
            {
                foreach (var move in GetValidMoves(state, isLightPlayer))
                {
                    aiMove = move;
                    aiMove.Value = isLightPlayer ? Int32.MinValue : Int32.MaxValue;
                    break;
                }
            }

            return aiMove;
        }

        /// <summary>
        /// Cancel the ongoing operation, if there is one.
        /// </summary>
        public void Cancel()
        {
            if(m_cts!=null)
                m_cts.Cancel();
        }

        /// <summary>
        /// Returns the number of moves considered by the most recent Search.
        /// </summary>
        public int MovesConsidered
        {
            get { return m_movesConsidered; }
        }

        private int m_maxDepth, m_degOfParallelism;
        private TimeSpan m_timeLimit;
        private int m_taskCount;
        private volatile int m_movesConsidered;
        private CancellationTokenSource m_cts;
        private CancellationToken m_ct;
    }

    /// <summary>
    /// An enum that represents the state of a board game spot.
    /// </summary>
    public enum MinimaxSpot
    {
        Empty = 0,
        Dark = -1,
        Light = 1
    }

    /// <summary>
    /// A struct that represents a board game move.  The value field
    /// should only be manipulated by Minimax.
    /// </summary>
    public struct MinimaxMove
    {
        public int Row, Col;
        public int? Value;

        public MinimaxMove(int row, int col)
        {
            Row = row;
            Col = col;
            Value = null;
        }

        public MinimaxMove(int? value)
        {
            Row = Col = -1;
            Value = value;
        }

        public MinimaxMove(int row, int col, int? value)
        {
            Row = row;
            Col = col;
            Value = value;
        }
    }
}
