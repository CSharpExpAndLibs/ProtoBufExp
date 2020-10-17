using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ProtoBuf;

namespace ProtoBufExp
{
    class Program
    {
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

            Console.WriteLine("--- num={0} ---", dataStructure.num);
            Console.WriteLine("--- name={0} ---", dataStructure.name);

            // Serialize into dataStream
            MemoryStream dataStream = new MemoryStream();
            Serializer.Serialize(dataStream, dataStructure);
            dataStream.Seek(0, SeekOrigin.Begin);

            // Desirialize from stream into d2
            DataStructure d2;
            d2 = Serializer.Deserialize<DataStructure>(dataStream);
            

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
