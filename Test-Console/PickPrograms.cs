using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    internal class PickPrograms
    {
        public static void Entry()
        {
            for (int i = 0; i < 10000; i++)
            {
                Console.Write('.');

                Programs programs = new Programs();
                var result1 = programs.pickEach();
                var result2 = programs.pickEach2();

                if (!result1.SequenceEqual(result2))
                {
                    Console.WriteLine();
                    programs.Write();
                    WriteSequence(result1);
                    WriteSequence(result2);
                    Console.WriteLine();
                }
            }
        }

        static void WriteSequence(IEnumerable<int> vs)
        {
            foreach (var value in vs)
            {
                Console.Write(value);
                Console.Write("\t");
            }
            Console.WriteLine();
        }

        class Programs
        {
            int N, n;
            public Program[] ps;
            public Programs()
            {
                Random random = new Random();

                N = random.Next(2, 32);
                ps = new Program[N];

                for (int i = 0; i < N; i++)
                {
                    ps[i] = new Program();
                }

                ps = ps.OrderBy(p => p.a + p.b * 1000).ToArray();
                
                /*ps = new Program[]
                {
                    new Program(){ a = 10, b = 20, c = 9},
                    new Program(){ a = 0, b = 10, c = 4},
                };
                N = ps.Length;*/
            }

            public int[] pickEach2()
            {
                int[] result = new int[N];

                var list = new List<Program>();

                int max = 0;

                for (n = 0; n < N; n++)
                {
                    int count = list.Count;

                    for (int i = 0; i < count; i++)
                    {
                        if (max < list[i].c)
                        {
                            max = list[i].c;
                        }

                        if (!ps[n].IsIntersectedWith(list[i]))
                        {
                            list.Add(ps[n] + list[i]);
                        }
                    }

                    list.Add(ps[n]);

                    for (int i = count; i < list.Count; i++)
                    {
                        if (max < list[i].c)
                        {
                            max = list[i].c;
                        }
                    }

                    result[n] = max;
                }

                return result;
            }

            public int[] pickEach()
            {
                int[] result = new int[N];
                for (n = 1; n <= N; n++)
                {
                    result[n - 1] = pick(0, 0, 30, -10);
                }
                return result;
            }

            int pick(int sum, int level, int start, int end)
            {
                if (n == level)
                {
                    return sum;
                }

                int sum1 = pick(sum, level + 1, start, end);

                if (level > 0 && ps[level].IsIntersectedWith(start, end))
                {
                    return sum1;
                }

                Program p = ps[level];
                int sum2 = pick(sum + p.c, level + 1, Math.Min(start, p.a), Math.Max(end, p.b));
                return Math.Max(sum1, sum2);
            }

            public void Write()
            {
                WriteSequence(ps.Select(p => p.a));
                WriteSequence(ps.Select(p => p.b));
                WriteSequence(ps.Select(p => p.c));
            }
        }

        class Program
        {
            public int a, b, c;

            public Program()
            {
                Random random = new Random();
                a = random.Next(12);
                b = random.Next(a + 1, 24);
                c = random.Next(1, 10);
            }

            public bool IsIntersectedWith(Program p) => IsIntersectedWith(p.a, p.b);
            public bool IsIntersectedWith(int pa, int pb)
            {
                //Console.WriteLine($"({a}, {b})\t({pa}, {pb})\t{(a != pb && pa != b) && ((a <= pb && a >= pa) || (b <= pb && b >= pa) || (pa <= b && pa >= a) || (pb <= b && pb >= a))}");
                return (a != pb && pa != b) && ((a <= pb && a >= pa) || (b <= pb && b >= pa) || (pa <= b && pa >= a) || (pb <= b && pb >= a));
            }

            public static Program operator +(Program p1, Program p2)
            {
                return new Program()
                {
                    a = Math.Min(p1.a, p2.a),
                    b = Math.Max(p1.b, p2.b),
                    c = p1.c + p2.c,
                };
            }

            public override string ToString()
            {
                return $"{a}, {b}, {c}";
            }
        }
    }
}
