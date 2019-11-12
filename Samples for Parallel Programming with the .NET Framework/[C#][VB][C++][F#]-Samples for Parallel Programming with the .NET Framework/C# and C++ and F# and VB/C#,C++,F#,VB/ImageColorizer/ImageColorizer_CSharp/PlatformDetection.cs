//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: PlatformDetection.cs
//
//--------------------------------------------------------------------------

using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using Microsoft.Ink;
using Microsoft.StylusInput;

namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples
{
	/// <summary>
	/// Utility class providing information about Tablet PC libraries and 
	/// functionality that's available for use.
	/// </summary>
	internal sealed class PlatformDetection
	{
		/// <summary>Prevent external instantiation.</summary>
		private PlatformDetection(){}

		/// <summary>Whether the correct version of the Microsoft.Ink.dll assembly is installed and available.</summary>
		private static bool _inkAssemblyAvailable = (LoadInkAssembly() != null);

		/// <summary>Loads the Microsoft.Ink.dll assembly.</summary>
		/// <returns>The Assembly instance for Microsoft.Ink if it's available; null, otherwise.</returns>
		private static Assembly LoadInkAssembly()
		{
			try 
			{ 
				return LoadInkAssemblyInternal(); 
			}
			catch(TypeLoadException) {}
			catch(IOException){}
			catch(SecurityException){}
			catch(BadImageFormatException){}
			return null;
		}

		/// <summary>Loads the Microsoft.Ink.dll assembly.</summary>
		/// <returns>The Assembly instance for Microsoft.Ink.</returns>
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static Assembly LoadInkAssemblyInternal()
		{
			return typeof(InkOverlay).Assembly;
		}

        /// <summary>Gets whether this platform supports using ink.</summary>
        public static bool SupportsInk { get { return InkAssemblyAvailable && RecognizerInstalled; } }

		/// <summary>Gets whether the correct version of the Microsoft.Ink.dll assembly is installed and available.</summary>
		public static bool InkAssemblyAvailable { get { return _inkAssemblyAvailable; } }

		/// <summary>Gets whether a valid recognizer is installed.</summary>
		public static bool RecognizerInstalled
		{
			get
			{
				if (!_inkAssemblyAvailable) return false;
				return GetDefaultRecognizer() != null;
			}
		}

		/// <summary>Gets the best recognizer for the current locale.</summary>
		/// <returns>The best recognizer for the current locale.</returns>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Recognizer GetDefaultRecognizer() 
		{
			Recognizer recognizer = null;
			try 
			{ 
				Recognizers recognizers = new Recognizers();
				if (recognizers.Count > 1)
				{
					// First try the current locale's recognizer
					try { recognizer = recognizers.GetDefaultRecognizer(); } 
					catch {}
					
					// Fallback to the en-US (1033) recognizer
					if (recognizer == null)
					{
						try { recognizer = recognizers.GetDefaultRecognizer(1033); }
						catch {}
					}
				}
			}
			catch {} 
			return recognizer;
		}

		/// <summary>Gets whether a gesture recognizer is installed and available for use.</summary>
		public static bool GestureRecognizerInstalled
		{
			get { return _inkAssemblyAvailable && GestureRecognizerInstalledInternal; }
		}

		/// <summary>Gets whether a gesture recognizer is installed and available for use.</summary>
		/// <remarks>Should only be called if the Microsoft.Ink assembly is already known to be available.</remarks>
		private static bool GestureRecognizerInstalledInternal 
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				try
				{
					Recognizers recognizers = new Recognizers();
					if (recognizers.Count > 0)
					{
						using(new GestureRecognizer()) return true;
					}
				}
				catch{}
				return false;
			}
		}
	}
}