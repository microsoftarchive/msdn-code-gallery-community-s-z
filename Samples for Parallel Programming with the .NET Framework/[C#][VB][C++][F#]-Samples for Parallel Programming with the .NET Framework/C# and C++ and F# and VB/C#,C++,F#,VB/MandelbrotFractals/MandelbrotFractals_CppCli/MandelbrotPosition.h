//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: MandelbrotPosition.h
//
//--------------------------------------------------------------------------

#pragma once

value struct MandelbrotPosition
{
public:
	static property MandelbrotPosition Default
	{
		MandelbrotPosition get()
		{
			MandelbrotPosition pos;
			pos.Width = 2.9;
			pos.Height = 2.27;
			pos.CenterX = -.75;
			pos.CenterY = .006;
			return pos;
		}
	}
	double Width, Height, CenterX, CenterY;
};