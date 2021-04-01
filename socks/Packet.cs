using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace socks
{
    class Packet
    {
        public const int FieldTypeIndex = 0;
        public const int FieldTypeSize = 1;
        public const int SequenceNumIndex = 1;
        public const int SequenceNumSize = 1;
        public const int PayloadIndex = 2;

        public enum PacketType
        {
            Data,
            Ack,
            Nack
        }
        public Byte[] Data { get; private set; }
        public int PayloadSize { get; private set; }
        public Packet(int pSize)
        {
            PayloadSize = pSize;
            Data = new byte[PayloadSize+2];
        }
        public Packet(Byte[] buffer)
        {
            PayloadSize = buffer.Length-2;
            Data = buffer;
        }
        private Packet(Packet.PacketType t)
        {
            Data = new byte[2];
            PayloadSize = 0;
            SetType((Byte)t);
        }
        public static Packet ACK_Pack()
        {
            return new Packet(PacketType.Ack);
        }
        public static Packet NACK_Pack()
        {
            return new Packet(PacketType.Nack);
        }
        public static string typeToString(Byte pt)
        {
            switch(pt)
            {
                case ((Byte)PacketType.Ack):
                    return "ACK";
                case ((Byte)PacketType.Nack):
                    return "NACK";
                case ((Byte)PacketType.Data):
                    return "DATA";
                default:
                    return "ERR";

            }
        }
        public void SetType(Byte t)
        {
            Data[FieldTypeIndex] = t;
        }
        public Byte getType()
        {
            return Data[FieldTypeIndex];
        }
        public void SetSequenceNum(Byte n)
        {
            Data[SequenceNumIndex] = n;
        }
        public Byte GetSequenceNum()
        {
            return Data[SequenceNumIndex];
        }
        public void SetPayloadData(Byte[] dat)
        {
            for (int n = 0; n < PayloadSize; ++n)
            {
                Data[PayloadIndex + n] = dat[n];
            }
        }
        public Byte[] getPayload()
        {
            Byte[] output = new byte[PayloadSize];
            return Packer.subArray(Data, PayloadIndex, PayloadSize);
        }
    }
}
