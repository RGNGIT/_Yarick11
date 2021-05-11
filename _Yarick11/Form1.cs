using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace _Yarick11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<double> Normal = new List<double>();
        List<double> Equal = new List<double>();
        Random random = new Random();

        double GetEqualValue() => (double)random.Next(0, 10);
        double GetNormalValue(int mx, int dx) => (double)(1 / Math.Sqrt(dx) * Math.Sqrt(2 * Math.PI)) * Math.Exp(-1 * (Math.Pow(random.Next(0, 50) - mx, 2)) / 2 * dx);

        List<double> ConcateList()
        {
            List<double> Temp = new List<double>();
            for(int i = 0; i < 50; i++)
            {
                Temp.Add(Normal[i]);
                Temp.Add(Equal[i]);
            }
            Temp.Sort();
            return Temp;
        }

        void Calculate()
        {
            double Average = 0;
            double Dispersion = 0;
            foreach (var i in ConcateList())
            {
                Average += i;
            }
            foreach (var i in ConcateList())
            {
                Dispersion += Math.Pow(i - (Average / ConcateList().Count), 2);
            }
            Dispersion /= ConcateList().Count - 1;
            label4.Text = $"Среднее значение: {Average / ConcateList().Count} Дисперсия: {Dispersion}";
        }

        private void ChartSet()
        {
            label4.Text += "\n";
            int i = 0; double sum = 0;
            foreach (double d in ConcateList())
            {
                if (i % 10 == 0)
                {
                    label4.Text += $"Столб.{i / 10 + 1}: {sum} ";
                    chart1.Series[0].Points.Add(sum);
                    sum = 0;
                }
                else
                {
                    sum += d;
                }
                i++;
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            buttonStart.Visible = false;
            for(int i = 0; i < 50; i++)
            {
                Equal.Add(GetEqualValue());
                Normal.Add(GetNormalValue(5, 4));
                listBox1.Items.Add(Equal[i]);
                listBox2.Items.Add(Normal[i]);
            }
            foreach(double i in ConcateList())
            {
                listBox3.Items.Add(i);
            }
            Calculate();
            ChartSet();
        }
    }
}
