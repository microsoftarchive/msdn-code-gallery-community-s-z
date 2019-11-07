//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: MandelbrotGenerator.h
//
//--------------------------------------------------------------------------

#pragma once

using namespace System;
using namespace System::Drawing;
using namespace System::Drawing::Imaging;
using namespace System::Threading;
using namespace System::Threading::Tasks;

ref class MandelbrotGenerator
{
public:
	static Bitmap^ Create(MandelbrotPosition position, int width, int height, CancellationToken cancellationToken, bool parallel)
	{
        // Capture all data necessary to render an image
		RenderImageData^ rrd = gcnew RenderImageData(position, width, height);

		// Render in parallel or sequentially
		if (parallel)
		{
			ParallelOptions ^options = gcnew ParallelOptions();
			options->CancellationToken = cancellationToken;
			Parallel::For(0, rrd->ImageHeight, options, gcnew Action<int>(rrd, &RenderImageData::RenderRow));
		}
		else
		{
			for (int row = 0; row < rrd->ImageHeight; row++) 
			{
				cancellationToken.ThrowIfCancellationRequested();
				rrd->RenderRow(row);
			}
		}

        // Produce a Bitmap from the byte array of color indices and return it
		pin_ptr<Byte> scan0 = &(rrd->Data[0]);
		Bitmap tempBitmap(rrd->ImageWidth, rrd->ImageHeight, rrd->ImageWidth, PixelFormat::Format8bppIndexed, (IntPtr)scan0);
		Bitmap^ bitmap = tempBitmap.Clone(Rectangle(0, 0, rrd->ImageWidth, rrd->ImageHeight), PixelFormat::Format8bppIndexed);
        UpdatePalette(bitmap);
        return bitmap;
	}

private:
	static array<Color>^ _paletteColors = CreatePaletteColors();

	static array<Color>^ CreatePaletteColors()
	{
		array<Color>^ paletteColors = gcnew array<Color>(256);
		paletteColors[0] = Color::Black;
		for (int i = 1; i < 256; i++) paletteColors[i] = Color::FromArgb(0, i * 5 % 256, i * 5 % 256); // change this at will for different colorings
		return paletteColors;
	}

	static void UpdatePalette(Bitmap^ bmp)
	{
		ColorPalette^ p = bmp->Palette;
		Array::Copy(_paletteColors, p->Entries, _paletteColors->Length);
		bmp->Palette = p; // The Bitmap will only update when the Palette property's setter is used
	}

	ref class RenderImageData
	{
	public:
		RenderImageData(MandelbrotPosition position, int width, int height)
		{
			ImageWidth = width;
			ImageHeight = height;

			// The maximum number of iterations to perform for each pixel.  Higher number means better
			// quality but also slower.
			MaxIterations = 256;

			// In order to use the Bitmap ctor that accepts a stride, the stride must be divisible by four.
			// We're using imageWidth as the stride, so shift it to be divisible by 4 as necessary.
			if (ImageWidth % 4 != 0) ImageWidth = (ImageWidth / 4) * 4;

			// Based on the fractal bounds, determine its upper left coordinate
			Left = position.CenterX - (position.Width / 2);
			Top = position.CenterY - (position.Height / 2);

			// Get the factors that can be multiplied by row and col to arrive at specific x and y values
			ColToXTranslation = position.Width / (double)ImageWidth;
			RowToYTranslation = position.Height / (double)ImageHeight;

			// Create the byte array that will store the rendered color indices
			Pixels = ImageWidth * ImageHeight;
			Data = gcnew array<Byte>(Pixels); // initialized to all 0s, which equates to all black based on the default palette
		}

		void RenderRow(int row)
		{
			double initialY = row * RowToYTranslation + Top;
			for (int col = 0, currentPixelIndex = row * ImageWidth; col < ImageWidth; col++, currentPixelIndex++)
			{
				double y = initialY, x = col * ColToXTranslation + Left, x0 = x, y0 = y;
				for (int iteration = 0; iteration < MaxIterations; iteration++)
				{
					double x2 = x * x, y2 = y * y;
					if (x2 + y2 > 4)
					{
						Data[currentPixelIndex] = iteration;
						break;
					}
					y = (2 * x * y) + y0;
					x = x2 - y2 + x0;
				}
			}
		}

		int MaxIterations, ImageWidth, ImageHeight, Pixels;
		double Left, Top, ColToXTranslation, RowToYTranslation;
		array<Byte>^ Data;
	};
};