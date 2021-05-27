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
        //全局变量声明

        private long receive_count = 0;
        private StringBuilder sb = new StringBuilder();     //为了避免在接收处理函数中反复调用，依然声明为一个全局变量
        private DateTime current_time = new DateTime();    //为了避免在接收处理函数中反复调用，依然声明为一个全局变量


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
            string[] BandRate = { "9600", "74800", "115200", "230400", "2000000" }; //波特率字段
            string[] DataBit = { "1", "2", "3", "4", "5", "6", "7", "8" };          //数据位字段
            string[] Parity = { "None", "Odd", "Even", "Mark", "Space" };           //校验位字段
            string[] StopBit = { "1", "1.5", "2" };                                 //停止位字段


            comboBox1.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());    //将系统COM口获取添加入comboBox1里面
            comboBox2.Items.AddRange(BandRate);                                     //将波特率字段添加入comboBox2里面
            comboBox3.Items.AddRange(DataBit);                                      //将数据位字段添加入comboBox3里面
            comboBox4.Items.AddRange(Parity);                                       //将校验位字段添加入comboBox4里面
            comboBox5.Items.AddRange(StopBit);                                      //将停止位字段添加入comboBox5里面

            comboBox1.Text = "COM1";                                                //默认选择COM1
            comboBox2.Text = "9600";                                                //默认波特率9600
            comboBox3.Text = "8";                                                   //默认数据位8位
            comboBox4.Text = "None";                                                //默认无校验位
            comboBox5.Text = "1";                                                   //默认停止位1位

            button2.Enabled = false;                                                //发送按钮失能

        }

        private void button1_Click(object sender, EventArgs e)                      //`打开串口`按键
        {
            try
            {
                //将可能产生异常的代码放置在try块中
                //根据当前串口属性来判断是否打开
                if (serialPort1.IsOpen)
                {
                    //串口已经处于打开状态
                    serialPort1.Close();    //关闭串口
                    button1.Text = "打开串口";
                    button1.BackColor = Color.ForestGreen;
                    comboBox1.Enabled = true;
                    comboBox2.Enabled = true;
                    comboBox3.Enabled = true;
                    comboBox4.Enabled = true;
                    comboBox5.Enabled = true;
                    textBox2.Text = "";  //清空接收区
                    textBox1.Text = "";     //清空发送区

                    label6.Text = "串口已关闭";
                    label6.ForeColor = Color.Red;

                    button2.Enabled = false;                                          //发送按钮失能

                }
                else
                {
                    //串口已经处于关闭状态，则设置好串口属性后打开
                    comboBox1.Enabled = false;
                    comboBox2.Enabled = false;
                    comboBox3.Enabled = false;
                    comboBox4.Enabled = false;
                    comboBox5.Enabled = false;
                    serialPort1.PortName = comboBox1.Text;
                    serialPort1.BaudRate = Convert.ToInt32(comboBox2.Text);
                    serialPort1.DataBits = Convert.ToInt16(comboBox3.Text);

                    if (comboBox4.Text.Equals("None"))
                        serialPort1.Parity = System.IO.Ports.Parity.None;
                    else if (comboBox4.Text.Equals("Odd"))
                        serialPort1.Parity = System.IO.Ports.Parity.Odd;
                    else if (comboBox4.Text.Equals("Even"))
                        serialPort1.Parity = System.IO.Ports.Parity.Even;
                    else if (comboBox4.Text.Equals("Mark"))
                        serialPort1.Parity = System.IO.Ports.Parity.Mark;
                    else if (comboBox4.Text.Equals("Space"))
                        serialPort1.Parity = System.IO.Ports.Parity.Space;

                    if (comboBox5.Text.Equals("1"))
                        serialPort1.StopBits = System.IO.Ports.StopBits.One;
                    else if (comboBox5.Text.Equals("1.5"))
                        serialPort1.StopBits = System.IO.Ports.StopBits.OnePointFive;
                    else if (comboBox5.Text.Equals("2"))
                        serialPort1.StopBits = System.IO.Ports.StopBits.Two;

                    serialPort1.Open();     //打开串口
                    button1.Text = "关闭串口";
                    button1.BackColor = Color.Firebrick;

                    label6.Text = "串口已打开";
                    label6.ForeColor = Color.Green;

                    button2.Enabled = true;                                             //发送按钮使能

                }
            }
            catch (Exception ex)
            {
                //捕获可能发生的异常并进行处理

                //捕获到异常，创建一个新的对象，之前的不可以再用
                serialPort1 = new System.IO.Ports.SerialPort();
                //刷新COM口选项
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
                //响铃并显示异常给用户
                System.Media.SystemSounds.Beep.Play();
                button1.Text = "打开串口";
                button1.BackColor = Color.ForestGreen;
                MessageBox.Show(ex.Message);
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                comboBox4.Enabled = true;
                comboBox5.Enabled = true;
            }
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
            //发送区
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //接收区
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //首先判断串口是否开启
                if (serialPort1.IsOpen)
                {
                    //串口处于开启状态，将发送区文本发送
                    serialPort1.Write(textBox1.Text);
                }
            }
            catch (Exception ex)
            {
                //捕获到异常，创建一个新的对象，之前的不可以再用
                serialPort1 = new System.IO.Ports.SerialPort();
                //刷新COM口选项
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
                //响铃并显示异常给用户
                System.Media.SystemSounds.Beep.Play();
                button1.Text = "打开串口";
                button1.BackColor = Color.ForestGreen;
                MessageBox.Show(ex.Message);
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                comboBox4.Enabled = true;
                comboBox5.Enabled = true;
            }
        }

        //串口接收事件处理
        private void SerialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int num = serialPort1.BytesToRead;
            byte[] received_buf = new byte[num];

            receive_count += num;
            serialPort1.Read(received_buf,0,num);

            sb.Clear();     //防止出错,首先清空字符串构造器
                            //遍历数组进行字符串转化及拼接
            if (radioButton2.Checked)
            {
                //选中HEX模式显示
                foreach (byte b in received_buf)
                {
                    sb.Append(b.ToString("X2") + ' ');    //将byte型数据转化为2位16进制文本显示,用空格隔开
                }
            }
            else
            {
                //选中ASCII模式显示
                sb.Append(Encoding.ASCII.GetString(received_buf));  //将整个数组解码为ASCII数组
            }

            try
            {
                //因为要访问UI资源，所以需要使用invoke方式同步ui
                this.Invoke((EventHandler)(delegate
                {
                    if (checkBox1.Checked)
                    {
                        //显示时间
                        current_time = System.DateTime.Now;     //获取当前时间
                        textBox2.AppendText(current_time.ToString("HH:mm:ss") + "  " + sb.ToString());

                    }
                    else
                    {
                        //不显示时间 
                        textBox2.AppendText(sb.ToString());
                    }
                    label7.Text = "Rx:" + receive_count.ToString() + "Bytes";
                }
                   )
                );

            }
            catch (Exception ex)
            {
                //响铃并显示异常给用户
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show(ex.Message);

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";  //清空接收文本框
            textBox1.Text = "";     //清空发送文本框
            receive_count = 0;          //计数清零
            label7.Text = "Rx:" + receive_count.ToString() + "Bytes";   //刷新界面
        }
    }
}
