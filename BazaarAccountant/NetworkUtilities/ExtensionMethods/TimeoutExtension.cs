using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetworkUtilities.ExtensionMethods
{
    public static class TimeoutExtension
    {
        public static void WithTimeout(this Action action, int miliseconds)
        {
            Thread thread = new Thread(() => action());
            Stopwatch stopwatch = new Stopwatch();
            bool succesful = false;

            thread.Start();
            stopwatch.Start();
            while (!(succesful) && (stopwatch.ElapsedMilliseconds < miliseconds))
            {
                succesful = !thread.IsAlive;
            }
            if (!succesful)
                throw new WebException("Operation timed out!");
        }

        public static T WithTimeout<T>(this Func<T> action, int miliseconds)
        {
            var result = default(T);
            Thread thread = new Thread(() => result = action());
            Stopwatch stopwatch = new Stopwatch();
            bool succesful = false;

            thread.Start();
            stopwatch.Start();
            while (!(succesful) && (stopwatch.ElapsedMilliseconds < miliseconds))
            {
                succesful = !thread.IsAlive;
            }
            if (!succesful)
                throw new WebException("Operation timed out!");
            else return result;
        }

        public static Func<R> Curry<P1, R>(this Func<P1, R> func, P1 param1)
        {
            return () => func(param1);
        }

        public static Func<P1, Func<P2, R>> Curry<P1, P2, R>(this Func<P1, P2, R> func)
        {
            return a => b => func(a, b);
        }

        public static Func<P1, Func<P2, Func<P3, R>>> Curry<P1, P2, P3, R>(this Func<P1, P2, P3, R> func)
        {
            return a => b => c => func(a, b, c);
        }

        public static Func<P1, Func<P2, Func<P3, Func<P4, R>>>> Curry<P1, P2, P3, P4, R>(this Func<P1, P2, P3, P4, R> func)
        {
            return a => b => c => d => func(a, b, c, d);
        }
    }
}
