using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest
{
    class ConvertType
    {
        class A
        {
            public A(string s)
            {
                member = s;
            }

            string member;
        }

        class B
        {
            public B(string s)
            {
                member = s;
            }

            string member;
        }

        static void Cast(object[] vs)
        {
            foreach (object o in vs)
            {
                try
                {
                    A v = (A)o;
                }
                catch
                {

                }
            }
        }

        static void AsIf(object[] vs)
        {
            foreach (object o in vs)
            {
                A v = o as A;
                if (v == null) { }
            }
        }

        static void IfIs(object[] vs)
        {
            foreach (object o in vs)
            {
                if (o is A v) { }
            }
        }

        static void IfIsCast(object[] vs)
        {
            foreach (object o in vs)
            {
                if (o is A)
                {
                    A v = (A)o;
                }
            }
        }

        static void IfIsAs(object[] vs)
        {
            foreach (object o in vs)
            {
                if (o is A)
                {
                    A v = o as A;
                }
            }
        }

        static void TryMethods(int percentageOfA)
        {
            int separator = (int)(percentageOfA / 100f * ss.Length);
            object[] vs = ss.Select((s, i) => i < separator ? (object)new A(s) : new B(s)).ToArray();

            Console.WriteLine($"{percentageOfA}%");
            Console.WriteLine($"Cast:\t\t{Program.Measure(count, () => Cast(vs))}");
            Console.WriteLine($"AsIf:\t\t{Program.Measure(count, () => AsIf(vs))}");
            Console.WriteLine($"IfIs:\t\t{Program.Measure(count, () => IfIs(vs))}");
            Console.WriteLine($"IfIsCast:\t{Program.Measure(count, () => IfIsCast(vs))}");
            Console.WriteLine($"IfIsAs:\t\t{Program.Measure(count, () => IfIsAs(vs))}");
            Console.WriteLine();
        }

        static int count = 3000;
        static string[] ss = new string[10000000];

        public static void Entry()
        {
            Random random = new Random();
            for (int i = 0; i < ss.Length; i++)
            {
                int length = random.Next(10);
                for (int j = 0; j < length; j++)
                {
                    ss[i] += (char)random.Next('A', 'z');
                }
            }

            Console.WriteLine($"count:\t{count}");
            Console.WriteLine($"length:\t{ss.Length}");
            Console.WriteLine();

            /*TryMethods(0);
            TryMethods(20);
            TryMethods(40);
            TryMethods(60);
            TryMethods(80);*/
            TryMethods(100);
        }
    }
}
