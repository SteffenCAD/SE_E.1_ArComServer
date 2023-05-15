using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Opc.Ua;
using Opc.Ua.Client;
using DUR.OPCUA.EVENTS;


namespace DUR.OPCUA
{
    public class UaUi
    {
        private TreeView BrowseNodesTV     = null;
        private ListView AttributesLV      = null;
        private ListView MonitoredItemsLV  = null;
        private UaClient UaClient          = null;

        #region Menue
        private System.Windows.Forms.ColumnHeader AttributeNameCH;
        private System.Windows.Forms.ColumnHeader AttributeDataTypeCH;
        private System.Windows.Forms.ColumnHeader AttributeValueCH;

        private System.Windows.Forms.ColumnHeader MonitoredItemIdCH;
        private System.Windows.Forms.ColumnHeader VariableNameCH;
        private System.Windows.Forms.ColumnHeader MonitoringModeCH;
        private System.Windows.Forms.ColumnHeader SamplingIntevalCH;
        private System.Windows.Forms.ColumnHeader DeadbandCH;
        private System.Windows.Forms.ColumnHeader ValueCH;
        private System.Windows.Forms.ColumnHeader QualityCH;
        private System.Windows.Forms.ColumnHeader TimestampCH;
        private System.Windows.Forms.ColumnHeader LastOperationStatusCH;
        private System.Windows.Forms.ContextMenuStrip BrowsingMenu;
        private System.Windows.Forms.ToolStripMenuItem Browse_MonitorMI;
        private System.Windows.Forms.ToolStripMenuItem Browse_WriteMI;
        private System.Windows.Forms.ContextMenuStrip MonitoringMenu;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_DeleteMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_MonitoringModeMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_MonitoringMode_DisabledMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_MonitoringMode_SamplingMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_MonitoringMode_ReportingMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_SamplingIntervalMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_SamplingInterval_FastMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_SamplingInterval_1000MI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_SamplingInterval_2500MI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_SamplingInterval_5000MI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_DeadbandMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_Deadband_NoneMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_Deadband_AbsoluteMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_Deadband_Absolute_5MI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_Deadband_Absolute_10MI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_Deadband_Absolute_25MI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_Deadband_PercentageMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_Deadband_Percentage_1MI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_Deadband_Percentage_5MI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_Deadband_Percentage_10MI;
        private System.Windows.Forms.ToolStripMenuItem Browse_ReadHistoryMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_WriteMI;
        #endregion

        public void connect(UaClient uaClient, TreeView browseNodesTV, ListView attributesLV = null, ListView monitoredItemsLV = null)
        {
            //save object references in UaUi class
            BrowseNodesTV      = browseNodesTV;
            AttributesLV       = attributesLV;
            MonitoredItemsLV   = monitoredItemsLV;
            UaClient           = uaClient;

            //add events
            BrowseNodesTV.MouseDown    += BrowseNodesTV_MouseDown;
            BrowseNodesTV.AfterSelect  += BrowseNodesTV_AfterSelect;
            BrowseNodesTV.BeforeExpand += BrowseNodesTV_BeforeExpand;
            BrowseNodesTV.ContextMenuStrip = BrowsingMenu;

            //Menu configuration
            Menu_AddItems();

            //fill Treeview with opc server tags/objects
            PopulateBranch(ObjectIds.ObjectsFolder, BrowseNodesTV.Nodes);

            UaClient.m_monitoredItem_Notification += new MonitoredItemNotificationEventHandler(MonitoredItem_Notification);
        }

        #region Menues


