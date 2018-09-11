// Part of Snappy for Windows: https://snappy.machinezoo.com/
﻿﻿using Snappy.Console.Common;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Text;

namespace Snappy.Console.Decompress
{
    class Program
    {
        static int Main(string[] args)
        {
            try
            {
                SnappyConsole.Run(args, CompressionMode.Decompress);
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
