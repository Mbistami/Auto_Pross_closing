using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;


namespace WindowsFormsApp26
{

    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out uint ProcessId);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var processss = from proc in System.Diagnostics.Process.GetProcesses() orderby proc.ProcessName ascending select proc;
            foreach (var item in processss)
            {
                if (item.ProcessName.Equals("NetFu"))
                {
                    gunaElipsePanel2.BaseColor = System.Drawing.Color.Green;
                }
            }
            gunaCheckBox1.Checked = true;
            timer2.Start();
            gunaAdvenceButton2.Enabled = false;
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            label1.Text = "Timer ON";
            label1.ForeColor = System.Drawing.Color.Green;
            timer1.Start();
            gunaAdvenceButton2.Enabled = true;
            gunaAdvenceButton1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Date.Equals(gunaDateTimePicker1.Value.Date))
                if (DateTime.Now.Hour.Equals(dateTimePicker1.Value.Hour))
                    if (DateTime.Now.Minute.Equals(dateTimePicker1.Value.Minute))
                        if (DateTime.Now.Second.Equals(dateTimePicker1.Value.Second))
                        {
                            Process[] processes = Process.GetProcessesByName(gunaTextBox1.Text);
                            foreach (var process in processes)
                            {
                                process.Kill();
                            }
                            label1.Text = "Timer OFF";
                            label1.ForeColor = System.Drawing.Color.Red;
                            gunaElipsePanel2.BaseColor = System.Drawing.Color.Red;
                            //check netfu ouverture !
                            var processss = from proc in System.Diagnostics.Process.GetProcesses() orderby proc.ProcessName ascending select proc;
                            foreach (var item in processss)
                            {
                                if (item.ProcessName.Equals("NetFu"))
                                {
                                    gunaElipsePanel2.BaseColor = System.Drawing.Color.Green;
                                }
                            }
                            gunaAdvenceButton1.Enabled = true;
                            gunaCheckBox1.Checked = true;
                            timer1.Stop();
                        }
        }

        private void gunaElipsePanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox1.Checked)
            {
                //gunaTextBox1.Enabled = false;
                gunaDateTimePicker1.Enabled = false;
                gunaAdvenceButton1.Enabled = true;
                gunaTextBox1.Enabled = false;
                dateTimePicker1.Enabled = false;
            }
            else
            {
                //gunaTextBox1.Enabled = true;
                gunaDateTimePicker1.Enabled = true;
                gunaAdvenceButton1.Enabled = false;
                gunaTextBox1.Enabled = true;
                dateTimePicker1.Enabled = true;
            }
        }

        private void gunaTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            var processss = from proc in System.Diagnostics.Process.GetProcesses() orderby proc.ProcessName ascending select proc;
            foreach (var item in processss)
            {
                if (item.ProcessName.Equals("NetFu"))
                {
                    gunaElipsePanel2.BaseColor = System.Drawing.Color.Green;
                }
            }
        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            label1.Text = "Timer OFF";
            label1.ForeColor = System.Drawing.Color.Red;
            timer1.Stop();
            gunaAdvenceButton2.Enabled = false;
            gunaAdvenceButton1.Enabled = true;
        }
    }
}
