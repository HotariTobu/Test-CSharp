using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    internal class BitConvertionTest
    {
        public static void Entry()
        {
            byte[] data = BitConverter.GetBytes(100);
            byte[] newData = data.Append((byte)1).ToArray();
            int value = BitConverter.ToInt32(newData, 2);
            Console.WriteLine(value);
        }
    }
}
