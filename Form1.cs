using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2105Demo1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //int i;
            //for (i = 1; i <= 8; i++)
            //{
            //    comboBox3.Items.Add(i.ToString());
            //}
            string[] BandRate = { "9600", "115200", "230400", "2000000" };
            string[] DataBit = { "1", "2", "3", "4", "5", "6", "7", "8" };
            

            comboBox1.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            comboBox2.Items.AddRange(BandRate);
            comboBox3.Items.AddRange(DataBit);

            comboBox1.Text = "COM1";
            comboBox2.Text = "115200";
            comboBox3.Text = "8";
            comboBox4.Text = "None";
            comboBox5.Text = "1";

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
