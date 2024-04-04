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
            this.ipConnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ipInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ipConnect
            // 
            this.ipConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ipConnect.Enabled = false;
            this.ipConnect.Location = new System.Drawing.Point(524, 327);
            this.ipConnect.Name = "ipConnect";
            this.ipConnect.Size = new System.Drawing.Size(203, 42);
            this.ipConnect.TabIndex = 0;
            this.ipConnect.Text = "Connect To IP";
            this.ipConnect.UseVisualStyleBackColor = true;
            this.ipConnect.Click += new System.EventHandler(this.ipConnect_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(503, 263);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please type in a valid TCP/IP address.";
            // 
            // ipInput
            // 
            this.ipInput.Location = new System.Drawing.Point(524, 286);
            this.ipInput.Name = "ipInput";
            this.ipInput.Size = new System.Drawing.Size(203, 22);
            this.ipInput.TabIndex = 2;
            this.ipInput.Tag = "";
            this.ipInput.Text = "192.168.0.1";
            this.ipInput.TextChanged += new System.EventHandler(this.ipInput_TextChanged);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.ipInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ipConnect);
            this.Name = "Client";
            this.Text = "ChatTCP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ipConnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ipInput;
    }
}

