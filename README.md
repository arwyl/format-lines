# format-lines [![NuGet Badge](https://buildstats.info/nuget/format-lines)](https://www.nuget.org/packages/format-lines/)

This is a simple tool to format every line in a text file or stdin.


## How to install it

Install it as a global tool here:

```
dotnet tool install -g format-lines
```

If you already have it installed, make sure to update:

```
dotnet tool update -g format-lines
```


## How to use it

```console
format-lines [options] format

Arguments:
  format    Line format where {0} is initial line.

Options:
  -i, --input                      Input file to be processed. If not set stdin will be used.
  -d, --delimiter                  Delimiter for formatted lines. Default value is new line.
  -t, --trim                       If set, the input lines will be trimmed before formatting.
  -e, --ignore-empty-lines         If set, empty or whitespace lines will not be formatted and included in result.
  -m, --min-length                 Minimum length for lines to be formatted and included in result.
  -o, --output                     Output file name. If not set, stdout will be used.
  --version                        Show version information
  -?, -h, --help                   Show help and usage information
```


## Examples

Add single quotes for every line in input.txt and save it to output.txt:

```console
format-lines '{0}' -i input.txt -o output.txt
```

or:

```console
format-lines '{0}' > output.txt < input.txt
```

Write lines manually and save them surrounded by simgle quotes to output.txt:

```console
format-lines '{0}' -o output.txt
```

Note: you can exit this process with <kbd>Ctrl</kbd> + <kbd>C</kbd>.


Trim all lines, remove every empty line, remove all lines with length less than 2 and format like pseudoo json with square brackets '[ "value": "%MyLine%" ],' for every line in input.txt and save it to output.txt in a single line with comma as delimiter:

```console
format-lines "[ ""value"": ""{0}"" ]" --input input.txt --trim --ignore-empty-lines --min-length 2 --delimiter , --output output.txt
```


## P.S.

There is a lot of overengineering here, and it was supposed to be that way =) 
