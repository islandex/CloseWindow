using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CloseWindow.Library;


namespace CloseWindow
{
    public partial class Form1 : Form
    {

        const int multiplier = 60;
        private int seconds;
        private short[] param = new short[2] {-1,-1};
        private bool countDown = false;
        private Button activeButton;

        public Form1()
        {
            InitializeComponent();
        }       

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.activeButton = this.btnLogout;

            if (this.countDown == false)
            {                
                this.decorateButtons(new int[] { 1, 0, 0, 0 }, "Cancel Log out");
                this.initializeParams(0, 0);
                this.initTimer();                                
            }
            else
            {             
                this.decorateButtons(new int[] { 1, 1, 1, 1 }, "Log out");                           
                this.stopTimer();                                
            }
        }       

        private void btnForceLogOut_Click(object sender, EventArgs e)
        {
            this.activeButton = this.btnForceLogOut;

            if (this.countDown == false)
            {
                this.decorateButtons(new int[] { 0, 1, 0, 0 }, "Cancel Force Log out");
                this.initializeParams(4, 0);
                this.initTimer();                
            }
            else
            {
                this.decorateButtons(new int[] { 1, 1, 1, 1 }, "Force Log out");
                this.stopTimer();                
            }
        }

        private void btnShutDown_Click(object sender, EventArgs e)
        {
            this.activeButton = this.btnShutDown;

            if (this.countDown == false)
            {
                this.decorateButtons(new int[] { 0, 0, 1, 0 }, "Cancel ShutDown");
                this.initializeParams(1, 0);
                this.initTimer();
            }
            else
            {
                this.decorateButtons(new int[] { 1, 1, 1, 1 }, "ShutDown");
                this.stopTimer();
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            this.activeButton = this.btnRestart;

            if (this.countDown == false)
            {
                this.decorateButtons(new int[] { 0, 0, 0, 1 }, "Cancel Restart");
                this.initializeParams(2, 0);
                this.initTimer();
            }
            else
            {
                this.decorateButtons(new int[] { 1, 1, 1, 1 }, "Restart");
                this.stopTimer();
            }
        }

        private void btnHideApp_Click(object sender, EventArgs e)
        {
            Hide();
        }
        
        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            Show();
        }

        private void initTimer()
        {
            int minutes = Convert.ToInt32(this.numericUpDown.Value);            
            this.seconds = minutes * Form1.multiplier;
            this.countDown = true;
            this.numericUpDown.Enabled = false;
            this.timer1.Start();            
        }
        
        private void stopTimer()
        {                        
            this.labelTimer.Text = "0:00";
            this.countDown = false;
            this.numericUpDown.Enabled = true;
            this.timer1.Stop();
        }

        private void initializeParams(short one, short two)
        {
            this.param[0] = one;
            this.param[1] = two;
        }


        /// <summary>
        /// CO 1 sekundę
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (this.countDown == true)
            {
                this.seconds--;
                this.formatTime();
            }

            if (this.seconds == 0 && this.countDown == true)
            {
                this.countDown = false;

                if (this.param[0] == 1)
                    MyWindows.Shutdown();
                else if(this.param[0] == 2)
                    MyWindows.Restart();
                else
                    MyWindows.ExitWindowsEx(this.param[0], this.param[1]);
            }
        }

        private void formatTime() {
            
            int minutes = this.seconds / 60;
            int rest = this.seconds % 60;

            if (rest < 10)
                this.labelTimer.Text = String.Format("{0}:0{1}", minutes, rest);            
            else
                this.labelTimer.Text = String.Format("{0}:{1}", minutes, rest);            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="btns"></param>
        private void decorateButtons(int[] btns, string text) { 

            if (btns[0] == 1)
                this.btnLogout.Enabled = true;
            if (btns[1] == 1)
                this.btnForceLogOut.Enabled = true;
            if (btns[2] == 1)
                this.btnShutDown.Enabled = true;
            if (btns[3] == 1)
                this.btnRestart.Enabled = true;
            if (btns[0] == 0)
                this.btnLogout.Enabled = false;
            if (btns[1] == 0)
                this.btnForceLogOut.Enabled = false;
            if (btns[2] == 0)
                this.btnShutDown.Enabled = false;
            if (btns[3] == 0)
                this.btnRestart.Enabled = false;

            this.activeButton.Text = text;
        }
    }
}
