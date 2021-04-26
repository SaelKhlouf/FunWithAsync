using FunWithAsync.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FunWithAsync.Utils
{
    public static class Helpers
    {
        public static ThreadsInfo getThreadsInfo()
        {
            int availableWorkerThreads, workerThreadsMax;
            ThreadPool.GetAvailableThreads(out availableWorkerThreads, out _);
            ThreadPool.GetMaxThreads(out workerThreadsMax, out _);

            return new ThreadsInfo
            {
                availableThreads = availableWorkerThreads,
                usedThreads = workerThreadsMax - availableWorkerThreads
            };
        }

        /*
         * This function demonstrates a synchronous operation that takes "seconds" time.
         */
        public static ThreadsInfo delaySync(int seconds)
        {
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
            return getThreadsInfo();
        }

        /*
        * This function demonstrates an asynchronous operation that takes "seconds" time.
        */
        public static async Task<ThreadsInfo> delayAsync(int seconds)
        {
            await Task.Delay(TimeSpan.FromSeconds(seconds));
            return getThreadsInfo();
        }
    }
}
