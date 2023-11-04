using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest
{
    internal class PickNumbers
    {
        static int N;
        static int[] numbers;
        public static void Entry()
        {
            Random random = new Random();
            for (int i = 0; i < 10000; i++)
            {
                Console.Write('.');

                N = random.Next(1, 32);
                numbers = new int[N];
                for (int j = 0; j < N; j++)
                {
                    numbers[j] = random.Next(100);
                }

                var result1 = pickEach();
                var result2 = pickEach2();

                if (!result1.SequenceEqual(result2))
                {
                    Console.WriteLine();
                    WriteSequence(numbers);
                    WriteSequence(result1);
                    WriteSequence(result2);
                    Console.WriteLine();
                }
            }
        }

        static void WriteSequence(int[] vs)
        {
            for (int i = 0; i < vs.Length; i++)
            {
                Console.Write(vs[i]);
                Console.Write("\t");
            }
            Console.WriteLine();
        }

        static int[] pickEach2()
        {
            int[] result = new int[N];
            int[] c = new int[N];

            switch (N)
            {
                case 0:
                    return result;
                case 1:
                    result[0] = numbers[0];
                    return result;
                case 2:
                    result[0] = numbers[0];
                    result[1] = numbers[0] + numbers[1];
                    return result;
                case 3:
                    result[0] = numbers[0];
                    result[1] = numbers[0] + numbers[1];
                    result[2] = Math.Max(Math.Max(numbers[0] + numbers[1], numbers[1] + numbers[2]), numbers[0] + numbers[2]);
                    return result;
                case 4:
                    result[0] = numbers[0];
                    result[1] = numbers[0] + numbers[1];
                    result[2] = Math.Max(Math.Max(numbers[0] + numbers[1], numbers[1] + numbers[2]), numbers[0] + numbers[2]);
                    result[3] = Math.Max(Math.Max(numbers[0] + numbers[1] + numbers[3], numbers[0] + numbers[2] + numbers[3]), numbers[1] + numbers[2]);
                    return result;
            }

            result[0] = numbers[0];
            result[1] = numbers[0] + numbers[1];
            result[2] = Math.Max(Math.Max(numbers[0] + numbers[1], numbers[1] + numbers[2]), numbers[0] + numbers[2]);
            result[3] = Math.Max(Math.Max(numbers[0] + numbers[1] + numbers[3], numbers[0] + numbers[2] + numbers[3]), numbers[1] + numbers[2]);

            if (result[3] == numbers[1] + numbers[2])
            {
                c[3] = 0;
            }
            else if (result[3] == numbers[0] + numbers[1] + numbers[3])
            {
                c[3] = 1;
            }
            else
            {
                c[3] = 2;
            }

            for (n = 4; n < N; n++)
            {
                if (c[n - 1] == 2)
                {
                    int x = result[n - 1];
                    int y = result[n - 2] + numbers[n];
                    int z = result[n - 3] + numbers[n - 1] + numbers[n];
                    result[n] = Math.Max(Math.Max(x, y), z);

                    if (result[n] == x)
                    {
                        c[n] = 0;
                    }
                    else if (result[n] == y)
                    {
                        c[n] = 1;
                    }
                    else
                    {
                        c[n] = 2;
                    }
                }
                else
                {
                    result[n] = result[n - 1] + numbers[n];
                    c[n] = c[n - 1] + 1;
                }
            }

            return result;
        }

        static int n;
        static int[] pickEach()
        {
            int[] result = new int[N];
            for (n = 1; n <= N; n++)
            {
                result[n - 1] = pick(0, 0);
            }
            return result;
        }

        static int pick(int flags, int level)
        {
            if (n == level)
            {
                int sum = 0;
                for (int i = 0; i < n; i++)
                {
                    if (get(flags, i))
                    {
                        sum += numbers[i];
                    }
                }
                return sum;
            }

            int sum1 = pick(flags, level + 1);

            if (level >= 2 && get(flags, level - 2) && get(flags, level - 1))
            {
                return sum1;
            }

            set(ref flags, level);
            int sum2 = pick(flags, level + 1);
            return Math.Max(sum1, sum2);
        }

        static bool get(int x, int i)
        {
            return ((x >> i) & 1) != 0;
        }

        static void set(ref int x, int i, bool v = true)
        {
            if (v)
            {
                x |= (1 << i);
            }
        }

        static bool[] gets(int x)
        {
            bool[] v = new bool[n];
            for (int i = 0; i < n; i++)
            {
                v[i] = get(x, i);
            }
            return v;
        }
    }
}
