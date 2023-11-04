using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.ZONE
{
    class s1
    {
        public static void Entry()
        {
            List<string> vs = new List<string>();
            while (true)
            {
                string str = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(str))
                {
                    break;
                }
                vs.Add(new string(str.Select(c => (char)('a' + ((int)c - 'a' + 13) % 26)).ToArray()));
            }

            foreach (string str in vs)
            {
                Console.WriteLine(str);
            }
        }
    }
}
