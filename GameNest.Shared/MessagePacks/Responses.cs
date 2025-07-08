using GameNest.Shared.ViewModels;
using MessagePack;

namespace GameNest.Shared.MessagePacks;

[MessagePackObject(true)]
public class RegisterResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public AccountModel Account { get; set; }
}

