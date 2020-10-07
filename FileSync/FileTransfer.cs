using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace FileSync
{
    class ProcessBundle
    {
        public Process process = new Process();
        public bool isExit;
        public bool isError;
        public string stdoutInfo;
        public string stderrorInfo;
        public int processId;
        public volatile int isUsed;

    }
    class FileTransfer
    {
        public FileTransfer(int processNum)
        {

            _processNum = processNum;
            processesList = new List<ProcessBundle>(_processNum);
            for (int i = 0; i < _processNum; i++)
            {
                processesList.Add(new ProcessBundle());
            }
            
            int processCounter = 0;
            foreach (var item in processesList)
            {
                process = new Process();
                item.processId = processCounter++;
                item.isUsed = 0;
                item.process.StartInfo.UseShellExecute = false;
                item.process.StartInfo.CreateNoWindow = true;
                item.process.StartInfo.RedirectStandardOutput = true;
                item.process.StartInfo.RedirectStandardError = true;
                item.process.ErrorDataReceived += Process_ErrorDataReceived;
                item.process.OutputDataReceived += Process_OutputDataReceived;
                item.process.Exited += Process_Exited;
               
            }
        }

        private void Process_Exited(object sender, EventArgs e)
        {
            for (  int i = 0; i < processesList.Count; i++)
            {
                if (processesList[i].process == sender)
                {
                    processesList[i].isExit = true;
                    return;
                }
                
            }
        }

        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            for (int i = 0; i < processesList.Count; i++)
            {
                if (processesList[i].process == sender)
                {
                    processesList[i].stdoutInfo  += e.Data;
                    return;
                }
            }
        }       

        public bool processIsFinishedWithSucess(int processId, out string info)
        {
            if (processId >= _processNum)
            {
                info = "processId is bigger than the _processNum !";
                return false;
            }
            ProcessBundle processBundle = null;
            foreach (var item in processesList)
            {
                if (item.processId == processId)
                {
                    processBundle = item;
                }
            }
            if (processBundle == null)
            {
                info = " can not find the processId for current process list";
                return false;
            }
            if (processBundle.process.HasExited)
            {
                if (!processBundle.isError && 
                    processBundle.process.ExitCode == 0)
                {

                    Interlocked.Exchange(ref processBundle.isUsed, 0);
                    info = processBundle.stdoutInfo;
                    return true;
                }
                info = processBundle.stderrorInfo;
                Interlocked.Exchange(ref processBundle.isUsed, 0);
                return false;
            }
            else
            {
                processBundle.process.WaitForExit(20000);
                if (processBundle.process.HasExited)
                {
                    if (!processBundle.isError &&
                        processBundle.process.ExitCode == 0)
                    {
                        Interlocked.Exchange(ref processBundle.isUsed, 0);
                        info = processBundle.stdoutInfo;
                        return true;
                    }
                    Interlocked.Exchange(ref processBundle.isUsed, 0);
                    info = processBundle.stderrorInfo;
                    return false;
                }
                else
                {
                    processBundle.process.Kill();
                    Interlocked.Exchange(ref processBundle.isUsed, 0);
                    info = "Programm is not finished";
                    return false;
                }
            }
        }

        private bool findProcessToRunCmd(string command, out int processId)
        {
            foreach (var item in processesList)
            {
                if (item.isUsed != 1)
                {
                    item.process.StartInfo.FileName = programPath;
                    item.process.StartInfo.Arguments = "-c " + command;
                    LogHelper.writeInfoLog(string.Format("send command: {0}", command));
                    item.process.Start();
                    Interlocked.Exchange(ref item.isUsed, 1);
                    processId =  item.processId;
                    return true;
                }
            }
            processId = -1;
            return false;
        }

        private int runCommand(string command)
        {
            int processId = -1;
            while (!findProcessToRunCmd(command,out processId))
            {
                Thread.Sleep(100);
            }
            return processId;

        }

        public int executeWSLBashCommand(string command)
        {

            return runCommand(command);

        }

        private void Process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            for (int i = 0; i < processesList.Count; i++)
            {
                if (processesList[i].process == sender)
                {
                    processesList[i].stderrorInfo += e.Data;
                    processesList[i].isError = true;
                    return;
                }
            }
        }
        public string programPath { get; set; }
        private Process process = new Process();
        private List<ProcessBundle> processesList ;
        private int _processNum;
    }
}
