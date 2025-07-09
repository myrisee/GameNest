using System.Diagnostics;
using GameNest.Shared.MessagePacks;
using GameNest.Shared.Services;
using Grpc.Core;
using MagicOnion.Client;
using System;

namespace GameNest.Client.Console;

public class WithAuthenticationFilter(ChannelBase channel) : IClientFilter
{
    private string _token;

    public void SetAuthentication(string token)
    {
        _token = token ?? throw new ArgumentNullException(nameof(token));
    }
    
    public async ValueTask<ResponseContext> SendAsync(RequestContext context, Func<RequestContext, ValueTask<ResponseContext>> next)
    {
        if (string.IsNullOrEmpty(_token))
            throw new InvalidOperationException("Authentication token is not set.");

        context.CallOptions.Headers.Remove(new Metadata.Entry("Authorization", string.Empty));
        context.CallOptions.Headers.Remove(new Metadata.Entry("authorization", string.Empty));
        context.CallOptions.Headers.Add("authorization", "Bearer " + _token);
        // Sadece küçük harfli header eklendi, tekrar tekrar birikme olmaz.

        return await next(context);
    }
}
