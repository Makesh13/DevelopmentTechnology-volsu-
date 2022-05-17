using System;
using Algorythms.RegularExpression;

namespace Algorythms.RegularExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            //(bc|ab)*|(bd*)+

            char[] text = Console.ReadLine().ToCharArray();
            ExpressionConverter.Convert(text);
            Console.Read();
        }
    }
}
