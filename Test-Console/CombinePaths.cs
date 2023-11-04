using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleTest
{
    class CombinePaths
    {
        public static void Entry()
        {
            string p1 = @"TEST\SUB";
            string p2 = @"../../TEST.txt";

            string p3 = Path.Combine(p1, p2);
            TryRead(p3);
            //TryRead(Path.GetRelativePath(p1, p2));
            TryRead(Path.Join(p1, p2));
            string p4 = Path.GetFullPath(p3);
            TryRead(p4);

            Console.WriteLine(Path.GetRelativePath(p1, p4));
            Console.WriteLine(Path.GetDirectoryName(p4));
        }

        static void TryRead(string path)
        {
            try
            {
                Console.WriteLine(path);
                Console.WriteLine(File.ReadAllText(path));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
