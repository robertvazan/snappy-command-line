// Part of Snappy for Windows: https://snappy.machinezoo.com/
﻿﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Text;

namespace Snappy.Console.Common
{
    public class SnappyConsole
    {
        public static void Run(string[] args, CompressionMode mode)
        {
            var options = Options.Parse(args, mode);
            if (options == null)
                return;
            var errorOut = System.Console.Error;
            Stream stdout = options.Stdout || options.Files.Count == 0 ? System.Console.OpenStandardOutput() : null;
            foreach (var file in options.Files)
            {
                using (var input = File.Open(file, FileMode.Open, FileAccess.Read))
                {
                    var output = options.Test ? null : stdout ?? File.Open(GetAltFileName(file, options), FileMode.Create, FileAccess.Write);
                    ProcessFile(input, output, options);
                    if (output != null && output != stdout)
                        output.Close();
                }
            }
            if (options.Files.Count == 0)
            {
                Stream stdin = System.Console.OpenStandardInput();
                ProcessFile(stdin, stdout, options);
            }
            if (stdout != null)
                stdout.Close();
        }

        static void ProcessFile(Stream input, Stream output, Options options)
        {
            var buffer = new byte[8192];
            if (options.Mode == CompressionMode.Compress)
            {
                using (var compressor = new SnappyStream(output, CompressionMode.Compress, true))
                {
                    while (true)
                    {
                        int read = input.Read(buffer, 0, buffer.Length);
                        if (read == 0)
                            break;
                        compressor.Write(buffer, 0, read);
                    }
                }
            }
            else if (!options.Test)
            {
                using (var decompressor = new SnappyStream(input, CompressionMode.Decompress, true))
                {
                    while (true)
                    {
                        int read = decompressor.Read(buffer, 0, buffer.Length);
                        if (read == 0)
                            break;
                        output.Write(buffer, 0, read);
                    }
                }
            }
            else
            {
                using (var decompressor = new SnappyStream(input, CompressionMode.Decompress, true))
                {
                    while (true)
                    {
                        int read = input.Read(buffer, 0, buffer.Length);
                        if (read == 0)
                            break;
                    }
                }
            }
        }

        static string GetAltFileName(string filename, Options options)
        {
            if (options.Mode == CompressionMode.Compress)
                return filename + ".sz";
            return Path.Combine(Path.GetDirectoryName(filename), Path.GetFileNameWithoutExtension(filename));
        }
    }
}
