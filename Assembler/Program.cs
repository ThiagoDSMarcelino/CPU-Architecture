using System.Collections.Generic;
using System.IO;
using System;
using System.Text.RegularExpressions;

if (args.Length == 0)
{
    Console.WriteLine("You need to pass the file path for compilation to happen.");
    return;
}

var path = args[0];

if (!File.Exists(path))
{
    Console.WriteLine($"{path} file does not exist.");
    return;
}

StreamWriter writer = null;
StreamReader reader = null;

try
{
    IDictionary<string, int> labels = new Dictionary<string, int>();
    reader = new StreamReader(path);
    int index = 0;

    while (!reader.EndOfStream)
    {
        string line = reader.ReadLine();
        if (line.Contains(';'))
            continue;
        else if (line.Contains(':'))
            labels.Add(line.Replace(":", ""), index);
        else
            index++;
    }

    reader = new StreamReader(path);
    writer = new StreamWriter("memory");
    
    
    writer.WriteLine("v2.0 raw");
    
    while (!reader.EndOfStream)
    {
        string line = processLine(reader.ReadLine(), labels);
        writer.Write(line);
        writer.Write(" ");
        index++;
    }
}
catch (Exception ex)
{
    Console.WriteLine($"The following error occurred during compilation: {ex.Message}");
}
finally
{
    reader.Close();
    writer.Close();
}



string processLine(string line, IDictionary<string, int> labels)
{
    IDictionary<string, ushort> toShort = new Dictionary<string, ushort>()
    {
        {"nop",   0},

        {"and",   61440},
        {"sub",   61696},
        {"imult", 61952},
        {"idiv",  62208},
        {"nand",  62464},
        {"rsh",   62720},
        {"xnor",  62976},
        {"inc",   63232},
        {"dec",   63488},
        {"xor",   63744},
        {"not",   64000},
        {"nor",   64256},
        {"lsh",   64512},
        {"add",   64768},
        {"ivt",   65024},
        {"or",    65280},

        {"jump",  4096},
        {"je",    8192},
        {"jne",   12288},
        {"jg",    12288},
        {"jge",   16384},
        {"jz",    24576},

        {"movconst",  32768},
        {"load",  37120},
        {"store", 37376},
        {"mov",   37632},
        {"push",  37888},
        {"pop",   38144},

        {"cmp",   49152},
        {"cmpconst",  57344},

        {"call",  40960},
        {"ret",   45056}
    };


    ushort code = 0;
    line = line.Trim();

    if (line.Contains(':'))
        return "";
    

    string[] script =  Regex.Replace(line.Replace(',', ' '), " {2,}", " ").Split(' ');
    bool flag = false;
    ushort a = 0;


    foreach (var command in script)
    {
        if (toShort.ContainsKey(command))
        {
            code = toShort[command];
            continue;
        }


        if (command.Contains('$') && !flag)
        {
            a = ushort.Parse(command.Replace("$", ""));
            flag = true;
        }
        else if (command.Contains('$') && flag)
        {
            code = (ushort)(code | a << 4);
            code = (ushort)(code | ushort.Parse(command.Replace("$", "")));
        }
        else if (flag)
        {
            code = (ushort)(code | a << 8);
            code = (ushort)(code | ushort.Parse(command));
        }
        else
            code = (ushort)(code | labels[command]);
    }

    return code.ToString("x4");
}