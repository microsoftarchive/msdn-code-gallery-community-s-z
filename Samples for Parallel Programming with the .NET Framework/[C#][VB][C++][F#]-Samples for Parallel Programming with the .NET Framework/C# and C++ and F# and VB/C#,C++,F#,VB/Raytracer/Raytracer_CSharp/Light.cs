//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: Light.cs
//
//--------------------------------------------------------------------------

namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples
{
    class Light
    {
        public Vector Pos;
        public Color Color;

        public Light(Vector pos, Color color) { Pos = pos; Color = color; }
    }
}
