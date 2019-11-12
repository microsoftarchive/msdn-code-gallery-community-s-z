//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: LineAndPair.cs
//
//--------------------------------------------------------------------------

using System;
using System.Drawing;

namespace ParallelMorph
{
    [Serializable]
    public class Line : Pair<PointF>
    {
        public Line(PointF first, PointF second) : base(first, second) { }
    }

    [Serializable]
    public class Pair<T>
    {
        public Pair(T item1, T item2) { this.Item1 = item1; this.Item2 = item2; }

        public T Item1 { get; set; }

        public T Item2 { get; set; }

        public T this[int itemNumber]
        {
            get
            {
                switch (itemNumber)
                {
                    case 0: return Item1;
                    case 1: return Item2;
                    default: throw new ArgumentOutOfRangeException("itemNumber");
                }
            }
            set
            {
                switch (itemNumber)
                {
                    case 0: Item1 = value; break;
                    case 1: Item2 = value; break;
                    default: throw new ArgumentOutOfRangeException("itemNumber");
                }
            }
        }
    }
}