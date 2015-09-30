using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kyrt;

namespace WindowsFormsApplication1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Run_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var message = Runner();

                Message.Lines = message.ToArray();
            }
        }

 
        private string[] Runner()
        {
            var results = new ConcurrentQueue<string>();
            var exitCode = Executor.Run((s)=> results.Enqueue(s), (s) => results.Enqueue(s),
                "powershell.exe", "-NoProfile", "-NoLogo", "-ExecutionPolicy Unrestricted", @"-File scripts\broken5.ps1");
            results.Enqueue(exitCode.ToString());
            return results.ToArray();
        }
    }
}
