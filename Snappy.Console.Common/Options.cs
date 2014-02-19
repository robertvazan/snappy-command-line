using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Text;

namespace Snappy.Console.Common
{
    class Options
    {
        public CompressionMode Mode;
        public bool Stdout;
        public bool Test;
        public bool Verbose;
        public readonly List<string> Files = new List<string>();

        public static Options Parse(string[] args, CompressionMode mode)
        {
            var options = new Options();
            options.Mode = mode;
            var errorOut = System.Console.Error;
            foreach (var arg in args)
            {
                switch (arg)
                {
                    case "-d":
                    case "--decompress":
                    case "--uncompress":
                        options.Mode = CompressionMode.Decompress;
                        break;
                    case "-c":
                    case "--stdout":
                    case "--to-stdout":
                        options.Stdout = true;
                        break;
                    case "-t":
                    case "--test":
                        options.Mode = CompressionMode.Decompress;
                        options.Test = true;
                        break;
                    case "-v":
                    case "--verbose":
                        options.Verbose = true;
                        break;
                    case "-V":
                    case "--version":
                        errorOut.WriteLine("snzip {0}", AssemblyName.GetAssemblyName(typeof(SnappyCodec).Assembly.Location).Version);
                        return null;
                    case "-h":
                    case "--help":
                        errorOut.WriteLine("snzip, znunzip - Snappy compression command-line tool");
                        errorOut.WriteLine("Options:");
                        errorOut.WriteLine(" -d --decompress --uncompress");
                        errorOut.WriteLine("   Run in decompression mode. This is default if started as 'snunzip'.");
                        errorOut.WriteLine(" -c --stdout --to-stdout");
                        errorOut.WriteLine("   Output to standard output instead of file.");
                        errorOut.WriteLine(" -t --test");
                        errorOut.WriteLine("   Only test integrity of the compressed file. Don't actually unpack it.");
                        errorOut.WriteLine(" -v --verbose");
                        errorOut.WriteLine("   Verbose output.");
                        errorOut.WriteLine(" -V --version");
                        errorOut.WriteLine("   Version. Display the version number and compilation options then quit. ");
                        errorOut.WriteLine(" -h --help");
                        errorOut.WriteLine("   Display this information and quit.");
                        return null;
                    default:
                        options.Files.Add(arg);
                        break;
                }
            }
            if (options.Mode == CompressionMode.Decompress && !options.Test)
                foreach (var file in options.Files)
                {
                    if (!File.Exists(file))
                    {
                        if (file.StartsWith("-"))
                            errorOut.WriteLine("Unknown option '{0}'", file);
                        else
                            errorOut.WriteLine("Cannot find file '{0}'", file);
                        return null;
                    }
                    if (options.Mode == CompressionMode.Decompress && !options.Test && !options.Stdout && !file.EndsWith(".sz"))
                    {
                        errorOut.WriteLine("Compressed file must have suffix '.sz': {0}", file);
                        return null;
                    }
                }
            return options;
        }
    }
}
