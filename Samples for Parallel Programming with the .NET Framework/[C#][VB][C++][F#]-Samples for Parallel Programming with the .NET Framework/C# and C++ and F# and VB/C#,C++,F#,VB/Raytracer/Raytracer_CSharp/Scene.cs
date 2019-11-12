//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: Scene.cs
//
//--------------------------------------------------------------------------

using System.Collections.Generic;

namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples
{
    class Scene
    {
        public SceneObject[] Things;
        public Light[] Lights;
        public Camera Camera;

        public Scene(SceneObject[] things, Light[] lights, Camera camera) { Things = things; Lights = lights; Camera = camera; }

        public IEnumerable<ISect> Intersect(Ray r)
        {
            foreach (SceneObject obj in Things)
            {
                yield return obj.Intersect(r);
            }
        }
    }
}
