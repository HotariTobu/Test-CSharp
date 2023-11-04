using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.ZONE
{
    class s2
    {
        public static void Entry()
        {
            int count = 0;
            while (true)
            {
                string str = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(str))
                {
                    break;
                }
                count += str.Split(' ').Count(e =>
                 {
                     int num = int.Parse(e);
                     if (num <= 1)
                     {
                         return false;
                     }

                     for (int i = 2; i < num; i++)
                     {
                         if (num % i == 0)
                         {
                             return false;
                         }
                     }
                     return true;
                 });
            }

            Console.WriteLine(count);
        }
    }
}
