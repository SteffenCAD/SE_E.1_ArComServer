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
            this.components = new System.ComponentModel.Container();
            this.BtnConnect = new System.Windows.Forms.Button();
            this.BtnRead = new System.Windows.Forms.Button();
            this.TbTagName = new System.Windows.Forms.TextBox();
            this.TbTagValue = new System.Windows.Forms.TextBox();
            this.BtnDisconnect = new System.Windows.Forms.Button();
            this.TbWriteValue = new System.Windows.Forms.TextBox();
            this.BtnWrite = new System.Windows.Forms.Button();
            this.TbMonitor = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.listView1 = new System.Windows.Forms.ListView();
            this.AttributeNameCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AttributeDataTypeCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AttributeValueCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CbUntrusted = new System.Windows.Forms.CheckBox();
            this.CbSecurity = new System.Windows.Forms.CheckBox();
            this.TbServerAddress = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TvScannedTags = new System.Windows.Forms.TreeView();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnScanTags = new System.Windows.Forms.Button();
            this.TmBackground = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.LbState = new System.Windows.Forms.Label();
            this.LbMonitoring = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnConnect
            // 
            this.BtnConnect.Location = new System.Drawing.Point(9, 43);
            this.BtnConnect.Margin = new System.Windows.Forms.Padding(4);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(100, 28);
            this.BtnConnect.TabIndex = 0;
            this.BtnConnect.Text = "connect";
            this.BtnConnect.UseVisualStyleBackColor = true;
            this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // BtnRead
            // 
            this.BtnRead.Location = new System.Drawing.Point(16, 132);
            this.BtnRead.Margin = new System.Windows.Forms.Padding(4);
            this.BtnRead.Name = "BtnRead";
            this.BtnRead.Size = new System.Drawing.Size(133, 28);
            this.BtnRead.TabIndex = 1;
            this.BtnRead.Text = "read";
            this.BtnRead.UseVisualStyleBackColor = true;
            this.BtnRead.Click += new System.EventHandler(this.BtnRead_Click);
            // 
            // TbTagName
            // 
            this.TbTagName.Location = new System.Drawing.Point(16, 100);
            this.TbTagName.Margin = new System.Windows.Forms.Padding(4);
            this.TbTagName.Name = "TbTagName";
            this.TbTagName.Size = new System.Drawing.Size(273, 22);
            this.TbTagName.TabIndex = 2;
            // 
            // TbTagValue
            // 
            this.TbTagValue.Location = new System.Drawing.Point(157, 136);
            this.TbTagValue.Margin = new System.Windows.Forms.Padding(4);
            this.TbTagValue.Name = "TbTagValue";
            this.TbTagValue.Size = new System.Drawing.Size(132, 22);
            this.TbTagValue.TabIndex = 3;
            // 
            // BtnDisconnect
            // 
            this.BtnDisconnect.Location = new System.Drawing.Point(117, 43);
            this.BtnDisconnect.Margin = new System.Windows.Forms.Padding(4);
            this.BtnDisconnect.Name = "BtnDisconnect";
            this.BtnDisconnect.Size = new System.Drawing.Size(100, 28);
            this.BtnDisconnect.TabIndex = 4;
            this.BtnDisconnect.Text = "disconnect";
            this.BtnDisconnect.UseVisualStyleBackColor = true;
            this.BtnDisconnect.Click += new System.EventHandler(this.BtnDisconnect_Click);
            // 
            // TbWriteValue
            // 
            this.TbWriteValue.Location = new System.Drawing.Point(157, 172);
            this.TbWriteValue.Margin = new System.Windows.Forms.Padding(4);
            this.TbWriteValue.Name = "TbWriteValue";
            this.TbWriteValue.Size = new System.Drawing.Size(132, 22);
            this.TbWriteValue.TabIndex = 6;
            // 
            // BtnWrite
            // 
            this.BtnWrite.Location = new System.Drawing.Point(16, 168);
            this.BtnWrite.Margin = new System.Windows.Forms.Padding(4);
            this.BtnWrite.Name = "BtnWrite";
            this.BtnWrite.Size = new System.Drawing.Size(133, 28);
            this.BtnWrite.TabIndex = 5;
            this.BtnWrite.Text = "write";
            this.BtnWrite.UseVisualStyleBackColor = true;
            this.BtnWrite.Click += new System.EventHandler(this.BtnWrite_Click);
            // 
            // TbMonitor
            // 
            this.TbMonitor.Location = new System.Drawing.Point(16, 204);
            this.TbMonitor.Margin = new System.Windows.Forms.Padding(4);
            this.TbMonitor.Name = "TbMonitor";
            this.TbMonitor.Size = new System.Drawing.Size(133, 28);
            this.TbMonitor.TabIndex = 7;
            this.TbMonitor.Text = "monitor";
            this.TbMonitor.UseVisualStyleBackColor = true;
            this.TbMonitor.Click += new System.EventHandler(this.TbMonitor_Click);
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Location = new System.Drawing.Point(3, 33);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(540, 281);
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
            this.listView1.Location = new System.Drawing.Point(3, 33);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(622, 278);
            this.listView1.TabIndex = 11;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // AttributeNameCH
            // 
            this.AttributeNameCH.Text = "Name";
            this.AttributeNameCH.Width = 117;
            // 
            // AttributeDataTypeCH
            // 
            this.AttributeDataTypeCH.Text = "Data Type";
            this.AttributeDataTypeCH.Width = 183;
            // 
            // AttributeValueCH
            // 
            this.AttributeValueCH.Text = "Value";
            this.AttributeValueCH.Width = 143;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1213, 600);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1205, 571);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Browser";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.10018F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.89982F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1193, 559);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.LbState);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.CbUntrusted);
            this.panel1.Controls.Add(this.CbSecurity);
            this.panel1.Controls.Add(this.TbServerAddress);
            this.panel1.Controls.Add(this.BtnConnect);
            this.panel1.Controls.Add(this.BtnDisconnect);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1187, 84);
            this.panel1.TabIndex = 0;
            // 
            // CbUntrusted
            // 
            this.CbUntrusted.AutoSize = true;
            this.CbUntrusted.Location = new System.Drawing.Point(598, 16);
            this.CbUntrusted.Name = "CbUntrusted";
            this.CbUntrusted.Size = new System.Drawing.Size(92, 21);
            this.CbUntrusted.TabIndex = 7;
            this.CbUntrusted.Text = "Untrusted";
            this.CbUntrusted.UseVisualStyleBackColor = true;
            // 
            // CbSecurity
            // 
            this.CbSecurity.AutoSize = true;
            this.CbSecurity.Location = new System.Drawing.Point(495, 16);
            this.CbSecurity.Name = "CbSecurity";
            this.CbSecurity.Size = new System.Drawing.Size(81, 21);
            this.CbSecurity.TabIndex = 6;
            this.CbSecurity.Text = "Security";
            this.CbSecurity.UseVisualStyleBackColor = true;
            // 
            // TbServerAddress
            // 
            this.TbServerAddress.Location = new System.Drawing.Point(9, 14);
            this.TbServerAddress.Name = "TbServerAddress";
            this.TbServerAddress.Size = new System.Drawing.Size(469, 22);
            this.TbServerAddress.TabIndex = 5;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 93);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1187, 463);
            this.splitContainer1.SplitterDistance = 320;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel3);
            this.splitContainer2.Size = new System.Drawing.Size(1187, 320);
            this.splitContainer2.SplitterDistance = 552;
            this.splitContainer2.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.treeView1, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(546, 317);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Browser";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.listView1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(628, 314);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "TagInfo";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1205, 571);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ReadWrite";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.LbMonitoring);
            this.panel2.Controls.Add(this.TvScannedTags);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.BtnScanTags);
            this.panel2.Controls.Add(this.TbTagName);
            this.panel2.Controls.Add(this.BtnRead);
            this.panel2.Controls.Add(this.TbTagValue);
            this.panel2.Controls.Add(this.TbMonitor);
            this.panel2.Controls.Add(this.BtnWrite);
            this.panel2.Controls.Add(this.TbWriteValue);
            this.panel2.Location = new System.Drawing.Point(6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1193, 559);
            this.panel2.TabIndex = 0;
            // 
            // TvScannedTags
            // 
            this.TvScannedTags.Location = new System.Drawing.Point(551, 23);
            this.TvScannedTags.Name = "TvScannedTags";
            this.TvScannedTags.Size = new System.Drawing.Size(436, 519);
            this.TvScannedTags.TabIndex = 13;
            this.TvScannedTags.DoubleClick += new System.EventHandler(this.TvScannedTags_DoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Name:";
            // 
            // BtnScanTags
            // 
            this.BtnScanTags.Location = new System.Drawing.Point(16, 23);
            this.BtnScanTags.Name = "BtnScanTags";
            this.BtnScanTags.Size = new System.Drawing.Size(133, 28);
            this.BtnScanTags.TabIndex = 8;
            this.BtnScanTags.Text = "scan Tags";
            this.BtnScanTags.UseVisualStyleBackColor = true;
            this.BtnScanTags.Click += new System.EventHandler(this.button1_Click);
            // 
            // TmBackground
            // 
            this.TmBackground.Enabled = true;
            this.TmBackground.Interval = 500;
            this.TmBackground.Tick += new System.EventHandler(this.TmBackground_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(269, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "connection state:";
            // 
            // LbState
            // 
            this.LbState.AutoSize = true;
            this.LbState.Location = new System.Drawing.Point(391, 49);
            this.LbState.Name = "LbState";
            this.LbState.Size = new System.Drawing.Size(116, 17);
            this.LbState.TabIndex = 9;
            this.LbState.Text = "DISCONNECTED";
            // 
            // LbMonitoring
            // 
            this.LbMonitoring.AutoSize = true;
            this.LbMonitoring.Location = new System.Drawing.Point(156, 210);
            this.LbMonitoring.Name = "LbMonitoring";
            this.LbMonitoring.Size = new System.Drawing.Size(0, 17);
            this.LbMonitoring.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 607);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "DUR OPCua Client";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader AttributeNameCH;
        private System.Windows.Forms.ColumnHeader AttributeDataTypeCH;
        private System.Windows.Forms.ColumnHeader AttributeValueCH;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnScanTags;
        private System.Windows.Forms.TextBox TbServerAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TreeView TvScannedTags;
        private System.Windows.Forms.CheckBox CbUntrusted;
        private System.Windows.Forms.CheckBox CbSecurity;
        private System.Windows.Forms.Timer TmBackground;
        private System.Windows.Forms.Label LbState;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LbMonitoring;
    }
}

