using System;
using System.Diagnostics;
using System.Threading;

namespace Medooza.NET.Extensions
{
    public static class Waiter
    {
        public static bool WaitWhile(Func<bool> predicate, int waitTime, int minWaitTime)
        {
            Thread.Sleep(minWaitTime);

            var timer = new Stopwatch();
            timer.Start();

            while (timer.ElapsedMilliseconds < waitTime - minWaitTime)
            {
                var result = predicate();
                if (!result) continue;
                timer.Stop();
                return true;
            }

            timer.Stop();
            return false;
        }
    }
}