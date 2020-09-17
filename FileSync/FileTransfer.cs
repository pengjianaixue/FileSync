using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace FileSync
{
    class FileTransfer
    {
        public FileTransfer()
        {
            
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.ErrorDataReceived += Process_ErrorDataReceived;
            process.OutputDataReceived += Process_OutputDataReceived;
            process.Exited += (sender, e) => { isFinished = true; };

        }

        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            _stdoutInfo += e.Data;
        }       

        public bool processIsFinishedWithSucess(out string info)
        {

            if (process.HasExited)
            {
                if (isError)
                {
                    info = _errorInfo;
                    return false;
                }
                info = _stdoutInfo;
                return true;
            }
            else
            {
                process.WaitForExit(10000);
                if (process.HasExited)
                {
                    if (isError)
                    {
                        info = _errorInfo;
                        return false;
                    }
                    info = _stdoutInfo;
                    return true;
                }
                else
                {
                    info = "Programm is not finished";
                    return false;
                }
            }
        }

        private void runCommand(string command)
        {

            process.StartInfo.FileName = programPath;
            LogHelper.writeInfoLog(string.Format("send rsync command: {0}", command));
            process.StartInfo.Arguments = "-c " + command;
            process.Start();
            
        }

        public bool executeWSLBashCommand(string command)
        {

            runCommand(command);
            return true;

        }

        private void Process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!isError)
            {
                isError = true;
            }
            _errorInfo += e.Data;
        }
        public string programPath { get; set; }
        private bool isFinished = false;
        private bool isError = false;
        private string _errorInfo = "";
        private string _stdoutInfo = "";
        private Process process = new Process();
        private bool isFindWSLBash = false;
        private string wlsBashPath = "";
    }
}
