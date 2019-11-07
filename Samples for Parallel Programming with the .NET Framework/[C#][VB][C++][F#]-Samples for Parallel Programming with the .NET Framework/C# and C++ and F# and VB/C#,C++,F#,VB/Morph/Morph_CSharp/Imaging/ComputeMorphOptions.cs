//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: ComputeMorphOptions.cs
//
//--------------------------------------------------------------------------

using System;
using System.ComponentModel;

namespace ParallelMorph
{
	/// <summary>Holds settings for the current morph.</summary>
	[Serializable]
	public class ComputeMorphOptions
	{
		private int _numberOfOutputFrames = 48;
        private double _constA = 2.0;
		private double _constB = 2.0;
		private double _constP = .25;

		/// <summary>Gets or sets the number of output frames to generate.</summary>
        [Description("The number of output frames to generate.")]
        [Category("Algorithm")]
		public int NumberOfOutputFrames 
		{ 
			get { return _numberOfOutputFrames; }
			set 
			{ 
				if (value < 3) throw new ArgumentOutOfRangeException("NumberOfFrames", value, "There must be at least three output frames.");
				_numberOfOutputFrames = value; 
			} 
		}

		/// <summary>
		/// If a is barely greater than zero, then if the distance from the line to the pixel is zero, 
		/// the strength is nearly infinite. With this value for a, the user knows that pixels on the 
		/// line will go exactly where he wants them. Values larger than that will yield a more smooth 
		/// warping, but with less precise control.
		/// </summary>
        [Description(
            "If a is barely greater than zero, then if the distance from the line to the pixel is zero, "+
		    "the strength is nearly infinite. With this value for a, the user knows that pixels on the "+
		    "line will go exactly where he wants them. Values larger than that will yield a more smooth "+
		    "warping, but with less precise control.")]
        [Category("Algorithm")]
        public double ConstA 
		{ 
			get { return _constA; } 
			set 
			{ 
				if (value < 0) throw new ArgumentOutOfRangeException("ConstA", value, "Must not be negative.");
				_constA = value; 
			} 
		}
		
		/// <summary>
		/// The variable b determines how the relative strength of different lines falls off with distance. 
		/// If it is large, then every pixel will be affected only by the line nearest it. If b is zero, 
		/// then each pixel will be affected by all lines equally. Values of b in the range [0.5, 2] are the 
		/// most useful.
		/// </summary>
        [Description(
            "The variable b determines how the relative strength of different lines falls off with distance. "+
		    "If it is large, then every pixel will be affected only by the line nearest it. If b is zero, "+
		    "then each pixel will be affected by all lines equally. Values of b in the range [0.5, 2] are the"+ 
		    "most useful.")]
        [Category("Algorithm")]
        public double ConstB 
		{ 
			get { return _constB; } 
			set 
			{ 
				if (value < 0) throw new ArgumentOutOfRangeException("ConstB", value, "Must not be negative.");
				_constB = value; 
			} 
		}
		
		/// <summary>
		/// The value of p is typically in the range [0, 1]. If it is zero, then all lines have the same weight;
		/// if it is one, then longer lines have a greater relative weight than shorter lines.
		/// </summary>
        [Description(
            "The value of p is typically in the range [0, 1]. If it is zero, then all lines have the same weight;"+
            "if it is one, then longer lines have a greater relative weight than shorter lines.")]
        [Category("Algorithm")]
        public double ConstP 
		{ 
			get { return _constP; } 
			set 
			{ 
				if (value < 0) throw new ArgumentOutOfRangeException("ConstP", value, "Must not be negative.");
				_constP = value; 
			} 
		}
    }
}
