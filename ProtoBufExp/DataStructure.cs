using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace ProtoBufExp
{
    [ProtoContract]
    unsafe struct FixedBuffer
    {
        [ProtoMember(1)]
        public fixed int buffer[10];
    }

    [ProtoContract]
    class DataStructure
    {
        [ProtoMember(1)]
        public int num;

        [ProtoMember(2)]
        public string name;

        [ProtoMember(3)]
        public int[] buffer;

    }
}
