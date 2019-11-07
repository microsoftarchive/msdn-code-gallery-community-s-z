//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: PassthroughImageWriter.cs
//
//--------------------------------------------------------------------------

using System;
using System.Drawing;

namespace ParallelMorph
{
    public class PassthroughImageWriter : IImageWriter
    {
        private IImageWriter _writer;
        private Action<Bitmap> [] _handlers;

        public PassthroughImageWriter(IImageWriter writer, params Action<Bitmap> [] handlers)
        {
            if (writer == null) throw new ArgumentNullException("writer");
            _writer = writer;
            _handlers = handlers;
        }

        public void AddFrame(Bitmap frame)
        {
            if (_handlers != null) foreach (var handler in _handlers) handler(frame);
            _writer.AddFrame(frame);
        }

        void IDisposable.Dispose() {}
    }
}
