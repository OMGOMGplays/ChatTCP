namespace ChatTCP
{
    partial class Client
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Client));
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
            this.SuspendLayout();
            // 
            // ipConnect
            // 
            this.ipConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ipConnect.Enabled = false;
            this.ipConnect.Location = new System.Drawing.Point(349, 169);
            this.ipConnect.Margin = new System.Windows.Forms.Padding(2);
            this.ipConnect.Name = "ipConnect";
            this.ipConnect.Size = new System.Drawing.Size(152, 34);
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
            this.label1.Location = new System.Drawing.Point(317, 113);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Type the TCP/IP address you wish to connect to";
            // 
            // ipInput
            // 
            this.ipInput.Location = new System.Drawing.Point(349, 136);
            this.ipInput.Margin = new System.Windows.Forms.Padding(2);
            this.ipInput.Name = "ipInput";
            this.ipInput.Size = new System.Drawing.Size(153, 20);
            this.ipInput.TabIndex = 2;
            this.ipInput.Tag = "";
            this.ipInput.TextChanged += new System.EventHandler(this.IPInput_TextChanged);
            // 
            // hostInput
            // 
            this.hostInput.Location = new System.Drawing.Point(615, 134);
            this.hostInput.Margin = new System.Windows.Forms.Padding(2);
            this.hostInput.Name = "hostInput";
            this.hostInput.Size = new System.Drawing.Size(153, 20);
            this.hostInput.TabIndex = 5;
            this.hostInput.Tag = "";
            this.hostInput.TextChanged += new System.EventHandler(this.HostInput_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(644, 111);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Host on specified IP";
            // 
            // hostButton
            // 
            this.hostButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hostButton.Enabled = false;
            this.hostButton.Location = new System.Drawing.Point(798, 223);
            this.hostButton.Margin = new System.Windows.Forms.Padding(2);
            this.hostButton.Name = "hostButton";
            this.hostButton.Size = new System.Drawing.Size(152, 34);
            this.hostButton.TabIndex = 3;
            this.hostButton.Text = "Start hosting on specified IP";
            this.hostButton.UseVisualStyleBackColor = true;
            this.hostButton.Click += new System.EventHandler(this.HostButton_Click);
            // 
            // maxUserInput
            // 
            this.maxUserInput.Location = new System.Drawing.Point(615, 183);
            this.maxUserInput.Margin = new System.Windows.Forms.Padding(2);
            this.maxUserInput.Name = "maxUserInput";
            this.maxUserInput.Size = new System.Drawing.Size(153, 20);
            this.maxUserInput.TabIndex = 7;
            this.maxUserInput.Tag = "";
            this.maxUserInput.TextChanged += new System.EventHandler(this.MaxUsersInput_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(664, 165);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Max users";
            // 
            // serverNameInput
            // 
            this.serverNameInput.Location = new System.Drawing.Point(798, 183);
            this.serverNameInput.Margin = new System.Windows.Forms.Padding(2);
            this.serverNameInput.Name = "serverNameInput";
            this.serverNameInput.Size = new System.Drawing.Size(153, 20);
            this.serverNameInput.TabIndex = 9;
            this.serverNameInput.Tag = "";
            this.serverNameInput.TextChanged += new System.EventHandler(this.serverNameInput_TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(840, 165);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Server name";
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1280, 720);
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
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Client";
            this.Text = "ChatTCP";
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
    }
}

