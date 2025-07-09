using MessagePack;

namespace GameNest.Shared.MessagePacks;

[MessagePackObject(true)]
public struct ChatMessage
{
    public string Message { get; set; }
    public string SenderId { get; set; }
    public string SenderName { get; set; }
}