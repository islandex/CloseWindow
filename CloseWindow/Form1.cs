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



namespace CloseWindow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        public static extern int ExitWindowsEx(int operationFlag, int operationReason);

        private void logout_Click(object sender, EventArgs e)
        {

            MessageBox.Show(this.numericUpDown.Value.GetType().ToString());
            //ExitWindowsEx(0, 0);
        }

        private void forceLogOut_Click(object sender, EventArgs e)
        {
            //ExitWindowsEx(4, 0);
        }

        private void shutDown_Click(object sender, EventArgs e)
        {
            //ExitWindowsEx(1, 0);
        }

        private void restart_Click(object sender, EventArgs e)
        {
            //ExitWindowsEx(2, 0);
        }

        private void hideApp_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //this.liczba++;
            //DateTime curDate = DateTime.Now;
            //string czas = curDate.TimeOfDay.ToString();
            //this.labelClock.Text = czas.Remove(8, 8);

            //if (this.countDownBool == true)
            //{
            //    this.countDownVal--;
            //    this.labelCountDown.Text = countDownVal.ToString();

            //    if (this.countDownVal == 0)
            //    {
            //        Show();
            //        this.countDownBool = false;
            //        this.countDownSetter.Enabled = true;
            //        this.btnCountDown.Text = "Start";
            //        this.countDownVal = this.multiply * this.countDownSetter.Value;
            //        this.a.controls.play();
            //    }
            //}
        }                              
    }
}
