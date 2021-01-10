using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace Heart_Rate_Krzysztof_Oko
{
    public partial class Form1 : Form
    {
        String name;
        int age;
        int maxhr;
        int maxhr_85;
        int x;
        int[] x_values = new int[5];
        Hashtable xy_cord = new Hashtable();
        int[] y_values = new int[5];
        int meanx;
        int meany;
        int meanxy;
        int meanxsqr;
        float m;
        float xbar;
        float ybar;
        int b;
        int[] y_cord = new int[5];
        float max_x;
        int count;
        Dictionary<string, string> listdata = new Dictionary<string, string>();
        bool[] colored = new bool[5];

        public Form1()
        {
            InitializeComponent();
            var chart = chart1.ChartAreas[0];
            chart1.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart.AxisX.Interval = 5;
            chart.AxisY.Interval = 50;
            chart1.Series.Add("Value");
            chart1.Series["Value"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Value"].Color = Color.Green;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 200;
            chart1.Series["Value"].BorderWidth = 4;
            chart1.Series["Series1"].BorderWidth = 3;
        }

        public void calculate()
        {
            for (int i = 0; i < y_values.Length; i++)
            {
                int div = 0;
                if (y_values[i] > 0)
                    div = maxhr / y_values[i];

                if (div >= 2 || y_values[i] >= maxhr_85 || y_values[i] == 0)
                {
                    colored[i] = false;
                }
                else
                {
                    colored[i] = true;
                    xy_cord.Add(x_values[i], y_values[i]);
                    count++;
                }
            }

            foreach (DictionaryEntry value in xy_cord)
            {
                meanx = meanx + Int32.Parse(value.Key.ToString());
                meany = meany + Int32.Parse(value.Value.ToString());
                meanxy = meanxy + (Int32.Parse(value.Key.ToString()) * Int32.Parse(value.Value.ToString()));
            }

            foreach (DictionaryEntry value in xy_cord)
            {
                meanxsqr = meanxsqr + (Int32.Parse(value.Key.ToString()) * Int32.Parse(value.Key.ToString()));
            }

            m = (meanxy - ((meanx * meany) / count)) / (meanxsqr - ((meanx * meanx) / count));

            xbar = meanx / count;
            ybar = meany / count;

            b = (int)(ybar - (m * xbar));

            max_x = ((maxhr - b) / m);

            Dictionary<int, int> sd = xy_cord.Cast<DictionaryEntry>().ToDictionary(kvp => (int)kvp.Key, kvp => (int)kvp.Value);
            SortedDictionary<int, int> ans = new SortedDictionary<int, int>(sd);

            chart1.Series["Series1"].Points.AddXY(0, b);
            chart1.Series["Series1"].Points.AddXY(max_x, maxhr);
            chart1.Series["Series1"].Points.AddXY(max_x, 0);

            ResultLAb.Text = max_x.ToString();
            ResultLAb.Visible = true;
            ResultLAb.ForeColor = System.Drawing.Color.Green;
            ResultLAb.Font = new Font("Font Name", 16, FontStyle.Regular);
            foreach (int value in ans.Keys)
            {
                chart1.Series["Value"].Points.AddXY(Int32.Parse(value.ToString()), Int32.Parse(ans[value].ToString()));
            }

            chart1.Visible = true;
            WomanLab.Visible = true;
            MenLab.Visible = true;
            updateman();
            updatewoman();
            updateTextBox();

        }

        private void updateTextBox()
        {
            if (colored[0] == true)
                numericUpDown2.ForeColor = Color.Green;
            else
                numericUpDown2.ForeColor = Color.Red;
            if (colored[1] == true)
                numericUpDown3.ForeColor = Color.Green;
            else
                numericUpDown3.ForeColor = Color.Red;
            if (colored[2] == true)
                numericUpDown4.ForeColor = Color.Green;
            else
                numericUpDown4.ForeColor = Color.Red;
            if (colored[3] == true)
                numericUpDown5.ForeColor = Color.Green;
            else
                numericUpDown5.ForeColor = Color.Red;
            if (colored[4] == true)
                numericUpDown6.ForeColor = Color.Green;
            else
                numericUpDown6.ForeColor = Color.Red;

            numericUpDown2.Enabled = true;
            numericUpDown3.Enabled = true;
            numericUpDown4.Enabled = true;
            numericUpDown5.Enabled = true;
            numericUpDown6.Enabled = true;
        }

        private void updatewoman()
        {
            if (age >= 15 && age <= 19)
            {
                if (max_x >= 29 && max_x <= 35)
                    WomanLab.Text = "Below Average";
                else if (max_x >= 36 && max_x <= 43)
                    WomanLab.Text = "Average";
                else if (max_x >= 44 && max_x <= 54)
                    WomanLab.Text = "Good";
                else if (max_x >= 55)
                    WomanLab.Text = "Excellent";
                else
                    WomanLab.Text = "Poor";
            }

            else if (age >= 20 && age <= 29)
            {
                if (max_x >= 27 && max_x <= 31)
                    WomanLab.Text = "Below Average";
                else if (max_x >= 32 && max_x <= 39)
                    WomanLab.Text = "Average";
                else if (max_x >= 40 && max_x <= 49)
                    WomanLab.Text = "Good";
                else if (max_x >= 50)
                    WomanLab.Text = "Excellent";
                else
                    WomanLab.Text = "Poor";
            }
            else if (age >= 30 && age <= 39)
            {
                if (max_x >= 25 && max_x <= 29)
                    WomanLab.Text = "Below Average";
                else if (max_x >= 30 && max_x <= 35)
                    WomanLab.Text = "Average";
                else if (max_x >= 36 && max_x <= 45)
                    WomanLab.Text = "Good";
                else if (max_x >= 46)
                    WomanLab.Text = "Excellent";
                else
                    WomanLab.Text = "Poor";
            }
            else if (age >= 40 && age <= 49)
            {
                if (max_x >= 22 && max_x <= 27)
                    WomanLab.Text = "Below Average";
                else if (max_x >= 28 && max_x <= 33)
                    WomanLab.Text = "Average";
                else if (max_x >= 34 && max_x <= 42)
                    WomanLab.Text = "Good";
                else if (max_x >= 43)
                    WomanLab.Text = "Excellent";
                else
                    WomanLab.Text = "Poor";
            }
            else if (age >= 50 && age <= 59)
            {
                if (max_x >= 21 && max_x <= 25)
                    WomanLab.Text = "Below Average";
                else if (max_x >= 26 && max_x <= 32)
                    WomanLab.Text = "Average";
                else if (max_x >= 33 && max_x <= 40)
                    WomanLab.Text = "Good";
                else if (max_x >= 41)
                    WomanLab.Text = "Excellent";
                else
                    WomanLab.Text = "Poor";
            }
            else if (age >= 60 && age <= 65)
            {
                if (max_x >= 19 && max_x <= 23)
                    WomanLab.Text = "Below Average";
                else if (max_x >= 24 && max_x <= 30)
                    WomanLab.Text = "Average";
                else if (max_x >= 31 && max_x <= 38)
                    WomanLab.Text = "Good";
                else if (max_x >= 39)
                    WomanLab.Text = "Excellent";
                else
                    WomanLab.Text = "Poor";
            }

        }

        private void updateman()
        {
            if (age >= 15 && age <= 19)
            {
                if (max_x >= 30 && max_x <= 38)
                    MenLab.Text = "Below Average";
                else if (max_x >= 39 && max_x <= 47)
                    MenLab.Text = "Average";
                else if (max_x >= 48 && max_x <= 59)
                    MenLab.Text = "Good";
                else if (max_x >= 60)
                    MenLab.Text = "Excellent";
                else
                    MenLab.Text = "Poor";
            }

            else if (age >= 20 && age <= 29)
            {
                if (max_x >= 28 && max_x <= 34)
                    MenLab.Text = "Below Average";
                else if (max_x >= 35 && max_x <= 43)
                    MenLab.Text = "Average";
                else if (max_x >= 44 && max_x <= 54)
                    MenLab.Text = "Good";
                else if (max_x >= 55)
                    MenLab.Text = "Excellent";
                else
                    MenLab.Text = "Poor";
            }
            else if (age >= 30 && age <= 39)
            {
                if (max_x >= 26 && max_x <= 33)
                    MenLab.Text = "Below Average";
                else if (max_x >= 34 && max_x <= 39)
                    MenLab.Text = "Average";
                else if (max_x >= 40 && max_x <= 49)
                    MenLab.Text = "Good";
                else if (max_x >= 50)
                    MenLab.Text = "Excellent";
                else
                    MenLab.Text = "Poor";
            }
            else if (age >= 40 && age <= 49)
            {
                if (max_x >= 25 && max_x <= 31)
                    MenLab.Text = "Below Average";
                else if (max_x >= 32 && max_x <= 36)
                    MenLab.Text = "Average";
                else if (max_x >= 37 && max_x <= 45)
                    MenLab.Text = "Good";
                else if (max_x >= 46)
                    MenLab.Text = "Excellent";
                else
                    MenLab.Text = "Poor";
            }
            else if (age >= 50 && age <= 59)
            {
                if (max_x >= 23 && max_x <= 28)
                    MenLab.Text = "Below Average";
                else if (max_x >= 29 && max_x <= 34)
                    MenLab.Text = "Average";
                else if (max_x >= 35 && max_x <= 43)
                    MenLab.Text = "Good";
                else if (max_x >= 44)
                    MenLab.Text = "Excellent";
                else
                    MenLab.Text = "Poor";
            }
            else if (age >= 60 && age <= 65)
            {
                if (max_x >= 20 && max_x <= 24)
                    MenLab.Text = "Below Average";
                else if (max_x >= 25 && max_x <= 32)
                    MenLab.Text = "Average";
                else if (max_x >= 33 && max_x <= 39)
                    MenLab.Text = "Good";
                else if (max_x >= 40)
                    MenLab.Text = "Excellent";
                else
                    MenLab.Text = "Poor";
            }
        }

        public void setName()
        {
            TesterNameLabel.Text = Form2.name;
            Stepheightlabel.Text = Form2.step.ToString();

            TesterNameLabel.Font = new Font("Font Name", 16, FontStyle.Regular);
            Stepheightlabel.Font = new Font("Font Name", 16, FontStyle.Regular);
            x = Form2.step;
            switch (x)
            {
                case 15:
                    {
                        x_values[0] = 11;
                        x_values[1] = 14;
                        x_values[2] = 18;
                        x_values[3] = 21;
                        x_values[4] = 25;
                        break;
                    }

                case 20:
                    {
                        x_values[0] = 12;
                        x_values[1] = 17;
                        x_values[2] = 21;
                        x_values[3] = 25;
                        x_values[4] = 29;
                        break;
                    }

                case 25:
                    {
                        x_values[0] = 14;
                        x_values[1] = 19;
                        x_values[2] = 24;
                        x_values[3] = 28;
                        x_values[4] = 33;
                        break;
                    }

                case 30:
                    {
                        x_values[0] = 16;
                        x_values[1] = 21;
                        x_values[2] = 27;
                        x_values[3] = 32;
                        x_values[4] = 37;
                        break;
                    }

                default: break;


            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2.form2.Close();
            this.Close();
            Application.Exit();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            NameTB.Text = "";
            AgeTB.Text = "";
            MAXHRTB.Text = "";
            MAXhr_85TB.Text = "";
            numericUpDown2.Text = "";
            numericUpDown3.Text = "";
            numericUpDown4.Text = "";
            numericUpDown5.Text = "";
            numericUpDown6.Text = "";
            ResultLAb.Text = "";
            chart1.Visible = false;
            NameTB.Enabled = true;
            AgeTB.Enabled = true;
            MAXHRTB.Enabled = true;
            MAXhr_85TB.Enabled = true;
            checkBox1.Enabled = true;
            checkBox2.Enabled = true;
            checkBox3.Enabled = true;
            button1.Enabled = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked || checkBox2.Checked || checkBox3.Checked)
            {
                try
                {
                    name = NameTB.Text;
                    age = Int32.Parse(AgeTB.Value.ToString());
                    maxhr = 220 - age;
                    maxhr_85 = (int)(maxhr * 0.85);
                    NameTB.Enabled = false;
                    AgeTB.Enabled = false;
                    MAXHRTB.Enabled = false;
                    MAXhr_85TB.Enabled = false;
                    checkBox1.Enabled = false;
                    checkBox2.Enabled = false;
                    checkBox3.Enabled = false;
                    button1.Enabled = false;
                    Calculatebutton.Enabled = true;
                    numericUpDown2.Enabled = true;
                    numericUpDown3.Enabled = true;
                    numericUpDown4.Enabled = true;
                    numericUpDown5.Enabled = true;
                    numericUpDown6.Enabled = true;
                }
                catch
                {
                    MessageBox.Show("INVALID INPUT");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Checkboxes not selected");
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tabPage1_Leave(object sender, EventArgs e)
        {

        }

        private void groupBox1_Validating(object sender, CancelEventArgs e)
        {

        }

        private const int WS_SYSMENU = 0x80000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style &= ~WS_SYSMENU;
                return cp;
            }
        }

        private void Calculatebutton_Click(object sender, EventArgs e)
        {
            try
            {
                y_values[0] = Int32.Parse(numericUpDown2.Value.ToString());
                y_values[1] = Int32.Parse(numericUpDown3.Value.ToString());
                y_values[2] = Int32.Parse(numericUpDown4.Value.ToString());
                y_values[3] = Int32.Parse(numericUpDown5.Value.ToString());
                y_values[4] = Int32.Parse(numericUpDown6.Value.ToString());
                Calculatebutton.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;
                numericUpDown6.Enabled = false;
                calculate();
                button2.Enabled = true;
                Button3.Enabled = true;
            }
            catch
            {
                MessageBox.Show("INVALID INPUT");
                return;
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.ShowDialog();
                var filePath = op.FileName;

                var lines = File.ReadAllLines(filePath).Select(a => a.Split(','));

                foreach (string[] names in lines)
                {
                    listdata.Add(names[0], names[1]);
                }

                foreach (string i in listdata.Keys)
                {
                    participantlist.Items.Add(i + "," + listdata[i]);
                }

                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
            }
            catch
            { }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            participantlist.Items.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            participantlist.Sorted = true;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var s = (string)participantlist.SelectedItem;
            var t = s.Split(',');
            NameTB.Text = t[0];
            AgeTB.Value = Int32.Parse(t[1]);
            participantlist.Items.Remove(participantlist.SelectedItem);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                try
                {
                    var age = Int32.Parse(AgeTB.Value.ToString());
                    maxhr = 220 - age;
                    maxhr_85 = (int)(maxhr * 0.85);
                    MAXHRTB.Text = maxhr.ToString();
                    MAXhr_85TB.Text = maxhr_85.ToString();
                }
                catch
                {
                    MessageBox.Show("Age Yet to be specified");
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                try
                {
                    var age = Int32.Parse(AgeTB.Value.ToString());
                    maxhr = 220 - age;
                    maxhr_85 = (int)(maxhr * 0.85);
                    MAXHRTB.Text = maxhr.ToString();
                    MAXhr_85TB.Text = maxhr_85.ToString();
                }
                catch
                {
                    MessageBox.Show("Age Yet to be specified");
                }
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                try
                {
                    var age = Int32.Parse(AgeTB.Value.ToString());
                    maxhr = 220 - age;
                    maxhr_85 = (int)(maxhr * 0.85);
                    MAXHRTB.Text = maxhr.ToString();
                    MAXhr_85TB.Text = maxhr_85.ToString();
                }
                catch
                {
                    MessageBox.Show("Age Yet to be specified");
                }
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"d:\TestResults.txt";
                using (StreamWriter file = new StreamWriter(path))
                {
                    file.WriteLine("Name=" + name);
                    file.WriteLine("Age=" + age);
                    file.WriteLine("MAXHR=" + maxhr);
                    file.WriteLine("MAXHR85=" + maxhr_85);
                    file.WriteLine("Test1=" + y_values[0]);
                    file.WriteLine("Test2=" + y_values[1]);
                    file.WriteLine("Test3=" + y_values[2]);
                    file.WriteLine("Test4=" + y_values[3]);
                    file.WriteLine("Test5=" + y_values[4]);
                    file.WriteLine("Aerobic Capacity=" + max_x);
                    file.WriteLine("Female =" + WomanLab.Text);
                    file.WriteLine("Male =" + MenLab.Text);
                    file.WriteLine("Step Height=" + Form2.step);
                    file.WriteLine("Tester Name=" + Form2.name);
                    file.Close();
                    MessageBox.Show("The Data has been saved in a file in location (d:\\TestResults.txt) ","PRINT");
                }
            }
            catch
            { }
        }
    }
}
