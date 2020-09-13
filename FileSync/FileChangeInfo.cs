using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace FileSync
{
    struct FileChangeInfo
    {
        public string fullPath;
        public WatcherChangeTypes changeType;
        public string changeTime;
    }
}
