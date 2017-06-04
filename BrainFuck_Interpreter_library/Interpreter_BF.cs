using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainFuck_Interpreter_library
{
    public class Interpreter_BF
    {
        #region Constructors
        public Interpreter_BF(string BF_machine_instructions, string Inputs)
        {
            this.memoryPointer = 0;
            this.instructionPointer = 0;
            this.inputPointer = 0;
            this.machine_memory = new byte[ushort.MaxValue + 1];
            this.BF_machine_instructions = BF_machine_instructions;
            this.Inputs = Inputs;
            this.loop_call_stack = new Stack<int>();
            this.Outputs = "";
        }
        #endregion

        #region Fields
        private ushort memoryPointer;
        private int instructionPointer;
        private int inputPointer;
        private byte[] machine_memory;
        private string BF_machine_instructions;
        private string Inputs;
        private Stack<int> loop_call_stack;
        #endregion

        #region Properties
        public string Outputs { get; private set; }
        #endregion

        #region Methods
        public void Interpret()
        {
            StringBuilder OutputBuilder = new StringBuilder();

            while (this.instructionPointer < this.BF_machine_instructions.Length)
            {
                char ch = this.BF_machine_instructions[this.instructionPointer];

                switch (ch)
                {
                    case '>':
                        this.memoryPointer++;
                        goto default;

                    case '<':
                        this.memoryPointer--;
                        goto default;

                    case '+':
                        this.machine_memory[this.memoryPointer]++;
                        goto default;

                    case '-':
                        this.machine_memory[this.memoryPointer]--;
                        goto default;

                    case '.':
                        OutputBuilder.Append((char)this.machine_memory[this.memoryPointer]);
                        goto default;

                    case ',':
                        this.machine_memory[this.memoryPointer] = (byte)this.Inputs[this.inputPointer];
                        this.inputPointer++;
                        goto default;

                    case '[':
                        if (this.machine_memory[this.memoryPointer] == 0)
                        {
                            int loops = 1;

                            while (loops > 0)
                            {
                                this.instructionPointer++;

                                if (this.BF_machine_instructions[this.instructionPointer] == '[')
                                    loops++;
                                else if (this.BF_machine_instructions[this.instructionPointer] == ']')
                                    loops--;
                            }
                        }
                        else
                            this.loop_call_stack.Push(this.instructionPointer);
                        goto default;

                    case ']':
                        this.instructionPointer = this.loop_call_stack.Pop();
                        break;

                    default:
                        this.instructionPointer++;
                        break;
                }
            }

            this.Outputs = OutputBuilder.ToString();
        }
        #endregion

    }
}
