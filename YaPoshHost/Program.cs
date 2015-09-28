using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;


namespace YaPoshHost
{
    // see: Windows PowerShell Host02 Sample
    // https://code.msdn.microsoft.com/windowsdesktop/Windows-PowerShell-Host02-68308214

    //
    //
    class Program
    {
        public bool ShouldExit { get; set; }

        public int ExitCode { get; set; }


        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("no script file");
                Environment.Exit(1);
            }
            var program = new Program();
            var host = new YaPSHost(program);
            using (var runSpace = RunspaceFactory.CreateRunspace(host))
            {
                runSpace.Open();

                using (var powershell = PowerShell.Create())
                {
                    powershell.Runspace = runSpace;

                    powershell.AddScript(@"Set-ExecutionPolicy Unrestricted -Scope Process");

                    powershell.AddScript(args[0]);

                    powershell.AddCommand("Out-Default");

                    powershell.Commands.Commands[0].MergeMyResults(PipelineResultTypes.Error, PipelineResultTypes.Output);

                    powershell.Invoke();

                    if (program.ShouldExit)
                        Environment.Exit(program.ExitCode);
                }
            }

        }
    }
}
