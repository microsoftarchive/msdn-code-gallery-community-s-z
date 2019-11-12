//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: RoomPoint.cs
//
//--------------------------------------------------------------------------

using System;

namespace AntisocialRobots
{
    /// <summary>
    /// Represents a location within the room in "robot coordinates".  For example, the location
    /// of robot at the top-left corner of the room is (0,0); the location of a second robot
    /// that's immediately to the right of that robot is (1,0).
    /// </summary>
    internal struct RoomPoint
    {
        /// <summary>An x-coordinate in "robot coordinates".</summary>
        public int X;

        /// <summary>A y-coordinate of the robot in "robot coordinates".</summary>
        public int Y;

        /// <summary>
        /// Initializes an instance of this class.
        /// </summary>
        /// <param name="x">The x-coordinate.</param>
        /// <param name="y">The y-coordinate.</param>
        public RoomPoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Returns the distance from this point to another point.
        /// </summary>
        /// <param name="other">The other point.</param>
        public double DistanceTo(RoomPoint other) { return Math.Sqrt(Square(other.X - X) + Square(other.Y - Y)); }

        /// <summary>
        /// Returns the angle from this point to another point, measured in clockwise radians from
        /// the ray pointing to the right of this point.
        /// </summary>
        /// <param name="other">The other point.</param>
        public double AngleTo(RoomPoint other) { return Math.Atan2(other.Y - Y, other.X - X); }

        /// <summary>
        /// Returns the square of a given number.
        /// </summary>
        /// <param name="n">The number to square.</param>
        public static double Square(double n) { return n * n; }
    }
}
