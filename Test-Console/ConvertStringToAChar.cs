using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    internal class ConvertStringToAChar
    {
        public static void Entry()
        {
            char ga = '\u304C';
            Console.Write("str = ");
            string str = Console.ReadLine();

            int hexValue= Convert.ToInt32(str, 16);
            char c = Convert.ToChar(char.ConvertFromUtf32(hexValue));
            Console.WriteLine($"c = {c}");
        }
    }
}
