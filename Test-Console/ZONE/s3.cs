using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.ZONE
{
    class s3
    {
        public static void Entry()
        {
            int[] nm = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
            int n = nm[0];
            HashSet<int>[] vs = new HashSet<int>[n];
            for (int i = 0; i < n; i++)
            {
                vs[i] = new HashSet<int>();
            }
            for (int i=0; i<nm[1]; i++)
            {
                int[] pc = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
                vs[pc[0]].Add(pc[1]);
                vs[pc[1]].Add(pc[0]);
            }

            int max = 0;
            string re = "temp";
            Console.WriteLine();

            /*for (int x = 0; x < n; x++)
            {
                HashSet<int> cx = vs[x].Union(new int[] { x }).ToHashSet();
                for (int y = x + 1; y < n; y++)
                {
                    if (cx.Contains(y))
                    {
                        break;
                    }

                    HashSet<int> cy = vs[y].Union(cx.Append(y)).ToHashSet();
                    for (int z = y + 1; z < n; z++)
                    {
                        if (cy.Contains(z))
                        {
                            break;
                        }

                        HashSet<int> cz = vs[z].Union(cy.Append(z)).ToHashSet();
                        int c = cz.Count;
                        if (max < c)
                        {
                            max = c;
                            re = $"{x} {y} {z} {c}";
                        }
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine(re);*/

            for (int x = 0; x < n; x++)
            {
                for (int y = 0; y < n; y++)
                {
                    for (int z = 0; z < n; z++)
                    {
                        int c = vs[x].Union(vs[y]).Union(vs[z]).Union(new int[] { x, y, z }).Count();
                        /*HashSet<int> ts = new HashSet<int>();
                        ts.Add(x);
                        ts.Add(y);
                        ts.Add(z);
                        foreach (int v in vs[x])
                        {
                            ts.Add(v);
                        }
                        foreach (int v in vs[y])
                        {
                            ts.Add(v);
                        }
                        foreach (int v in vs[z])
                        {
                            ts.Add(v);
                        }
                        c = ts.Count;*/
                        if (max < c)
                        {
                            max = c;
                            re = $"{x} {y} {z} {c}";
                        }
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine(re);

            return;
        }

        static List<int> range(int start, int end)
        {
            int count = end - start;
            if (count < 1)
            {
                return new List<int>();
            }
            else
            {
                return Enumerable.Range(start, count).ToList();
            }
        }
    }
}
