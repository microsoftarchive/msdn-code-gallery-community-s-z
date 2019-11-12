//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: ISect.cs
//
//--------------------------------------------------------------------------


namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples
{
    class ISect
    {
        public SceneObject Thing;
        public Ray Ray;
        public double Dist;

        public ISect(SceneObject thing, Ray ray, double dist) { Thing = thing; Ray = ray; Dist = dist; }

        public static bool IsNull(ISect sect) { return sect == null; }
        public readonly static ISect Null = null;
    }
}
