# Snappy for Windows command line #

This is source code for snzip and snunzip - command-line compression tools using [Snappy compression algorithm](https://google.github.io/snappy/).

* Documentation: [Home](https://snappy.machinezoo.com/), [Tutorial for command-line tools](https://snappy.machinezoo.com/#shell)
* Download: see [Tutorial for command-line tools](https://snappy.machinezoo.com/#shell)
* Sources: [GitHub](https://github.com/robertvazan/snappy-command-line), [Bitbucket](https://bitbucket.org/robertvazan/snappy-command-line)
* Issues: [GitHub](https://github.com/robertvazan/snappy-command-line/issues), [Bitbucket](https://bitbucket.org/robertvazan/snappy-command-line/issues)
* License: [BSD license](LICENSE)
* See also [upstream Snappy](https://google.github.io/snappy/)

***

```
snzip, snunzip - Snappy compression command-line tool
Options:
 -d --decompress --uncompress
   Run in decompression mode. This is default if started as 'snunzip'.
 -c --stdout --to-stdout
   Output to standard output instead of file.
 -t --test
   Only test integrity of the compressed file. Don't actually unpack it.
 -v --verbose
   Verbose output.
 -V --version
   Version. Display the version number and compilation options then quit.
 -h --help
   Display this information and quit.
```

