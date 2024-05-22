using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace KURSUVA
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            UpdateCurrentTime();

            Timer timer = new Timer();
            timer.Tick += Timer_tick1;
            timer.Start();
        }
        private void UpdateCurrentTime()
        {
            DateTime currentTime = DateTime.Now;
            TimerTick.Text = "Зараз часу: " + currentTime.ToString("HH:mm:ss");
        }

        private void Timer_tick1(object sender, EventArgs e)
        {
            UpdateCurrentTime();
        }

        private void RegisterNewBankCards_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 RegisterCardform = new Form4();

            RegisterCardform.Show();
        }

        private void ExitForm_click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void InfoBalance_Click(object sender, EventArgs e)
        {
        }
    }
}
