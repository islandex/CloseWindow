using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CloseWindow.Library
{
    class MyWindows
    {

        [DllImport("user32.dll")]
       internal static extern int ExitWindowsEx(int operationFlag, int operationReason);

       internal static void Shutdown()
       {            
            Process.Start("shutdown.exe", "-s -f -t 00");
       }

       internal static void Restart()
       {        
           Process.Start("shutdown.exe", "-r -f -t 00");
       }        
    }
}
