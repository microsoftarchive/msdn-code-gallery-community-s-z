//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: Plane.cs
//
//--------------------------------------------------------------------------

namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples
{
    class Plane : SceneObject
    {
        public Vector Norm;
        public double Offset;

        public Plane(Vector norm, double offset, Surface surface) : base(surface) { Norm = norm; Offset = offset; }

        public override ISect Intersect(Ray ray)
        {
            double denom = Vector.Dot(Norm, ray.Dir);
            if (denom > 0) return ISect.Null;
            return new ISect(this, ray, (Vector.Dot(Norm, ray.Start) + Offset) / (-denom));
        }

        public override Vector Normal(Vector pos)
        {
            return Norm;
        }
    }
}
