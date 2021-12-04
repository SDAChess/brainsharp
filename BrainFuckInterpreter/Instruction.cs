using System;
using System.Collections.Generic;

namespace BrainFuckInterpreter
{
    public class LoopInstruction : Instruction
    {
        private List<Instruction> body = new List<Instruction>();

        public void AppendInstruction(Instruction instr)
        {
            body.Add(instr);
        }

        public List<Instruction> GetInstructions()
        {
            return this.body;
        }

        public override void Execute(Memory memory)
        {
            while (memory.GetMemoryContent() != 0)
            {
                foreach (var instruction in body)
                {
                    instruction.Execute(memory);
                }
            }
        }
    }

    public class IncrementPtr : Instruction
    {
        public override void Execute(Memory memory)
        {
            memory.IncrementPtr();
        }
    }

    public class DecrementPtr : Instruction
    {
        public override void Execute(Memory memory)
        {
            memory.DecrementPtr();
        }
    }

    public class IncrementData : Instruction
    {
        public override void Execute(Memory memory)
        {
            memory.IncrementData();
        }
    }

    public class DecrementData : Instruction
    {
        public override void Execute(Memory memory)
        {
            memory.DecrementData();
        }
    }

    public class OutputByte : Instruction
    {
        public override void Execute(Memory memory)
        {
            Console.Write((char) memory.GetMemoryContent());
        }
    }
    
    public class InputByte : Instruction
    {
        public override void Execute(Memory memory)
        {
            //TODO Handle IO errors.
            memory.SetMemoryContent(Console.Read());
        }
    }

    public abstract class Instruction
    {
        public abstract void Execute(Memory memory);
    }
}