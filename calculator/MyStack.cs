using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    internal class MyStack
    {
        public const int StuckSize = 10;
        public const int Empty = -1;

        private string[] arrStack = new string[StuckSize];
        private int top = Empty;

        public void Push(string s)
        {
            arrStack[++top] = s;
        }
        public void Pop(out string s)
        {
            s = arrStack[top--];
        }
        public void Peek(out string s)
        {
            s = arrStack[top];
        }
    }
}