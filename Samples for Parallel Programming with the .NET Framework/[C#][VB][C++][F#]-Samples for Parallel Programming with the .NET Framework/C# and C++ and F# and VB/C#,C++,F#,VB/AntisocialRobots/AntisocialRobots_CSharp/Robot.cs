//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: Robot.cs
//
//--------------------------------------------------------------------------

using System.Windows.Shapes;

namespace AntisocialRobots
{
    /// <summary>Represents one robot.</summary>
    internal class Robot
    {
        /// <summary>The visual element used to represent the robot on the screen.</summary>
        public Ellipse Element;

        /// <summary>The current location of the robot within the room.</summary>
        public RoomPoint Location;

        /// <summary>The game frame in which this robot was last moved.</summary>
        public int LastMovedFrame;
    }
}
