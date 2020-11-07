using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace ProtoBufExp
{
    [ProtoContract]
    class BufferBase
    {
        [ProtoMember(1)]
        public string Name { get; set; }

        [ProtoMember(2)]
        public int[] Data { get; set; }
    }

    [ProtoContract]
    class DataStructure
    {
        [ProtoMember(1)]
        public string Id { get; set; }

        [ProtoMember(2)]
        public BufferBase[] Buffer { get; set; }
    }
}
