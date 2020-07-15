using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBat
{
    public class BatchExecute
    {
        public string BatchCode(string command)
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

            process.Close();

            return output;
        }
        public string BatchFile(string filepath)
        {
            using (var fs = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var reader = new StreamReader(fs))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] lineInfo = line.Split(' ');
                    string NumbersTemp = lineInfo[1];
                    BatchCode(NumbersTemp);
                }
            }
            string returne = "Done";
            return returne;
        }
    }
}
