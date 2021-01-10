using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Heart_Rate_Krzysztof_Oko
{
    public partial class Form2 : Form
    {
        Form1 form1 = new Form1();
        static public Form2 form2 = new Form2();
        static public string name;
        static public int step;
        public Form2()
        {
            InitializeComponent();
            form2 = this;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BTNAdd_Click(object sender, EventArgs e)
        {
            name= TesterName.Text.ToString();
            try
            {
                step = Int32.Parse(StepHeight.Text);
            }
            catch
            {
                MessageBox.Show("INVALID INPUT");
                return;
            }
            if (name != "")
            {
                form1.Show();
                form1.setName();
                this.Hide(); 
            }
            else
                MessageBox.Show("Fill required Data","AlertBox");
        }
    }
}
