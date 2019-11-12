//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: Camera.cs
//
//--------------------------------------------------------------------------


namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples
{
    class Camera
    {
        public Vector Pos;
        public Vector Forward;
        public Vector Up;
        public Vector Right;

        public Camera(Vector pos, Vector forward, Vector up, Vector right) { Pos = pos; Forward = forward; Up = up; Right = right; }

        public static Camera Create(Vector pos, Vector lookAt)
        {
            Vector forward = Vector.Norm(Vector.Minus(lookAt, pos));
            Vector down = new Vector(0, -1, 0);
            Vector right = Vector.Times(1.5, Vector.Norm(Vector.Cross(forward, down)));
            Vector up = Vector.Times(1.5, Vector.Norm(Vector.Cross(forward, right)));

            return new Camera(pos, forward, up, right);
        }
    }
}
