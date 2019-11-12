using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Filtering
{
    public class Complex
    {
        private double re, im;

        public double Re
        {
            get
            {
                return re;
            }
            set
            {
                re = value;
            }
        }

        public double Im
        {
            get
            {
                return im;
            }
            set
            {
                im = value;
            }
        }

        public Complex()
        {
            re = im = 0.0;
        }

        public Complex(double r, double i)
        {
            re = r;
            im = i;
        }

        public Complex Add(Complex z)
        {
            return new Complex(re + z.re, im + z.im);
        }

        public Complex Sub(Complex z)
        {
            return new Complex(re - z.re, im - z.im);
        }

        public Complex Mul(Complex z)
        {
            double r = re * z.re - im * z.im;
            double i = re * z.im + im * z.re;

            return new Complex(r, i);
        }

        public Complex Div(Complex z)
        {
            double d = z.re * z.re + z.im * z.im;
            double r = (re * z.re + im * z.im) / d;
            double i = (im * z.re - re * z.im) / d;

            return new Complex(r, i);
        }

        public double Abs()
        {
            return Math.Sqrt(re * re + im * im);
        }

        public Complex Exp(Complex z)
        {
            double e = Math.Exp(z.re);
            double r = Math.Cos(z.im);
            double i = Math.Sin(z.im);

            return new Complex(e * r, e * i);
        }

        public Complex[] RecursiveFFT(Complex[] a)
        {
            int n = a.Length;
            int n2 = n / 2;

            if (n == 1)
                return a;

            Complex z = new Complex(0.0, 2.0 * Math.PI / n);
            Complex omegaN = Exp(z);
            Complex omega = new Complex(1.0, 0.0);
            Complex[] a0 = new Complex[n2];
            Complex[] a1 = new Complex[n2];
            Complex[] y0 = new Complex[n2];
            Complex[] y1 = new Complex[n2];
            Complex[] y = new Complex[n];

            for (int i = 0; i < n2; i++)
            {
                a0[i] = new Complex(0.0, 0.0);
                a0[i] = a[2 * i];
                a1[i] = new Complex(0.0, 0.0);
                a1[i] = a[2 * i + 1];
            }

            y0 = RecursiveFFT(a0);
            y1 = RecursiveFFT(a1);

            for (int k = 0; k < n2; k++)
            {
                y[k] = new Complex(0.0, 0.0);
                y[k] = y0[k].Add(y1[k].Mul(omega));
                y[k + n2] = new Complex(0.0, 0.0);
                y[k + n2] = y0[k].Sub(y1[k].Mul(omega));
                omega = omega.Mul(omegaN);
            }

            return y;
        }

        public Complex[] DFT(double[] x)
        {
            double pi2oN = 2.0 * Math.PI / x.Length;
            int k, n;
            Complex[] X = new Complex[x.Length];

            for (k = 0; k < x.Length; k++)
            {
                X[k] = new Complex(0.0, 0.0);

                for (n = 0; n < x.Length; n++)
                {
                    X[k].re += x[n] * Math.Cos(pi2oN * k * n);
                    X[k].im -= x[n] * Math.Sin(pi2oN * k * n);
                }

                X[k].re /= x.Length;
                X[k].im /= x.Length;
            }

            return X;
        }

        public double[] InverseDFT(Complex[] X)
        {
            double[] x = new double[X.Length];
            double imag, pi2oN = 2.0 * Math.PI / X.Length;

            for (int n = 0; n < X.Length; n++)
            {
                imag = x[n] = 0.0;

                for (int k = 0; k < X.Length; k++)
                {
                    x[n] += X[k].re * Math.Cos(pi2oN * k * n)
                          - X[k].im * Math.Sin(pi2oN * k * n);
                    imag += X[k].re * Math.Sin(pi2oN * k * n)
                          + X[k].im * Math.Cos(pi2oN * k * n);
                }
            }

            return x;
        }

        public void BitReversalFFT(int N, Complex[] d)
        {
            double theta = 2.0 * Math.PI / N;
            int mmax = 1, istep;
            Complex Wp = Exp(new Complex(0.0, theta));

            while (N > mmax)
            {
                istep = 2 * mmax;
                Complex W = new Complex(1.0, 0.0);

                for (int m = 0; m < mmax; m++)
                {
                    for (int i = 0; i < N; i += istep)
                    {
                        int j = i + mmax;
                        Complex t = W.Mul(d[j]);
                        d[j] = d[i].Sub(t);
                        d[i] = d[i].Add(t);
                    }

                    W = W.Mul(Wp);
                }

                mmax = istep;
            }
        }

        // This computes an in-place complex-to-complex FFT 
        // x and y are the real and imaginary arrays of 2^m points.
        // dir =  1 gives forward transform
        // dir = -1 gives reverse transform 
        // see http://astronomy.swin.edu.au/~pbourke/analysis/dft/

        public void FFT(short dir, int m, double[] x, double[] y)
        {
            int n, i, i1, j, k, i2, l, l1, l2;
            double c1, c2, tx, ty, t1, t2, u1, u2, z;

            // Calculate the number of points

            n = 1;

            for (i = 0; i < m; i++)
                n *= 2;

            // Do the bit reversal

            i2 = n >> 1;
            j = 0;
            for (i = 0; i < n - 1; i++)
            {
                if (i < j)
                {
                    tx = x[i];
                    ty = y[i];
                    x[i] = x[j];
                    y[i] = y[j];
                    x[j] = tx;
                    y[j] = ty;
                }
                k = i2;

                while (k <= j)
                {
                    j -= k;
                    k >>= 1;
                }

                j += k;
            }

            // Compute the FFT

            c1 = -1.0;
            c2 = 0.0;
            l2 = 1;

            for (l = 0; l < m; l++)
            {
                l1 = l2;
                l2 <<= 1;
                u1 = 1.0;
                u2 = 0.0;

                for (j = 0; j < l1; j++)
                {
                    for (i = j; i < n; i += l2)
                    {
                        i1 = i + l1;
                        t1 = u1 * x[i1] - u2 * y[i1];
                        t2 = u1 * y[i1] + u2 * x[i1];
                        x[i1] = x[i] - t1;
                        y[i1] = y[i] - t2;
                        x[i] += t1;
                        y[i] += t2;
                    }

                    z = u1 * c1 - u2 * c2;
                    u2 = u1 * c2 + u2 * c1;
                    u1 = z;
                }

                c2 = Math.Sqrt((1.0 - c1) / 2.0);

                if (dir == 1)
                    c2 = -c2;

                c1 = Math.Sqrt((1.0 + c1) / 2.0);
            }

            // Scaling for forward transform

            if (dir == 1)
            {
                for (i = 0; i < n; i++)
                {
                    x[i] /= n;
                    y[i] /= n;
                }
            }
        }
    }
}
