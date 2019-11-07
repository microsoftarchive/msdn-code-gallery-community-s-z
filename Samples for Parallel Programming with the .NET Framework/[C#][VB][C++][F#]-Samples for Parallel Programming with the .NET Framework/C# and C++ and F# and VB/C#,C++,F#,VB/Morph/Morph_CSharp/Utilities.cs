//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: Utilities.cs
//
//--------------------------------------------------------------------------

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ParallelMorph
{
    /// <summary>Helper utilities.</summary>
    public static class Utilities
    {
        /// <summary>Deep clones a serializable object.</summary>
        /// <typeparam name="T">Specifies the type of the object to be cloned.</typeparam>
        /// <param name="source">The source object to be cloned.</param>
        /// <returns>The generated deep clone.</returns>
        public static T DeepClone<T>(T source) where T : class
        {
            using (MemoryStream ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, source);
                ms.Position = 0;
                return (T)formatter.Deserialize(ms);
            }
        }

        /// <summary>Clones an image into a new Bitmap.</summary>
        /// <param name="source">The source image.</param>
        /// <returns>The new Bitmap.</returns>
        public static Bitmap CreateNewBitmapFrom(Image source) 
        { 
            return CreateNewBitmapFrom(source, 1); 
        }

        /// <summary>Creates a copy of the source image by scaling it with the specified scale value.</summary>
        /// <param name="source">The source image.</param>
        /// <param name="scalingFactor">The scaling factor to use when generating the target image.</param>
        /// <returns>The new Bitmap.</returns>
        public static Bitmap CreateNewBitmapFrom(Image source, float scalingFactor)
        {
            return CreateNewBitmapFrom(source, (int)(source.Width*scalingFactor), (int)(source.Height*scalingFactor));
        }

        /// <summary>Creates a copy of the source image using the specified target width and height.</summary>
        /// <param name="source">The source image.</param>
        /// <param name="targetWidth">The target width for the generated image.</param>
        /// <param name="targetHeight">The target height for the generated image.</param>
        /// <returns>The new Bitmap.</returns>
        public static Bitmap CreateNewBitmapFrom(Image source, int targetWidth, int targetHeight)
        {
            var newBmp = new Bitmap(targetWidth, targetHeight, PixelFormat.Format32bppArgb);
            using (var g = Graphics.FromImage(newBmp)) g.DrawImage(source, 0, 0, newBmp.Width, newBmp.Height);
            return newBmp;
        }

        /// <summary>Retrieves an element from a Tuple by item number.</summary>
        /// <typeparam name="T">Specifies the type of data contained in the tuple.</typeparam>
        /// <param name="tuple">The tuple.</param>
        /// <param name="itemNumber">The item number.</param>
        /// <returns>Item1 if itemNumber is 0, otherwise Item2 if itemNumber is 1.</returns>
        public static T Item<T>(this Tuple<T, T> tuple, int itemNumber)
        {
            switch (itemNumber)
            {
                case 0: return tuple.Item1;
                case 1: return tuple.Item2;
                default: throw new ArgumentOutOfRangeException("itemNumber");
            }
        }
    }
}