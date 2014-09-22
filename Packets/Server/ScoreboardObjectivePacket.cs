using MineLib.Network.IO;

namespace MineLib.Network.Packets.Server
{
    public struct ScoreboardObjectivePacket : IPacket
    {
        public string ObjectiveName;
        public sbyte Mode;
        public string ObjectiveValue;
        public string Type;

        public const byte PacketId = 0x3B;
        public byte Id { get { return PacketId; } }

        public void ReadPacket(PacketByteReader reader)
        {
            ObjectiveName = reader.ReadString();
            Mode = reader.ReadSByte();
            ObjectiveValue = reader.ReadString();
            Type = reader.ReadString();
        }

        public void WritePacket(ref PacketStream stream)
        {
            stream.WriteVarInt(Id);
            stream.WriteString(ObjectiveName);
            stream.WriteSByte(Mode);
            stream.WriteString(ObjectiveValue);
            stream.WriteString(Type);
            stream.Purge();
        }
    }
}