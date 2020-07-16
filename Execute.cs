using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading.Tasks;

namespace CBat
{
    public static class Execute
    {

        public static string Cmd(string command)
        {
            int exitCode;
            ProcessStartInfo processInfo;
            Process process;
            processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;
            process = Process.Start(processInfo);
            process.WaitForExit();
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();
            exitCode = process.ExitCode;
            string exitcode = exitCode.ToString();

            process.Close();
            return exitcode;
        }
        public static string BatchFile(string filepath)
        {
            System.Diagnostics.Process.Start(filepath);
            return "BatchFile executed";
        }
        public static string Bash(this string cmd)
        {
            var escapedArgs = cmd.Replace("\"", "\\\"");

            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "/bin/bash",
                    Arguments = $"-c \"{escapedArgs}\"",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            process.Start();
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return result;
        }
        public static string PowerShellCmd(string cmd)
        {
            Runspace runspace = RunspaceFactory.CreateRunspace(InitialSessionState.CreateDefault());
            runspace.Open();

            string script = cmd;
            PowerShell powerShellCommand = PowerShell.Create();
            powerShellCommand.Runspace = runspace;
            powerShellCommand.AddScript(script);
            foreach (string result in powerShellCommand.Invoke<string>())
            {
                return result;
            }
            runspace.Close();
            return "Done";
        }

    }
}