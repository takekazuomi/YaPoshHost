using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Kyrt;

namespace CreateProcess
{

    class Program
    {
        static void Main(string[] args)
        {
            if (Environment.UserInteractive)
            {
                Trace.WriteLine("Has console");
            }

            Executor.Run("powershell.exe", @"-NoProfile -NoLogo -ExecutionPolicy Unrestricted -File scripts\broken1.ps1");
            
        }
    }
}
