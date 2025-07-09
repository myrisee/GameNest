using MessagePack;

namespace GameNest.Shared.MessagePacks;

[MessagePackObject(true)]
public class RegisterMessage
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }

    public RegisterMessage(string username, string password, string email)
    {
        this.Username = username;
        this.Password = password;
        this.Email = email;
    }
    
    public RegisterMessage()
    {
        // Parameterless constructor for deserialization
    }
}