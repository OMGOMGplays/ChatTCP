namespace ChatTCP
{
    partial class MainClient
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
            this.ipConnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ipInput = new System.Windows.Forms.TextBox();
            this.hostInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.hostButton = new System.Windows.Forms.Button();
            this.maxUserInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.serverNameInput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.usernameInput = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ipConnect
            // 
            this.ipConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ipConnect.Enabled = false;
            this.ipConnect.Location = new System.Drawing.Point(465, 208);
            this.ipConnect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ipConnect.Name = "ipConnect";
            this.ipConnect.Size = new System.Drawing.Size(203, 42);
            this.ipConnect.TabIndex = 0;
            this.ipConnect.Text = "Connect to IP";
            this.ipConnect.UseVisualStyleBackColor = true;
            this.ipConnect.Click += new System.EventHandler(this.IPConnect_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(423, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Type the TCP/IP address you wish to connect to";
            // 
            // ipInput
            // 
            this.ipInput.Location = new System.Drawing.Point(465, 167);
            this.ipInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ipInput.Name = "ipInput";
            this.ipInput.Size = new System.Drawing.Size(203, 22);
            this.ipInput.TabIndex = 2;
            this.ipInput.Tag = "";
            this.ipInput.TextChanged += new System.EventHandler(this.IPInput_TextChanged);
            this.ipInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IPInput_KeyPress);
            // 
            // hostInput
            // 
            this.hostInput.Location = new System.Drawing.Point(820, 165);
            this.hostInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.hostInput.Name = "hostInput";
            this.hostInput.Size = new System.Drawing.Size(203, 22);
            this.hostInput.TabIndex = 5;
            this.hostInput.Tag = "";
            this.hostInput.TextChanged += new System.EventHandler(this.HostInput_TextChanged);
            this.hostInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HostInputs_KeyPress);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(859, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Host on specified IP";
            // 
            // hostButton
            // 
            this.hostButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hostButton.Enabled = false;
            this.hostButton.Location = new System.Drawing.Point(1064, 274);
            this.hostButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.hostButton.Name = "hostButton";
            this.hostButton.Size = new System.Drawing.Size(203, 42);
            this.hostButton.TabIndex = 3;
            this.hostButton.Text = "Start hosting on specified IP";
            this.hostButton.UseVisualStyleBackColor = true;
            this.hostButton.Click += new System.EventHandler(this.HostButton_Click);
            // 
            // maxUserInput
            // 
            this.maxUserInput.Location = new System.Drawing.Point(820, 225);
            this.maxUserInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.maxUserInput.Name = "maxUserInput";
            this.maxUserInput.Size = new System.Drawing.Size(203, 22);
            this.maxUserInput.TabIndex = 7;
            this.maxUserInput.Tag = "";
            this.maxUserInput.TextChanged += new System.EventHandler(this.MaxUsersInput_TextChanged);
            this.maxUserInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HostInputs_KeyPress);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(885, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Max users";
            // 
            // serverNameInput
            // 
            this.serverNameInput.Location = new System.Drawing.Point(1064, 225);
            this.serverNameInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.serverNameInput.Name = "serverNameInput";
            this.serverNameInput.Size = new System.Drawing.Size(203, 22);
            this.serverNameInput.TabIndex = 9;
            this.serverNameInput.Tag = "";
            this.serverNameInput.TextChanged += new System.EventHandler(this.ServerNameInput_TextChanged);
            this.serverNameInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HostInputs_KeyPress);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1120, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Server name";
            // 
            // usernameInput
            // 
            this.usernameInput.Location = new System.Drawing.Point(465, 428);
            this.usernameInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.usernameInput.Name = "usernameInput";
            this.usernameInput.Size = new System.Drawing.Size(203, 22);
            this.usernameInput.TabIndex = 11;
            this.usernameInput.Tag = "";
            this.usernameInput.TextChanged += new System.EventHandler(this.UsernameInput_TextChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(491, 400);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Type in your username";
            // 
            // MainClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1707, 886);
            this.Controls.Add(this.usernameInput);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.serverNameInput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.maxUserInput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.hostInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.hostButton);
            this.Controls.Add(this.ipInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ipConnect);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainClient";
            this.Text = "ChatTCP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainClient_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

