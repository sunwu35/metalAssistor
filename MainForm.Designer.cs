
namespace metalAssistor
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelNav = new System.Windows.Forms.Panel();
            this.buttonHelp = new DevComponents.DotNetBar.ButtonX();
            this.buttonInfo = new DevComponents.DotNetBar.ButtonX();
            this.buttonCreatTask = new DevComponents.DotNetBar.ButtonX();
            this.advTreeXml = new DevComponents.AdvTree.AdvTree();
            this.nodeConnector2 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle2 = new DevComponents.DotNetBar.ElementStyle();
            this.grid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonUpload = new DevComponents.DotNetBar.ButtonX();
            this.labelSelectedNode = new DevComponents.DotNetBar.LabelX();
            this.panelNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advTreeXml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelNav
            // 
            this.panelNav.BackColor = System.Drawing.Color.White;
            this.panelNav.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelNav.Controls.Add(this.buttonHelp);
            this.panelNav.Controls.Add(this.buttonInfo);
            this.panelNav.Controls.Add(this.buttonCreatTask);
            this.panelNav.Controls.Add(this.advTreeXml);
            this.panelNav.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelNav.Location = new System.Drawing.Point(0, 0);
            this.panelNav.Name = "panelNav";
            this.panelNav.Size = new System.Drawing.Size(362, 478);
            this.panelNav.TabIndex = 83;
            // 
            // buttonHelp
            // 
            this.buttonHelp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonHelp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonHelp.Location = new System.Drawing.Point(297, 3);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(53, 25);
            this.buttonHelp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonHelp.TabIndex = 87;
            this.buttonHelp.Text = "帮助";
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // buttonInfo
            // 
            this.buttonInfo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonInfo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonInfo.Location = new System.Drawing.Point(238, 3);
            this.buttonInfo.Name = "buttonInfo";
            this.buttonInfo.Size = new System.Drawing.Size(53, 25);
            this.buttonInfo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonInfo.TabIndex = 89;
            this.buttonInfo.Text = "信息";
            this.buttonInfo.Click += new System.EventHandler(this.buttonInfo_Click);
            // 
            // buttonCreatTask
            // 
            this.buttonCreatTask.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonCreatTask.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonCreatTask.Location = new System.Drawing.Point(6, 3);
            this.buttonCreatTask.Name = "buttonCreatTask";
            this.buttonCreatTask.Size = new System.Drawing.Size(53, 25);
            this.buttonCreatTask.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonCreatTask.TabIndex = 86;
            this.buttonCreatTask.Text = "刷新";
            this.buttonCreatTask.Click += new System.EventHandler(this.buttonCreatTask_Click);
            // 
            // advTreeXml
            // 
            this.advTreeXml.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTreeXml.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.advTreeXml.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advTreeXml.BackgroundStyle.Class = "TreeBorderKey";
            this.advTreeXml.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTreeXml.DragDropEnabled = false;
            this.advTreeXml.Location = new System.Drawing.Point(3, 31);
            this.advTreeXml.MultiSelect = true;
            this.advTreeXml.Name = "advTreeXml";
            this.advTreeXml.NodesConnector = this.nodeConnector2;
            this.advTreeXml.NodeStyle = this.elementStyle2;
            this.advTreeXml.PathSeparator = ";";
            this.advTreeXml.Size = new System.Drawing.Size(352, 440);
            this.advTreeXml.Styles.Add(this.elementStyle2);
            this.advTreeXml.TabIndex = 69;
            this.advTreeXml.Text = "advTree1";
            this.advTreeXml.TileGroupLineColor = System.Drawing.Color.Empty;
            this.advTreeXml.NodeClick += new DevComponents.AdvTree.TreeNodeMouseEventHandler(this.advTreeXml_NodeClick);
            this.advTreeXml.NodeDoubleClick += new DevComponents.AdvTree.TreeNodeMouseEventHandler(this.advTreeXml_NodeDoubleClick);
            // 
            // nodeConnector2
            // 
            this.nodeConnector2.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle2
            // 
            this.elementStyle2.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle2.Name = "elementStyle2";
            this.elementStyle2.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // grid
            // 
            this.grid.AllowDrop = true;
            this.grid.AllowUserToResizeRows = false;
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grid.BackgroundColor = System.Drawing.Color.White;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid.DefaultCellStyle = dataGridViewCellStyle2;
            this.grid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.grid.Location = new System.Drawing.Point(365, 33);
            this.grid.Name = "grid";
            this.grid.PaintEnhancedSelection = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grid.RowHeadersWidth = 30;
            this.grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grid.RowTemplate.Height = 23;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(579, 437);
            this.grid.TabIndex = 85;
            this.grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellDoubleClick);
            this.grid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellEndEdit);
            this.grid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_CellFormatting);
            this.grid.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grid_RowHeaderMouseDoubleClick);
            this.grid.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.grid_UserDeletedRow);
            this.grid.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.grid_UserDeletingRow);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipText = "金属上传小工具";
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "金属上传小工具";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(101, 26);
            this.contextMenuStrip.Text = "退出";
            this.contextMenuStrip.Click += new System.EventHandler(this.contextMenuStrip_Click);
            // 
            // toolStripMenuItem
            // 
            this.toolStripMenuItem.Name = "toolStripMenuItem";
            this.toolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem.Text = "退出";
            // 
            // buttonUpload
            // 
            this.buttonUpload.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUpload.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonUpload.Location = new System.Drawing.Point(886, 5);
            this.buttonUpload.Name = "buttonUpload";
            this.buttonUpload.Size = new System.Drawing.Size(53, 25);
            this.buttonUpload.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonUpload.TabIndex = 88;
            this.buttonUpload.Text = "上传";
            this.buttonUpload.Click += new System.EventHandler(this.buttonUpload_Click);
            // 
            // labelSelectedNode
            // 
            this.labelSelectedNode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelSelectedNode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelSelectedNode.Location = new System.Drawing.Point(368, 5);
            this.labelSelectedNode.Name = "labelSelectedNode";
            this.labelSelectedNode.Size = new System.Drawing.Size(512, 23);
            this.labelSelectedNode.TabIndex = 89;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 478);
            this.Controls.Add(this.labelSelectedNode);
            this.Controls.Add(this.buttonUpload);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.panelNav);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "金属上传小工具";
            this.panelNav.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advTreeXml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelNav;
        private DevComponents.AdvTree.AdvTree advTreeXml;
        private DevComponents.AdvTree.NodeConnector nodeConnector2;
        private DevComponents.DotNetBar.ElementStyle elementStyle2;
        private DevComponents.DotNetBar.ButtonX buttonCreatTask;
        private DevComponents.DotNetBar.Controls.DataGridViewX grid;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem;
        private DevComponents.DotNetBar.ButtonX buttonHelp;
        private DevComponents.DotNetBar.ButtonX buttonInfo;
        private DevComponents.DotNetBar.ButtonX buttonUpload;
        private DevComponents.DotNetBar.LabelX labelSelectedNode;
    }
}

