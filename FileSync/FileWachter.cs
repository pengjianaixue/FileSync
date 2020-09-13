using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace FileSync
{
    class FileWachter
    {


        public delegate void monitorFileChanged(object sender, FileChangeInfo fileChangeInfo);

        public event monitorFileChanged MonitorFileChanged;
        public FileWachter()
        {
            
        }

        private void FileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            FileChangeInfo fileChangeInfo = new FileChangeInfo();
            fileChangeInfo.fullPath = e.FullPath;
            fileChangeInfo.changeType = e.ChangeType;
            fileChangeInfo.changeTime = DateTime.Now.ToString();
            MonitorFileChanged?.Invoke(sender, fileChangeInfo);
        }

        private void FileSystemWatcher_Error(object sender, ErrorEventArgs e)
        {
            throw new NotImplementedException();
        }

        public bool startWatchProcess(string path)
        {
            fileSystemWatcher.BeginInit();
            fileSystemWatcher.Renamed += FileSystemWatcher_Changed;
            fileSystemWatcher.Created += FileSystemWatcher_Changed;
            fileSystemWatcher.Deleted += FileSystemWatcher_Changed;
            fileSystemWatcher.Error += FileSystemWatcher_Error;
            fileSystemWatcher.Changed += FileSystemWatcher_Changed;
            fileSystemWatcher.IncludeSubdirectories = true;
            //fileSystemWatcher.NotifyFilter = NotifyFilters.Attributes | NotifyFilters.CreationTime
            //    | NotifyFilters.DirectoryName | NotifyFilters.FileName | NotifyFilters.LastAccess
            //    | NotifyFilters.LastWrite | NotifyFilters.Security | NotifyFilters.Size;
            fileSystemWatcher.Path = path;
            fileSystemWatcher.EndInit();
            fileSystemWatcher.EnableRaisingEvents = true;
            return true;
        }

        private void FileSystemWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private FileSystemWatcher fileSystemWatcher = new FileSystemWatcher();
    }
}
