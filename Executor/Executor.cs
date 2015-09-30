using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Kyrt
{
    public static class Executor
    {
        private static Process CreateProcess(string path, string arguments)
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

        public static int Run(string program, params string[] args)
        {
            var modulePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            using (var stdout = new StreamWriter(modulePath + @"\stdout.log", true, Encoding.UTF8))
            using (var stderr = new StreamWriter(modulePath + @"\stderr.log", true, Encoding.UTF8))
            {

                var result = Run(stdout.WriteLine, stderr.WriteLine, program, args);

                stdout.Flush();
                stderr.Flush();
                return result;
            }

        }

        public static int Run(Action<string> stdout, Action<string> stderr, string program,  params string[] args)
        {
            using (var process = CreateProcess(program, string.Join(" ", args)))
            {

                process.OutputDataReceived += (sender, eventArgs) => stdout(eventArgs.Data??"");
                process.ErrorDataReceived += (sender, eventArgs) => stderr(eventArgs.Data ??"");

                if (!process.Start())
                    return -1;

                process.BeginErrorReadLine();
                process.BeginOutputReadLine();
                process.StandardInput.Close();

                if (!process.WaitForExit(-1))
                    return -2;

                return process.ExitCode;
            }
        }
    }
}
