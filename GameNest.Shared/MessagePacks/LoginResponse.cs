using MessagePack;

namespace GameNest.Shared.MessagePacks;

[MessagePackObject(true)]
public class LoginResponse
{
    public string Token { get; set; }
    public string UserId { get; set; }
    public string Username { get; set; }
    public DateTime Expiration { get; set; }

    public LoginResponse(string token, string username)
    {
        this.Token = token;
        this.Username = username;
    }
    
    public LoginResponse()
    {
        // Default constructor for deserialization
    }

    public override string ToString()
    {
        return $"Token: {Token}, Username: {Username}";
    }
}