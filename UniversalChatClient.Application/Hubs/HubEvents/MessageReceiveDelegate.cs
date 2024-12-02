using UniversalChatContracts.Model;

namespace UniversalChatClient.Application.Hubs.HubEvents;

public delegate void OnMessageReceivedDelegate(TextMessage message);