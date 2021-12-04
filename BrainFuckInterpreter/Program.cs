using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using BrainFuckInterpreter;


static class Program
{
    public static void Main(string[] argv)
    {
        if (argv.Length == 0 || !File.Exists(argv[0]))
            return;

        string str = "";
        using (StreamReader sr = File.OpenText(argv[0]))
        {
            string? s;
            while ((s = sr.ReadLine()) != null)
            {
                str += s;
            }
        }
        try
        {
            Parser parser = new Parser();
            List<Instruction> instructions = parser.Parse(str);
            Memory memory = new Memory(2000000000);
            foreach (var instr in instructions)
            {
                instr.Execute(memory);
            }
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.Message);
        }
    }
}