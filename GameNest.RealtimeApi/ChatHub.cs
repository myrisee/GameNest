using System.Security.Claims;
using GameNest.Shared.Hubs;
using GameNest.Shared.MessagePacks;
using Grpc.Core;
using MagicOnion.Server.Hubs;
using Microsoft.AspNetCore.Authorization;

namespace GameNest.RealtimeApi;

[Authorize]
public class ChatHub : StreamingHubBase<IChatHub,IChatHubReceiver>, IChatHub
{
    private IGroup<IChatHubReceiver> roomGroup;
    private string myName;
    private string roomName;
    private string accountId;
    private string accountName;

    protected override async ValueTask OnConnecting()
    {
        var httpContext = this.Context.CallContext.GetHttpContext();
        var authHeader = httpContext.Request.Headers["Authorization"].FirstOrDefault();
        Console.WriteLine($"[ChatHub] Authorization header: {authHeader}");
        var claims = httpContext.User.Claims;
        accountId = claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        accountName = claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
        await base.OnConnecting();
    }

    public async Task JoinAsync(JoinMessage joinMessage)
    {
        this.roomName = joinMessage.RoomName;
        this.roomGroup = await this.Group.AddAsync(roomName);
        this.roomGroup.All.OnJoin(accountId);
    }

    public async Task LeaveAsync()
    {
        if (roomGroup != null)
        {
            await roomGroup.RemoveAsync(this.Context);
            this.roomGroup.All.OnLeave(accountId);
        }
    }

    public async Task SendMessageAsync(string message)
    {
        if (roomGroup == null) return;
        var chatMessage = new ChatMessage { Message = message, SenderId = accountId, SenderName = accountName};
        this.roomGroup.All.OnSendMessage(chatMessage);
    }
}