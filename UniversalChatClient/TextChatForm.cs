using UniversalChatClient.Application.Hubs.HubServices.Interfaces;

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
        
        await _gatewayService.SendMessageAsync(usernameTexBox.Text, chatTextBox.Text);
        chatTextBox.Text = string.Empty;
    }

    private void OnMessageReceived(string message)
    {
        if (chatBox.InvokeRequired)
            chatBox.Invoke(new MethodInvoker(delegate { chatBox.Items.Add(message); }));
        else
            chatBox.Items.Add(message);
    }
}
