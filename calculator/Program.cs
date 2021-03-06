using System;

namespace calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string str;
            Console.WriteLine("Введите арифментической выражение (без пробелов)");
            str = Console.ReadLine();
            Console.WriteLine(Calc(str));
        }
        public static double Calc(string str)
        {
            int[,] mas = new int[,] { { 6, 1, 1, 1, 1, 1, 5 },
                                      { 5, 1, 1, 1, 1, 1, 3 },
                                      { 4, 1, 2, 2, 1, 1, 4 },
                                      { 4, 1, 2, 2, 1, 1, 4 },
                                      { 4, 1, 4, 4, 2, 2, 4 },
                                      { 4, 1, 4, 4, 2, 2, 4 } };
            int ind1 = 0, ind2 = 0;
            MyStack stE = new MyStack();
            MyStack stT = new MyStack();
            string num = "";
            str += " ";
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
                    ind1 = Define(Convert.ToChar(stT.Peek()));
                    Action(ind1, ind2, str[i], stT, stE, mas);
                }
            }
            return Convert.ToDouble(stE.Pop());
        }
        public static void Action(int ind1, int ind2, char c, MyStack stT, MyStack stE, int[,] mas)
        {
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
                    f4(stT, stE);
                    Action(Define(Convert.ToChar(stT.Peek())), Define(c), c, stT, stE, mas);
                    break;
                case 5:
                    Console.WriteLine("Ошибка в выражении");
                    Environment.Exit(0);
                    break;
            }
        }
        public static int Define(char oper)
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
            double a, b;
            b = Convert.ToDouble(stE.Pop());
            a = Convert.ToDouble(stE.Pop());
            switch (Convert.ToChar(stT.Pop()))
            {
                case '*':
                    stE.Push(Convert.ToString(a * b));
                    break;
                case '+':
                    stE.Push(Convert.ToString(a + b));
                    break;
                case '/':
                    if (b != 0)
                        stE.Push(Convert.ToString(a / b));
                    else
                    {
                        Console.WriteLine("Делить на ноль нельзя");
                        Environment.Exit(0);
                    }
                    break;
                case '-':
                    stE.Push(Convert.ToString(a - b));
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
        public static void f4(MyStack stT, MyStack stE)
        {
            Operation(stT, stE);
        }
    }

}