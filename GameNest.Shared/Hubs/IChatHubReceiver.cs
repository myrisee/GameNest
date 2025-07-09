using GameNest.Shared.MessagePacks;

namespace GameNest.Shared.Hubs;

public interface IChatHubReceiver
{
    void OnJoin(string name);
    void OnLeave(string name);
    void OnSendMessage(ChatMessage message);
    Task<string> HelloAsync(string name, int age);
}