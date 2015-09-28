using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PoshTest
{
    [TestFixture]

    //https://github.com/projectkudu/kudu/blob/master/Kudu.Core/Infrastructure/Executable.cs#L289


    public class ProcessTest
    {
        internal Process CreateProcess(string path, string arguments)
        {
            var psi = new ProcessStartInfo
            {
                FileName = path,
                WorkingDirectory = Environment.CurrentDirectory,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                UseShellExecute = false,
                ErrorDialog = false,
                Arguments = arguments,
                StandardOutputEncoding = Encoding.UTF8,
                StandardErrorEncoding = Encoding.UTF8 
        };



            var process = new Process()
            {
                StartInfo = psi
            };

            return process;
        }

        [Test]
        public void CreateProcessNoWindowTest()
        {
            using (var process = CreateProcess("powershell.exe", @"-NoProfile -NoLogo -ExecutionPolicy Unrestricted -File CreateProcessNoWindowTest.ps1"))
            {

                process.OutputDataReceived += (sender, eventArgs) => Console.Out.WriteLine(eventArgs.Data);
                process.ErrorDataReceived += (sender, eventArgs) => Console.Error.WriteLine(eventArgs.Data);

                process.Start();
                process.BeginErrorReadLine();
                process.BeginOutputReadLine();
                process.StandardInput.Close();

                var processExited = process.WaitForExit(-1);

                Console.WriteLine(processExited);
            }
        }
    }
    
}
