using GameNest.Shared.MessagePacks;
using MagicOnion;

namespace GameNest.Shared.Hubs;

public interface IChatHub : IStreamingHub<IChatHub,IChatHubReceiver>
{
    Task JoinAsync(JoinMessage joinMessage);
    Task LeaveAsync();
    Task SendMessageAsync(string message);
}