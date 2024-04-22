namespace ChatTCP
{
    internal partial class MainClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainClient));
            ipConnect = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            ipInput = new System.Windows.Forms.TextBox();
            hostInput = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            hostButton = new System.Windows.Forms.Button();
            maxUserInput = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            serverNameInput = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            usernameInput = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            serverOutput = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // ipConnect
            // 
            ipConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            ipConnect.Enabled = false;
            ipConnect.Location = new System.Drawing.Point(465, 260);
            ipConnect.Name = "ipConnect";
            ipConnect.Size = new System.Drawing.Size(203, 52);
            ipConnect.TabIndex = 0;
            ipConnect.Text = "Connect to IP";
            ipConnect.UseVisualStyleBackColor = true;
            ipConnect.Click += IPConnect_Click;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(423, 173);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(319, 20);
            label1.TabIndex = 1;
            label1.Text = "Type the TCP/IP address you wish to connect to";
            // 
            // ipInput
            // 
            ipInput.Location = new System.Drawing.Point(465, 209);
            ipInput.Name = "ipInput";
            ipInput.Size = new System.Drawing.Size(203, 27);
            ipInput.TabIndex = 2;
            ipInput.Tag = "";
            ipInput.TextChanged += IPInput_TextChanged;
            ipInput.KeyPress += IPInput_KeyPress;
            // 
            // hostInput
            // 
            hostInput.Location = new System.Drawing.Point(821, 207);
            hostInput.Name = "hostInput";
            hostInput.Size = new System.Drawing.Size(203, 27);
            hostInput.TabIndex = 5;
            hostInput.Tag = "";
            hostInput.TextChanged += HostInput_TextChanged;
            hostInput.KeyPress += HostInputs_KeyPress;
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(859, 171);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(141, 20);
            label2.TabIndex = 4;
            label2.Text = "Host on specified IP";
            // 
            // hostButton
            // 
            hostButton.Cursor = System.Windows.Forms.Cursors.Hand;
            hostButton.Enabled = false;
            hostButton.Location = new System.Drawing.Point(1064, 343);
            hostButton.Name = "hostButton";
            hostButton.Size = new System.Drawing.Size(203, 52);
            hostButton.TabIndex = 3;
            hostButton.Text = "Start hosting on specified IP";
            hostButton.UseVisualStyleBackColor = true;
            hostButton.Click += HostButton_Click;
            // 
            // maxUserInput
            // 
            maxUserInput.Location = new System.Drawing.Point(821, 281);
            maxUserInput.Name = "maxUserInput";
            maxUserInput.Size = new System.Drawing.Size(203, 27);
            maxUserInput.TabIndex = 7;
            maxUserInput.Tag = "";
            maxUserInput.TextChanged += MaxUsersInput_TextChanged;
            maxUserInput.KeyPress += HostInputs_KeyPress;
            // 
            // label3
            // 
            label3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(885, 253);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(74, 20);
            label3.TabIndex = 6;
            label3.Text = "Max users";
            // 
            // serverNameInput
            // 
            serverNameInput.Location = new System.Drawing.Point(1064, 281);
            serverNameInput.Name = "serverNameInput";
            serverNameInput.Size = new System.Drawing.Size(203, 27);
            serverNameInput.TabIndex = 9;
            serverNameInput.Tag = "";
            serverNameInput.TextChanged += ServerNameInput_TextChanged;
            serverNameInput.KeyPress += HostInputs_KeyPress;
            // 
            // label4
            // 
            label4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(1120, 253);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(91, 20);
            label4.TabIndex = 8;
            label4.Text = "Server name";
            // 
            // usernameInput
            // 
            usernameInput.Location = new System.Drawing.Point(465, 535);
            usernameInput.Name = "usernameInput";
            usernameInput.Size = new System.Drawing.Size(203, 27);
            usernameInput.TabIndex = 11;
            usernameInput.Tag = "";
            usernameInput.TextChanged += UsernameInput_TextChanged;
            // 
            // label5
            // 
            label5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(491, 500);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(157, 20);
            label5.TabIndex = 10;
            label5.Text = "Type in your username";
            // 
            // serverOutput
            // 
            serverOutput.Location = new System.Drawing.Point(927, 719);
            serverOutput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            serverOutput.Multiline = true;
            serverOutput.Name = "serverOutput";
            serverOutput.ReadOnly = true;
            serverOutput.Size = new System.Drawing.Size(717, 336);
            serverOutput.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI", 18F);
            label6.Location = new System.Drawing.Point(927, 672);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(198, 41);
            label6.TabIndex = 13;
            label6.Text = "Server output";
            // 
            // MainClient
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ActiveCaption;
            ClientSize = new System.Drawing.Size(1707, 1055);
            Controls.Add(label6);
            Controls.Add(serverOutput);
            Controls.Add(usernameInput);
            Controls.Add(label5);
            Controls.Add(serverNameInput);
            Controls.Add(label4);
            Controls.Add(maxUserInput);
            Controls.Add(label3);
            Controls.Add(hostInput);
            Controls.Add(label2);
            Controls.Add(hostButton);
            Controls.Add(ipInput);
            Controls.Add(label1);
            Controls.Add(ipConnect);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "MainClient";
            Text = "ChatTCP";
            FormClosing += MainClient_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button ipConnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ipInput;
        private System.Windows.Forms.TextBox hostInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button hostButton;
        private System.Windows.Forms.TextBox maxUserInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox serverNameInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox usernameInput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public static System.Windows.Forms.TextBox serverOutput;
    }
}

