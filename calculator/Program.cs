using System;

namespace calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string str;                                              
            str = "2+2/0 ";
            Console.WriteLine(Calc(str));
        }
        public static double Calc(string str)
        {
            int ind1 = 0, ind2 = 0;
            MyStack stE = new MyStack();
            MyStack stT = new MyStack();
            string num = "";            
            for (int i = 0; i < str.Length; i++)
            {
                if ((str[i] != ' ') && (str[i] != '*') && (str[i] != '/') && (str[i] != '+') && (str[i] != '-') && (str[i] != '(') && (str[i] != ')'))
                {
                    num += str[i];
                    if ((str[i + 1] == ' ') || (str[i + 1] == '*') || (str[i + 1] == '/') || (str[i + 1] == '+') || (str[i + 1] == '-') || (str[i + 1] == '(') || (str[i + 1] == ')'))
                    {
                        stE.Push(Convert.ToString(num));
                        num = "";
                    }                   
                }
                else
                {
                    ind2 = Define(str[i]);                   
                    Action(ind1, ind2, str[i], stT, stE);
                    if (ind2 != 6)
                         ind1 = ind2;

                }
               
            }
            return Convert.ToDouble(stE.Pop());
        }
        public static void Action(int ind1, int ind2, char c, MyStack stT, MyStack stE)
        {
            int[,] mas = new int[,] { { 6, 1, 1, 1, 1, 1, 5 },
                                      { 5, 1, 1, 1, 1, 1, 3 },
                                      { 4, 1, 2, 2, 1, 1, 4 },
                                      { 4, 1, 2, 2, 1, 1, 4 },
                                      { 4, 1, 4, 4, 2, 2, 4 },
                                      { 4, 1, 4, 4, 2, 2, 4 } };
            switch (mas[ind1, ind2])
            {
                case 1:
                    f1(c, stT);
                    break;
                case 2:
                    f2(c, stT, stE);
                    break;
                case 3:
                    f3(stT);
                    break;
                case 4:
                    f4(c, stT, stE);
                    break;
                case 5:
                    Console.WriteLine("Error");
                    break;
                case 6:
                    break;                    
            }
        }
        public static int Define (char oper)
        {
            int res = -1;
            switch (oper)
            {
                case ' ':
                    res = 0;
                    break;
                case '(':
                    res = 1;
                    break;
                case '+':
                    res = 2;
                    break;
                case '-':
                    res = 3;
                    break;
                case '*':
                    res = 4;
                    break;
                case '/':
                    res = 5;
                    break;
                case ')':
                    res = 6;
                    break;
            }
            return res;
        }
        public static void Operation(MyStack stT, MyStack stE)
        {
            switch (Convert.ToChar(stT.Pop()))
            {
                case '*':
                    stE.Push(Convert.ToString(Convert.ToDouble(stE.Pop()) * Convert.ToDouble(stE.Pop())));
                    break;
                case '+':
                    stE.Push(Convert.ToString(Convert.ToDouble(stE.Pop()) + Convert.ToDouble(stE.Pop())));
                    break;
                case '/':
                    stE.Push(Convert.ToString(Convert.ToDouble(stE.Pop()) / Convert.ToDouble(stE.Pop())));
                    break;
                case '-':
                    stE.Push(Convert.ToString(Convert.ToDouble(stE.Pop()) - Convert.ToDouble(stE.Pop())));
                    break;
            }
        }
        public static void f1(char oper, MyStack stT)
        {
            stT.Push(Convert.ToString(oper));
        }
        public static void f2(char oper, MyStack stT, MyStack stE)
        {
            Operation(stT, stE);
            f1(oper, stT);
        }
        public static void f3(MyStack stT)
        {
            stT.Del();
        }
        public static void f4(char oper, MyStack stT, MyStack stE)
        {
            Operation(stT, stE);
            Action(Define(Convert.ToChar(stT.Peek())), Define(oper), oper, stT, stE);
        }
    }

}