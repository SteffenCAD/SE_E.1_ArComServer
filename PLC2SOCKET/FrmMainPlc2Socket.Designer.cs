namespace PLC2SOCKET
{
    partial class FrmMainPlc2Socket
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
            this.RtbLog = new System.Windows.Forms.RichTextBox();
            this.TbSendString = new System.Windows.Forms.TextBox();
            this.BtnSendString = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TpUnityCon = new System.Windows.Forms.TabPage();
            this.BtnSocketClose = new System.Windows.Forms.Button();
            this.BtnSocketOpen = new System.Windows.Forms.Button();
            this.TpOPCua = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.BrowseNodesTV = new System.Windows.Forms.TreeView();
            this.AttributesLV = new System.Windows.Forms.ListView();
            this.AttributeNameCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AttributeDataTypeCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AttributeValueCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MonitoredItemsLV = new System.Windows.Forms.ListView();
            this.MonitoredItemIdCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VariableNameCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MonitoringModeCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SamplingIntevalCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DeadbandCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ValueCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.QualityCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TimestampCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LastOperationStatusCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.LbConnectionState = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnDisconnect = new System.Windows.Forms.Button();
            this.BtnConnect = new System.Windows.Forms.Button();
            this.TbOpcAddress = new System.Windows.Forms.TextBox();
            this.TpSettings = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnSettingsSave = new System.Windows.Forms.Button();
            this.BtnSettingsLoad = new System.Windows.Forms.Button();
            this.PgSettings = new System.Windows.Forms.PropertyGrid();
            this.TmBackWorker = new System.Windows.Forms.Timer(this.components);
            this.BtnSaveMI = new System.Windows.Forms.Button();
            this.BtnLoadMI = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.TpUnityCon.SuspendLayout();
            this.TpOPCua.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.TpSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // RtbLog
            // 
            this.RtbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RtbLog.Location = new System.Drawing.Point(3, 161);
            this.RtbLog.Name = "RtbLog";
            this.RtbLog.Size = new System.Drawing.Size(960, 269);
            this.RtbLog.TabIndex = 1;
            this.RtbLog.Text = "";
            // 
            // TbSendString
            // 
            this.TbSendString.Location = new System.Drawing.Point(6, 63);
            this.TbSendString.Name = "TbSendString";
            this.TbSendString.Size = new System.Drawing.Size(371, 20);
            this.TbSendString.TabIndex = 12;
            // 
            // BtnSendString
            // 
            this.BtnSendString.Location = new System.Drawing.Point(6, 89);
            this.BtnSendString.Name = "BtnSendString";
            this.BtnSendString.Size = new System.Drawing.Size(75, 23);
            this.BtnSendString.TabIndex = 13;
            this.BtnSendString.Text = "send";
            this.BtnSendString.UseVisualStyleBackColor = true;
            this.BtnSendString.Click += new System.EventHandler(this.BtnSendString_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.TpUnityCon);
            this.tabControl1.Controls.Add(this.TpOPCua);
            this.tabControl1.Controls.Add(this.TpSettings);
            this.tabControl1.Location = new System.Drawing.Point(5, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(986, 525);
            this.tabControl1.TabIndex = 14;
            // 
            // TpUnityCon
            // 
            this.TpUnityCon.Controls.Add(this.BtnSocketClose);
            this.TpUnityCon.Controls.Add(this.BtnSocketOpen);
            this.TpUnityCon.Controls.Add(this.RtbLog);
            this.TpUnityCon.Controls.Add(this.BtnSendString);
            this.TpUnityCon.Controls.Add(this.TbSendString);
            this.TpUnityCon.Location = new System.Drawing.Point(4, 22);
            this.TpUnityCon.Name = "TpUnityCon";
            this.TpUnityCon.Padding = new System.Windows.Forms.Padding(3);
            this.TpUnityCon.Size = new System.Drawing.Size(978, 499);
            this.TpUnityCon.TabIndex = 0;
            this.TpUnityCon.Text = "UnityConnection";
            this.TpUnityCon.UseVisualStyleBackColor = true;
            // 
            // BtnSocketClose
            // 
            this.BtnSocketClose.Location = new System.Drawing.Point(87, 6);
            this.BtnSocketClose.Name = "BtnSocketClose";
            this.BtnSocketClose.Size = new System.Drawing.Size(75, 23);
            this.BtnSocketClose.TabIndex = 15;
            this.BtnSocketClose.Text = "close";
            this.BtnSocketClose.UseVisualStyleBackColor = true;
            this.BtnSocketClose.Click += new System.EventHandler(this.BtnSocketClose_Click);
            // 
            // BtnSocketOpen
            // 
            this.BtnSocketOpen.Location = new System.Drawing.Point(6, 6);
            this.BtnSocketOpen.Name = "BtnSocketOpen";
            this.BtnSocketOpen.Size = new System.Drawing.Size(75, 23);
            this.BtnSocketOpen.TabIndex = 14;
            this.BtnSocketOpen.Text = "open";
            this.BtnSocketOpen.UseVisualStyleBackColor = true;
            this.BtnSocketOpen.Click += new System.EventHandler(this.BtnSocketOpen_Click);
            // 
            // TpOPCua
            // 
            this.TpOPCua.Controls.Add(this.tableLayoutPanel3);
            this.TpOPCua.Location = new System.Drawing.Point(4, 22);
            this.TpOPCua.Margin = new System.Windows.Forms.Padding(2);
            this.TpOPCua.Name = "TpOPCua";
            this.TpOPCua.Size = new System.Drawing.Size(978, 499);
            this.TpOPCua.TabIndex = 2;
            this.TpOPCua.Text = "OPCua";
            this.TpOPCua.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.splitContainer3, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.622642F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.37736F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(974, 495);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer3.Location = new System.Drawing.Point(2, 49);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.MonitoredItemsLV);
            this.splitContainer3.Size = new System.Drawing.Size(970, 444);
            this.splitContainer3.SplitterDistance = 287;
            this.splitContainer3.SplitterWidth = 3;
            this.splitContainer3.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(2, 2);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.BrowseNodesTV);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.AttributesLV);
            this.splitContainer2.Size = new System.Drawing.Size(965, 283);
            this.splitContainer2.SplitterDistance = 403;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 0;
            // 
            // BrowseNodesTV
            // 
            this.BrowseNodesTV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowseNodesTV.Location = new System.Drawing.Point(2, 2);
            this.BrowseNodesTV.Margin = new System.Windows.Forms.Padding(2);
            this.BrowseNodesTV.Name = "BrowseNodesTV";
            this.BrowseNodesTV.Size = new System.Drawing.Size(400, 278);
            this.BrowseNodesTV.TabIndex = 0;
            // 
            // AttributesLV
            // 
            this.AttributesLV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AttributesLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AttributeNameCH,
            this.AttributeDataTypeCH,
            this.AttributeValueCH});
            this.AttributesLV.HideSelection = false;
            this.AttributesLV.Location = new System.Drawing.Point(2, 2);
            this.AttributesLV.Margin = new System.Windows.Forms.Padding(2);
            this.AttributesLV.Name = "AttributesLV";
            this.AttributesLV.Size = new System.Drawing.Size(560, 278);
            this.AttributesLV.TabIndex = 0;
            this.AttributesLV.UseCompatibleStateImageBehavior = false;
            this.AttributesLV.View = System.Windows.Forms.View.Details;
            // 
            // AttributeNameCH
            // 
            this.AttributeNameCH.Text = "Name";
            this.AttributeNameCH.Width = 170;
            // 
            // AttributeDataTypeCH
            // 
            this.AttributeDataTypeCH.DisplayIndex = 2;
            this.AttributeDataTypeCH.Text = "Data Type";
            this.AttributeDataTypeCH.Width = 170;
            // 
            // AttributeValueCH
            // 
            this.AttributeValueCH.DisplayIndex = 1;
            this.AttributeValueCH.Text = "Value";
            this.AttributeValueCH.Width = 208;
            // 
            // MonitoredItemsLV
            // 
            this.MonitoredItemsLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MonitoredItemIdCH,
            this.VariableNameCH,
            this.MonitoringModeCH,
            this.SamplingIntevalCH,
            this.DeadbandCH,
            this.ValueCH,
            this.QualityCH,
            this.TimestampCH,
            this.LastOperationStatusCH});
            this.MonitoredItemsLV.HideSelection = false;
            this.MonitoredItemsLV.Location = new System.Drawing.Point(2, 3);
            this.MonitoredItemsLV.Name = "MonitoredItemsLV";
            this.MonitoredItemsLV.Size = new System.Drawing.Size(965, 148);
            this.MonitoredItemsLV.TabIndex = 0;
            this.MonitoredItemsLV.UseCompatibleStateImageBehavior = false;
            this.MonitoredItemsLV.View = System.Windows.Forms.View.Details;
            // 
            // MonitoredItemIdCH
            // 
            this.MonitoredItemIdCH.Text = "ID";
            // 
            // VariableNameCH
            // 
            this.VariableNameCH.Text = "Variable";
            // 
            // MonitoringModeCH
            // 
            this.MonitoringModeCH.Text = "Mode";
            // 
            // SamplingIntevalCH
            // 
            this.SamplingIntevalCH.Text = "Sampling Rate";
            // 
            // DeadbandCH
            // 
            this.DeadbandCH.Text = "Deadband";
            // 
            // ValueCH
            // 
            this.ValueCH.Text = "Value";
            // 
            // QualityCH
            // 
            this.QualityCH.Text = "Quality";
            // 
            // TimestampCH
            // 
            this.TimestampCH.Text = "Timestamp";
            // 
            // LastOperationStatusCH
            // 
            this.LastOperationStatusCH.Text = "Last Error";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.BtnLoadMI);
            this.panel1.Controls.Add(this.BtnSaveMI);
            this.panel1.Controls.Add(this.LbConnectionState);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.BtnDisconnect);
            this.panel1.Controls.Add(this.BtnConnect);
            this.panel1.Controls.Add(this.TbOpcAddress);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(970, 43);
            this.panel1.TabIndex = 2;
            // 
            // LbConnectionState
            // 
            this.LbConnectionState.AutoSize = true;
            this.LbConnectionState.Location = new System.Drawing.Point(479, 5);
            this.LbConnectionState.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LbConnectionState.Name = "LbConnectionState";
            this.LbConnectionState.Size = new System.Drawing.Size(92, 13);
            this.LbConnectionState.TabIndex = 4;
            this.LbConnectionState.Text = "DISCONNECTED";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(426, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "STATUS:";
            // 
            // BtnDisconnect
            // 
            this.BtnDisconnect.Location = new System.Drawing.Point(322, 2);
            this.BtnDisconnect.Margin = new System.Windows.Forms.Padding(2);
            this.BtnDisconnect.Name = "BtnDisconnect";
            this.BtnDisconnect.Size = new System.Drawing.Size(77, 19);
            this.BtnDisconnect.TabIndex = 2;
            this.BtnDisconnect.Text = "disconnect";
            this.BtnDisconnect.UseVisualStyleBackColor = true;
            this.BtnDisconnect.Click += new System.EventHandler(this.BtnDisconnect_Click);
            // 
            // BtnConnect
            // 
            this.BtnConnect.Location = new System.Drawing.Point(240, 2);
            this.BtnConnect.Margin = new System.Windows.Forms.Padding(2);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(77, 19);
            this.BtnConnect.TabIndex = 1;
            this.BtnConnect.Text = "connect";
            this.BtnConnect.UseVisualStyleBackColor = true;
            this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // TbOpcAddress
            // 
            this.TbOpcAddress.Location = new System.Drawing.Point(4, 2);
            this.TbOpcAddress.Margin = new System.Windows.Forms.Padding(2);
            this.TbOpcAddress.Name = "TbOpcAddress";
            this.TbOpcAddress.Size = new System.Drawing.Size(232, 20);
            this.TbOpcAddress.TabIndex = 0;
            this.TbOpcAddress.Text = "opc.tcp://127.0.0.1:4840";
            this.TbOpcAddress.TextChanged += new System.EventHandler(this.TbOpcAddress_TextChanged);
            // 
            // TpSettings
            // 
            this.TpSettings.Controls.Add(this.splitContainer1);
            this.TpSettings.Location = new System.Drawing.Point(4, 22);
            this.TpSettings.Name = "TpSettings";
            this.TpSettings.Padding = new System.Windows.Forms.Padding(3);
            this.TpSettings.Size = new System.Drawing.Size(978, 499);
            this.TpSettings.TabIndex = 1;
            this.TpSettings.Text = "Settings";
            this.TpSettings.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(971, 490);
            this.splitContainer1.SplitterDistance = 545;
            this.splitContainer1.TabIndex = 14;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.PgSettings, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(545, 490);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.BtnSettingsSave, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnSettingsLoad, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 458);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(539, 29);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // BtnSettingsSave
            // 
            this.BtnSettingsSave.Location = new System.Drawing.Point(272, 3);
            this.BtnSettingsSave.Name = "BtnSettingsSave";
            this.BtnSettingsSave.Size = new System.Drawing.Size(203, 23);
            this.BtnSettingsSave.TabIndex = 13;
            this.BtnSettingsSave.Text = "Save";
            this.BtnSettingsSave.UseVisualStyleBackColor = true;
            this.BtnSettingsSave.Click += new System.EventHandler(this.BtnSettingsSave_Click);
            // 
            // BtnSettingsLoad
            // 
            this.BtnSettingsLoad.Location = new System.Drawing.Point(3, 3);
            this.BtnSettingsLoad.Name = "BtnSettingsLoad";
            this.BtnSettingsLoad.Size = new System.Drawing.Size(202, 23);
            this.BtnSettingsLoad.TabIndex = 12;
            this.BtnSettingsLoad.Text = "Load";
            this.BtnSettingsLoad.UseVisualStyleBackColor = true;
            this.BtnSettingsLoad.Click += new System.EventHandler(this.BtnSettingsLoad_Click);
            // 
            // PgSettings
            // 
            this.PgSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PgSettings.Location = new System.Drawing.Point(3, 3);
            this.PgSettings.Name = "PgSettings";
            this.PgSettings.Size = new System.Drawing.Size(539, 449);
            this.PgSettings.TabIndex = 0;
            // 
            // TmBackWorker
            // 
            this.TmBackWorker.Enabled = true;
            this.TmBackWorker.Interval = 500;
            this.TmBackWorker.Tick += new System.EventHandler(this.TmBackWorker_Tick);
            // 
            // BtnSaveMI
            // 
            this.BtnSaveMI.Location = new System.Drawing.Point(612, 5);
            this.BtnSaveMI.Name = "BtnSaveMI";
            this.BtnSaveMI.Size = new System.Drawing.Size(75, 23);
            this.BtnSaveMI.TabIndex = 5;
            this.BtnSaveMI.Text = "SaveMI";
            this.BtnSaveMI.UseVisualStyleBackColor = true;
            this.BtnSaveMI.Click += new System.EventHandler(this.BtnSaveMI_Click);
            // 
            // BtnLoadMI
            // 
            this.BtnLoadMI.Location = new System.Drawing.Point(693, 5);
            this.BtnLoadMI.Name = "BtnLoadMI";
            this.BtnLoadMI.Size = new System.Drawing.Size(75, 23);
            this.BtnLoadMI.TabIndex = 6;
            this.BtnLoadMI.Text = "LoadMI";
            this.BtnLoadMI.UseVisualStyleBackColor = true;
            // 
            // FrmMainPlc2Socket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 532);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmMainPlc2Socket";
            this.Text = "PLC2SOCKET";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.tabControl1.ResumeLayout(false);
            this.TpUnityCon.ResumeLayout(false);
            this.TpUnityCon.PerformLayout();
            this.TpOPCua.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.TpSettings.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox RtbLog;
        private System.Windows.Forms.TextBox TbSendString;
        private System.Windows.Forms.Button BtnSendString;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TpUnityCon;
        private System.Windows.Forms.TabPage TpSettings;
        private System.Windows.Forms.Button BtnSettingsLoad;
        private System.Windows.Forms.Button BtnSettingsSave;
        private System.Windows.Forms.PropertyGrid PgSettings;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TabPage TpOPCua;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView BrowseNodesTV;
        private System.Windows.Forms.ListView AttributesLV;
        private System.Windows.Forms.ColumnHeader AttributeNameCH;
        private System.Windows.Forms.ColumnHeader AttributeDataTypeCH;
        private System.Windows.Forms.ColumnHeader AttributeValueCH;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LbConnectionState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnDisconnect;
        private System.Windows.Forms.Button BtnConnect;
        private System.Windows.Forms.TextBox TbOpcAddress;
        private System.Windows.Forms.Button BtnSocketClose;
        private System.Windows.Forms.Button BtnSocketOpen;
        private System.Windows.Forms.ListView MonitoredItemsLV;
        private System.Windows.Forms.ColumnHeader MonitoredItemIdCH;
        private System.Windows.Forms.ColumnHeader VariableNameCH;
        private System.Windows.Forms.ColumnHeader MonitoringModeCH;
        private System.Windows.Forms.ColumnHeader SamplingIntevalCH;
        private System.Windows.Forms.ColumnHeader DeadbandCH;
        private System.Windows.Forms.ColumnHeader ValueCH;
        private System.Windows.Forms.ColumnHeader QualityCH;
        private System.Windows.Forms.ColumnHeader TimestampCH;
        private System.Windows.Forms.ColumnHeader LastOperationStatusCH;
        private System.Windows.Forms.Timer TmBackWorker;
        private System.Windows.Forms.Button BtnLoadMI;
        private System.Windows.Forms.Button BtnSaveMI;
    }
}

