namespace Assembler;

using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.IO;

public class Assembler16Bit
{
    private IDictionary<string, ushort> opcode = new Dictionary<string, ushort>()
    {
        {"nop",       0},

        // ULA opcodes
        {"and",       61440},
        {"sub",       61696},
        {"mul",       61952},
        {"div",       62208},
        {"nand",      62464},
        {"rsh",       62720},
        {"xnor",      62976},
        {"inc",       63232},
        {"dec",       63488},
        {"xor",       63744},
        {"not",       64000},
        {"nor",       64256},
        {"lsh",       64512},
        {"add",       64768},
        {"ivt",       65024},
        {"or",        65280},

        // Jumps opcodes
        {"jump",      4096},
        {"je",        8192},
        {"jne",       12288},
        {"jg",        12288},
        {"jge",       16384},
        {"jz",        24576},

        // Mov opcodes
        {"movconst",  32768},
        {"load",      37120},
        {"store",     37376},
        {"mov",       37632},
        {"push",      37888},
        {"pop",       38144},

        // Compare opcodes
        {"cmp",       49152},
        {"cmpconst",  57344},

        // Functions opcodes
        {"call",      40960},
        {"ret",       45056}
    };
    public void Convert(string path)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException();

        IDictionary<string, int> labels = new Dictionary<string, int>();
        StreamReader reader = new StreamReader(path);
        StreamWriter writer = new StreamWriter("memory");
        int index = 0;

        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine().Trim();

            if (line.Contains(';') || line.Length == 0)
                continue;
            else if (line.Contains(':'))
                labels.Add(line.Replace(":", ""), index);
            else
                index++;
        }

        writer.WriteLine("v2.0 raw");
    
        reader = new StreamReader(path);
        while (!reader.EndOfStream)
        {
            string line = this.processLine(reader.ReadLine().Trim(), labels);
            
            if (line.Length == 0)
                continue;
            
            writer.Write(line);
            writer.Write(" ");
        }

        reader.Close();
        writer.Close();
    }

    private string processLine(string line, IDictionary<string, int> labels)
    {
        if (line.Contains(';') || line.Contains(':') || line.Length == 0)
            return "";

        ushort code = 0;

        string[] script =  Regex.Replace(line.Replace(',', ' '), " {2,}", " ").Split(' ');
        ushort a = 0;
        bool
            isB = false,
            hasB = script.Length > 2;

        foreach (var command in script)
        {
            if (this.opcode.ContainsKey(command))
                code = this.opcode[command];
            else if (command.Contains('$') && !isB)
            {
                a = ushort.Parse(command.Replace("$", ""));
                isB = true;
                
                if (!hasB)
                    code = (ushort)(code | a << 4);
            }
            else if (command.Contains('$') && isB)
            {
                code = (ushort)(code | a << 4);
                code = (ushort)(code | ushort.Parse(command.Replace("$", "")));
            }
            else if (isB)
            {
                code = (ushort)(code | a << 8);
                code = (ushort)(code | ushort.Parse(command));
            }
            else
                code = (ushort)(code | labels[command]);
        }

        return code.ToString("X4");
    }
}