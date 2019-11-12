using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace TSPSolvers
{
    public partial class MainForm : Form
    {
        private bool randomTSP;
        private double[] X;
        private double[] Y;
        private int N, seed;
        private Algorithms algos = new Algorithms();
        private List<City> lCity;

        public MainForm()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            checkBox1.Enabled = true;
            checkBox1.Checked = true;
            button1.Enabled = false;
            button3.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int number = 0;
                StreamReader sr = new StreamReader(
                    openFileDialog1.FileName);

                string line = sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    if (line.Contains("DIMENSION"))
                    {
                        StringBuilder sb = new StringBuilder();

                        for (int i = 0; i < line.Length; i++)
                        {
                            char c = line[i];

                            if (c >= '0' && c <= '9')
                                sb.Append(c);
                        }

                        number = int.Parse(sb.ToString());

                        break;
                    }

                    line = sr.ReadLine();
                }

                X = new double[number];
                Y = new double[number];

                int count = 0;

                line = sr.ReadLine();

                while (line != null && line.Length != 0)
                {
                    if (line[0] >= '0' && line[0] <= '9')
                    {
                        StringBuilder sb = new StringBuilder();
                        int i, j;

                        for (i = 0; i < line.Length; i++)
                        {
                            char c = line[i];

                            if (c >= '0' && c <= '9')
                                sb.Append(c);

                            else
                                break;
                        }

                        sb = new StringBuilder();

                        for (j = i + 1; j < line.Length; j++)
                        {
                            char c = line[j];

                            if (c >= '0' && c <= '9' || c == '.')
                                sb.Append(c);

                            else
                                break;
                        }

                        X[count] = double.Parse(sb.ToString());

                        sb = new StringBuilder();

                        for (i = j + 1; i < line.Length; i++)
                        {
                            char c = line[i];

                            if (c >= '0' && c <= '9' || c == '.')
                                sb.Append(c);

                            else
                                break;
                        }

                        Y[count++] = double.Parse(sb.ToString());
                    }

                    line = sr.ReadLine();
                }

                sr.Close();

                N = number;
                button1.Enabled = false;
                button2.Enabled = true;
                lCity = new List<City>(N);

                for (int i = 0; i < N; i++)
                    lCity.Add(new City(X[i], Y[i], i));
            }
        }

        private void PrintTime(Stopwatch sw)
        {
            TimeSpan ts = sw.Elapsed;

            textBox1.Text += ts.Hours.ToString("D2") + ":";
            textBox1.Text += ts.Minutes.ToString("D2") + ":";
            textBox1.Text += ts.Seconds.ToString("D2") + ".";
            textBox1.Text += ts.Milliseconds.ToString("D3") + "\r\n";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            button2.Enabled = false;
            button3.Enabled = false;

            if (randomTSP)
            {
                City[] initial = algos.GenerateRandomInitial(N, seed);

                lCity = new List<City>(initial);
            }

            bool saga = false;
            double fS = 0, bestfS = double.MaxValue;
            double[] fitness = null;
            int method = comboBox1.SelectedIndex;
            int restarts = (int)numericUpDown1.Value;
            City[] best, result;
            City[,] chromosome = null;
            List<City> S = new List<City>(lCity);
            List<City> SS = null;

            textBox1.Text += N.ToString() + "\r\n";
            textBox1.Text += (string)comboBox1.SelectedItem + "\r\n";

            switch (method)
            {
                case 0:
                    for (int i = 0; i < 40000 * restarts; i++)
                    {
                        SS = algos.SDLS(N, S, out fS);
                        S = new List<City>(SS);

                        if (fS < bestfS)
                        {
                            bestfS = fS;
                            best = S.ToArray();
                        }
                    }

                    break;
                case 1:
                    for (int i = 0; i < restarts; i++)
                    {
                        SS = algos.TabuSearch(N, 1000 * N, S, out fS);
                        S = new List<City>(SS);

                        if (fS < bestfS)
                        {
                            bestfS = fS;
                            best = S.ToArray();
                        }
                    }

                    break;
                case 2:
                    for (int i = 0; i < restarts; i++)
                    {
                        result = algos.EvolutionaryHillClimber(N, 10000 * N, 100 * N,
                            S.ToArray(), out fS, ref chromosome, ref fitness);
                        S = new List<City>(result);

                        if (fS < bestfS)
                        {
                            bestfS = fS;
                            best = S.ToArray();
                        }
                    }

                    break;
                case 3:
                    for (int i = 0; i < restarts; i++)
                    {
                        result = algos.GeneticAlgortihm(0.10, 1.00, N, 10000 * N, 100 * N,
                            S.ToArray(), out fS, ref chromosome, ref fitness);
                        S = new List<City>(result);

                        if (fS < bestfS)
                        {
                            bestfS = fS;
                            best = S.ToArray();
                        }
                    }

                    break;
                case 4:
                    int count1, count2, count3, count4;

                    for (int i = 0; i < restarts; i++)
                    {
                        algos.SimulatedAnnealing(N, 10000, 10000 * N, N, S.ToArray(),
                            out result, out fS, out count1, out count2, out count3, out count4);
                        S = new List<City>(result);

                        if (fS < bestfS)
                        {
                            bestfS = fS;
                            best = S.ToArray();
                        }
                    }

                    if (saga)
                        goto case 3;

                    break;
                case 5:
                    saga = true;
                    goto case 4;
                case 6:
                    for (int i = 0; i < restarts; i++)
                    {
                        algos.SimulatedAnnealing(N, 10000, 100000, 20, S.ToArray(),
                            out result, out fS, out count1, out count2, out count3, out count4);
                        S = new List<City>(result);

                        if (fS < bestfS)
                        {
                            bestfS = fS;
                            best = S.ToArray();
                        }

                        result = algos.GeneticAlgortihm(0.10, 1.00, N, 10000 * N, 100 * N,
                            S.ToArray(), out fS, ref chromosome, ref fitness);
                        S = new List<City>(result);

                        if (fS < bestfS)
                        {
                            bestfS = fS;
                            best = S.ToArray();
                        }
                    }

                    break;
                case 7:
                    for (int i = 0; i < restarts; i++)
                    {
                        algos.SASDLS(N, 10000, 5000, 10, S.ToArray(),
                            out result, out fS, out count1, out count2, out count3, out count4);
                        S = new List<City>(result);

                        if (fS < bestfS)
                        {
                            bestfS = fS;
                            best = S.ToArray();
                        }
                    }

                    break;
                case 8:
                    if (randomTSP)
                        best = algos.BruteForce(N, lCity.ToArray(), out bestfS);

                    else
                        MessageBox.Show("Random must be checked", "Warning Message",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    break;
            }

            textBox1.Text += bestfS.ToString("F2") + "\r\n";
            sw.Stop();
            PrintTime(sw);

            if (!randomTSP)
                button1.Enabled = true;

            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                N = (int)numericUpDown2.Value;
                seed = (int)numericUpDown3.Value;
                randomTSP = true;
                button1.Enabled = false;
                button2.Enabled = true;
                numericUpDown2.Enabled = true;
                numericUpDown3.Enabled = true;
            }

            else
            {
                randomTSP = false;
                button1.Enabled = true;
                button2.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            N = (int)numericUpDown2.Value;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            seed = (int)numericUpDown2.Value;
        }
    }
}