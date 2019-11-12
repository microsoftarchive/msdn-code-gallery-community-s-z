//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: Cylinder.cs
//
//--------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows;

namespace Reversi
{
    public class Cylinder : ModelVisual3D
    {
        private Material m_material; // we save the material locally to the object so it's easy to get later

        public Cylinder(double radius, double height, int resolution, Material material)
            : base()
        {

            m_material = material;
            // 3 meshes per resolution of a cylineder: the top triange, a bottom triangle, 
            // and a square that makes up the edge of the cylinder
            // this translates to 6 points: the center of the top of the cylinder, 
            // the center of the bottom of the cylinder, and the four points
            // that make up the square

            // constants
            var cylinderMeshGroup = new Model3DGroup();
            // invariant ref points
            var topCenter = new Point3D(0.0, 0.0, height);
            var bottomCenter = new Point3D(0.0, 0.0, 0.0);
            // degrees of the circle that each resolution covers
            var rotateTransform = new RotateTransform(360.0 / resolution);
            // we use this point to determine the 2d dimensional points that make 
            // up the edge of both the top and bottom circles
            var circleReferencePoint = new Point(radius, 0.0);

            // make one mesh object per resolution
            for (int i = 0; i < resolution; ++i)
            {
                // 4 points that make up the edge square
                Point3D topLeft, bottomLeft, topRight, bottomRight;
                topLeft = new Point3D(circleReferencePoint.X, circleReferencePoint.Y, height);
                bottomLeft = new Point3D(circleReferencePoint.X, circleReferencePoint.Y, 0.0);
                // rotate again to find right edge of square
                circleReferencePoint = rotateTransform.Transform(circleReferencePoint);
                topRight = new Point3D(circleReferencePoint.X, circleReferencePoint.Y, height);
                bottomRight = new Point3D(circleReferencePoint.X, circleReferencePoint.Y, 0.0);

                // create top triangle mesh
                var topTriangleMesh = new MeshGeometry3D();
                topTriangleMesh.Positions.Add(topCenter);
                topTriangleMesh.Positions.Add(topLeft);
                topTriangleMesh.Positions.Add(topRight);
                // create bottom triangle mesh
                var bottomTriangleMesh = new MeshGeometry3D();
                bottomTriangleMesh.Positions.Add(bottomCenter);
                bottomTriangleMesh.Positions.Add(bottomRight);
                bottomTriangleMesh.Positions.Add(bottomLeft);
                // create side square mesh
                var sideSquareMesh = new MeshGeometry3D();
                sideSquareMesh.Positions.Add(topLeft);
                sideSquareMesh.Positions.Add(bottomLeft);
                sideSquareMesh.Positions.Add(topRight);
                sideSquareMesh.Positions.Add(bottomRight);
                sideSquareMesh.TriangleIndices.Add(0);
                sideSquareMesh.TriangleIndices.Add(1);
                sideSquareMesh.TriangleIndices.Add(2);
                sideSquareMesh.TriangleIndices.Add(1);
                sideSquareMesh.TriangleIndices.Add(3);
                sideSquareMesh.TriangleIndices.Add(2);

                // add the meshes to the overall cylinder
                // top triangle
                var topTriangleModel = new GeometryModel3D();
                topTriangleModel.Geometry = topTriangleMesh;
                topTriangleModel.Material = material;
                cylinderMeshGroup.Children.Add(topTriangleModel);
                // bottom triangle
                var bottomTriangleModel = new GeometryModel3D();
                bottomTriangleModel.Geometry = bottomTriangleMesh;
                bottomTriangleModel.Material = material;
                cylinderMeshGroup.Children.Add(bottomTriangleModel);
                // side square
                var sideSquareModel = new GeometryModel3D();
                sideSquareModel.Geometry = sideSquareMesh;
                sideSquareModel.Material = material;
                cylinderMeshGroup.Children.Add(sideSquareModel);
            }
            this.Content = cylinderMeshGroup;
            m_centerPoint = new Point3D(0.0, 0.0, 0.0);
            Transform = new Transform3DGroup();
        }

        public Material Material
        {
            get
            {
                return m_material;
            }
        }

        public new Transform3D Transform
        {
            get
            {
                return base.Transform;
            }

            set
            {
                //m_centerPoint = value.Transform(CenterPoint);
                base.Transform = value;
            }
        }

        //public Point3D CenterPoint
        //{
        //    get
        //    {
        //        return m_centerPoint;
        //    }
        //}
        private Point3D m_centerPoint;

        public void MoveTo(Point3D newCenterPoint)
        {

            (Transform as Transform3DGroup).Children.Add( new TranslateTransform3D(Point3D.Subtract(newCenterPoint, m_centerPoint)));
        }
        
   
    }
}

