using System;
using System.Collections.Generic;

namespace Algorythms.ReversePolland
{
    class Program
    {
        static void Main(string[] args)
        {
            string arg;
            Stack<int> st = new Stack<int>();

            while ((arg = Console.ReadLine()) != "exit")
            {
                int num;
                bool isNum = int.TryParse(arg, out num);
                if (isNum)
                    st.Push(num);
                else
                {
                    double op2;
                    switch (arg)
                    {
                        case "+":
                            st.Push(st.Pop() + st.Pop());
                            break;
                        case "*":
                            st.Push(st.Pop() * st.Pop());
                            break;
                        case "-":
                            op2 = st.Pop();
                            st.Push(st.Pop() - op2);
                            break;
                        case "/":
                            op2 = st.Pop();
                            if (op2 != 0.0)
                                st.Push(st.Pop() / op2);
                            else
                                Console.WriteLine("Ошибка. Деление на ноль");
                            break;
                        case "calc":
                            Console.WriteLine("Результат: " + st.Pop());
                            break;
                        default:
                            Console.WriteLine("Ошибка. Неизвестная команда");
                            break;
                    }
                }
            }
        }
    }
}
