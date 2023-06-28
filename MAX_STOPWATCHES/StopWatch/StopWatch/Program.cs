using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace StopWatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            SWController swc = new SWController(byte.Parse(Environment.GetEnvironmentVariable("MAX_STOPWATCHES")), "/interface/request.txt", "interface/response.txt");
            swc.CommandProcessing();
        }
    }
}
