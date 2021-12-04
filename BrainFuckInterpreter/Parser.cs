using System;
using System.Collections.Generic;


namespace BrainFuckInterpreter
{
    public class Parser
    {
        private Instruction ParseCharInstr(char op)
        {
            return op switch
            {
                '>' => new IncrementPtr(),
                '<' => new DecrementPtr(),
                '+' => new IncrementData(),
                '-' => new DecrementData(),
                '.' => new OutputByte(),
                ',' => new InputByte(),
                _ => throw new Exception("Not a single char instruction")
            };
        }

        private bool IsCharInstr(char op)
        {
            return op is '>' or '<' or '+' or '-' or '.' or ',';
        }

        public List<Instruction> Parse(string code)
        {
            List<Instruction> instructions = new ();
            for (var i = 0; i < code.Length; i++)
            {
                var ch = code[i];
                if (IsCharInstr(ch))
                    instructions.Add(ParseCharInstr(ch));
                else if (ch == '[')
                {
                    LoopInstruction loopInstruction = new LoopInstruction();
                    i = ParseLoopInstruction(loopInstruction, code, i + 1);
                    instructions.Add(loopInstruction);
                }
                else
                {
                    throw new Exception("Syntax Error");
                }
            }

            return instructions;
        }
        private int ParseLoopInstruction(LoopInstruction instruction, string code, int position)
        {
            while (code[position] != ']')
            {
                if (code[position] == '[')
                {
                    LoopInstruction child = new LoopInstruction();
                    position = ParseLoopInstruction(child, code, position + 1);
                    instruction.AppendInstruction(child);
                }
                else
                {
                    instruction.AppendInstruction(ParseCharInstr(code[position]));
                }

                position++;
            }

            return position;
        }
    }
}