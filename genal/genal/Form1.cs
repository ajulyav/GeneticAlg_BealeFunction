using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;


namespace genal
{
    public partial class Form1 : Form
    {
        public static Random r;
        public Form1()
        {

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            r = new Random();
            Popul p = new Popul();
            p.Pop_size =  Convert.ToInt32(textBox5.Text);
            p.iteration = Convert.ToInt32(textBox4.Text);
            p.mut_proba = Convert.ToDouble(textBox8.Text);
            p.cross_proba = Convert.ToDouble(textBox9.Text);
            p.e = 0.01;
            p.n_GEN = Convert.ToInt32(textBox7.Text);
            Hrom final = new Hrom();

            string cros_value = null;
            string mut_value = null;
            string sel_value = null;

            if (radioButton1.Checked==true)
            {
                cros_value = "arif";
            }
            else
            {
                cros_value = "lin";
            }

            if (radioButton3.Checked == true)
            {
                mut_value = "rand";
            }
            else
            {
                mut_value = "real";
            }

            if (radioButton5.Checked == true)
            {
                sel_value = "rand";
            }
            else
            {
                sel_value = "roul";
            }
            

           final = p.Start(cros_value, mut_value, sel_value);
           textBox1.Text = final.fitness.ToString();
           textBox6.Text = (final.fitness-0).ToString();

           textBox2.Text = final.Gen_array[0].X_gen.ToString();
           textBox3.Text = final.Gen_array[1].X_gen.ToString();

           ArrayList points = new ArrayList();

           points.AddRange(p.best_fitnessdouble);

           chart1.Series[0].Points.Clear();
           chart1.Series["Series1"].BorderWidth = 2;
           chart1.ChartAreas[0].AxisX.Minimum = 0;
           chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;

           for (int i = 0; i < points.Count; i++)
           {
                chart1.Series[0].Points.AddXY(i, points[i]);
           }


        }

    }
}
