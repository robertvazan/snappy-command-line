using Snappy.Console.Common;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Text;

namespace Snappy.Console.Compress
{
    class Program
    {
        static int Main(string[] args)
        {
            try
            {
                SnappyConsole.Run(args, CompressionMode.Compress);
                return 0;
            }
            catch (Exception e)
            {
                System.Console.Error.WriteLine(e.Message);
                return -1;
            }
        }
    }
}
