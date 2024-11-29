using Microsoft.AspNetCore.SignalR.Client;

namespace UniversalChatClient;

public partial class TextChat : Form
{
    private readonly HubConnection? _hubConnection;
    
    public TextChat()
    {
        InitializeComponent();
        
        _hubConnection = new HubConnectionBuilder()
            .WithUrl("http://localhost:5297/textChatHub")
            .Build();

        _hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
        {
            var textMessage = $"{user}: {message}";
            chatBox.Items.Add(textMessage);
        });
        
        _hubConnection.StartAsync().Wait();
    }

    private void sendMessageButton_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(chatTextBox.Text))
            return;
        
        var username = !string.IsNullOrEmpty(usernameTexBox.Text) ? usernameTexBox.Text : "Demo User";
        
        SendMessage(username, chatTextBox.Text);
        chatTextBox.Text = string.Empty;
    }

    private async Task SendMessage(string username, string message)
    {
        await _hubConnection?.InvokeAsync("SendMessage", username, message);
    }
}
