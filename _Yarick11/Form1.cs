using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        double GetEqualValue()
        {
            Random random = new Random();
            int a = random.Next(-10, 20);
            return a < 0 || a > 10 ? 0 : 0.1;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < 50; i++)
            {
                Equal.Add(GetEqualValue());
            }
            foreach(double i in Equal)
            {
                listBox1.Items.Add(i);
            }
        }
    }
}
