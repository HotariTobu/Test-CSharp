using System;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ArrayAccessTest.Entry();
        }

        public static TimeSpan Measure(int count, Action action)
        {
            DateTime time = DateTime.Now;
            for (int i = 0; i < count; i++)
            {
                action();
            }
            return DateTime.Now - time;
        }
    }
}
