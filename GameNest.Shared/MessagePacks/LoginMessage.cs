using MessagePack;

namespace GameNest.Shared.MessagePacks;

[MessagePackObject(true)]
public class LoginMessage
{
    public string Username { get; set; }
    public string Password { get; set; }
}