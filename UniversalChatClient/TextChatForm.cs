using UniversalChatClient.Application.Hubs.HubServices.Interfaces;
using UniversalChatContracts.Model;

namespace UniversalChatClient;

public partial class TextChatForm : Form
{
    private readonly IGatewayService _gatewayService;
    
    public TextChatForm(IGatewayService gatewayService)
    {
        InitializeComponent();
        _gatewayService = gatewayService;
        
        _gatewayService.OnMessageReceived += OnMessageReceived;
        _gatewayService.Initialize();
        _gatewayService.ConnectToHubAsync();

        FormClosing += (sender, args) =>
        {
            _gatewayService.DisconnectFromHubAsync();
        };
    }

    private async void sendMessageButton_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(chatTextBox.Text))
            return;
        
        await _gatewayService.SendMessageAsync(chatTextBox.Text);
        chatTextBox.Text = string.Empty;
    }

    private void OnMessageReceived(TextMessage message)
    {
        var text = $"{usernameTexBox.Text}: {message.Text}";
        
        if (chatBox.InvokeRequired)
            chatBox.Invoke(new MethodInvoker(delegate { chatBox.Items.Add(text); }));
        else
            chatBox.Items.Add(text);
    }
}
