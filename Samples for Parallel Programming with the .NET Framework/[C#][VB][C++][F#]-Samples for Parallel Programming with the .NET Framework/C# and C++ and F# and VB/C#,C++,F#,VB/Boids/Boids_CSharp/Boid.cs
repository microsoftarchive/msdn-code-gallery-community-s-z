//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: Boid.cs
//
//--------------------------------------------------------------------------

using System;
using System.Windows.Media.Media3D;
using System.Windows.Media;
using System.Windows;

namespace ParallelBoids
{
    /// <summary>Represents a Boid.</summary>
    internal class Boid : ModelVisual3D
    {
        /// <summary>The up vector.</summary>
        private static readonly Vector3D UNIT_Y = new Vector3D(0, 1, 0);
        /// <summary>Multiplicative factor to control the size of a boid.</summary>
        private const int MODEL_SCALE = 3;

        /// <summary>Rotation of the boid.</summary>
        private AxisAngleRotation3D _rotation;
        /// <summary>Translation of the boid.</summary>
        private TranslateTransform3D _translation;
        /// <summary>The boid's colors.</summary>
        private Tuple<Color, Color> _colors;
        /// <summary>The brush for the material.</summary>
        private SolidColorBrush _materialBrush;
        /// <summary>The brush for the backmaterial.</summary>
        private SolidColorBrush _backmaterialBrush;

        /// <summary>Initializes the boid.</summary>
        /// <param name="colors">The boids color's, Item1 for Material and Item2 for BackMaterial.</param>
        public Boid(Tuple<Color,Color> colors)
        {
            if (colors == null) throw new ArgumentNullException("colors");

            // Store the colors
            _colors = colors;
            _materialBrush = new SolidColorBrush(colors.Item1);
            _backmaterialBrush = new SolidColorBrush(colors.Item2);

            // Set up the boid's model
            base.Content = new GeometryModel3D()
            {
                Material = new DiffuseMaterial(_materialBrush),
                BackMaterial = new DiffuseMaterial(_backmaterialBrush),
                Geometry = new MeshGeometry3D()
                {
                    // Two perpendicular triangles pointing up
                    Positions = Point3DCollection.Parse("0 1 0  1 -1 0  -1 -1 0  0 1 0  0 -1 1  0 -1 -1"), 
                    Normals = Vector3DCollection.Parse("0 0 -1  1 0 0"),
                    TriangleIndices = Int32Collection.Parse("0 1 2  3 4 5")
                }
            };

            // Initialize its rotation and translation
            _rotation = new AxisAngleRotation3D(UNIT_Y, 0);
            _translation = new TranslateTransform3D(new Vector3D());

            // Add all of the necessary transforms
            var t = new Transform3DGroup();
            t.Children.Add(new ScaleTransform3D(MODEL_SCALE, MODEL_SCALE, MODEL_SCALE));
            t.Children.Add(new RotateTransform3D(_rotation));
            t.Children.Add(_translation);
            base.Transform = t;
        }

        /// <summary>Gets or sets the boid's velocity.</summary>
        public Vector3D Velocity { get; set; }
        /// <summary>Gets or sets the boid's position.</summary>
        public Vector3D Position { get; set; }

        /// <summary>Gets the boid's previous velocity.</summary>
        public Vector3D PreviousVelocity { get; private set; }
        /// <summary>Gets the boid's previous position.</summary>
        public Vector3D PreviousPosition { get; private set; }

        /// <summary>Stores the current position and velocity into the previous.</summary>
        public void StorePositionAndVelocityIntoPrevious()
        {
            PreviousVelocity = Velocity;
            PreviousPosition = Position;
        }

        /// <summary>Sets the boid's rotation and translation for the scene.</summary>
        public void TransformByPositionAndVelocity()
        {
            var direction = Velocity;
            direction.Normalize();

            _rotation.Axis = Vector3D.CrossProduct(UNIT_Y, direction);
            _rotation.Angle = Math.Acos(Vector3D.DotProduct(UNIT_Y, direction) / (UNIT_Y.Length * direction.Length)) * (180 / Math.PI);

            var pos = Position;
            _translation.OffsetX = pos.X;
            _translation.OffsetY = pos.Y;
            _translation.OffsetZ = pos.Z;
        }

        public void ToggleTranslucency()
        {
            _materialBrush.Color = Color.FromArgb(
                _materialBrush.Color.A < 255 ? (byte)255 : (byte)25,
                _materialBrush.Color.R,
                _materialBrush.Color.G,
                _materialBrush.Color.B);
            _backmaterialBrush.Color = Color.FromArgb(
                _backmaterialBrush.Color.A < 255 ? (byte)255 : (byte)25,
                _backmaterialBrush.Color.R,
                _backmaterialBrush.Color.G,
                _backmaterialBrush.Color.B);
        }

        /// <summary>Computes the angle between two boids based on the current boid's direction.</summary>
        /// <param name="other">The other boid.</param>
        /// <returns>The angle.</returns>
        public double ComputeAngle(Boid other)
        {
            if (other == null) throw new ArgumentNullException("comparisonBoid");
            return Math.Acos(
                Vector3D.DotProduct(this.PreviousVelocity, other.PreviousPosition - this.PreviousPosition) /
                    (this.PreviousVelocity.Length * (other.PreviousPosition - this.PreviousPosition).Length))
                * (180 / Math.PI);
        }

        MeshGeometry3D GenerateSphere(Point3D center, double radius, int slices, int stacks)
        {
            // Create the MeshGeometry3D.
            MeshGeometry3D mesh = new MeshGeometry3D();

            // Fill the Position, Normals, and TextureCoordinates collections.
            for (int stack = 0; stack <= stacks; stack++)
            {
                double phi = Math.PI / 2 - stack * Math.PI / stacks;
                double y = radius * Math.Sin(phi);
                double scale = -radius * Math.Cos(phi);

                for (int slice = 0; slice <= slices; slice++)
                {
                    double theta = slice * 2 * Math.PI / slices;
                    double x = scale * Math.Sin(theta);
                    double z = scale * Math.Cos(theta);

                    Vector3D normal = new Vector3D(x, y, z);
                    mesh.Normals.Add(normal);
                    mesh.Positions.Add(normal + center);
                    mesh.TextureCoordinates.Add(new Point((double)slice / slices, (double)stack / stacks));
                }
            }

            // Fill the TriangleIndices collection.
            for (int stack = 0; stack < stacks; stack++)
            {
                for (int slice = 0; slice < slices; slice++)
                {
                    int n = slices + 1; // Keep the line length down.

                    if (stack != 0)
                    {
                        mesh.TriangleIndices.Add((stack + 0) * n + slice);
                        mesh.TriangleIndices.Add((stack + 1) * n + slice);
                        mesh.TriangleIndices.Add((stack + 0) * n + slice + 1);
                    }
                    if (stack != stacks - 1)
                    {
                        mesh.TriangleIndices.Add((stack + 0) * n + slice + 1);
                        mesh.TriangleIndices.Add((stack + 1) * n + slice);
                        mesh.TriangleIndices.Add((stack + 1) * n + slice + 1);
                    }
                }
            }
            return mesh;
        }
    }
}
