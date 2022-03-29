using System;

namespace calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStack a = new MyStack();

        }
        public static double Calc(string str)
        {
            int ind1 = 0, ind2 = 0;
            int[,] mas = new int[,] { { 6, 1, 1, 1, 1, 1, 5 },
                                      { 5, 1, 1, 1, 1, 1, 3 },
                                      { 4, 1, 2, 2, 1, 1, 4 },
                                      { 4, 1, 2, 2, 1, 1, 4 },
                                      { 4, 1, 4, 4, 2, 2, 4 },
                                      { 4, 1, 4, 4, 2, 2, 4 } };
            MyStack stE = new MyStack();
            MyStack stT = new MyStack();
            string num = "";
            char oper;
            for (int i = 0; i < str.Length; i++)
            {
                if ((str[i] != '*') && (str[i] != '/') && (str[i] != '+') && (str[i] != '-') && (str[i] != '(') && (str[i] != ')'))
                {
                    num += str[i];
                    if ((str[i + 1] == '*') || (str[i + 1] == '/') || (str[i + 1] == '+') || (str[i + 1] == '-') || (str[i + 1] == '(') || (str[i + 1] == ')'))
                    {
                        stE.Push(Convert.ToString(num));
                    }
                    else
                    {
                        num = "";
                    }
                }
                else
                {
                    oper = str[i];
                    switch (oper)
                    {
                        case ' ':
                            ind2 = 0;
                            break;
                        case '(':
                            ind2 = 1;
                            break;
                        case '+':
                            ind2 = 2;
                            break;
                        case '-':
                            ind2 = 3;
                            break;
                        case '*':
                            ind2 = 4;
                            break;
                        case '/':
                            ind2 = 5;
                            break;
                        case ')':
                            ind2 = 6;
                            break;
                    }
                    switch (mas[ind1, ind2])
                    {
                        case 1:
                            stT.Push(Convert.ToString(oper));
                            break;
                        case 2:

                    }

                }
            }
        }
        public static void f2()
    }

}