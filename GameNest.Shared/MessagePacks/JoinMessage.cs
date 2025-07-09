using MessagePack;

namespace GameNest.Shared.MessagePacks;

[MessagePackObject(true)]
public struct JoinMessage
{
    public string RoomName { get; set; }
}