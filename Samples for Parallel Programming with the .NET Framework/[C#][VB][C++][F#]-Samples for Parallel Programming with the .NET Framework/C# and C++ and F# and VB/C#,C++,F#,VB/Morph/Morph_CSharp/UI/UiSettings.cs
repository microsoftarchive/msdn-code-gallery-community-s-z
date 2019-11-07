//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: UiSettings.cs
//
//--------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Drawing;

namespace ParallelMorph
{
    /// <summary>Specifies the output format for a morph.</summary>
    public enum OutputMode
    {
        /// <summary>Render the output as a movie.</summary>
        Movie,
        /// <summary>Render the output as an image sequence.</summary>
        ImageSequence
    }

    /// <summary>Specifies the data to be stored for a morph in a .morph settings file.</summary>
    [Serializable]
    public class SavedSettings
    {
        /// <summary>The source image of the morph.</summary>
        public Image FirstImage;
        /// <summary>The destination image of the morph.</summary>
        public Image SecondImage;
        /// <summary>The collection of morphing lines used to morph from the source to the destination.</summary>
        public LinePairCollection Lines;
        /// <summary>The settings that control the morphing operation.</summary>
        public UiSettings Settings;
    }

    /// <summary>Morph algorithm settings as well as options for rendering a movie.</summary>
	[Serializable]
	public class UiSettings : ComputeMorphOptions
	{
        private int _framesPerSecond = 24;
        private string _fourcc = String.Empty;

		/// <summary>Gets or sets the number of frames per second for the output AVI.</summary>
        [Description("The number of frames per second for an output AVI movie.")]
        [Category("Movie")]
		public int FramesPerSecond
		{
			get { return _framesPerSecond; }
			set
			{
				if (value < 1) throw new ArgumentOutOfRangeException("FramesPerSecond", value, "Must be at least one frame per second.");
				_framesPerSecond = value;
			}
		}

		/// <summary>Gets or sets the FOURCC compression code for the output AVI.</summary>
        [Description("The FOURCC compression code to use for an output AVI movie.")]
        [Category("Movie")]
        public string FourCC
		{
			get { return _fourcc; }
			set 
			{
				if (string.IsNullOrEmpty(value) || value.Length != 4)
				{
					throw new ArgumentOutOfRangeException("FourCC", value, "A FourCC value must be four characters in length.");
				}
				_fourcc = value; 
			}
		}
    }
}
