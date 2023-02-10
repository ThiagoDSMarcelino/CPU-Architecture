Assembler asm = new Assembler();

if (args.Length == 0)
    throw new System.Exception("You need to pass the file path for compilation to happen.");

asm.Convert(args[0]);