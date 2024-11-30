using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UniversalChatClient.Application;
using UniversalChatClient.Application.Configuration;

namespace UniversalChatClient;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static async Task Main()
    {
        ApplicationConfiguration.Initialize();

        var host = CreateHostApplicationBuilder().Build();
        await host.StartAsync();

        using IServiceScope serviceScope = host.Services.CreateScope();
        System.Windows.Forms.Application.Run(serviceScope.ServiceProvider.GetRequiredService<TextChatForm>());
    }

    static HostApplicationBuilder CreateHostApplicationBuilder()
    {
        var builder = Host.CreateApplicationBuilder();
        
        builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        var config = builder.Configuration.GetSection("HubSettings");
        builder.Services.Configure<HubSettings>(config, o => o.BindNonPublicProperties = true);
        builder.Services.AddTransient<TextChatForm>();
        builder.Services.AddApplication();

        return builder;
    }
}