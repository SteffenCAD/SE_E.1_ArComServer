namespace DUR.OPCUA
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
            this.BtnConnect = new System.Windows.Forms.Button();
            this.BtnRead = new System.Windows.Forms.Button();
            this.TbTagName = new System.Windows.Forms.TextBox();
            this.TbTagValue = new System.Windows.Forms.TextBox();
            this.BtnDisconnect = new System.Windows.Forms.Button();
            this.TbWriteValue = new System.Windows.Forms.TextBox();
            this.BtnWrite = new System.Windows.Forms.Button();
            this.TbMonitor = new System.Windows.Forms.Button();
            this.BtnScan = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.listView1 = new System.Windows.Forms.ListView();
            this.AttributeNameCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AttributeDataTypeCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AttributeValueCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // BtnConnect
            // 
            this.BtnConnect.Location = new System.Drawing.Point(28, 34);
            this.BtnConnect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(100, 28);
            this.BtnConnect.TabIndex = 0;
            this.BtnConnect.Text = "connect";
            this.BtnConnect.UseVisualStyleBackColor = true;
            this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // BtnRead
            // 
            this.BtnRead.Location = new System.Drawing.Point(251, 70);
            this.BtnRead.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnRead.Name = "BtnRead";
            this.BtnRead.Size = new System.Drawing.Size(133, 28);
            this.BtnRead.TabIndex = 1;
            this.BtnRead.Text = "read";
            this.BtnRead.UseVisualStyleBackColor = true;
            this.BtnRead.Click += new System.EventHandler(this.BtnRead_Click);
            // 
            // TbTagName
            // 
            this.TbTagName.Location = new System.Drawing.Point(251, 38);
            this.TbTagName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TbTagName.Name = "TbTagName";
            this.TbTagName.Size = new System.Drawing.Size(273, 22);
            this.TbTagName.TabIndex = 2;
            // 
            // TbTagValue
            // 
            this.TbTagValue.Location = new System.Drawing.Point(392, 74);
            this.TbTagValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TbTagValue.Name = "TbTagValue";
            this.TbTagValue.Size = new System.Drawing.Size(132, 22);
            this.TbTagValue.TabIndex = 3;
            // 
            // BtnDisconnect
            // 
            this.BtnDisconnect.Location = new System.Drawing.Point(28, 70);
            this.BtnDisconnect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnDisconnect.Name = "BtnDisconnect";
            this.BtnDisconnect.Size = new System.Drawing.Size(100, 28);
            this.BtnDisconnect.TabIndex = 4;
            this.BtnDisconnect.Text = "disconnect";
            this.BtnDisconnect.UseVisualStyleBackColor = true;
            // 
            // TbWriteValue
            // 
            this.TbWriteValue.Location = new System.Drawing.Point(392, 110);
            this.TbWriteValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TbWriteValue.Name = "TbWriteValue";
            this.TbWriteValue.Size = new System.Drawing.Size(132, 22);
            this.TbWriteValue.TabIndex = 6;
            // 
            // BtnWrite
            // 
            this.BtnWrite.Location = new System.Drawing.Point(251, 106);
            this.BtnWrite.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnWrite.Name = "BtnWrite";
            this.BtnWrite.Size = new System.Drawing.Size(133, 28);
            this.BtnWrite.TabIndex = 5;
            this.BtnWrite.Text = "write";
            this.BtnWrite.UseVisualStyleBackColor = true;
            this.BtnWrite.Click += new System.EventHandler(this.BtnWrite_Click);
            // 
            // TbMonitor
            // 
            this.TbMonitor.Location = new System.Drawing.Point(251, 142);
            this.TbMonitor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TbMonitor.Name = "TbMonitor";
            this.TbMonitor.Size = new System.Drawing.Size(133, 28);
            this.TbMonitor.TabIndex = 7;
            this.TbMonitor.Text = "monitor";
            this.TbMonitor.UseVisualStyleBackColor = true;
            this.TbMonitor.Click += new System.EventHandler(this.TbMonitor_Click);
            // 
            // BtnScan
            // 
            this.BtnScan.Location = new System.Drawing.Point(28, 255);
            this.BtnScan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnScan.Name = "BtnScan";
            this.BtnScan.Size = new System.Drawing.Size(100, 28);
            this.BtnScan.TabIndex = 8;
            this.BtnScan.Text = "SCAN";
            this.BtnScan.UseVisualStyleBackColor = true;
            this.BtnScan.Click += new System.EventHandler(this.BtnScan_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(28, 290);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(557, 208);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "";
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Location = new System.Drawing.Point(28, 177);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(599, 312);
            this.treeView1.TabIndex = 10;
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AttributeNameCH,
            this.AttributeDataTypeCH,
            this.AttributeValueCH});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(673, 34);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(358, 464);
            this.listView1.TabIndex = 11;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // AttributeNameCH
            // 
            this.AttributeNameCH.Text = "Name";
            // 
            // AttributeDataTypeCH
            // 
            this.AttributeDataTypeCH.Text = "Data Type";
            // 
            // AttributeValueCH
            // 
            this.AttributeValueCH.Text = "Value";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.BtnScan);
            this.Controls.Add(this.TbMonitor);
            this.Controls.Add(this.TbWriteValue);
            this.Controls.Add(this.BtnWrite);
            this.Controls.Add(this.BtnDisconnect);
            this.Controls.Add(this.TbTagValue);
            this.Controls.Add(this.TbTagName);
            this.Controls.Add(this.BtnRead);
            this.Controls.Add(this.BtnConnect);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnConnect;
        private System.Windows.Forms.Button BtnRead;
        private System.Windows.Forms.TextBox TbTagName;
        private System.Windows.Forms.TextBox TbTagValue;
        private System.Windows.Forms.Button BtnDisconnect;
        private System.Windows.Forms.TextBox TbWriteValue;
        private System.Windows.Forms.Button BtnWrite;
        private System.Windows.Forms.Button TbMonitor;
        private System.Windows.Forms.Button BtnScan;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader AttributeNameCH;
        private System.Windows.Forms.ColumnHeader AttributeDataTypeCH;
        private System.Windows.Forms.ColumnHeader AttributeValueCH;
    }
}

