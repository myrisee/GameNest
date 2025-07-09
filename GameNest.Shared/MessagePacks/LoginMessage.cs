using MessagePack;

namespace GameNest.Shared.MessagePacks;

[MessagePackObject(true)]
public class LoginMessage
{
    public string Username { get; set; }
    public string Password { get; set; }
    
    public LoginMessage(string username, string password)
    {
        Username = username;
        Password = password;
    }
    
    public LoginMessage() { } // Parameterless constructor for deserialization
}