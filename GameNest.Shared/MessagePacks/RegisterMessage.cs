using MessagePack;

namespace GameNest.Shared.MessagePacks;

[MessagePackObject(true)]
public class RegisterMessage
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
}