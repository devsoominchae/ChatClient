namespace ChatClient
{
    partial class ChatClient
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            ClientConnectButton = new Button();
            DisconnectClientButton = new Button();
            CurrentChatTextBox = new TextBox();
            SendTextBox = new TextBox();
            SendButton = new Button();
            ToLabel = new Label();
            IPAddressTextBox = new TextBox();
            PortTextBox = new TextBox();
            ConnectedClientComboBox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Bottom;
            splitContainer1.Location = new Point(0, 555);
            splitContainer1.Margin = new Padding(4);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(ClientConnectButton);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(DisconnectClientButton);
            splitContainer1.Size = new Size(448, 43);
            splitContainer1.SplitterDistance = 223;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 0;
            // 
            // ClientConnectButton
            // 
            ClientConnectButton.Dock = DockStyle.Bottom;
            ClientConnectButton.Location = new Point(0, 2);
            ClientConnectButton.Margin = new Padding(4);
            ClientConnectButton.Name = "ClientConnectButton";
            ClientConnectButton.Size = new Size(223, 41);
            ClientConnectButton.TabIndex = 0;
            ClientConnectButton.Text = "Connect";
            ClientConnectButton.UseVisualStyleBackColor = true;
            ClientConnectButton.Click += ClientConnectButton_Click;
            // 
            // DisconnectClientButton
            // 
            DisconnectClientButton.Dock = DockStyle.Bottom;
            DisconnectClientButton.Location = new Point(0, 2);
            DisconnectClientButton.Margin = new Padding(4);
            DisconnectClientButton.Name = "DisconnectClientButton";
            DisconnectClientButton.Size = new Size(220, 41);
            DisconnectClientButton.TabIndex = 0;
            DisconnectClientButton.Text = "Disconnect";
            DisconnectClientButton.UseVisualStyleBackColor = true;
            DisconnectClientButton.Click += DisconnectClientButton_Click;
            // 
            // CurrentChatTextBox
            // 
            CurrentChatTextBox.Location = new Point(14, 14);
            CurrentChatTextBox.Margin = new Padding(4);
            CurrentChatTextBox.Multiline = true;
            CurrentChatTextBox.Name = "CurrentChatTextBox";
            CurrentChatTextBox.ReadOnly = true;
            CurrentChatTextBox.ScrollBars = ScrollBars.Vertical;
            CurrentChatTextBox.Size = new Size(424, 356);
            CurrentChatTextBox.TabIndex = 1;
            // 
            // SendTextBox
            // 
            SendTextBox.Location = new Point(4, 417);
            SendTextBox.Margin = new Padding(4);
            SendTextBox.Multiline = true;
            SendTextBox.Name = "SendTextBox";
            SendTextBox.Size = new Size(353, 91);
            SendTextBox.TabIndex = 2;
            // 
            // SendButton
            // 
            SendButton.Font = new Font("맑은 고딕", 7F, FontStyle.Regular, GraphicsUnit.Point, 129);
            SendButton.Location = new Point(365, 416);
            SendButton.Margin = new Padding(4);
            SendButton.Name = "SendButton";
            SendButton.Size = new Size(73, 92);
            SendButton.TabIndex = 3;
            SendButton.Text = "Send";
            SendButton.UseVisualStyleBackColor = true;
            SendButton.Click += SendButton_Click;
            // 
            // ToLabel
            // 
            ToLabel.AutoSize = true;
            ToLabel.Location = new Point(14, 377);
            ToLabel.Margin = new Padding(4, 0, 4, 0);
            ToLabel.Name = "ToLabel";
            ToLabel.Size = new Size(56, 30);
            ToLabel.TabIndex = 6;
            ToLabel.Text = "To : ";
            // 
            // IPAddressTextBox
            // 
            IPAddressTextBox.Location = new Point(0, 515);
            IPAddressTextBox.Name = "IPAddressTextBox";
            IPAddressTextBox.Size = new Size(223, 35);
            IPAddressTextBox.TabIndex = 8;
            IPAddressTextBox.Text = "127.0.0.1";
            // 
            // PortTextBox
            // 
            PortTextBox.Location = new Point(228, 515);
            PortTextBox.Name = "PortTextBox";
            PortTextBox.Size = new Size(220, 35);
            PortTextBox.TabIndex = 9;
            PortTextBox.Text = "8888";
            // 
            // ConnectedClientComboBox
            // 
            ConnectedClientComboBox.FormattingEnabled = true;
            ConnectedClientComboBox.Location = new Point(72, 374);
            ConnectedClientComboBox.Name = "ConnectedClientComboBox";
            ConnectedClientComboBox.Size = new Size(364, 38);
            ConnectedClientComboBox.TabIndex = 10;
            // 
            // ChatClient
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(448, 598);
            Controls.Add(ConnectedClientComboBox);
            Controls.Add(PortTextBox);
            Controls.Add(IPAddressTextBox);
            Controls.Add(ToLabel);
            Controls.Add(SendButton);
            Controls.Add(SendTextBox);
            Controls.Add(CurrentChatTextBox);
            Controls.Add(splitContainer1);
            Margin = new Padding(4);
            Name = "ChatClient";
            Text = "Chat Client";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SplitContainer splitContainer1;
        private Button ClientConnectButton;
        private Button DisconnectClientButton;
        private TextBox CurrentChatTextBox;
        private TextBox SendTextBox;
        private Button SendButton;
        private Label ToLabel;
        private TextBox IPAddressTextBox;
        private TextBox PortTextBox;
        private ComboBox ConnectedClientComboBox;
    }
}
