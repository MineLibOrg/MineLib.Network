using MineLib.Network.IO;

namespace MineLib.Network.Main.Packets.Client.Status
{
    public struct PingPacket : IPacket
    {
        public long Time;

        public byte ID { get { return 0x01; } }

        public void ReadPacket(PacketByteReader reader)
        {
            Time = reader.ReadLong();
        }

        public void WritePacket(ref PacketStream stream)
        {
            stream.WriteVarInt(ID);
            stream.WriteLong(Time);
            stream.Purge();
        }

    }
}