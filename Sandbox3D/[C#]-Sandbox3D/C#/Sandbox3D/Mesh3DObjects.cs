using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Shapes;
using System.Windows.Navigation;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Mesh3DObjects
{
	/// <summary>
	/// A custom control.
	///
	/// To use custom controls in markup, you currently need to have them
	/// built into a separate assembly.  .Xaml pages that want to use the control
	/// need to have a mapping PI (Processing Instruction) before the root element:
	/// <?Mapping XmlNamespace="customControls" ClrNamespace="Mesh3DObjects" Assembly="Mesh3DObjects" ?>
	/// Then in the root tag of the .xaml, define a new namespace prefix:
	/// <DockPanel xmlns:cc="customControls" ... >
	/// Then go ahead and use your control in the .xaml somewhere.
	///     <cc:CustomControl1 MyProperty="Hello World" />
	/// </summary>

	public class TorusModelVisual3D : ModelVisual3D
	{
		public TorusModelVisual3D()
		{
			Mesh3DObjects.Torus torusFactory = new Mesh3DObjects.Torus(0.7f, 0.3f);
			Material materialGray = new DiffuseMaterial(new SolidColorBrush(Colors.Gray));
			GeometryModel3D torus = new GeometryModel3D(torusFactory.Mesh, materialGray);
			Transform3DGroup transformGroup3D = new Transform3DGroup();
			transformGroup3D.Children.Add(new ScaleTransform3D(new Vector3D(.1, .1, .1)));
			transformGroup3D.Children.Add(new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0,1,0), 0)));
			transformGroup3D.Children.Add(new TranslateTransform3D(new Vector3D(.1, .1, .1)));
			torus.Transform = transformGroup3D;
			this.Content = torus;			
		}
		public TorusModelVisual3D(Material material)
		{
			Mesh3DObjects.Torus torusFactory = new Mesh3DObjects.Torus(0.7f, 0.3f);
			GeometryModel3D torus = new GeometryModel3D(torusFactory.Mesh, material);
			Transform3DGroup transformGroup3D = new Transform3DGroup();
			transformGroup3D.Children.Add(new ScaleTransform3D(new Vector3D(.1, .1, .1)));
            transformGroup3D.Children.Add(new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 1, 0), 0)));
			transformGroup3D.Children.Add(new TranslateTransform3D(new Vector3D(.1, .1, .1)));
			torus.Transform = transformGroup3D;
			this.Content = torus;			

		}

	
	}

	public class Plane
		{
			// - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
			public Plane()
			{
				corner1 = new Point3D(-1, -1, 0);
				corner2 = new Point3D(1, 1, 0);
				rows = 1;
				columns = 1;
				changed = true;
			}

			// - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
			public Point3D Corner1
			{
				set
				{
					if (value != corner1)
					{
						corner1 = value;
						changed = true;
					}
				}
			}

			// - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
			public Point3D Corner2
			{
				set
				{
					if (value != corner2)
					{
						corner2 = value;
						changed = true;
					}
				}
			}

			// - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
			public int Rows
			{
				set
				{
					if (value != rows)
					{
						rows = value;
						changed = true;
					}
				}
			}

			// - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
			public int Columns
			{
				set
				{
					if (value != columns)
					{
						columns = value;
						changed = true;
					}
				}
			}

			// - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
			public MeshGeometry3D Mesh
			{
				get
				{
					if (changed)
					{
						CreateMesh();
						changed = false;
					}

					return mesh;
				}
			}

			// - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
			private void CreateMesh()
			{
				mesh = new MeshGeometry3D();

				double dx = (corner2.X - corner1.X) / (double)columns;
				double dy = (corner2.Y - corner1.Y) / (double)rows;
				double dz = (corner2.Z - corner1.Z) / (double)columns;
				ushort indices = 0;

				for (int y = 0; y < rows; y++)
				{
					double y0 = corner1.Y + y * dy;
					double y1 = y0 + dy;

					for (int x = 0; x < columns; x++)
					{
						double x0 = corner1.X + x * dx;
						double x1 = x0 + dx;
						double z0 = corner1.Z + x * dz;
						double z1 = z0 + dz;
						Point3D p0 = new Point3D(x0, y0, z0);
						Point3D p1 = new Point3D(x1, y0, z1);
						Point3D p2 = new Point3D(x0, y1, z0);
						Point3D p3 = new Point3D(x1, y1, z1);

						mesh.Positions.Add(p0);
						mesh.Positions.Add(p1);
						mesh.Positions.Add(p2);
						mesh.Positions.Add(p3);

						Vector3D norm = Vector3D.CrossProduct(corner2 - corner1, new Vector3D(0, 1, 0));

						mesh.Normals.Add(norm);
						mesh.Normals.Add(norm);
						mesh.Normals.Add(norm);
						mesh.Normals.Add(norm);

						double tx0 = (double)x / (double)columns;
						double tx1 = (double)(x + 1) / (double)columns;
						double ty0 = (double)y / (double)rows;
						double ty1 = (double)(y + 1) / (double)rows;

						Point tex0 = new Point(tx0, ty1);
						Point tex1 = new Point(tx1, ty1);
						Point tex2 = new Point(tx0, ty0);
						Point tex3 = new Point(tx1, ty0);

						mesh.TextureCoordinates.Add(tex0);
						mesh.TextureCoordinates.Add(tex1);
						mesh.TextureCoordinates.Add(tex2);
						mesh.TextureCoordinates.Add(tex3);
						mesh.TriangleIndices.Add(indices++);  // 0
						mesh.TriangleIndices.Add(indices++);  // 1
						mesh.TriangleIndices.Add(indices++);  // 2
						mesh.TriangleIndices.Add(indices--);  // 3
						mesh.TriangleIndices.Add(indices--);  // 2
						mesh.TriangleIndices.Add(indices++);  // 1
						indices += 2;
					}
				}
			}

			// - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
			private Point3D corner1;

			private Point3D corner2;

			private int rows;

			private int columns;

			private MeshGeometry3D mesh;

			private bool changed;
		}

	public class Cube
	{
		/// <summary>
		/// Class that builds a cube type object 
		/// </summary>
		public Cube()
		{
		}

		// properties
		public MeshGeometry3D Mesh
		{
			get
			{
				if (_mesh == null)
				{
					_mesh = new MeshGeometry3D();

					// vertex's added in z-order
					// vertex 0
					_mesh.Positions.Add(new Point3D(1.0, 1.0, 1.0));
					_mesh.Normals.Add(new Vector3D(0, 0, 1));
					_mesh.TextureCoordinates.Add(new Point(.25, 0));

					// vertex 1
					_mesh.Positions.Add(new Point3D(-1.0, 1.0, 1.0));
					_mesh.Normals.Add(new Vector3D(0, 0, 1));
					_mesh.TextureCoordinates.Add(new Point(0, 0));

					// vertex 2
					_mesh.Positions.Add(new Point3D(-1.0, -1.0, 1.0));
					_mesh.Normals.Add(new Vector3D(0, 0, 1));
					_mesh.TextureCoordinates.Add(new Point(0, 1));

					// vertex 3
					_mesh.Positions.Add(new Point3D(1.0, -1.0, 1.0));
					_mesh.Normals.Add(new Vector3D(0, 0, 1));
					_mesh.TextureCoordinates.Add(new Point(.25, 1));

					// vertex 4
					_mesh.Positions.Add(new Point3D(-1.0, 1.0, -1.0));
					_mesh.Normals.Add(new Vector3D(0, 0, 1));
					_mesh.TextureCoordinates.Add(new Point(.75, 0));

					// vertex 5
					_mesh.Positions.Add(new Point3D(-1.0, -1.0, -1.0));
					_mesh.Normals.Add(new Vector3D(0, 0, 1));
					_mesh.TextureCoordinates.Add(new Point(.75, 1));

					// vertex 6
					_mesh.Positions.Add(new Point3D(1.0, 1.0, -1.0));
					_mesh.Normals.Add(new Vector3D(0, 0, 1));
					_mesh.TextureCoordinates.Add(new Point(.5, 0));

					// vertex 7
					_mesh.Positions.Add(new Point3D(1.0, -1.0, -1.0));
					_mesh.Normals.Add(new Vector3D(0, 0, 1));
					_mesh.TextureCoordinates.Add(new Point(.5, 1));

					// vertex 8 (end wrap)
					_mesh.Positions.Add(new Point3D(-1.0, 1.0, 1.0));
					_mesh.Normals.Add(new Vector3D(0, 0, 1));
					_mesh.TextureCoordinates.Add(new Point(1, 0));

					// vertex 9 (end wrap)
					_mesh.Positions.Add(new Point3D(-1.0, -1.0, 1.0));
					_mesh.Normals.Add(new Vector3D(0, 0, 1));
					_mesh.TextureCoordinates.Add(new Point(1, 1));

					// Front Face
					_mesh.TriangleIndices.Add((ushort)0); _mesh.TriangleIndices.Add((ushort)2); _mesh.TriangleIndices.Add((ushort)1);
					_mesh.TriangleIndices.Add((ushort)0); _mesh.TriangleIndices.Add((ushort)3); _mesh.TriangleIndices.Add((ushort)2);

					// Right Side
					_mesh.TriangleIndices.Add((ushort)6); _mesh.TriangleIndices.Add((ushort)3); _mesh.TriangleIndices.Add((ushort)0);
					_mesh.TriangleIndices.Add((ushort)6); _mesh.TriangleIndices.Add((ushort)7); _mesh.TriangleIndices.Add((ushort)3);

					// Back Side
					_mesh.TriangleIndices.Add((ushort)6); _mesh.TriangleIndices.Add((ushort)7); _mesh.TriangleIndices.Add((ushort)5);
					_mesh.TriangleIndices.Add((ushort)6); _mesh.TriangleIndices.Add((ushort)5); _mesh.TriangleIndices.Add((ushort)4);

					// Left Side
					_mesh.TriangleIndices.Add((ushort)8); _mesh.TriangleIndices.Add((ushort)5); _mesh.TriangleIndices.Add((ushort)4);
					_mesh.TriangleIndices.Add((ushort)8); _mesh.TriangleIndices.Add((ushort)9); _mesh.TriangleIndices.Add((ushort)5);

					// Bottom Side
					_mesh.TriangleIndices.Add((ushort)7); _mesh.TriangleIndices.Add((ushort)5); _mesh.TriangleIndices.Add((ushort)2);
					_mesh.TriangleIndices.Add((ushort)7); _mesh.TriangleIndices.Add((ushort)3); _mesh.TriangleIndices.Add((ushort)2);

					// Top Side
					_mesh.TriangleIndices.Add((ushort)6); _mesh.TriangleIndices.Add((ushort)4); _mesh.TriangleIndices.Add((ushort)1);
					_mesh.TriangleIndices.Add((ushort)6); _mesh.TriangleIndices.Add((ushort)0); _mesh.TriangleIndices.Add((ushort)1);
				}

				return _mesh;
			}
		}

		// private variables
		private MeshGeometry3D _mesh;
	}

	public class Torus
	{
		/// <summary>
		/// Class that builds a torus shape.
		/// </summary>
		/// <param name="innerRadius">Radius of circle defining the skeleton of the torus</param>
		/// <param name="outerRadius">Radius of circle around the skeleton (<i>i.e.,</i> the profile)</param>
		public Torus(float innerRadius, float outerRadius)
		{
			_innerRadius = innerRadius;
			_outerRadius = outerRadius;
			_spineSegments = 25;
			_fleshSegments = 15;
		}

		public Torus()
		{
			_innerRadius = 0.2;
			_outerRadius = 0.05;
			_spineSegments = 25;
			_fleshSegments = 15;
		}

		public MeshGeometry3D Mesh
		{
			get
			{
				if (_mesh == null)
				{
					_mesh = new MeshGeometry3D();

					// The spine is the circle around the hole in the
					// torus, the flesh is a set of circles around the
					// spine.
					int cp = 0;	// Index of	last added point.

					for (int i = 0; i < _spineSegments; ++i)
					{
						double spineParam = ((double)i) / ((double)_spineSegments);
						double spineAngle = Math.PI * 2 * spineParam;
						Vector3D spineVector = new Vector3D(Math.Cos(spineAngle), Math.Sin(spineAngle), 0);

						for (int j = 0; j < _fleshSegments; ++j)
						{
							double fleshParam = ((double)j) / ((double)_fleshSegments);
							double fleshAngle = Math.PI * 2 * fleshParam;
							Vector3D fleshVector = spineVector * Math.Cos(fleshAngle) + new Vector3D(0, 0, Math.Sin(fleshAngle));
							Point3D p = new Point3D(0, 0, 0) + _innerRadius * spineVector + _outerRadius * fleshVector;

							_mesh.Positions.Add(p);
							_mesh.Normals.Add(fleshVector);
							_mesh.TextureCoordinates.Add(new Point(spineParam, fleshParam));

							// Now add a quad that has it's	upper-right	corner at the point	we just	added.
							// i.e.	cp . cp-1 . cp-1-_fleshSegments . cp-_fleshSegments
							int a = cp;
							int b = cp - 1;
							int c = cp - (int)1 - _fleshSegments;
							int d = cp - _fleshSegments;

							// The next two if statements handle the wrapping around of the torus.  For either i = 0 or j = 0
							// the created quad references vertices that haven't been created yet.
							if (j == 0)
							{
								b += _fleshSegments;
								c += _fleshSegments;
							}

							if (i == 0)
							{
								c += _fleshSegments * _spineSegments;
								d += _fleshSegments * _spineSegments;
							}

							_mesh.TriangleIndices.Add((ushort)a); _mesh.TriangleIndices.Add((ushort)b); _mesh.TriangleIndices.Add((ushort)c);
							_mesh.TriangleIndices.Add((ushort)a); _mesh.TriangleIndices.Add((ushort)c); _mesh.TriangleIndices.Add((ushort)d);
							++cp;
						}
					}
				}

				return _mesh;
			}
		}

		public double InnerRadius
		{
			get { return _innerRadius; }
			set
			{
				if (value < 0)
					throw new ArgumentOutOfRangeException("Torus radius must be non-negative");

				_innerRadius = value;
				_mesh = null;
			}
		}

		public double OuterRadius
		{
			get { return _outerRadius; }
			set
			{
				if (value < 0)
					throw new ArgumentOutOfRangeException("Torus radius must be non-negative");

				_outerRadius = value;
				_mesh = null;
			}
		}

		public int FleshSegments
		{
			get
			{
				return _fleshSegments;
			}
			set
			{
				// One segment won't produce a valid triangulation.
				if (value < 2)
					throw new ArgumentOutOfRangeException("Torus segments must be at least 2.");

				_fleshSegments = value;
				_mesh = null;
			}
		}

		public int SpineSegments
		{
			get
			{
				return _spineSegments;
			}
			set
			{
				// One segment won't produce a valid triangulation.
				if (value < 2)
					throw new ArgumentOutOfRangeException("Torus segments must be at least 2.");

				_spineSegments = value;
				_mesh = null;
			}
		}

		private MeshGeometry3D _mesh;

		private double _innerRadius, _outerRadius;

		private int _spineSegments, _fleshSegments;
	}

	public class Cylinder
    {
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public Cylinder()
        {
            height = 2.0;
            longitude = 48;
            radius = 1.0;
            changed = true;
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public double Height
        {
            set
            {
                if (value != height)
                {
                    height = value;
                    changed = true;
                }
            }
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public int Longitude
        {
            set
            {
                if (value != longitude)
                {
                    longitude = value;
                    changed = true;
                }
            }
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public double Radius
        {
            set
            {
                if (value != radius)
                {
                    radius = value;
                    changed = true;
                }
            }
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public MeshGeometry3D Mesh
        {
            get
            {
                if (changed)
                {
                    CreateMesh();
                    changed = false;
                }

                return mesh;
            }
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        private void CreateMesh()
        {
            mesh = new MeshGeometry3D();

            Point3D origin = new Point3D(0, 0, 0);
            Vector3D negY = new Vector3D(0, -1, 0);
            Vector3D posY = new Vector3D(0, 1, 0);
            Point texCoordTop = new Point(0, 0);
            Point texCoordBottom = new Point(0, 1);
            double lonDeltaTheta = 2.0 * Math.PI / (double)longitude;
            double y0 = height / 2;
            double y1 = -y0;
            double lonTheta = Math.PI;
            ushort indices = 0;

            for (int lon = 0; lon < longitude; lon++)
            {
                double u0 = (double)lon / (double)longitude;
                double x0 = radius * Math.Cos(lonTheta);
                double z0 = radius * Math.Sin(lonTheta);

                if (lon == longitude - 1)
                {
                    lonTheta = Math.PI;
                }
                else
                {
                    lonTheta -= lonDeltaTheta;
                }

                double u1 = (double)(lon + 1) / (double)longitude;
                double x1 = radius * Math.Cos(lonTheta);
                double z1 = radius * Math.Sin(lonTheta);
                Point3D p0 = new Point3D(x0, y1, z0);
                Point3D p1 = new Point3D(x0, y0, z0);
                Point3D p2 = new Point3D(x1, y1, z1);
                Point3D p3 = new Point3D(x1, y0, z1);
                Vector3D norm0 = new Vector3D(x0, 0, z0);
                Vector3D norm1 = new Vector3D(x1, 0, z1);

                norm0.Normalize();
                norm1.Normalize();

                // The triangles on the lateral face
                mesh.Positions.Add(p0);
                mesh.Positions.Add(p1);
                mesh.Positions.Add(p2);
                mesh.Positions.Add(p3);
                mesh.Normals.Add(norm0);
                mesh.Normals.Add(norm0);
                mesh.Normals.Add(norm1);
                mesh.Normals.Add(norm1);
                mesh.TextureCoordinates.Add(new Point(u0, 1));
                mesh.TextureCoordinates.Add(new Point(u0, 0));
                mesh.TextureCoordinates.Add(new Point(u1, 1));
                mesh.TextureCoordinates.Add(new Point(u1, 0));
                mesh.TriangleIndices.Add(indices++);  // 0
                mesh.TriangleIndices.Add(indices++);  // 1
                mesh.TriangleIndices.Add(indices++);  // 2
                mesh.TriangleIndices.Add(indices--);  // 3
                mesh.TriangleIndices.Add(indices--);  // 2
                mesh.TriangleIndices.Add(indices++);  // 1
                indices += 2;

                // The triangle at the base
                mesh.Positions.Add(p0);
                mesh.Positions.Add(p2);
                mesh.Positions.Add(new Point3D(0, y1, 0));
                mesh.Normals.Add(negY);
                mesh.Normals.Add(negY);
                mesh.Normals.Add(negY);
                mesh.TextureCoordinates.Add(texCoordBottom);
                mesh.TextureCoordinates.Add(texCoordBottom);
                mesh.TextureCoordinates.Add(texCoordBottom);
                mesh.TriangleIndices.Add(indices++);
                mesh.TriangleIndices.Add(indices++);
                mesh.TriangleIndices.Add(indices++);

                // The triangle at the base
                mesh.Positions.Add(p3);
                mesh.Positions.Add(p1);
                mesh.Positions.Add(new Point3D(0, y0, 0));
                mesh.Normals.Add(posY);
                mesh.Normals.Add(posY);
                mesh.Normals.Add(posY);
                mesh.TextureCoordinates.Add(texCoordTop);
                mesh.TextureCoordinates.Add(texCoordTop);
                mesh.TextureCoordinates.Add(texCoordTop);
                mesh.TriangleIndices.Add(indices++);
                mesh.TriangleIndices.Add(indices++);
                mesh.TriangleIndices.Add(indices++);
            }
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        private double height;

        private int longitude;

        private double radius;

        private bool changed;

        private MeshGeometry3D mesh;
    }

    public class Sphere
    {
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public Sphere()
        {
            latitude = 24;
            longitude = 48;
            radius = 1.0;
            changed = true;
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public int Latitude
        {
            set
            {
                if (value != latitude)
                {
                    latitude = value;
                    changed = true;
                }
            }
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public int Longitude
        {
            set
            {
                if (value != longitude)
                {
                    longitude = value;
                    changed = true;
                }
            }
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public double Radius
        {
            set
            {
                if (value != radius)
                {
                    radius = value;
                    changed = true;
                }
            }
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public MeshGeometry3D Mesh
        {
            get
            {
                if (changed)
                {
                    CreateMesh();
                    changed = false;
                }

                return mesh;
            }
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        private void CreateMesh()
        {

            mesh = new MeshGeometry3D();

            double latTheta = 0.0;
            double latDeltaTheta = Math.PI / latitude;
            double lonTheta = 0.0;
            double lonDeltaTheta = 2.0 * Math.PI / longitude;

            Point3D origin = new Point3D(0, 0, 0);

            // Order of vertex creation:
            //  - For each latitude strip (y := [+radius,-radius] by -increment)
            //      - start at (-x,y,0)
            //      - For each longitude line (CCW about +y ... meaning +y points out of the paper)
            //          - generate vertex for latitude-longitude intersection

            // So if you have a 2x1 texture applied to this sphere:
            //      +---+---+
            //      | A | B |
            //      +---+---+
            // A camera pointing down -z with up = +y will see the "A" half of the texture.
            // "A" is considered to be the front of the sphere.

            for (int lat = 0; lat <= latitude; lat++)
            {
                double v = (double)lat / (double)latitude;
                double y = radius * Math.Cos(latTheta);
                double r = radius * Math.Sin(latTheta);

                if (lat == latitude - 1)
                {
                    latTheta = Math.PI;     // Close the gap in case of precision error
                }
                else
                {
                    latTheta += latDeltaTheta;
                }

                lonTheta = Math.PI;

                for (int lon = 0; lon <= longitude; lon++)
                {
                    double u = (double)lon / (double)longitude;
                    double x = r * Math.Cos(lonTheta);
                    double z = r * Math.Sin(lonTheta);
                    if (lon == longitude - 1)
                    {
                        lonTheta = Math.PI;     // Close the gap in case of precision error
                    }
                    else
                    {
                        lonTheta -= lonDeltaTheta;
                    }

                    Point3D p = new Point3D(x, y, z);
                    Vector3D norm = p - origin;

                    mesh.Positions.Add(p);
                    mesh.Normals.Add(norm);
                    mesh.TextureCoordinates.Add(new Point(u, v));

                    if (lat != 0 && lon != 0)
                    {
                        // The loop just created the bottom right vertex (lat * (longitude + 1) + lon)
                        //  (the +1 comes because of the extra vertex on the seam)
                        // We only create panels when we're at the bottom-right vertex
                        //  (bottom-left, top-right, top-left have all been created by now)
                        //
                        //          +-----------+ x - (longitude + 1)
                        //          |           |
                        //          |           |
                        //      x-1 +-----------+ x

                        int bottomRight = lat * (longitude + 1) + lon;
                        int bottomLeft = bottomRight - 1;
                        int topRight = bottomRight - (longitude + 1);
                        int topLeft = topRight - 1;

                        // Wind counter-clockwise
                        mesh.TriangleIndices.Add(bottomLeft);
                        mesh.TriangleIndices.Add(topRight);
                        mesh.TriangleIndices.Add(topLeft);

                        mesh.TriangleIndices.Add(bottomRight);
                        mesh.TriangleIndices.Add(topRight);
                        mesh.TriangleIndices.Add(bottomLeft);
                    }
                }
            }
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        private int latitude;

        private int longitude;

        private double radius;

        private MeshGeometry3D mesh;

        private bool changed;
    }

    
}
