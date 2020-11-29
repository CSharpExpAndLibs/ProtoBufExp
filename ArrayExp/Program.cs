using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using ProtoBuf;

namespace ArrayExp
{
    
    class Program
    {
        static void Main(string[] args)
        {
            DataStructure d = new DataStructure();
            d.BoolArray2 = new bool[] { false, true };
            d.IntArray2 = new int[] { -1, -2 };

            Console.WriteLine("--- Before Serialize ---");
            d.WriteMember();

            // 処理を繰り返すたびに配列の長さが増大する?
            //   --> 配列のプロパティに初期化子を与えると、Desirializeするたびに
            //       再現されたデータの前に、新たに初期化されたデータが付加される。
            //       コンストラクタで初期化した場合も同じ振る舞い。
            //       配列をProtoMemberに加える場合は、初期化子を与えてはいけない。
            DataStructure din = d;
            DataStructure dout;
            for (int cnt = 0; cnt < 3; cnt++)
            {
                // 再初期化（？）によって設定した値が何処に配置されるのかを
                // 確認する
                din.BoolArray[0] = din.BoolArray[1] = false;
                din.IntArray[0] = 10 * (cnt + 1);
                din.IntArray[1] = -din.IntArray[0];

                din.BoolArray3 = new bool[] { false, false };
                din.IntArray3 = new int[] { 100, -100 };

                if (cnt%2 == 0)
                {
                    din.BoolArray4 = new bool[] { true, true };
                    din.IntArray4 = new int[] { 100, 200 };
                }
                else
                {
                    din.BoolArray4 = new bool[] { false, false };
                    din.IntArray4 = new int[] { -100, -200 };
                }
                

                din.len = 100 * (cnt + 1);

                // Serialize
                MemoryStream mstream = new MemoryStream();
                Serializer.Serialize<DataStructure>(mstream, din);
                mstream.Seek(0, SeekOrigin.Begin);

                // Deserialize
                dout = Serializer.Deserialize<DataStructure>(new MemoryStream(mstream.ToArray()));

                Console.WriteLine($"--- After Serialize/Deserialize #{cnt+1} ---");
                dout.WriteMember();

                din = dout;
            }

            Console.ReadLine();
        }

#if false
        static void SerDes<T>(T d)
        {
            Console.WriteLine("--- Before Serialize ---");
            d.GetType().GetMethod(
                "WriteMember",
                BindingFlags.Public | BindingFlags.Instance).Invoke(d, null);

            // 処理を繰り返すたびに配列の長さが増大する?
            //   --> 配列のプロパティに初期化子を与えると、Desirializeするたびに
            //       再現されたデータの後ろに新たに初期化されたデータが付加される
            //       ように見える。
            T din = d;
            T dout;
            for (int cnt = 0; cnt < 3; cnt++)
            {
                // Serialize
                MemoryStream mstream = new MemoryStream();
                Serializer.Serialize<T>(mstream, din);
                mstream.Seek(0, SeekOrigin.Begin);

                // Deserialize
                dout = Serializer.Deserialize<T>(new MemoryStream(mstream.ToArray()));

                Console.WriteLine($"--- After Serialize/Deserialize #{cnt + 1} ---");
                dout.GetType().GetMethod(
                    "WriteMember",
                    BindingFlags.Public | BindingFlags.Instance).Invoke(d, null);
                din = dout;
            }

        }
#endif
    }
}
