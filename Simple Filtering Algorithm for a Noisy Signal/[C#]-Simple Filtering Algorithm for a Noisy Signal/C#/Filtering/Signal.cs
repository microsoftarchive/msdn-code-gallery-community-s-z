using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Filtering
{
    class Signal
    {
        private double f(double t)
        {
            double pi2t = 2.0 * Math.PI * t;
            double s1 = 2.0 * Math.Sin(pi2t / 500.0);
            double c1 = Math.Cos(pi2t / 200.0);
            double s2 = 0.5 * Math.Sin(pi2t / 50.0);

            return s1 + c1 - s2;
        }

        public double[] Sample(int n)
        {
            double step = 500.0 / n, t = 0;
            double[] s = new double[n];

            for (int i = 0; i < n; i++)
            {
                s[i] = f(t);
                t += step;
            }

            return s;
        }

        public double[] AddWhiteNoise(int n, int seed, double[] s)
        {
            double sMin = double.MaxValue;
            double sMax = double.MinValue;
            double[] newS = new double[n];
            double[] noise = new double[n];
            Random random = new Random(seed);

            for (int i = 0; i < n; i++)
            {
                if (s[i] < sMin)
                    sMin = s[i];
                if (s[i] > sMax)
                    sMax = s[i];
            }

            for (int i = 0; i < n; i++)
                noise[i] = (sMax - sMin) * random.NextDouble() + sMin;

            for (int i = 0; i < n; i++)
            {
                double newSi = s[i] + noise[i];

                if (newSi < sMin)
                    newSi = sMin;
                if (newSi > sMax)
                    newSi = sMax;

                newS[i] = newSi;
            }

            return newS;
        }

        public double[] Filter(int n, double threshhold, double[] noisy)
        {
            Complex complex = new Complex();
            Complex[] N = complex.DFT(noisy);
            Complex[] S = new Complex[n];
           
            for (int i = 0; i < n; i++)
            {
                if (N[i].Abs() > threshhold)
                    S[i] = new Complex(N[i].Re, N[i].Im);
                else
                    S[i] = new Complex();
            }

            return complex.InverseDFT(S);
        }
    }
}
