using MineLib.Network.Data;
using MineLib.Network.IO;

namespace MineLib.Network.Packets.Server
{
    public struct MapChunkBulkPacket : IPacket
    {
        public bool SkyLightSent;
        public int ChunkColumnCount;
        public ChunkColumnMetadata MetaInformation;
        public byte[] ChunkData;

        public const byte PacketID = 0x26;
        public byte Id { get { return PacketID; } }

        public void ReadPacket(PacketByteReader reader)
        {
            SkyLightSent = reader.ReadBoolean();
            ChunkColumnCount = reader.ReadVarInt();
            MetaInformation = ChunkColumnMetadata.FromReader(reader);

            var length = reader.ReadVarInt();
            ChunkData = reader.ReadByteArray(length);
        }

        public void WritePacket(ref PacketStream stream)
        {
            stream.WriteVarInt(Id);
            stream.WriteBoolean(SkyLightSent);
            stream.WriteVarInt(ChunkColumnCount);
            MetaInformation.ToStream(ref stream);
            stream.WriteVarInt(ChunkData.Length);
            stream.WriteByteArray(ChunkData);
            stream.Purge();
        }
    }
}