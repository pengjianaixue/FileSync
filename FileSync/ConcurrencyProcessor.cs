using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace FileSync
{
    class ConcurrencyProcessor
    {
        public ConcurrencyProcessor(ParameterizedThreadStart threadWorkingcallBack,
                                    int processNum = 8,
                                    ThreadPriority threadPriority = ThreadPriority.Normal,
                                    bool startImmediately = true
                                    )
        {
            for (int i = 0; i < processNum; ++i)
            {
                Thread workThread = new Thread(threadWorkingcallBack);
                workThread.Priority = threadPriority;
                if (startImmediately)
                {
                    workThread.Start();
                }
                workingThreads.Add(workThread);
            }
        }
        void setProcessorPriority(ThreadPriority threadPriority)
        {
            foreach (Thread workThread in workingThreads)
            {
                workThread.Priority = threadPriority;
            }
        
        }
        public void stopAllProcessor( int waitTime = 10, bool isForceAbort = true)
        {
            foreach (Thread workThread in workingThreads)
            {
                if (workThread.IsAlive)
                {
                    if (isForceAbort)
                    {
                        workThread.Abort();
                    }
                    else
                    {
                        workThread.Join(waitTime);
                    }
                }
            }
        }
        /*
         * TODO
         * workThread.Suspend
         * workThread.Resume
         */
        private List<Thread> workingThreads = new List<Thread>();
    }
}
