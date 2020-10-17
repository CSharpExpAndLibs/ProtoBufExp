using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using ProtoBuf;

namespace ProtoBufExp
{
    class ParentBuffer
    {
        public string name { get; set; }
        public byte[] param;
    }

    class Program
    {
        [DllImport("PointarAccessSample.dll", CallingConvention = CallingConvention.Cdecl)]
        unsafe extern public static void ConvertContents(int size, int* data);

        static void Main(string[] args)
        {
            DataStructure dataStructure = new DataStructure();

            dataStructure.num = 10;
            dataStructure.name = "FREAD";
            dataStructure.buffer = new int[10];
            for (int i = 0; i < dataStructure.buffer.Length; i++)
            {
                dataStructure.buffer[i] = i;
            }

            Console.WriteLine("--- Original: -----");
            Console.WriteLine("--- num={0} ---", dataStructure.num);
            Console.WriteLine("--- name={0} ---", dataStructure.name);
            for (int i = 0; i < dataStructure.buffer.Length; i++)
            {
                Console.WriteLine("--- buffer[{0}] = {1} ---", i, dataStructure.buffer[i]);
            }
            Console.WriteLine();
            Console.WriteLine();

            // dllのextern関数を呼び出す
            unsafe
            {
                fixed(int* ptr = &dataStructure.buffer[0])
                {
                    ConvertContents(dataStructure.buffer.Length, ptr);
                }
            }

            // Serialize into dataStream
            MemoryStream dataStream = new MemoryStream();
            Serializer.Serialize(dataStream, dataStructure);
            dataStream.Seek(0, SeekOrigin.Begin);

            // Parent classのデータとして組み込む
            ParentBuffer p = new ParentBuffer();
            p.name = "Example";
            p.param = dataStream.ToArray();


            // Desirialize from stream into d2
            DataStructure d2;
            d2 = Serializer.Deserialize<DataStructure>(new MemoryStream(p.param));

            Console.WriteLine("--- After Conversion: -----");
            Console.WriteLine("--- num={0} ---", d2.num);
            Console.WriteLine("--- name={0} ---", d2.name);
            for (int i = 0; i < d2.buffer.Length; i++)
            {
                Console.WriteLine("--- buffer[{0}] = {1} ---", i, d2.buffer[i]);
            }

            Console.ReadLine();
            
        }
    }
}
