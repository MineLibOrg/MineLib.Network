using MineLib.Network.Data;
using MineLib.Network.IO;

namespace MineLib.Network.Packets.Server
{
    public struct SpawnPositionPacket : IPacket
    {
        public Position Location;

        public const byte PacketID = 0x05;
        public byte Id { get { return PacketID; } }

        public void ReadPacket(PacketByteReader reader)
        {
            Location = Position.FromReaderLong(reader);
        }

        public void WritePacket(ref PacketStream stream)
        {
            stream.WriteVarInt(Id);
            Location.ToStreamLong(ref stream);
            stream.Purge();
        }
    }
}