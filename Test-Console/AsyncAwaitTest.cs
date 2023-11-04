using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    internal class AsyncAwaitTest
    {
        public static void Entry()
        {
            new AsyncAwaitTest().MainTask();
            Console.ReadKey();
        }

        void MainTask()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Main Task {i}");
                SubTask(i);
            }
        }

        //待たない
        async void SubTask(int i)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.WriteLine($"Sub Task {i} {j}");
                await SubSubTask(i, j);
            }
        }

        //待つ
        async Task SubSubTask(int i, int j)
        {
            for (int k = 0; k < 3; k++)
            {
                Console.WriteLine($"Sub Sub Task {i} {j} {k}");
                await Task.Delay(1000);
            }
        }
    }
}
