using System;

namespace socks
{
    class Packer
    {
        const int MaxPayloadSize = 4; //Bytes
        public static Byte[] subArray(Byte[] arr, int start, int len)
        {
            int l = Math.Min(arr.Length - start, len);
            Byte[] output = new Byte[l];
            for (int n =0; n < l; ++n)
            {
                output[n] = arr[start + n];
            }
            return output;
        }
        static Packet createPacket(int size, Byte type, byte seq, byte[] data)
        {
            Packet p = new Packet(size);
            p.SetType(type);
            p.SetSequenceNum(seq);
            p.SetPayloadData(data);

            return p;
        }
        public static Packet[] PackageData(Byte[] data)
        {
            int numPackets = data.Length / MaxPayloadSize;

            if (data.Length % MaxPayloadSize != 0) ++numPackets;

            Packet[] output = new Packet[numPackets];

            int n = 0;
            for (; n < numPackets-1; ++n)
            {
                Byte[] d = subArray(data, n * MaxPayloadSize, MaxPayloadSize);
                Packet p = createPacket(MaxPayloadSize, (Byte)Packet.PacketType.Data, (Byte)n, d);
                output[n] = p;
            }
            int start = n * MaxPayloadSize;
            Byte[] da = subArray(data, start, data.Length - start);
            Packet pa = createPacket(da.Length, (Byte)Packet.PacketType.Data, (Byte)n, da);
            output[n] = pa;

            return output;
        }
    }
}
