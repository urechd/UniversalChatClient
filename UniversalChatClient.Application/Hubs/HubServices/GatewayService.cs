using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Options;
using UniversalChatClient.Application.Configuration;
using UniversalChatClient.Application.Hubs.HubEvents;
using UniversalChatClient.Application.Hubs.HubServices.Interfaces;

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
        
        _hubConnection.On<string>("ReceiveMessage", ReceiveMessage);
    }

    public async Task ConnectToHubAsync()
    {
        if (_hubConnection is null)
            return;
        
        await _hubConnection.StartAsync();
    }

    public async Task DisconnectFromHubAsync()
    {
        if (_hubConnection is null)
            return;
        
        _ = _hubConnection.DisposeAsync();
        _hubConnection = null;
    }

    public async Task SendMessageAsync(string username, string message)
    {
        if (_hubConnection is null)
            return;
        
        var user = !string.IsNullOrEmpty(username) ? username : "Demo User";
        await _hubConnection.InvokeAsync("SendMessage", user, message);
    }

    private void ReceiveMessage(string message)
    {
        OnMessageReceived?.Invoke(message);
    }
}