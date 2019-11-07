//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: SceneObject.cs
//
//--------------------------------------------------------------------------

namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples
{
    abstract class SceneObject
    {
        public Surface Surface;
        public abstract ISect Intersect(Ray ray);
        public abstract Vector Normal(Vector pos);

        public SceneObject(Surface surface) { Surface = surface; }
    }
}
