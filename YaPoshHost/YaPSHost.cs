using System;
using System.Globalization;
using System.Management.Automation.Host;
using YaPoshHost;
using static System.Threading.Thread;

namespace YaPoshHost
{
    class YaPSHost : PSHost
    {
        private Program _program;

        public YaPSHost(Program program)
        {
            _program = program;
        }

        public override void SetShouldExit(int exitCode)
        {
            _program.ShouldExit = true;
            _program.ExitCode = exitCode;
        }

        public override void EnterNestedPrompt()
        {
            throw new NotImplementedException();
        }

        public override void ExitNestedPrompt()
        {
            throw new NotImplementedException();
        }

        public override void NotifyBeginApplication()
        {
            // Do nothing.
        }

        public override void NotifyEndApplication()
        {
            // Do nothing.
        }

        public override string Name { get; } = "YaPoshHost";
        public override Version Version { get; } = new Version(0, 0, 1, 0);
        public override Guid InstanceId { get; } = Guid.NewGuid();
        public override PSHostUserInterface UI { get; }=new YaPSHostUserInterface();
        public override CultureInfo CurrentCulture { get; } = CurrentThread.CurrentCulture; 
        public override CultureInfo CurrentUICulture { get; } = CurrentThread.CurrentUICulture;
    }
}
