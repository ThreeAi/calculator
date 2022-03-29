using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    class MyStack
    {
        public const int StuckSize = 10;
        public const int Empty = -1;

        private string[] arrStack = new string[StuckSize];
        private int top = Empty;

        public void Push(string s)
        {
            arrStack[++top] = s;
        }
        public string Pop()
        {
            return arrStack[top--];
        }
        public string Peek()
        {
            if (top == -1)
                return " ";
            else
                return arrStack[top];
        }
        public void Del()
        {
            top--;
        }
    }
}