        private void Menu_AddItems()
        {
            this.BrowsingMenu = new System.Windows.Forms.ContextMenuStrip();
            this.Browse_MonitorMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Browse_WriteMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Browse_ReadHistoryMI = new System.Windows.Forms.ToolStripMenuItem();
            this.AttributeNameCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AttributeDataTypeCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AttributeValueCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MonitoredItemIdCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VariableNameCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MonitoringModeCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SamplingIntevalCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DeadbandCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ValueCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.QualityCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TimestampCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LastOperationStatusCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MonitoringMenu = new System.Windows.Forms.ContextMenuStrip();
            this.Monitoring_DeleteMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_WriteMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_MonitoringModeMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_MonitoringMode_DisabledMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_MonitoringMode_SamplingMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_MonitoringMode_ReportingMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_SamplingIntervalMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_SamplingInterval_FastMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_SamplingInterval_1000MI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_SamplingInterval_2500MI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_SamplingInterval_5000MI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_DeadbandMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_Deadband_NoneMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_Deadband_AbsoluteMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_Deadband_Absolute_5MI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_Deadband_Absolute_10MI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_Deadband_Absolute_25MI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_Deadband_PercentageMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_Deadband_Percentage_1MI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_Deadband_Percentage_5MI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_Deadband_Percentage_10MI = new System.Windows.Forms.ToolStripMenuItem();
            // 
            // BrowseNodesTV
            // 
            this.BrowseNodesTV.ContextMenuStrip = this.BrowsingMenu;
            this.BrowseNodesTV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BrowseNodesTV.Location = new System.Drawing.Point(0, 0);
            this.BrowseNodesTV.Name = "BrowseNodesTV";
            this.BrowseNodesTV.Size = new System.Drawing.Size(391, 278);
            this.BrowseNodesTV.TabIndex = 0;
            this.BrowseNodesTV.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.BrowseNodesTV_BeforeExpand);
            this.BrowseNodesTV.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.BrowseNodesTV_AfterSelect);
            this.BrowseNodesTV.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BrowseNodesTV_MouseDown);
            // 
            // BrowsingMenu
            // 
            this.BrowsingMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[]{
            this.Browse_MonitorMI,
            this.Browse_WriteMI,
            this.Browse_ReadHistoryMI});
            this.BrowsingMenu.Name = "BrowsingMenu";
            this.BrowsingMenu.Size = new System.Drawing.Size(151, 70);
            this.BrowsingMenu.Opening += new System.ComponentModel.CancelEventHandler(this.BrowsingMenu_Opening);

            // 
            // Browse_MonitorMI
            // 
            this.Browse_MonitorMI.Name = "Browse_MonitorMI";
            this.Browse_MonitorMI.Size = new System.Drawing.Size(150, 22);
            this.Browse_MonitorMI.Text = "Monitor";
            this.Browse_MonitorMI.Click += new System.EventHandler(this.Browse_MonitorMI_Click);
            // 
            // Browse_WriteMI
            // 
            this.Browse_WriteMI.Name = "Browse_WriteMI";
            this.Browse_WriteMI.Size = new System.Drawing.Size(150, 22);
            this.Browse_WriteMI.Text = "Write...";
            this.Browse_WriteMI.Click += new System.EventHandler(this.Browse_WriteMI_Click);
            // 
            // AttributesLV
            // 
            this.AttributesLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AttributeNameCH,
            this.AttributeDataTypeCH,
            this.AttributeValueCH});
            this.AttributesLV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AttributesLV.FullRowSelect = true;
            this.AttributesLV.HideSelection = false;
            this.AttributesLV.Location = new System.Drawing.Point(0, 0);
            this.AttributesLV.Name = "AttributesLV";
            this.AttributesLV.Size = new System.Drawing.Size(489, 278);
            this.AttributesLV.TabIndex = 0;
            this.AttributesLV.UseCompatibleStateImageBehavior = false;
            this.AttributesLV.View = System.Windows.Forms.View.Details;
            // 
            // AttributeNameCH
            // 
            this.AttributeNameCH.Text = "Name";
            // 
            // AttributeDataTypeCH
            // 
            this.AttributeDataTypeCH.DisplayIndex = 2;
            this.AttributeDataTypeCH.Text = "Data Type";
            this.AttributeDataTypeCH.Width = 102;
            // 
            // AttributeValueCH
            // 
            this.AttributeValueCH.DisplayIndex = 1;
            this.AttributeValueCH.Text = "Value";
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
            this.MonitoredItemsLV.ContextMenuStrip = this.MonitoringMenu;
            this.MonitoredItemsLV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MonitoredItemsLV.FullRowSelect = true;
            this.MonitoredItemsLV.HideSelection = false;
            this.MonitoredItemsLV.Location = new System.Drawing.Point(0, 0);
            this.MonitoredItemsLV.Name = "MonitoredItemsLV";
            this.MonitoredItemsLV.Size = new System.Drawing.Size(884, 120);
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
            this.SamplingIntevalCH.Width = 98;
            // 
            // DeadbandCH
            // 
            this.DeadbandCH.Text = "Deadband";
            this.DeadbandCH.Width = 89;
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
            this.TimestampCH.Width = 109;
            // 
            // LastOperationStatusCH
            // 
            this.LastOperationStatusCH.Text = "Last Error";
            // 
            // MonitoringMenu
            // 
            this.MonitoringMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Monitoring_DeleteMI,
            this.Monitoring_WriteMI,
            this.Monitoring_MonitoringModeMI,
            this.Monitoring_SamplingIntervalMI,
            this.Monitoring_DeadbandMI});
            this.MonitoringMenu.Name = "MonitoringMenu";
            this.MonitoringMenu.Size = new System.Drawing.Size(169, 114);
            // 
            // Monitoring_DeleteMI
            // 
            this.Monitoring_DeleteMI.Name = "Monitoring_DeleteMI";
            this.Monitoring_DeleteMI.Size = new System.Drawing.Size(168, 22);
            this.Monitoring_DeleteMI.Text = "Delete";
            this.Monitoring_DeleteMI.Click += new System.EventHandler(this.Monitoring_DeleteMI_Click);
            // 
            // Monitoring_WriteMI
            // 
            this.Monitoring_WriteMI.Name = "Monitoring_WriteMI";
            this.Monitoring_WriteMI.Size = new System.Drawing.Size(168, 22);
            this.Monitoring_WriteMI.Text = "Write...";
            this.Monitoring_WriteMI.Click += new System.EventHandler(this.Monitoring_WriteMI_Click);
            // 
            // Monitoring_MonitoringModeMI
            // 
            this.Monitoring_MonitoringModeMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Monitoring_MonitoringMode_DisabledMI,
            this.Monitoring_MonitoringMode_SamplingMI,
            this.Monitoring_MonitoringMode_ReportingMI});
            this.Monitoring_MonitoringModeMI.Name = "Monitoring_MonitoringModeMI";
            this.Monitoring_MonitoringModeMI.Size = new System.Drawing.Size(168, 22);
            this.Monitoring_MonitoringModeMI.Text = "Monitoring Mode";
            // 
            // Monitoring_MonitoringMode_DisabledMI
            // 
            this.Monitoring_MonitoringMode_DisabledMI.Name = "Monitoring_MonitoringMode_DisabledMI";
            this.Monitoring_MonitoringMode_DisabledMI.Size = new System.Drawing.Size(180, 22);
            this.Monitoring_MonitoringMode_DisabledMI.Text = "Disabled";
            this.Monitoring_MonitoringMode_DisabledMI.Click += new System.EventHandler(this.Monitoring_MonitoringMode_Click);
            // 
            // Monitoring_MonitoringMode_SamplingMI
            // 
            this.Monitoring_MonitoringMode_SamplingMI.Name = "Monitoring_MonitoringMode_SamplingMI";
            this.Monitoring_MonitoringMode_SamplingMI.Size = new System.Drawing.Size(180, 22);
            this.Monitoring_MonitoringMode_SamplingMI.Text = "Sampling";
            this.Monitoring_MonitoringMode_SamplingMI.Click += new System.EventHandler(this.Monitoring_MonitoringMode_Click);
            // 
            // Monitoring_MonitoringMode_ReportingMI
            // 
            this.Monitoring_MonitoringMode_ReportingMI.Name = "Monitoring_MonitoringMode_ReportingMI";
            this.Monitoring_MonitoringMode_ReportingMI.Size = new System.Drawing.Size(180, 22);
            this.Monitoring_MonitoringMode_ReportingMI.Text = "Reporting";
            this.Monitoring_MonitoringMode_ReportingMI.Click += new System.EventHandler(this.Monitoring_MonitoringMode_Click);
            // 
            // Monitoring_SamplingIntervalMI
            // 
            this.Monitoring_SamplingIntervalMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Monitoring_SamplingInterval_FastMI,
            this.Monitoring_SamplingInterval_1000MI,
            this.Monitoring_SamplingInterval_2500MI,
            this.Monitoring_SamplingInterval_5000MI});
            this.Monitoring_SamplingIntervalMI.Name = "Monitoring_SamplingIntervalMI";
            this.Monitoring_SamplingIntervalMI.Size = new System.Drawing.Size(168, 22);
            this.Monitoring_SamplingIntervalMI.Text = "Samping Interval";
            // 
            // Monitoring_SamplingInterval_FastMI
            // 
            this.Monitoring_SamplingInterval_FastMI.Name = "Monitoring_SamplingInterval_FastMI";
            this.Monitoring_SamplingInterval_FastMI.Size = new System.Drawing.Size(180, 22);
            this.Monitoring_SamplingInterval_FastMI.Text = "Fast as Possible";
            this.Monitoring_SamplingInterval_FastMI.Click += new System.EventHandler(this.Monitoring_SamplingInterval_Click);
            // 
            // Monitoring_SamplingInterval_1000MI
            // 
            this.Monitoring_SamplingInterval_1000MI.Name = "Monitoring_SamplingInterval_1000MI";
            this.Monitoring_SamplingInterval_1000MI.Size = new System.Drawing.Size(180, 22);
            this.Monitoring_SamplingInterval_1000MI.Text = "1000ms";
            this.Monitoring_SamplingInterval_1000MI.Click += new System.EventHandler(this.Monitoring_SamplingInterval_Click);
            // 
            // Monitoring_SamplingInterval_2500MI
            // 
            this.Monitoring_SamplingInterval_2500MI.Name = "Monitoring_SamplingInterval_2500MI";
            this.Monitoring_SamplingInterval_2500MI.Size = new System.Drawing.Size(180, 22);
            this.Monitoring_SamplingInterval_2500MI.Text = "2500ms";
            this.Monitoring_SamplingInterval_2500MI.Click += new System.EventHandler(this.Monitoring_SamplingInterval_Click);
            // 
            // Monitoring_SamplingInterval_5000MI
            // 
            this.Monitoring_SamplingInterval_5000MI.Name = "Monitoring_SamplingInterval_5000MI";
            this.Monitoring_SamplingInterval_5000MI.Size = new System.Drawing.Size(180, 22);
            this.Monitoring_SamplingInterval_5000MI.Text = "5000ms";
            this.Monitoring_SamplingInterval_5000MI.Click += new System.EventHandler(this.Monitoring_SamplingInterval_Click);
            // 
            // Monitoring_DeadbandMI
            // 
            this.Monitoring_DeadbandMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Monitoring_Deadband_NoneMI,
            this.Monitoring_Deadband_AbsoluteMI,
            this.Monitoring_Deadband_PercentageMI});
            this.Monitoring_DeadbandMI.Name = "Monitoring_DeadbandMI";
            this.Monitoring_DeadbandMI.Size = new System.Drawing.Size(168, 22);
            this.Monitoring_DeadbandMI.Text = "Deadband";
            // 
            // Monitoring_Deadband_NoneMI
            // 
            this.Monitoring_Deadband_NoneMI.Name = "Monitoring_Deadband_NoneMI";
            this.Monitoring_Deadband_NoneMI.Size = new System.Drawing.Size(180, 22);
            this.Monitoring_Deadband_NoneMI.Text = "None";
            this.Monitoring_Deadband_NoneMI.Click += new System.EventHandler(this.Monitoring_Deadband_Click);
            // 
            // Monitoring_Deadband_AbsoluteMI
            // 
            this.Monitoring_Deadband_AbsoluteMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Monitoring_Deadband_Absolute_5MI,
            this.Monitoring_Deadband_Absolute_10MI,
            this.Monitoring_Deadband_Absolute_25MI});
            this.Monitoring_Deadband_AbsoluteMI.Name = "Monitoring_Deadband_AbsoluteMI";
            this.Monitoring_Deadband_AbsoluteMI.Size = new System.Drawing.Size(180, 22);
            this.Monitoring_Deadband_AbsoluteMI.Text = "Absolute";
            // 
            // Monitoring_Deadband_Absolute_5MI
            // 
            this.Monitoring_Deadband_Absolute_5MI.Name = "Monitoring_Deadband_Absolute_5MI";
            this.Monitoring_Deadband_Absolute_5MI.Size = new System.Drawing.Size(180, 22);
            this.Monitoring_Deadband_Absolute_5MI.Text = "5";
            this.Monitoring_Deadband_Absolute_5MI.Click += new System.EventHandler(this.Monitoring_Deadband_Click);
            // 
            // Monitoring_Deadband_Absolute_10MI
            // 
            this.Monitoring_Deadband_Absolute_10MI.Name = "Monitoring_Deadband_Absolute_10MI";
            this.Monitoring_Deadband_Absolute_10MI.Size = new System.Drawing.Size(180, 22);
            this.Monitoring_Deadband_Absolute_10MI.Text = "10";
            this.Monitoring_Deadband_Absolute_10MI.Click += new System.EventHandler(this.Monitoring_Deadband_Click);
            // 
            // Monitoring_Deadband_Absolute_25MI
            // 
            this.Monitoring_Deadband_Absolute_25MI.Name = "Monitoring_Deadband_Absolute_25MI";
            this.Monitoring_Deadband_Absolute_25MI.Size = new System.Drawing.Size(180, 22);
            this.Monitoring_Deadband_Absolute_25MI.Text = "25";
            this.Monitoring_Deadband_Absolute_25MI.Click += new System.EventHandler(this.Monitoring_Deadband_Click);
            // 
            // Monitoring_Deadband_PercentageMI
            // 
            this.Monitoring_Deadband_PercentageMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Monitoring_Deadband_Percentage_1MI,
            this.Monitoring_Deadband_Percentage_5MI,
            this.Monitoring_Deadband_Percentage_10MI});
            this.Monitoring_Deadband_PercentageMI.Name = "Monitoring_Deadband_PercentageMI";
            this.Monitoring_Deadband_PercentageMI.Size = new System.Drawing.Size(180, 22);
            this.Monitoring_Deadband_PercentageMI.Text = "Percentage";
            // 
            // Monitoring_Deadband_Percentage_1MI
            // 
            this.Monitoring_Deadband_Percentage_1MI.Name = "Monitoring_Deadband_Percentage_1MI";
            this.Monitoring_Deadband_Percentage_1MI.Size = new System.Drawing.Size(180, 22);
            this.Monitoring_Deadband_Percentage_1MI.Text = "1%";
            this.Monitoring_Deadband_Percentage_1MI.Click += new System.EventHandler(this.Monitoring_Deadband_Click);
            // 
            // Monitoring_Deadband_Percentage_5MI
            // 
            this.Monitoring_Deadband_Percentage_5MI.Name = "Monitoring_Deadband_Percentage_5MI";
            this.Monitoring_Deadband_Percentage_5MI.Size = new System.Drawing.Size(180, 22);
            this.Monitoring_Deadband_Percentage_5MI.Text = "5%";
            this.Monitoring_Deadband_Percentage_5MI.Click += new System.EventHandler(this.Monitoring_Deadband_Click);
            // 
            // Monitoring_Deadband_Percentage_10MI
            // 
            this.Monitoring_Deadband_Percentage_10MI.Name = "Monitoring_Deadband_Percentage_10MI";
            this.Monitoring_Deadband_Percentage_10MI.Size = new System.Drawing.Size(180, 22);
            this.Monitoring_Deadband_Percentage_10MI.Text = "10%";
            this.Monitoring_Deadband_Percentage_10MI.Click += new System.EventHandler(this.Monitoring_Deadband_Click);




        }
        private void BrowsingMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Browse_MonitorMI.Enabled = true;
            Browse_ReadHistoryMI.Enabled = true;
            Browse_WriteMI.Enabled = true;

            if (UaClient.m_session == null || BrowseNodesTV.SelectedNode == null)
            {
                Browse_MonitorMI.Enabled = false;
                Browse_ReadHistoryMI.Enabled = false;
                Browse_WriteMI.Enabled = false;
                return;
            }

            ReferenceDescription reference = (ReferenceDescription)BrowseNodesTV.SelectedNode.Tag;

            if (reference.NodeId.IsAbsolute || reference.NodeClass != NodeClass.Variable)
            {
                Browse_MonitorMI.Enabled = false;
                Browse_ReadHistoryMI.Enabled = false;
                Browse_WriteMI.Enabled = false;
                return;
            }
        }

        /// <summary>
        /// Prompts the use to write the value of a varible.
        /// </summary>
        private void Browse_WriteMI_Click(object sender, EventArgs e)
        {
            try
            {
                // check if operation is currently allowed.
                if (UaClient.m_session == null || BrowseNodesTV.SelectedNode == null)
                {
                    return;
                }

                // can only subscribe to local variables. 
                ReferenceDescription reference = (ReferenceDescription)BrowseNodesTV.SelectedNode.Tag;

                if (reference.NodeId.IsAbsolute || reference.NodeClass != NodeClass.Variable)
                {
                    return;
                }

                //TODO
                //new WriteValueDlg().ShowDialog(UaClient.Session, (NodeId)reference.NodeId, Attributes.Value);
            }
            catch (Exception exception)
            {
               //ClientUtils.HandleException(this.Text, exception);
            }
        }

        /// <summary>
        /// Handles the Click event of the Browse_MonitorMI control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Browse_MonitorMI_Click(object sender, EventArgs e)
        {
            try
            {  
                // check if operation is currently allowed.
                if (UaClient.m_session == null || BrowseNodesTV.SelectedNode == null)
                {
                    return;
                }

                // can only subscribe to local variables. 
                ReferenceDescription reference = (ReferenceDescription)BrowseNodesTV.SelectedNode.Tag;

                Add_MonitorMI(reference);
            }
            catch (Exception exception)
            {
                //ClientUtils.HandleException(this.Text, exception);
            }
        }

        public void Add_MonitorMI(ReferenceDescription reference)
        {
            if (reference.NodeId.IsAbsolute || reference.NodeClass != NodeClass.Variable)
            {
                return;
            }

            ListViewItem item = CreateMonitoredItem((NodeId)reference.NodeId, Utils.Format("{0}", reference));

            UaClient.m_subscription.ApplyChanges();

            MonitoredItem monitoredItem = (MonitoredItem)item.Tag;

            if (ServiceResult.IsBad(monitoredItem.Status.Error))
            {
                item.SubItems[8].Text = monitoredItem.Status.Error.StatusCode.ToString();
            }

            item.SubItems.Add(monitoredItem.DisplayName);
            item.SubItems[1].Text = monitoredItem.MonitoringMode.ToString();
            item.SubItems[2].Text = monitoredItem.SamplingInterval.ToString();
            item.SubItems[3].Text = DeadbandFilterToText(monitoredItem.Filter);

            if(MonitoredItemsLV != null)
            {
                MonitoredItemsLV.Columns[0].Width = -2;
                MonitoredItemsLV.Columns[1].Width = -2;
                MonitoredItemsLV.Columns[8].Width = -2;
            }
        }

        /// <summary>
        /// Creates the monitored item.
        /// </summary>
        private ListViewItem CreateMonitoredItem(NodeId nodeId, string displayName)
        {
            if (UaClient.m_subscription == null)
            {
                UaClient.m_subscription = new Subscription(UaClient.m_session.DefaultSubscription);

                UaClient.m_subscription.PublishingEnabled = true;
                UaClient.m_subscription.PublishingInterval = 1000;
                UaClient.m_subscription.KeepAliveCount = 10;
                UaClient.m_subscription.LifetimeCount = 10;
                UaClient.m_subscription.MaxNotificationsPerPublish = 1000;
                UaClient.m_subscription.Priority = 100;

                UaClient.m_session.AddSubscription(UaClient.m_subscription);

                UaClient.m_subscription.Create();
            }

            // add the new monitored item.
            MonitoredItem monitoredItem = new MonitoredItem(UaClient.m_subscription.DefaultItem);

            monitoredItem.StartNodeId = nodeId;
            monitoredItem.AttributeId = Attributes.Value;
            monitoredItem.DisplayName = displayName;
            monitoredItem.MonitoringMode = MonitoringMode.Reporting;
            monitoredItem.SamplingInterval = 1000;
            monitoredItem.QueueSize = 0;
            monitoredItem.DiscardOldest = true;

            monitoredItem.Notification += UaClient.m_monitoredItem_Notification;
            monitoredItem.Notification += UaClient.m_monitoredItem_Notification;

            UaClient.m_subscription.AddItem(monitoredItem);


            // add the attribute name/value to the list view.
            ListViewItem item = new ListViewItem(monitoredItem.ClientHandle.ToString());
            monitoredItem.Handle = item;

            item.SubItems.Add(monitoredItem.DisplayName);
            item.SubItems.Add(monitoredItem.MonitoringMode.ToString());
            item.SubItems.Add(monitoredItem.SamplingInterval.ToString());
            item.SubItems.Add(DeadbandFilterToText(monitoredItem.Filter));
            item.SubItems.Add(String.Empty);
            item.SubItems.Add(String.Empty);
            item.SubItems.Add(String.Empty);
            item.SubItems.Add(String.Empty);

            item.Tag = monitoredItem;

            if (MonitoredItemsLV != null)
            {
                MonitoredItemsLV.Items.Add(item);
            }

            if (ServiceResult.IsBad(monitoredItem.Status.Error))
            {
                item.SubItems[8].Text = monitoredItem.Status.Error.StatusCode.ToString();
            }
            return item;
        }

        /// <summary>
        /// Changes the deadband for the currently selected monitored items.
        /// </summary>
        private void Monitoring_Deadband_Click(object sender, EventArgs e)
        {
            try
            {
                // check if operation is currently allowed.
                if (UaClient.m_session == null || UaClient.m_subscription == null || MonitoredItemsLV.SelectedItems.Count == 0)
                {
                    return;
                }

                // determine the filter being requested.
                DataChangeFilter filter = new DataChangeFilter();
                filter.Trigger = DataChangeTrigger.StatusValue;

                if (sender == Monitoring_Deadband_Absolute_5MI)
                {
                    filter.DeadbandType = (uint)DeadbandType.Absolute;
                    filter.DeadbandValue = 5.0;
                }
                else if (sender == Monitoring_Deadband_Absolute_10MI)
                {
                    filter.DeadbandType = (uint)DeadbandType.Absolute;
                    filter.DeadbandValue = 10.0;
                }
                else if (sender == Monitoring_Deadband_Absolute_25MI)
                {
                    filter.DeadbandType = (uint)DeadbandType.Absolute;
                    filter.DeadbandValue = 25.0;
                }
                else if (sender == Monitoring_Deadband_Percentage_1MI)
                {
                    filter.DeadbandType = (uint)DeadbandType.Percent;
                    filter.DeadbandValue = 1.0;
                }
                else if (sender == Monitoring_Deadband_Percentage_5MI)
                {
                    filter.DeadbandType = (uint)DeadbandType.Percent;
                    filter.DeadbandValue = 5.0;
                }
                else if (sender == Monitoring_Deadband_Percentage_10MI)
                {
                    filter.DeadbandType = (uint)DeadbandType.Percent;
                    filter.DeadbandValue = 10.0;
                }
                else
                {
                    filter = null;
                }

                // update the monitoring mode.
                List<MonitoredItem> itemsToChange = new List<MonitoredItem>();

                for (int ii = 0; ii < MonitoredItemsLV.SelectedItems.Count; ii++)
                {
                    MonitoredItem monitoredItem = MonitoredItemsLV.SelectedItems[ii].Tag as MonitoredItem;

                    if (monitoredItem != null)
                    {
                        monitoredItem.Filter = filter;
                        itemsToChange.Add(monitoredItem);
                    }
                }

                // apply the changes to the server.
                UaClient.m_subscription.ApplyChanges();

                // update the display.
                for (int ii = 0; ii < itemsToChange.Count; ii++)
                {
                    ListViewItem item = itemsToChange[ii].Handle as ListViewItem;

                    if (item != null)
                    {
                        item.SubItems[8].Text = String.Empty;

                        if (ServiceResult.IsBad(itemsToChange[ii].Status.Error))
                        {
                            itemsToChange[ii].Filter = null;
                            item.SubItems[8].Text = itemsToChange[ii].Status.Error.StatusCode.ToString();
                        }

                        item.SubItems[4].Text = DeadbandFilterToText(itemsToChange[ii].Status.Filter);
                    }
                }
            }
            catch (Exception exception)
            {
                //ClientUtils.HandleException(this.Text, exception);
            }
        }

        /// <summary>
        /// Handles the Click event of the Monitoring_DeleteMI control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Monitoring_DeleteMI_Click(object sender, EventArgs e)
        {
            try
            {
                // check if operation is currently allowed.
                if (MonitoredItemsLV.SelectedItems.Count == 0)
                {
                    return;
                }

                // collect the items to delete.
                List<ListViewItem> itemsToDelete = new List<ListViewItem>();

                for (int ii = 0; ii < MonitoredItemsLV.SelectedItems.Count; ii++)
                {
                    MonitoredItem monitoredItem = MonitoredItemsLV.SelectedItems[ii].Tag as MonitoredItem;

                    if (monitoredItem != null)
                    {
                        monitoredItem.Notification -= UaClient.m_monitoredItem_Notification;
                        itemsToDelete.Add(MonitoredItemsLV.SelectedItems[ii]);

                        if (UaClient.m_subscription != null)
                        {
                            UaClient.m_subscription.RemoveItem(monitoredItem);
                        }
                    }
                }

                // update the server.
                if (UaClient.m_subscription != null)
                {
                    UaClient.m_subscription.ApplyChanges();

                    // check the status.
                    for (int ii = 0; ii < itemsToDelete.Count; ii++)
                    {
                        MonitoredItem monitoredItem = itemsToDelete[ii].Tag as MonitoredItem;

                        if (ServiceResult.IsBad(monitoredItem.Status.Error))
                        {
                            itemsToDelete[ii].SubItems[8].Text = monitoredItem.Status.Error.StatusCode.ToString();
                            continue;
                        }
                    }
                }

                // remove the items.
                for (int ii = 0; ii < itemsToDelete.Count; ii++)
                {
                    itemsToDelete[ii].Remove();
                }

                MonitoredItemsLV.Columns[0].Width = -2;
                MonitoredItemsLV.Columns[1].Width = -2;
                MonitoredItemsLV.Columns[8].Width = -2;
            }
            catch (Exception exception)
            {
                //ClientUtils.HandleException(this.Text, exception);
            }
        }

        private void Monitoring_WriteMI_Click(object sender, EventArgs e)
        {
            try
            {
                // check if operation is currently allowed.
                if (UaClient.m_session == null || UaClient.m_subscription == null || MonitoredItemsLV.SelectedItems.Count == 0)
                {
                    return;
                }

                MonitoredItem monitoredItem = MonitoredItemsLV.SelectedItems[0].Tag as MonitoredItem;

                if (monitoredItem != null)
                {
                    //TODO
                    new WriteValueDlg().ShowDialog(UaClient.m_session, (NodeId)monitoredItem.ResolvedNodeId, Attributes.Value);
                }
            }
            catch (Exception exception)
            {
                //ClientUtils.HandleException(this.Text, exception);
            }
        }

        /// <summary>
        /// Changes the monitoring mode for the currently selected monitored items.
        /// </summary>
        private void Monitoring_MonitoringMode_Click(object sender, EventArgs e)
        {
            try
            {
                // check if operation is currently allowed.
                if (UaClient.m_session == null || UaClient.m_subscription == null || MonitoredItemsLV.SelectedItems.Count == 0)
                {
                    return;
                }

                // determine the monitoring mode being requested.
                MonitoringMode monitoringMode = MonitoringMode.Disabled;

                if (sender == Monitoring_MonitoringMode_ReportingMI)
                {
                    monitoringMode = MonitoringMode.Reporting;
                }

                if (sender == Monitoring_MonitoringMode_SamplingMI)
                {
                    monitoringMode = MonitoringMode.Sampling;
                }

                // update the monitoring mode.
                List<MonitoredItem> itemsToChange = new List<MonitoredItem>();

                for (int ii = 0; ii < MonitoredItemsLV.SelectedItems.Count; ii++)
                {
                    MonitoredItem monitoredItem = MonitoredItemsLV.SelectedItems[ii].Tag as MonitoredItem;

                    if (monitoredItem != null)
                    {
                        itemsToChange.Add(monitoredItem);
                    }
                }

                // apply the changes to the server.
                UaClient.m_subscription.SetMonitoringMode(monitoringMode, itemsToChange);

                // update the display.
                for (int ii = 0; ii < itemsToChange.Count; ii++)
                {
                    ListViewItem item = itemsToChange[ii].Handle as ListViewItem;

                    if (item != null)
                    {
                        item.SubItems[8].Text = String.Empty;

                        if (ServiceResult.IsBad(itemsToChange[ii].Status.Error))
                        {
                            item.SubItems[8].Text = itemsToChange[ii].Status.Error.StatusCode.ToString();
                        }

                        item.SubItems[2].Text = itemsToChange[ii].Status.MonitoringMode.ToString();
                    }
                }
            }
            catch (Exception exception)
            {
                //ClientUtils.HandleException(this.Text, exception);
            }
        }

        /// <summary>
        /// Changes the sampling interval for the currently selected monitored items.
        /// </summary>
        private void Monitoring_SamplingInterval_Click(object sender, EventArgs e)
        {
            try
            {
                // check if operation is currently allowed.
                if (UaClient.m_session == null || UaClient.m_subscription == null || MonitoredItemsLV.SelectedItems.Count == 0)
                {
                    return;
                }

                // determine the sampling interval being requested.
                double samplingInterval = 0;

                if (sender == Monitoring_SamplingInterval_1000MI)
                {
                    samplingInterval = 1000;
                }
                else if (sender == Monitoring_SamplingInterval_2500MI)
                {
                    samplingInterval = 2500;
                }
                else if (sender == Monitoring_SamplingInterval_5000MI)
                {
                    samplingInterval = 5000;
                }

                // update the monitoring mode.
                List<MonitoredItem> itemsToChange = new List<MonitoredItem>();

                for (int ii = 0; ii < MonitoredItemsLV.SelectedItems.Count; ii++)
                {
                    MonitoredItem monitoredItem = MonitoredItemsLV.SelectedItems[ii].Tag as MonitoredItem;

                    if (monitoredItem != null)
                    {
                        monitoredItem.SamplingInterval = (int)samplingInterval;
                        itemsToChange.Add(monitoredItem);
                    }
                }

                // apply the changes to the server.
                UaClient.m_subscription.ApplyChanges();

                // update the display.
                for (int ii = 0; ii < itemsToChange.Count; ii++)
                {
                    ListViewItem item = itemsToChange[ii].Handle as ListViewItem;

                    if (item != null)
                    {
                        item.SubItems[8].Text = String.Empty;

                        if (ServiceResult.IsBad(itemsToChange[ii].Status.Error))
                        {
                            item.SubItems[8].Text = itemsToChange[ii].Status.Error.StatusCode.ToString();
                        }

                        item.SubItems[3].Text = itemsToChange[ii].Status.SamplingInterval.ToString();
                    }
                }
            }
            catch (Exception exception)
            {
                //ClientUtils.HandleException(this.Text, exception);
            }
        }
        #endregion
        
        /// <summary>
        /// Converts a monitoring filter to text for display.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The deadback formatted as a string.</returns>
        private string DeadbandFilterToText(MonitoringFilter filter)
        {
            DataChangeFilter datachangeFilter = filter as DataChangeFilter;

            if (datachangeFilter != null)
            {
                if (datachangeFilter.DeadbandType == (uint)DeadbandType.Absolute)
                {
                    return Utils.Format("{0:##.##}", datachangeFilter.DeadbandValue);
                }

                if (datachangeFilter.DeadbandType == (uint)DeadbandType.Percent)
                {
                    return Utils.Format("{0:##.##}%", datachangeFilter.DeadbandValue);
                }
            }

            return "None";
        }

        /// <summary>
        /// Ensures the correct node is selected before displaying the context menu.
        /// </summary>
        private void BrowseNodesTV_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
               BrowseNodesTV.SelectedNode = BrowseNodesTV.GetNodeAt(e.X, e.Y);
            }
            catch (Exception exception)
            {
                //ClientUtils.HandleException(this.Text, exception);
            }
        }

        /// <summary>
        /// Updates the display after a node is selected.
        /// </summary>
        private void BrowseNodesTV_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                // get the source for the node.
                ReferenceDescription reference = e.Node.Tag as ReferenceDescription;

                if (reference == null || reference.NodeId.IsAbsolute)
                {
                    return;
                }

                // populate children.
                PopulateBranch((NodeId)reference.NodeId, e.Node.Nodes);
            }
            catch (Exception exception)
            {
                //ClientUtils.HandleException(this.Text, exception);
            }
        }

        /// <summary>
        /// Populates the branch in the tree view.
        /// </summary>
        /// <param name="sourceId">The NodeId of the Node to browse.</param>
        /// <param name="nodes">The node collect to populate.</param>
        private void PopulateBranch(NodeId sourceId, TreeNodeCollection nodes)
        {
            try
            {
                nodes.Clear();

                // find all of the components of the node.
                BrowseDescription nodeToBrowse1 = new BrowseDescription();

                nodeToBrowse1.NodeId = sourceId;
                nodeToBrowse1.BrowseDirection = BrowseDirection.Forward;
                nodeToBrowse1.ReferenceTypeId = ReferenceTypeIds.Aggregates;
                nodeToBrowse1.IncludeSubtypes = true;
                nodeToBrowse1.NodeClassMask = (uint)(NodeClass.Object | NodeClass.Variable);
                nodeToBrowse1.ResultMask = (uint)BrowseResultMask.All;

                // find all nodes organized by the node.
                BrowseDescription nodeToBrowse2 = new BrowseDescription();

                nodeToBrowse2.NodeId = sourceId;
                nodeToBrowse2.BrowseDirection = BrowseDirection.Forward;
                nodeToBrowse2.ReferenceTypeId = ReferenceTypeIds.Organizes;
                nodeToBrowse2.IncludeSubtypes = true;
                nodeToBrowse2.NodeClassMask = (uint)(NodeClass.Object | NodeClass.Variable);
                nodeToBrowse2.ResultMask = (uint)BrowseResultMask.All;

                BrowseDescriptionCollection nodesToBrowse = new BrowseDescriptionCollection();
                nodesToBrowse.Add(nodeToBrowse1);
                nodesToBrowse.Add(nodeToBrowse2);

                // fetch references from the server.
                ReferenceDescriptionCollection references = UaClientUI_utils.Browse(UaClient.m_session, nodesToBrowse, false);

                // process results.
                for (int ii = 0; ii < references.Count; ii++)
                {
                    ReferenceDescription target = references[ii];

                    // add node.
                    TreeNode child = new TreeNode(Utils.Format("{0}", target));
                    child.Tag = target;
                    child.Nodes.Add(new TreeNode());
                    nodes.Add(child);
                }

                // update the attributes display.
                DisplayAttributes(sourceId);
            }
            catch (Exception exception)
            {
                //ClientUtils.HandleException(this.Text, exception);
            }
        }

        /// <summary>
        /// Displays the attributes and properties in the attributes view.
        /// </summary>
        /// <param name="sourceId">The NodeId of the Node to browse.</param>
        private void DisplayAttributes(NodeId sourceId)
        {
            try
            {
                AttributesLV.Items.Clear();

                ReadValueIdCollection nodesToRead = new ReadValueIdCollection();

                // attempt to read all possible attributes.
                for (uint ii = Opc.Ua.Attributes.NodeClass; ii <= Opc.Ua.Attributes.UserExecutable; ii++)
                {
                    ReadValueId nodeToRead = new ReadValueId();
                    nodeToRead.NodeId = sourceId;
                    nodeToRead.AttributeId = ii;
                    nodesToRead.Add(nodeToRead);
                }

                int startOfProperties = nodesToRead.Count;

                // find all of the pror of the node.
                BrowseDescription nodeToBrowse1 = new BrowseDescription();

                nodeToBrowse1.NodeId = sourceId;
                nodeToBrowse1.BrowseDirection = BrowseDirection.Forward;
                nodeToBrowse1.ReferenceTypeId = ReferenceTypeIds.HasProperty;
                nodeToBrowse1.IncludeSubtypes = true;
                nodeToBrowse1.NodeClassMask = 0;
                nodeToBrowse1.ResultMask = (uint)BrowseResultMask.All;

                BrowseDescriptionCollection nodesToBrowse = new BrowseDescriptionCollection();
                nodesToBrowse.Add(nodeToBrowse1);

                // fetch property references from the server.
                ReferenceDescriptionCollection references = UaClientUI_utils.Browse(UaClient.m_session, nodesToBrowse, false);

                if (references == null)
                {
                    return;
                }

                for (int ii = 0; ii < references.Count; ii++)
                {
                    // ignore external references.
                    if (references[ii].NodeId.IsAbsolute)
                    {
                        continue;
                    }

                    ReadValueId nodeToRead = new ReadValueId();
                    nodeToRead.NodeId = (NodeId)references[ii].NodeId;
                    nodeToRead.AttributeId = Opc.Ua.Attributes.Value;
                    nodesToRead.Add(nodeToRead);
                }

                // read all values.
                DataValueCollection results = null;
                DiagnosticInfoCollection diagnosticInfos = null;

                UaClient.m_session.Read(
                    null,
                    0,
                    TimestampsToReturn.Neither,
                    nodesToRead,
                    out results,
                    out diagnosticInfos);

                ClientBase.ValidateResponse(results, nodesToRead);
                ClientBase.ValidateDiagnosticInfos(diagnosticInfos, nodesToRead);

                // process results.
                for (int ii = 0; ii < results.Count; ii++)
                {
                    string name = null;
                    string datatype = null;
                    string value = null;

                    // process attribute value.
                    if (ii < startOfProperties)
                    {
                        // ignore attributes which are invalid for the node.
                        if (results[ii].StatusCode == StatusCodes.BadAttributeIdInvalid)
                        {
                            continue;
                        }

                        // get the name of the attribute.
                        name = Opc.Ua.Attributes.GetBrowseName(nodesToRead[ii].AttributeId);

                        // display any unexpected error.
                        if (StatusCode.IsBad(results[ii].StatusCode))
                        {
                            datatype = Utils.Format("{0}", Opc.Ua.Attributes.GetDataTypeId(nodesToRead[ii].AttributeId));
                            value = Utils.Format("{0}", results[ii].StatusCode);
                        }

                        // display the value.
                        else
                        {
                            TypeInfo typeInfo = TypeInfo.Construct(results[ii].Value);

                            datatype = typeInfo.BuiltInType.ToString();

                            if (typeInfo.ValueRank >= ValueRanks.OneOrMoreDimensions)
                            {
                                datatype += "[]";
                            }

                            value = Utils.Format("{0}", results[ii].Value);
                        }
                    }

                    // process property value.
                    else
                    {
                        // ignore properties which are invalid for the node.
                        if (results[ii].StatusCode == StatusCodes.BadNodeIdUnknown)
                        {
                            continue;
                        }

                        // get the name of the property.
                        name = Utils.Format("{0}", references[ii - startOfProperties]);

                        // display any unexpected error.
                        if (StatusCode.IsBad(results[ii].StatusCode))
                        {
                            datatype = String.Empty;
                            value = Utils.Format("{0}", results[ii].StatusCode);
                        }

                        // display the value.
                        else
                        {
                            TypeInfo typeInfo = TypeInfo.Construct(results[ii].Value);

                            datatype = typeInfo.BuiltInType.ToString();

                            if (typeInfo.ValueRank >= ValueRanks.OneOrMoreDimensions)
                            {
                                datatype += "[]";
                            }

                            value = Utils.Format("{0}", results[ii].Value);
                        }
                    }

                    // add the attribute name/value to the list view.
                    ListViewItem item = new ListViewItem(name);
                    item.SubItems.Add(datatype);
                    item.SubItems.Add(value);
                    AttributesLV.Items.Add(item);
                }

                // adjust width of all columns.
                for (int ii = 0; ii < AttributesLV.Columns.Count; ii++)
                {
                    AttributesLV.Columns[ii].Width = -2;
                }
            }
            catch (Exception exception)
            {
                //ClientUtils.HandleException(this.Text, exception);
            }
        }

        /// <summary>
        /// Fetches the children for a node the first time the node is expanded in the tree view.
        /// </summary>
        private void BrowseNodesTV_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                // check if node has already been expanded once.
                if (e.Node.Nodes.Count != 1 || e.Node.Nodes[0].Text != String.Empty)
                {
                    return;
                }

                // get the source for the node.
                ReferenceDescription reference = e.Node.Tag as ReferenceDescription;

                if (reference == null || reference.NodeId.IsAbsolute)
                {
                    e.Cancel = true;
                    return;
                }

                // populate children.
                PopulateBranch((NodeId)reference.NodeId, e.Node.Nodes);
            }
            catch (Exception exception)
            {
                //ClientUtils.HandleException(this.Text, exception);
            }
        }

        /// <summary>
        /// Updates the display with a new value for a monitored variable. 
        /// </summary>
        public void MonitoredItem_Notification(MonitoredItem monitoredItem, MonitoredItemNotificationEventArgs e)
        {
            if (MonitoredItemsLV != null)
            {
                if (MonitoredItemsLV.InvokeRequired)
                {
                    MonitoredItemsLV.BeginInvoke(new MonitoredItemNotificationEventHandler(MonitoredItem_Notification), monitoredItem, e);
                    return;
                }

                try
                {
                    if (UaClient.m_session == null)
                    {
                        return;
                    }

                    MonitoredItemNotification notification = e.NotificationValue as MonitoredItemNotification;

                    if (notification == null)
                    {
                        return;
                    }

                    ListViewItem item = (ListViewItem)monitoredItem.Handle;

                    item.SubItems[5].Text = Utils.Format("{0}", notification.Value.WrappedValue);
                    item.SubItems[6].Text = Utils.Format("{0}", notification.Value.StatusCode);
                    item.SubItems[7].Text = Utils.Format("{0:HH:mm:ss.fff}", notification.Value.SourceTimestamp.ToLocalTime());
                }
                catch (Exception exception)
                {
                    //ClientUtils.HandleException(this.Text, exception);
                }
            }
        }


    }
}
