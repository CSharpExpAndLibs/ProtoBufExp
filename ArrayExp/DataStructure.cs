using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace ArrayExp
{
    [ProtoContract]
    class DataStructure
    {
        [ProtoMember(1)]
        public int len { get; set; } = 2;

        [ProtoMember(2)]
        public int[] IntArray { get; set; } = new int[] { 0, 1 };

        [ProtoMember(3)]
        public bool[] BoolArray { get; set; } = new bool[] { true, false };

        [ProtoMember(4)]
        public int[] IntArray2 { get; set; }

        [ProtoMember(5)]
        public bool[] BoolArray2 { get; set; }

        [ProtoMember(6)]
        public int[] IntArray3 { get; set; }

        [ProtoMember(7)]
        public bool[] BoolArray3 { get; set; }

        public DataStructure()
        {
            IntArray3 = new int[] { 2, 3 };
            BoolArray3 = new bool[] { false, true };
        }

        public void WriteMember()
        {
            Console.WriteLine($"len={len}");
            Console.WriteLine($"Length of IntArray={IntArray.Length}");
            Console.WriteLine($"Length of BoolArray={BoolArray.Length}");
            Console.WriteLine($"Length of IntArray2={IntArray2.Length}");
            Console.WriteLine($"Length of BoolArray2={BoolArray2.Length}");
            Console.WriteLine($"Length of IntArray3={IntArray3.Length}");
            Console.WriteLine($"Length of BoolArray3={BoolArray3.Length}");

            int idx = 0;
            Console.Write("IntArray:");
            foreach (int i in IntArray)
            {
                Console.Write($"[{idx}]={i},");
                idx++;
            }
            Console.WriteLine();

            idx = 0;
            Console.Write("BoolArray:");
            foreach (bool b in BoolArray)
            {
                Console.Write($"[{idx}]={b},");
                idx++;
            }
            Console.WriteLine();

            idx = 0;
            Console.Write("IntArray2:");
            foreach (int i in IntArray2)
            {
                Console.Write($"[{idx}]={i},");
                idx++;
            }
            Console.WriteLine();

            idx = 0;
            Console.Write("BoolArray2:");
            foreach (bool b in BoolArray2)
            {
                Console.Write($"[{idx}]={b},");
                idx++;
            }
            Console.WriteLine();

            idx = 0;
            Console.Write("IntArray3:");
            foreach (int i in IntArray3)
            {
                Console.Write($"[{idx}]={i},");
                idx++;
            }
            Console.WriteLine();

            idx = 0;
            Console.Write("BoolArray3:");
            foreach (bool b in BoolArray3)
            {
                Console.Write($"[{idx}]={b},");
                idx++;
            }
            Console.WriteLine();

        }
    }
}
