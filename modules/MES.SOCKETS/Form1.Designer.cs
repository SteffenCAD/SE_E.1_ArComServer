namespace MES.SOCKETS
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnStartServer = new System.Windows.Forms.Button();
            this.TbTextToSend = new System.Windows.Forms.TextBox();
            this.BtnClientSend = new System.Windows.Forms.Button();
            this.TbTextReceived = new System.Windows.Forms.TextBox();
            this.BtnStopServer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnStartServer
            // 
            this.BtnStartServer.Location = new System.Drawing.Point(51, 39);
            this.BtnStartServer.Margin = new System.Windows.Forms.Padding(4);
            this.BtnStartServer.Name = "BtnStartServer";
            this.BtnStartServer.Size = new System.Drawing.Size(179, 95);
            this.BtnStartServer.TabIndex = 0;
            this.BtnStartServer.Text = "startServer";
            this.BtnStartServer.UseVisualStyleBackColor = true;
            this.BtnStartServer.Click += new System.EventHandler(this.BtnStartServer_Click);
            // 
            // TbTextToSend
            // 
            this.TbTextToSend.Location = new System.Drawing.Point(51, 186);
            this.TbTextToSend.Margin = new System.Windows.Forms.Padding(4);
            this.TbTextToSend.Name = "TbTextToSend";
            this.TbTextToSend.Size = new System.Drawing.Size(949, 22);
            this.TbTextToSend.TabIndex = 1;
            // 
            // BtnClientSend
            // 
            this.BtnClientSend.Location = new System.Drawing.Point(51, 216);
            this.BtnClientSend.Margin = new System.Windows.Forms.Padding(4);
            this.BtnClientSend.Name = "BtnClientSend";
            this.BtnClientSend.Size = new System.Drawing.Size(179, 95);
            this.BtnClientSend.TabIndex = 2;
            this.BtnClientSend.Text = "sendClient";
            this.BtnClientSend.UseVisualStyleBackColor = true;
            this.BtnClientSend.Click += new System.EventHandler(this.BtnClientSend_Click);
            // 
            // TbTextReceived
            // 
            this.TbTextReceived.Location = new System.Drawing.Point(51, 418);
            this.TbTextReceived.Margin = new System.Windows.Forms.Padding(4);
            this.TbTextReceived.Name = "TbTextReceived";
            this.TbTextReceived.Size = new System.Drawing.Size(949, 22);
            this.TbTextReceived.TabIndex = 3;
            // 
            // BtnStopServer
            // 
            this.BtnStopServer.Location = new System.Drawing.Point(295, 39);
            this.BtnStopServer.Margin = new System.Windows.Forms.Padding(4);
            this.BtnStopServer.Name = "BtnStopServer";
            this.BtnStopServer.Size = new System.Drawing.Size(179, 95);
            this.BtnStopServer.TabIndex = 4;
            this.BtnStopServer.Text = "stopServer";
            this.BtnStopServer.UseVisualStyleBackColor = true;
            this.BtnStopServer.Click += new System.EventHandler(this.BtnStopServer_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.BtnStopServer);
            this.Controls.Add(this.TbTextReceived);
            this.Controls.Add(this.BtnClientSend);
            this.Controls.Add(this.TbTextToSend);
            this.Controls.Add(this.BtnStartServer);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnStartServer;
        private System.Windows.Forms.TextBox TbTextToSend;
        private System.Windows.Forms.Button BtnClientSend;
        private System.Windows.Forms.TextBox TbTextReceived;
        private System.Windows.Forms.Button BtnStopServer;
    }
}

