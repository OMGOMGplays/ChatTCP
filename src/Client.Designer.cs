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
            this.SuspendLayout();
            // 
            // ipConnect
            // 
            this.ipConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ipConnect.Enabled = false;
            this.ipConnect.Location = new System.Drawing.Point(143, 208);
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
            this.label1.Location = new System.Drawing.Point(100, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Type the TCP/IP address you wish to connect to";
            // 
            // ipInput
            // 
            this.ipInput.Location = new System.Drawing.Point(143, 167);
            this.ipInput.Name = "ipInput";
            this.ipInput.Size = new System.Drawing.Size(203, 22);
            this.ipInput.TabIndex = 2;
            this.ipInput.Tag = "";
            this.ipInput.TextChanged += new System.EventHandler(this.IPInput_TextChanged);
            // 
            // hostInput
            // 
            this.hostInput.Location = new System.Drawing.Point(143, 350);
            this.hostInput.Name = "hostInput";
            this.hostInput.Size = new System.Drawing.Size(203, 22);
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
            this.label2.Location = new System.Drawing.Point(182, 327);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Host on specified IP";
            // 
            // hostButton
            // 
            this.hostButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hostButton.Enabled = false;
            this.hostButton.Location = new System.Drawing.Point(143, 450);
            this.hostButton.Name = "hostButton";
            this.hostButton.Size = new System.Drawing.Size(203, 42);
            this.hostButton.TabIndex = 3;
            this.hostButton.Text = "Start hosting specified IP";
            this.hostButton.UseVisualStyleBackColor = true;
            this.hostButton.Click += new System.EventHandler(this.HostButton_Click);
            // 
            // maxUserInput
            // 
            this.maxUserInput.Location = new System.Drawing.Point(143, 408);
            this.maxUserInput.Name = "maxUserInput";
            this.maxUserInput.Size = new System.Drawing.Size(203, 22);
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
            this.label3.Location = new System.Drawing.Point(205, 385);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Max users";
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.maxUserInput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.hostInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.hostButton);
            this.Controls.Add(this.ipInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ipConnect);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
    }
}

