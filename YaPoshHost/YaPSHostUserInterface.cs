using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Host;
using System.Security;

namespace YaPoshHost
{
    class YaPSHostUserInterface: PSHostUserInterface
    {
        public override string ReadLine()
        {
            throw new NotImplementedException();
        }

        public override SecureString ReadLineAsSecureString()
        {
            throw new NotImplementedException();
        }

        public override void Write(string message)
        {
            Console.Write(message);
        }

        public override void Write(ConsoleColor foregroundColor, ConsoleColor backgroundColor, string message)
        {
            Console.Write(message);
        }

        public override void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public override void WriteErrorLine(string message)
        {
            Console.WriteLine($"ERROR: {message}");
        }

        public override void WriteDebugLine(string message)
        {
            Console.WriteLine($"DEBUG: {message}");
        }

        public override void WriteProgress(long sourceId, ProgressRecord record)
        {
            // Do nothing.
        }

        public override void WriteVerboseLine(string message)
        {
            Console.WriteLine($"VERBOSE: {message}");
        }

        public override void WriteWarningLine(string message)
        {
            Console.WriteLine($"WARNING: {message}");
        }

        public override Dictionary<string, PSObject> Prompt(string caption, string message, Collection<FieldDescription> descriptions)
        {
            throw new NotImplementedException();
        }

        public override PSCredential PromptForCredential(string caption, string message, string userName, string targetName)
        {
            throw new NotImplementedException();
        }

        public override PSCredential PromptForCredential(string caption, string message, string userName, string targetName, PSCredentialTypes allowedCredentialTypes, PSCredentialUIOptions options)
        {
            throw new NotImplementedException();
        }

        public override int PromptForChoice(string caption, string message, Collection<ChoiceDescription> choices, int defaultChoice)
        {
            throw new NotImplementedException();
        }

        public override PSHostRawUserInterface RawUI { get; } = new YaPSHostRawUserInterface();
    }
}
