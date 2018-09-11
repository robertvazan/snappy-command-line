# Snappy for Windows command line #

This is source code for snzip and snunzip - command-line compression tools
utilizing [Snappy compression algorithm](https://google.github.io/snappy/).

* [Website](https://snappy.machinezoo.com/)
* [Tutorial for command-line tools](https://snappy.machinezoo.com/#shell)
* [Source code (main repository)](https://bitbucket.org/robertvazan/snappy-command-line/src/default/)
* [BSD license](https://opensource.org/licenses/BSD-3-Clause)
* [Upstream Snappy](https://google.github.io/snappy/)

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

