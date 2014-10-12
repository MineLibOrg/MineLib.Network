﻿using MineLib.Network.IO;

namespace MineLib.Network.PocketEdition.Packets.Client
{
    public class ReadyPacket : IPacketWithSize
    {
        public byte Status;

        public byte ID { get { return 0x84; } }
        public short Size { get { return 0; } }

        public void ReadPacket(PacketByteReader reader)
        {
            Status = reader.ReadByte();
        }

        public void WritePacket(ref PacketStream stream)
        {
            stream.WriteVarInt(ID);
            stream.WriteByte(Status);
            stream.Purge();
        }
    }
}