// permutation generator
// arrays are FORTRAN 1-based

namespace TSPSolvers
{
    class Generator
    {
        private int Factorial(int n)
        {
            if (n < 1)
                return 1;
            else
                return n * Factorial(n - 1);
        }

        private void Divide(int a, int b, ref int q, ref int r)
        {
            q = a / b;
            r = a - q * b;
        }

        public double TourLength(int N, City[] city)
        {
            double length = 0;

            for (int i = 0; i < N - 1; i++)
                length += city[i].Distance(city[i + 1]);

            length += city[N - 1].Distance(city[0]);
            return length;
        }

        public City[] Generate(int n, City[] initial, out double fS)
        {
            double testfS = 0;
            int[] x = new int[n + 1];
            City[] best = new City[n];
            City[] test = new City[n];

            for (int i = 1; i <= n; i++)
                x[i] = i;

            for (int i = 0; i < n; i++)
                test[i] = initial[x[i + 1] - 1];

            fS = double.MaxValue;
            testfS = TourLength(n, test);

            if (testfS < fS)
            {
                fS = testfS;

                for (int i = 0; i < n; i++)
                    best[i] = test[i];
            }

            for (int i = 1; i < Factorial(n); i++)
            {
                int numer = i;
                int[] p = new int[n + 1];

                for (int j = 1; j <= n; j++)
                    p[j] = -1;

                for (int j = 1; j <= n; j++)
                {
                    int m = Factorial(n - j);
                    int count = 0, q = -1, r = -1, s = -1;

                    Divide(numer, m, ref q, ref r);

                    if (r != 0)
                    {
                        count = 1;
                        s = q + 1;
                    }

                    else
                        s = q;

                    for (int k = 1; k <= n; k++)
                    {
                        if (p[k] == -1)
                        {
                            if (count == s)
                            {
                                p[k] = j;
                                break;
                            }

                            count++;
                        }
                    }

                    numer = r;
                }

                for (int j = 0; j < n; j++)
                    test[j] = initial[p[j + 1] - 1];

                testfS = TourLength(n, test);

                if (testfS < fS)
                {
                    fS = testfS;

                    for (int j = 0; j < n; j++)
                        best[j] = test[j];
                }
            }

            return best;
        }
    }
}
