using System;
using System.Collections.Generic;
using System.Text;

namespace Algorythms.RegularExpression
{
    static class ExpressionConverter
    {
        public static void Convert(char[] str)
        {
            int i = 0;
            int state = 1;

            //char[] str = Console.ReadLine().ToCharArray();
            
            while (i < str.Length)
            {
                switch (state)
                {
                    case 1:
                        if (str[i].Equals('a'))
                        {
                            state = 2;
                            Console.Write("a");
                        }
                        else if (str[i].Equals('b'))
                        {
                            state = 3;
                            Console.Write('b');
                        }
                        else
                        {
                            Console.WriteLine();
                            state = 1;
                        }

                        i++;
                        break;
                    case 2:
                        if (str[i].Equals('b'))
                        {
                            state = 4;
                            Console.Write('b');
                        }
                        else
                        {
                            Console.WriteLine();
                            state = 1;
                        }

                        i++;
                        break;
                    case 3:
                        if (str[i].Equals('c'))
                        {
                            Console.Write('c');
                            state = 4;
                        }
                        else if (str[i].Equals('b') || str[i].Equals('d'))
                        {
                            Console.Write(str[i]);
                            state = 5;
                        }
                        else
                        {
                            Console.WriteLine();
                            state = 1;
                        }

                        i++;
                        break;
                    case 4:
                        if (str[i].Equals('b'))
                        {
                            state = 6;
                            Console.Write('b');
                        }
                        else if (str[i].Equals('a'))
                        {
                            state = 2;
                            Console.Write('a');
                        }
                        else
                        {
                            Console.WriteLine();
                            state = 1;
                        }

                        i++;
                        break;
                    case 5:
                        if (str[i].Equals('b') || str[i].Equals('d'))
                        {
                            state = 5;
                            Console.Write(str[i]);
                        }
                        else
                        {
                            Console.WriteLine();
                            state = 1;
                        }

                        i++;
                        break;
                    case 6:
                        if (str[i].Equals('c'))
                        {
                            state = 4;
                            Console.Write('c');
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
