namespace Assignment_2
{
    partial class ChatClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
            this.btnLogin = new System.Windows.Forms.Button();
            this.grpMessageWindow = new System.Windows.Forms.GroupBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtSendMessage = new System.Windows.Forms.TextBox();
            this.rtbMessages = new System.Windows.Forms.RichTextBox();
            this.grpUserCredentials = new System.Windows.Forms.GroupBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblLoginName = new System.Windows.Forms.Label();
            this.grpMessageWindow.SuspendLayout();
            this.grpUserCredentials.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(258, 11);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "&Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // grpMessageWindow
            // 
            this.grpMessageWindow.Controls.Add(this.btnSend);
            this.grpMessageWindow.Controls.Add(this.txtSendMessage);
            this.grpMessageWindow.Controls.Add(this.rtbMessages);
            this.grpMessageWindow.Enabled = false;
            this.grpMessageWindow.Location = new System.Drawing.Point(12, 58);
            this.grpMessageWindow.Name = "grpMessageWindow";
            this.grpMessageWindow.Size = new System.Drawing.Size(516, 296);
            this.grpMessageWindow.TabIndex = 3;
            this.grpMessageWindow.TabStop = false;
            this.grpMessageWindow.Text = "Message window";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(435, 235);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 55);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "&Send";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // txtSendMessage
            // 
            this.txtSendMessage.Location = new System.Drawing.Point(9, 235);
            this.txtSendMessage.Multiline = true;
            this.txtSendMessage.Name = "txtSendMessage";
            this.txtSendMessage.Size = new System.Drawing.Size(408, 55);
            this.txtSendMessage.TabIndex = 1;
            // 
            // rtbMessages
            // 
            this.rtbMessages.Location = new System.Drawing.Point(9, 33);
            this.rtbMessages.Name = "rtbMessages";
            this.rtbMessages.ReadOnly = true;
            this.rtbMessages.Size = new System.Drawing.Size(501, 190);
            this.rtbMessages.TabIndex = 0;
            this.rtbMessages.Text = "";
            // 
            // grpUserCredentials
            // 
            this.grpUserCredentials.Controls.Add(this.btnLogin);
            this.grpUserCredentials.Controls.Add(this.txtUserName);
            this.grpUserCredentials.Controls.Add(this.lblLoginName);
            this.grpUserCredentials.Location = new System.Drawing.Point(12, 12);
            this.grpUserCredentials.Name = "grpUserCredentials";
            this.grpUserCredentials.Size = new System.Drawing.Size(339, 40);
            this.grpUserCredentials.TabIndex = 4;
            this.grpUserCredentials.TabStop = false;
            this.grpUserCredentials.Text = "User credentials:";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(77, 12);
            this.txtUserName.MaxLength = 10;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(158, 20);
            this.txtUserName.TabIndex = 1;
            // 
            // lblLoginName
            // 
            this.lblLoginName.AutoSize = true;
            this.lblLoginName.Location = new System.Drawing.Point(6, 16);
            this.lblLoginName.Name = "lblLoginName";
            this.lblLoginName.Size = new System.Drawing.Size(65, 13);
            this.lblLoginName.TabIndex = 0;
            this.lblLoginName.Text = "Login name:";
            // 
            // ChatClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 366);
            this.Controls.Add(this.grpMessageWindow);
            this.Controls.Add(this.grpUserCredentials);
            this.Name = "ChatClient";
            this.Text = "ChatClient";
            this.grpMessageWindow.ResumeLayout(false);
            this.grpMessageWindow.PerformLayout();
            this.grpUserCredentials.ResumeLayout(false);
            this.grpUserCredentials.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.GroupBox grpMessageWindow;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtSendMessage;
        private System.Windows.Forms.RichTextBox rtbMessages;
        private System.Windows.Forms.GroupBox grpUserCredentials;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblLoginName;
    }
}