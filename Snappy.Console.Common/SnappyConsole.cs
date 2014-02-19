using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Text;

namespace Snappy.Console.Common
{
    public class SnappyConsole
    {
        public static void Run(string[] args, CompressionMode mode)
        {
            bool stdout = false;
            bool test = false;
            foreach (var arg in args)
            {
                switch (arg)
                {
                    case "-d":
                    case "--decompress":
                    case "--uncompress":
                        mode = CompressionMode.Decompress;
                        break;
                    case "-c":
                    case "--stdout":
                    case "--to-stdout":
                        stdout = true;
                        break;
                    case "-t":
                    case "--test":
                        test = true;
                        break;
                    case "-V":
                    case "--version":
                        break;
                }
            }
        }
    }
}
