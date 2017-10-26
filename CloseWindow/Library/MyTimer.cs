using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloseWindow.Library
{
    class MyTimer
    {

        private Timer timer;

        public MyTimer(Timer timer){
            this.timer = timer;
        }

        public void startTimer() {
            this.timer.Start();
        }

        public void stopTimer(){
            this.timer.Stop();
        }        
    }
}
