using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mook_ThreadReceiveData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            RaceThread = new Thread(ReceiveData);
            RaceThread.Start();
        }

        private void ReceiveData()
        {
            while (Runflags)
            {
                Thread.Sleep(1);
                foreach (var proc in Process.GetProcesses())
                {
                    if(proc.ProcessName.ToString().Equals("mook_SendData") == true)
                    {
                        Runflags = false;
                        this.lblReceive02.Text = "실행되었고 값은 " + mook_SendData.Form1.SendName;
                    }
                }
            }

            RaceThread.Abort();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(RaceThread != null)
            {
                RaceThread.Abort();
            }
        }
    }
}
