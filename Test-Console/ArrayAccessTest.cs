using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ConsoleTest
{
    unsafe internal class ArrayAccessTest
    {
        private static readonly int Count = 10000000;
        private static readonly int Size = 10;

        private static int[] VSA { get; } = new int[Size];
        private static IntPtr VSPH = Marshal.AllocHGlobal(sizeof(int) * Size);
        private static int* VSP { get; } = (int*)VSPH.ToPointer();

        private static void Array()
        {
            int[] a = VSA;
            for (int i = 0; i < Size; i++)
            {
                a[i] = i;
            }
        }

        private static void Pointer1()
        {
            int* p = VSP;
            for (int i = 0; i < Size; i++)
            {
                p[i] = i;
            }
        }

        private static void Pointer2()
        {
            int* p = VSP;
            for (int i = 0; i < Size; i++)
            {
                *(p + i) = i;
            }
        }

        private static void Pointer3()
        {
            int* p = VSP;
            for (int i = 0; i < Size; i++)
            {
                *p = i;
                p++;
            }
        }

        private static void Pointer4()
        {
            int* p = VSP;
            for (int i = 0; i < Size; i++)
            {
                *p = i;
                p += 1;
            }
        }

        public static void Entry()
        {
            /*Console.WriteLine($"Array:   \t{Program.Measure(Count, Array)}");
            Console.WriteLine($"Pointer1:\t{Program.Measure(Count, Pointer1)}");
            Console.WriteLine($"Pointer2:\t{Program.Measure(Count, Pointer2)}");
            Console.WriteLine($"Pointer3:\t{Program.Measure(Count, Pointer3)}");
            Console.WriteLine($"Pointer4:\t{Program.Measure(Count, Pointer4)}");*/

            Console.WriteLine(Program.Measure(Count, Array).TotalMilliseconds);
            Console.WriteLine(Program.Measure(Count, Pointer1).TotalMilliseconds);
            Console.WriteLine(Program.Measure(Count, Pointer2).TotalMilliseconds);
            Console.WriteLine(Program.Measure(Count, Pointer3).TotalMilliseconds);
            Console.WriteLine(Program.Measure(Count, Pointer4).TotalMilliseconds);

            Marshal.FreeHGlobal(VSPH);
        }
    }
}
