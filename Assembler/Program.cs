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
    writer = new StreamWriter("memory");
    writer.WriteLine("v2.0 raw");
    reader = new StreamReader(path);
    
    while (!reader.EndOfStream)
    {
        string line = processLine(reader.ReadLine());
        writer.Write(line);
        writer.Write(" ");
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

IDictionary<string, byte> commandToByte = new Dictionary<string, byte>()
{
    {"nop",   0},

    {"and",   240},
    {"sub",   241},
    {"iMult", 242},
    {"iDiv",  243},
    {"nand",  244},
    {"rsh",   245},
    {"xnor",  246},
    {"inc",   247},
    {"dec",   248},
    {"xor",   249},
    {"not",   250},
    {"nor",   251},
    {"lsh",   252},
    {"add",   253},
    {"ivt",   254},
    {"or",    255},

    {"jump",  16},
    {"je",    32},
    {"jne",   48},
    {"jg",    64},
    {"jge",   80},
    {"jz",    96},

    {"iMov",  128},
    {"load",  145},
    {"store", 146},
    {"mov",   147},
    {"push",  148},
    {"pop",   149},

    {"cmp",   192},
    {"iCmp",  224},

    {"call",  160},
    {"ret",   176}
};

string processLine(string line)
{
    byte[] opCode = new byte[2];
    
    if (line.Contains(':'))
        return line.Replace(':', '\0');
    

    var sla =  Regex.Replace(line, " {2,}", " ").Split(' ');
    Console.WriteLine(sla.Length);
    return "Assembler.commandToByte[sla[0]].ToString()";
}

string toHex(byte[] code)
{
    return "0000";
}