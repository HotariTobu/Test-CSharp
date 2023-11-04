using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    internal class LINQTest
    {
        public static void Entry()
        {
            IEnumerable<int> vs = Enumerable.Range(0, 10);
            write(vs);
            write(vs.Take(new Range(0, 4)));
            write(vs.Take(new Range(2, 5)));

            void write(IEnumerable<int> vs)
            {
                Console.WriteLine(string.Join(", ", vs.Select(x => x.ToString())));
            }
        }
    }
}
