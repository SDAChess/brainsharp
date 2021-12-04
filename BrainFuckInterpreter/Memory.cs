namespace BrainFuckInterpreter
{
    public class Memory
    {
        private int index;
        private int[] memory;

        public Memory()
        {
            index = 0;
            memory = new int[3000];
        }
        
        public Memory(int memorySize)
        {
            index = 0;
            memory = new int[memorySize];
        }

        public void IncrementPtr()
        {
            index += 1;
        }
        
        public void DecrementPtr()
        {
            //TODO Implement error when i < 0;
            index -= 1;
        }

        public void IncrementData()
        {
            memory[index] += 1;
        }

        public void DecrementData()
        {
            memory[index] -= 1;
        }

        public int GetMemoryContent()
        {
            return memory[index];
        }
        
        public void SetMemoryContent(int value)
        {
            memory[index] = value;
        }

    }
}