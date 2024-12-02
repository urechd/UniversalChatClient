using UniversalChatClient.Application.Hubs.HubEvents;

namespace UniversalChatClient.Application.Hubs.HubServices.Interfaces;

public interface IGatewayService
{
    event OnMessageReceivedDelegate OnMessageReceived;
    
    void Initialize();
    Task ConnectToHubAsync();
    Task DisconnectFromHubAsync();
    Task SendMessageAsync(string message);
}