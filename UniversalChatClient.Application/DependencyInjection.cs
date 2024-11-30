using Microsoft.Extensions.DependencyInjection;
using UniversalChatClient.Application.Hubs.HubServices;
using UniversalChatClient.Application.Hubs.HubServices.Interfaces;

namespace UniversalChatClient.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<IGatewayService, GatewayService>();
        
        return services;
    }
}