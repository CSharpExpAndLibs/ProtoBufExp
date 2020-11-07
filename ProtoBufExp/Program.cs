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
        [DllImport("PointarAccessSample", CallingConvention = CallingConvention.Cdecl)]
        unsafe extern public static void ConvertContents(int size, int* data);

        static void Main(string[] args)
        {
            DataStructure dataStructure = new DataStructure()
            {
                Id = "Special Session!",
                Buffer = new BufferBase[]
                {
                    new BufferBase()
                    {
                        Name = "一号",
                        Data = new int[]
                        {
                            100,
                            200,
                        },
                    },
                    new BufferBase()
                    {
                        Name = "二号",
                        Data = new int[]
                        {
                            -4,
                            -500,
                        },
                    },
                },
            };

            Console.WriteLine("--- Original: -----");
            DispDataStructure(dataStructure);

            // データ構造に多次元かjagged構成の、配列・リスト・辞書・マップ
            // が含まれていると"UnsupportedException"が発生する。
            // 構成はシンプルな一次元でないとだめらしい。
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
            DispDataStructure(d2);

            Console.ReadLine();
            
        }
        static void DispDataStructure(DataStructure d)
        {
            Console.WriteLine($"Id = {d.Id}");
            int idx = 0;
            foreach (var buf in d.Buffer)
            {
                Console.WriteLine($"Buffer[{idx}].Name = {buf.Name}");
                for (int i = 0; i < buf.Data.Length; i++)
                {
                    Console.WriteLine($"Data[{i}]={buf.Data[i]}");
                }
                idx++;
            }

        }
    }
}
