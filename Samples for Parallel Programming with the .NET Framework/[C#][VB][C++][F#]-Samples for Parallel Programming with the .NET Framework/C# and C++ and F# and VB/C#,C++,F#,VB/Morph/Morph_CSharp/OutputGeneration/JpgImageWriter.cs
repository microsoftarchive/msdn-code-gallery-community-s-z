//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: JpgImageWriter.cs
//
//--------------------------------------------------------------------------

using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ParallelMorph
{
    /// <summary>Outputs Bitmap "frames" by writing them as individual files to a folder.</summary>
    public class JpgImageWriter : IImageWriter
    {
        private string _imageFilePrefix;
        private string _directoryPath;
        private int _frameNum = 0;

        public JpgImageWriter(string directoryPath, string imageFilePrefix)
        {
            if (directoryPath == null) throw new ArgumentNullException("directoryPath");
            if (imageFilePrefix == null) throw new ArgumentNullException("imageFilePrefix");
            if (!directoryPath.EndsWith("\\")) directoryPath += "\\";
            _directoryPath = directoryPath;
            _imageFilePrefix = imageFilePrefix;
        }

        public void AddFrame(Bitmap frame)
        {
            frame.Save(_directoryPath + _imageFilePrefix + "_" + _frameNum++ + ".jpg", ImageFormat.Jpeg);
        }

        public void Dispose() { }
    }
}
