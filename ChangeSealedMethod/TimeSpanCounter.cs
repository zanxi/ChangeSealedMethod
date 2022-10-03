using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChangeSealedMethod
{
    internal class TimeSpanCounter
    {
        public static readonly ThreadLocal<Stopwatch> sw = new ThreadLocal<Stopwatch> ();

        public static void Before()
        {
            sw.Value = Stopwatch.StartNew();
        }

        public static void After()
        {
            sw.Value.Stop();
            Console.WriteLine(sw.Value.Elapsed);
        }
    }
}
