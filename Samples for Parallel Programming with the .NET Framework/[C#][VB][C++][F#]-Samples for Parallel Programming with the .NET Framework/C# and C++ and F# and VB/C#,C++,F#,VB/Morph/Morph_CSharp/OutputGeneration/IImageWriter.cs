//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: IImageWriter.cs
//
//--------------------------------------------------------------------------

using System;
using System.Drawing;

namespace ParallelMorph
{
    /// <summary>Used to write out bitmap frames.</summary>
    public interface IImageWriter : IDisposable
    {
        void AddFrame(Bitmap frame);
    }
}
