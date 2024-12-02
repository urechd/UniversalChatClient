using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Options;
using UniversalChatClient.Application.Configuration;
using UniversalChatClient.Application.Hubs.HubEvents;
using UniversalChatClient.Application.Hubs.HubServices.Interfaces;
using UniversalChatContracts.Helpers;
using UniversalChatContracts.Model;

namespace UniversalChatClient.Application.Hubs.HubServices;

public class GatewayService(IOptions<HubSettings> options) : IGatewayService
{
    private HubConnection? _hubConnection;
    
    public event OnMessageReceivedDelegate? OnMessageReceived;

    public void Initialize()
    {
        if (_hubConnection is not null)
            return;
        
        _hubConnection = new HubConnectionBuilder()
            .WithUrl(options.Value.HubEndpoint)
            .Build();
        
        _hubConnection.On<byte[]>("ReceiveMessage", ReceiveMessage);
    }

    public async Task ConnectToHubAsync()
    {
        if (_hubConnection is null)
            return;
        
        await _hubConnection.StartAsync();
    }

    public Task DisconnectFromHubAsync()
    {
        if (_hubConnection is null)
            return Task.CompletedTask;
        
        _ = _hubConnection.DisposeAsync();
        _hubConnection = null;
        return Task.CompletedTask;
    }

    public async Task SendMessageAsync(string message)
    {
        if (_hubConnection is null)
            return;

        var textMessage = new TextMessage
        {
            MessageId = Guid.NewGuid(),
            ChannelId = Guid.NewGuid(),
            UserId = Guid.NewGuid(),
            Text = message
        };
        
        await _hubConnection.InvokeAsync("SendMessage", ProtobufHelper.Serialize(textMessage));
    }

    private void ReceiveMessage(byte[] message)
    {
        var textMessage = ProtobufHelper.Deserialize<TextMessage>(message);
        OnMessageReceived?.Invoke(textMessage);
    }
}