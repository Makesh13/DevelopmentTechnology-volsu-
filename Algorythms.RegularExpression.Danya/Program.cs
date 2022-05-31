using System;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            // (bcc)+|(bd*)+
            int i = 0;
            int state = 1;

            string str = Console.ReadLine();
            char[] s = str.ToCharArray();

            while (i < s.Length)
            {
                switch (state)
                {
                    case 1:
                        if (s[i] == 'b')
                        {
                            state = 2;
                            Console.WriteLine();
                            Console.Write("b");
                        }
                        else
                        {
                            Console.WriteLine();
                            state = 1;
                        }
                        i++;
                        break;
                    case 2:
                        if (s[i] == 'b')
                        {
                            state = 3;
                            Console.WriteLine();
                            Console.Write("b");
                        }
                        else if (s[i] == 'd')
                        {
                            state = 3;
                            Console.Write("d");
                        }
                        else if (s[i] == 'c')
                        {
                            state = 4;
                        }
                        else
                        {
                            Console.WriteLine();
                            state = 1;
                        }
                        i++;
                        break;
                    case 3:
                        if (s[i] == 'b')
                        {
                            state = 2;
                            Console.WriteLine();
                            Console.Write("b");
                        }
                        else if (s[i] == 'd')
                        {
                            state = 2;
                            Console.Write("d");
                        }
                        else
                        {
                            Console.WriteLine();
                            state = 1;
                        }
                        i++;
                        break;
                    case 4:
                        if (s[i] == 'c')
                        {
                            state = 5;
                            Console.Write("cc");
                        }
                        else
                        {
                            Console.WriteLine();
                            state = 1;
                        }
                        i++;
                        break;
                    case 5:
                        if (s[i] == 'b')
                        {
                            state = 2;
                            Console.Write("b");
                        }
                        else
                        {
                            Console.WriteLine();
                            state = 1;
                        }
                        i++;
                        break;

                    default:
                        state = 1;
                        i++;
                        break;
                }
            }
        }
    }
}
