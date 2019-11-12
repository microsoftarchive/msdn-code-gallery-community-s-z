//------------------------------------------------------------------
//
//  For licensing information and to get the latest version go to:
//  http://workspaces.gotdotnet.com/3dtools
//
//  THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY
//  OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//  LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
//  FITNESS FOR A PARTICULAR PURPOSE.
//
//------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace _3DTools
{
    public static class MathUtils
    {
        public static double GetAspectRatio(Size size)
        {
            return size.Width / size.Height;
        }

        public static double DegreesToRadians(double degrees)
        {
            return degrees * (Math.PI / 180.0);
        }

        private static Matrix3D GetViewMatrix(ProjectionCamera camera)
        {
            Debug.Assert(camera != null,
                "Caller needs to ensure camera is non-null.");

            // This math is identical to what you find documented for
            // D3DXMatrixLookAtRH with the exception that WPF uses a
            // LookDirection vector rather than a LookAt point.

            Vector3D zAxis = -camera.LookDirection;
            zAxis.Normalize();

            Vector3D xAxis = Vector3D.CrossProduct(camera.UpDirection, zAxis);
            xAxis.Normalize();

            Vector3D yAxis = Vector3D.CrossProduct(zAxis, xAxis);

            Vector3D position = (Vector3D)camera.Position;
            double offsetX = -Vector3D.DotProduct(xAxis, position);
            double offsetY = -Vector3D.DotProduct(yAxis, position);
            double offsetZ = -Vector3D.DotProduct(zAxis, position);

            return new Matrix3D(
                xAxis.X, yAxis.X, zAxis.X, 0,
                xAxis.Y, yAxis.Y, zAxis.Y, 0,
                xAxis.Z, yAxis.Z, zAxis.Z, 0,
                offsetX, offsetY, offsetZ, 1);
        }

        /// <summary>
        ///     Computes the effective view matrix for the given
        ///     camera.
        /// </summary>
        public static Matrix3D GetViewMatrix(Camera camera)
        {
            if (camera == null)
            {
                throw new ArgumentNullException("camera");
            }

            ProjectionCamera projectionCamera = camera as ProjectionCamera;

            if (projectionCamera != null)
            {
                return GetViewMatrix(projectionCamera);
            }

            MatrixCamera matrixCamera = camera as MatrixCamera;

            if (matrixCamera != null)
            {
                return matrixCamera.ViewMatrix;
            }

            throw new ArgumentException(String.Format("Unsupported camera type '{0}'.", camera.GetType().FullName), "camera");
        }

        private static Matrix3D GetProjectionMatrix(OrthographicCamera camera, double aspectRatio)
        {
            Debug.Assert(camera != null,
                "Caller needs to ensure camera is non-null.");

            // This math is identical to what you find documented for
            // D3DXMatrixOrthoRH with the exception that in WPF only
            // the camera's width is specified.  Height is calculated
            // from width and the aspect ratio.

            double w = camera.Width;
            double h = w / aspectRatio;
            double zn = camera.NearPlaneDistance;
            double zf = camera.FarPlaneDistance;

            double m33 = 1 / (zn - zf);
            double m43 = zn * m33;

            return new Matrix3D(
                2 / w, 0, 0, 0,
                  0, 2 / h, 0, 0,
                  0, 0, m33, 0,
                  0, 0, m43, 1);
        }

        private static Matrix3D GetProjectionMatrix(PerspectiveCamera camera, double aspectRatio)
        {
            Debug.Assert(camera != null,
                "Caller needs to ensure camera is non-null.");

            // This math is identical to what you find documented for
            // D3DXMatrixPerspectiveFovRH with the exception that in
            // WPF the camera's horizontal rather the vertical
            // field-of-view is specified.

            double hFoV = MathUtils.DegreesToRadians(camera.FieldOfView);
            double zn = camera.NearPlaneDistance;
            double zf = camera.FarPlaneDistance;

            double xScale = 1 / Math.Tan(hFoV / 2);
            double yScale = aspectRatio * xScale;
            double m33 = (zf == double.PositiveInfinity) ? -1 : (zf / (zn - zf));
            double m43 = zn * m33;

            return new Matrix3D(
                xScale, 0, 0, 0,
                     0, yScale, 0, 0,
                     0, 0, m33, -1,
                     0, 0, m43, 0);
        }

        /// <summary>
        ///     Computes the effective projection matrix for the given
        ///     camera.
        /// </summary>
        public static Matrix3D GetProjectionMatrix(Camera camera, double aspectRatio)
        {
            if (camera == null)
            {
                throw new ArgumentNullException("camera");
            }

            PerspectiveCamera perspectiveCamera = camera as PerspectiveCamera;

            if (perspectiveCamera != null)
            {
                return GetProjectionMatrix(perspectiveCamera, aspectRatio);
            }

            OrthographicCamera orthographicCamera = camera as OrthographicCamera;

            if (orthographicCamera != null)
            {
                return GetProjectionMatrix(orthographicCamera, aspectRatio);
            }

            MatrixCamera matrixCamera = camera as MatrixCamera;

            if (matrixCamera != null)
            {
                return matrixCamera.ProjectionMatrix;
            }

            throw new ArgumentException(String.Format("Unsupported camera type '{0}'.", camera.GetType().FullName), "camera");
        }

        private static Matrix3D GetHomogeneousToViewportTransform(Rect viewport)
        {
            double scaleX = viewport.Width / 2;
            double scaleY = viewport.Height / 2;
            double offsetX = viewport.X + scaleX;
            double offsetY = viewport.Y + scaleY;

            return new Matrix3D(
                 scaleX, 0, 0, 0,
                      0, -scaleY, 0, 0,
                      0, 0, 1, 0,
                offsetX, offsetY, 0, 1);
        }

        /// <summary>
        ///     Computes the transform from world space to the Viewport3DVisual's
        ///     inner 2D space.
        /// 
        ///     This method can fail if Camera.Transform is non-invertable
        ///     in which case the camera clip planes will be coincident and
        ///     nothing will render.  In this case success will be false.
        /// </summary>
        public static Matrix3D TryWorldToViewportTransform(Viewport3DVisual visual, out bool success)
        {
            success = false;
            Matrix3D result = Matrix3D.Identity;

            Camera camera = visual.Camera;

            if (camera == null)
            {
                return ZeroMatrix;
            }

            Rect viewport = visual.Viewport;

            if (viewport == Rect.Empty)
            {
                return ZeroMatrix;
            }

            Transform3D cameraTransform = camera.Transform;

            if (cameraTransform != null)
            {
                Matrix3D m = cameraTransform.Value;

                if (!m.HasInverse)
                {
                    return ZeroMatrix;
                }

                m.Invert();
                result.Append(m);
            }

            result.Append(GetViewMatrix(camera));
            result.Append(GetProjectionMatrix(camera, MathUtils.GetAspectRatio(viewport.Size)));
            result.Append(GetHomogeneousToViewportTransform(viewport));

            success = true;
            return result;
        }

        /// <summary>
        ///     Computes the transform from the inner space of the given
        ///     Visual3D to the 2D space of the Viewport3DVisual which
        ///     contains it.
        /// 
        ///     The result will contain the transform of the given visual.
        /// 
        ///     This method can fail if Camera.Transform is non-invertable
        ///     in which case the camera clip planes will be coincident and
        ///     nothing will render.  In this case success will be false.
        /// </summary>
        /// <param name="visual"></param>
        /// <param name="success"></param>
        /// <returns></returns>
        public static Matrix3D TryTransformTo2DAncestor(DependencyObject visual, out Viewport3DVisual viewport, out bool success)
        {
            success = false;
            Matrix3D to2D = Matrix3D.Identity;
            viewport = null;

            if (!(visual is Visual3D))
            {
                throw new ArgumentException("Must be of type Visual3D.", "visual");
            }

            while (visual != null)
            {
                if (!(visual is ModelVisual3D))
                {
                    break;
                }

                Transform3D transform = (Transform3D) visual.GetValue(ModelVisual3D.TransformProperty);

                if (transform != null)
                {
                    to2D.Append(transform.Value);
                }

                visual = VisualTreeHelper.GetParent(visual);
            }

            viewport = visual as Viewport3DVisual;

            if (viewport == null)
            {
                if (visual != null)
                {
                    // In WPF 3D v1 the only possible configuration is a chain of
                    // ModelVisual3Ds leading up to a Viewport3DVisual.

                    throw new ApplicationException(
                        String.Format("Unsupported type: '{0}'.  Expected tree of ModelVisual3Ds leading up to a Viewport3DVisual.",
                        visual.GetType().FullName));
                }

                return ZeroMatrix;
            }

            success = true;
            to2D.Append(MathUtils.TryWorldToViewportTransform(viewport, out success));

            if (!success)
            {
                return ZeroMatrix;
            }

            return to2D;
        }

        public static readonly Matrix3D ZeroMatrix = new Matrix3D(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
    }
}
