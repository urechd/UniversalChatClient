namespace UniversalChatClient;

partial class TextChatForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        label1 = new System.Windows.Forms.Label();
        usernameTexBox = new System.Windows.Forms.TextBox();
        chatBox = new System.Windows.Forms.ListBox();
        chatTextBox = new System.Windows.Forms.TextBox();
        sendMessageButton = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
        label1.Location = new System.Drawing.Point(15, 33);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(65, 23);
        label1.TabIndex = 0;
        label1.Text = "Username: ";
        // 
        // usernameTexBox
        // 
        usernameTexBox.Location = new System.Drawing.Point(80, 25);
        usernameTexBox.Name = "usernameTexBox";
        usernameTexBox.Size = new System.Drawing.Size(100, 23);
        usernameTexBox.TabIndex = 1;
        // 
        // chatBox
        // 
        chatBox.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
        chatBox.FormattingEnabled = true;
        chatBox.ItemHeight = 15;
        chatBox.Location = new System.Drawing.Point(213, 24);
        chatBox.Name = "chatBox";
        chatBox.Size = new System.Drawing.Size(711, 394);
        chatBox.TabIndex = 2;
        // 
        // chatTextBox
        // 
        chatTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
        chatTextBox.Location = new System.Drawing.Point(213, 445);
        chatTextBox.Name = "chatTextBox";
        chatTextBox.Size = new System.Drawing.Size(630, 23);
        chatTextBox.TabIndex = 3;
        // 
        // sendMessageButton
        // 
        sendMessageButton.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
        sendMessageButton.Location = new System.Drawing.Point(867, 445);
        sendMessageButton.Name = "sendMessageButton";
        sendMessageButton.Size = new System.Drawing.Size(57, 23);
        sendMessageButton.TabIndex = 4;
        sendMessageButton.Text = "Send";
        sendMessageButton.UseVisualStyleBackColor = true;
        sendMessageButton.Click += sendMessageButton_Click;
        // 
        // TextChatForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(972, 480);
        Controls.Add(sendMessageButton);
        Controls.Add(chatTextBox);
        Controls.Add(chatBox);
        Controls.Add(usernameTexBox);
        Controls.Add(label1);
        Text = "UniversalChat";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.TextBox chatTextBox;
    private System.Windows.Forms.Button sendMessageButton;

    private System.Windows.Forms.ListBox chatBox;

    private System.Windows.Forms.TextBox usernameTexBox;

    private System.Windows.Forms.Label label1;

    #endregion
}
