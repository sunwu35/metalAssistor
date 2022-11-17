using DevComponents.AdvTree;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using metalAssistor.entity;
using metalAssistor.form;
using metalAssistor.HttpUtil;
using metalAssistor.server;
using metalAssistor.util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace metalAssistor
{
    public partial class MainForm : Form
    {

        public static MainForm Instance;

        public MainForm(string[] args)
        {
            InitializeComponent();
            Instance = this;
            if (args != null&&args.Length>0&&args[0]=="-s")
            {
                this.ShowInTaskbar = false;
                this.WindowState = FormWindowState.Minimized;
            }
            InitToolTip();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Timer_Tick(null, null);
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Tick;
            timer.Start();
            LoadTaskCache();
            //AddTaskNode(TaskBean.Create());
            GetTask();
        }

        private void GetTask()
        {
            Task.Factory.StartNew(() =>
            {
                List<TaskBean> tbs = WebAPI.GetTask();
                Instance.Invoke((EventHandler)delegate
                {
                    if (tbs != null && tbs.Count > 0)
                    {
                        advTreeXml.Nodes.Clear();
                        selectedNode = null;
                        grid.Rows.Clear();
                        grid.Columns.Clear();
                        labelSelectedNode.Text = "";
                        foreach (TaskBean tb in tbs)
                        {
                            AddTaskNode(tb);
                        }
                    }
                });              
            });
        }

        private void LoadTaskCache()
        {
            List<TaskBean> tbs = new List<TaskBean>() { TaskBean.Create() }; //TaskCache.GetTaskCache();
            if (tbs == null) return;
            foreach(TaskBean tb in tbs)
            {
                AddTaskNode(tb);
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            List<TaskBean> tbs = new List<TaskBean>();
            foreach(Node n in advTreeXml.Nodes)
            {
                tbs.Add(n.Tag as TaskBean);
                TaskCache.SaveSubTaskCache(n.Tag as TaskBean);
            }
            //TaskCache.SaveTaskCache(tbs);
            notifyIcon.Visible = false;
            base.OnClosing(e);
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
        }

        private ContextMenuStrip menuStrip;
        private ContextMenuStrip menuStripTask;
        private ContextMenuStrip menuStripSubTask;
        private ContextMenuStrip menuStripCheckUnit;
        private Node selectedNode;
        private Node selectingNode;
        private ElementStyle nodeDefauleStyle = new ElementStyle();
        private ElementStyle nodeSelectedStyle = new ElementStyle();
        private void InitToolTip()
        {
            nodeSelectedStyle.BackColor = Color.Aquamarine;

            ToolStripMenuItem menuItem;
            //主任务
            menuStrip = new ContextMenuStrip();
            //advTreeXml.ContextMenuStrip = menuStripTask;
            
            menuItem = new ToolStripMenuItem("创建主任务");
            menuItem.Click += CreateTask;
            menuStrip.Items.Add(menuItem);

            //子任务
            menuStripTask = new ContextMenuStrip();
            menuItem = new ToolStripMenuItem("创建隔离开关触头镀银层厚度检测");
            menuItem.Tag = TaskTypeUtil.DisconnectSwitch;
            menuItem.Click += CreateSubTask;
            menuStripTask.Items.Add(menuItem);
            menuItem = new ToolStripMenuItem("创建开关柜触头镀银层厚度检测");
            menuItem.Tag = TaskTypeUtil.SwitchCabinet;
            menuItem.Click += CreateSubTask;
            menuStripTask.Items.Add(menuItem);
            menuItem = new ToolStripMenuItem("创建铜排连接导电接触部位镀银层厚度检测");
            menuItem.Tag = TaskTypeUtil.CopperBar;
            menuItem.Click += CreateSubTask;
            menuStripTask.Items.Add(menuItem);
            menuItem = new ToolStripMenuItem("创建输电线路地脚螺栓、螺母硬度检测");
            menuItem.Tag = TaskTypeUtil.MechanicsBehaviorSclerometer;
            menuItem.Click += CreateSclerometerTask;
            menuStripTask.Items.Add(menuItem);
            menuItem = new ToolStripMenuItem("创建输电线路螺栓楔负载检测");
            menuItem.Tag = TaskTypeUtil.MechanicsBehaviorWedge;
            menuItem.Click += CreateWedgeTask;
            menuStripTask.Items.Add(menuItem);
            menuItem = new ToolStripMenuItem("创建输电线路螺母保证负荷检测");
            menuItem.Tag = TaskTypeUtil.MechanicsBehaviorGuarantee;
            menuItem.Click += CreateGuaranteeTask;
            menuStripTask.Items.Add(menuItem);


            menuStripSubTask = new ContextMenuStrip();
            menuItem = new ToolStripMenuItem("删除");
            menuItem.Click += DelSubTask;
            menuStripSubTask.Items.Add(menuItem);
            menuItem = new ToolStripMenuItem("修改");
            menuItem.Click += ChangeSubTask;
            menuStripSubTask.Items.Add(menuItem);
            menuItem = new ToolStripMenuItem("添加样品");
            menuItem.Click += CreateCheckUnit;
            menuStripSubTask.Items.Add(menuItem);


            menuStripCheckUnit = new ContextMenuStrip();
            menuItem = new ToolStripMenuItem("删除");
            menuItem.Click += DelCheckUnit;
            menuStripCheckUnit.Items.Add(menuItem);
            menuItem = new ToolStripMenuItem("修改");
            menuItem.Click += ChangeCheckUnit;
            menuStripCheckUnit.Items.Add(menuItem);
        }

        private void CheckMenuStripSubTask(TaskBean tb)
        {
            if (tb == null) return;
        }
        private void advTreeXml_NodeClick(object sender, TreeNodeMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            if (e.Node.DataKeyString == "Task")
            {
                CheckMenuStripSubTask(e.Node.Tag as TaskBean);
                menuStripTask.Tag = e.Node;
                menuStripTask.Show(advTreeXml, e.X, e.Y);
            }
            if (e.Node.DataKeyString.StartsWith("SubTask"))
            {
                menuStripSubTask.Tag = e.Node;
                menuStripSubTask.Show(advTreeXml, e.X, e.Y);
            }

            if (e.Node.DataKeyString.StartsWith("Unit"))
            {
                menuStripCheckUnit.Tag = e.Node;
                menuStripCheckUnit.Show(advTreeXml, e.X, e.Y);
            }

        }
        private void CreateTask(object sender, EventArgs e)
        {
            CreateTaskForm form = new CreateTaskForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                AddTaskNode(form.Task);
            }
        }

        private void CreateSubTask(object sender, EventArgs e)
        {
            CreateSubTaskForm form = new CreateSubTaskForm();
            int taskType = (int)(sender as ToolStripMenuItem).Tag;
            Node node = (sender as ToolStripMenuItem).GetCurrentParent().Tag as Node;
            TaskBean tb = node.Tag as TaskBean;
            form.Task = tb;
            form.TaskType = taskType;
            if (form.ShowDialog() == DialogResult.OK)
            {
                AddSubTaskNode(form.SubTask, node);
            }
        }
        private void CreateSclerometerTask(object sender, EventArgs e)
        {
            CreateSclerometerForm form = new CreateSclerometerForm();
            int taskType = (int)(sender as ToolStripMenuItem).Tag;
            Node node = (sender as ToolStripMenuItem).GetCurrentParent().Tag as Node;
            TaskBean tb = node.Tag as TaskBean;
            form.Task = tb;
            form.TaskType = taskType;
            if (form.ShowDialog() == DialogResult.OK)
            {
                AddSubTaskNode(form.SubTask, node);
            }
        }
        private void CreateLoadTask(object sender, EventArgs e)
        {
            CreateGuaranteeTaskForm form = new CreateGuaranteeTaskForm();
            int taskType = (int)(sender as ToolStripMenuItem).Tag;
            Node node = (sender as ToolStripMenuItem).GetCurrentParent().Tag as Node;
            TaskBean tb = node.Tag as TaskBean;
            form.Task = tb;
            form.TaskType = taskType;
            if (form.ShowDialog() == DialogResult.OK)
            {
                AddSubTaskNode(form.SubTask, node);
            }
        }
        private void CreateWedgeTask(object sender, EventArgs e)
        {
            CreateWedgeTaskForm form = new CreateWedgeTaskForm();
            int taskType = (int)(sender as ToolStripMenuItem).Tag;
            Node node = (sender as ToolStripMenuItem).GetCurrentParent().Tag as Node;
            TaskBean tb = node.Tag as TaskBean;
            form.Task = tb;
            form.TaskType = taskType;
            if (form.ShowDialog() == DialogResult.OK)
            {
                AddSubTaskNode(form.SubTask, node);
            }
        }
        private void CreateGuaranteeTask(object sender, EventArgs e)
        {
            CreateGuaranteeTaskForm form = new CreateGuaranteeTaskForm();
            int taskType = (int)(sender as ToolStripMenuItem).Tag;
            Node node = (sender as ToolStripMenuItem).GetCurrentParent().Tag as Node;
            TaskBean tb = node.Tag as TaskBean;
            form.Task = tb;
            form.TaskType = taskType;
            if (form.ShowDialog() == DialogResult.OK)
            {
                AddSubTaskNode(form.SubTask, node);
            }
        }
        private void DelSubTask(object sender, EventArgs e)
        {
            Node node = (sender as ToolStripMenuItem).GetCurrentParent().Tag as Node;
            SubTaskBean sb = node.Tag as SubTaskBean;
            Node taskNode = node.Parent;
            while (taskNode.Parent != null) taskNode = taskNode.Parent;
            TaskBean tb= taskNode.Tag as TaskBean;

            node.Parent.Nodes.Remove(node);
            tb.SubTaskBeans.Remove(sb);
            //if(grid.Tag as SubTaskBean == sb)
            //{
            //    selectedNode = null;
            //    labelSelectedNode.Text = "";
            //    grid.Rows.Clear();
            //}
        }

        private void ChangeSubTask(object sender, EventArgs e)
        {
            Node node = (sender as ToolStripMenuItem).GetCurrentParent().Tag as Node;
            SubTaskBean sb = node.Tag as SubTaskBean;
            Node taskNode = node.Parent;
            while (taskNode.Parent != null) taskNode = taskNode.Parent;
            TaskBean tb = taskNode.Tag as TaskBean;

            if (sb.TaskType == TaskTypeUtil.MechanicsBehaviorSclerometer)
            {
                SclerometerTaskBean mb = sb as SclerometerTaskBean;
                ChangeSclerometerForm from = new ChangeSclerometerForm();
                from.SubTask = mb;
                if (from.ShowDialog() == DialogResult.OK)
                {
                    node.Text = sb.FullName();
                }
            }
            else if (sb.TaskType == TaskTypeUtil.MechanicsBehaviorWedge)
            {
                WedgeTaskBean mb = sb as WedgeTaskBean;
                ChangeWedgeTaskForm from = new ChangeWedgeTaskForm();
                from.SubTask = mb;
                if (from.ShowDialog() == DialogResult.OK)
                {
                    node.Text = sb.FullName();
                }
            }
            else if (sb.TaskType == TaskTypeUtil.MechanicsBehaviorGuarantee)
            {
                GuaranteeTaskBean mb = sb as GuaranteeTaskBean;
                ChangeGuaranteeTaskForm from = new ChangeGuaranteeTaskForm();
                from.SubTask = mb;
                if (from.ShowDialog() == DialogResult.OK)
                {
                    node.Text = sb.FullName();
                }
            }
            else
            {
                ChangeSubTaskForm from = new ChangeSubTaskForm();
                from.SubTask = sb;
                if (from.ShowDialog() == DialogResult.OK)
                {
                    node.Text = sb.FullName();
                }
            }

            if (selectedNode != null)
            {
                CheckUnit ub = selectedNode.Tag as CheckUnit;
                CheckPointGrid(ub, sb);
            }
        }
        private void CreateCheckUnit(object sender, EventArgs e)
        {
            Node node = (sender as ToolStripMenuItem).GetCurrentParent().Tag as Node;
            SubTaskBean sb = node.Tag as SubTaskBean;
            CheckUnit u = sb.AddUnit();

            AddCheckUnitNode(u, node);
        }
        private void DelCheckUnit(object sender, EventArgs e)
        {
            Node node = (sender as ToolStripMenuItem).GetCurrentParent().Tag as Node;
            CheckUnit u = node.Tag as CheckUnit;
            SubTaskBean sb = node.Parent.Tag as SubTaskBean;
            

            node.Parent.Nodes.Remove(node);
            sb.Units.Remove(u);
            if (selectedNode==node)
            {
                selectedNode = null;
                labelSelectedNode.Text = "";
                grid.Rows.Clear();
                grid.Columns.Clear();
            }
        }
        private void ChangeCheckUnit(object sender, EventArgs e)
        {
            Node node = (sender as ToolStripMenuItem).GetCurrentParent().Tag as Node;
            CheckUnit u = node.Tag as CheckUnit;
            SubTaskBean sb = node.Parent.Tag as SubTaskBean;

            ChangeCheckUnitForm from = new ChangeCheckUnitForm();
            from.Unit = u;
            if (from.ShowDialog() == DialogResult.OK)
            {
                node.Text = u.Name;

                if (selectedNode != node) return;
                foreach (DataGridViewColumn c in grid.Columns)
                {
                    if (c.HeaderText == "样品名")
                    {
                        foreach (DataGridViewRow r in grid.Rows)
                        {
                            if (r.Cells[c.Index].Value != null) r.Cells[c.Index].Value = u.Name;
                        }
                        break;
                    }
                }
            }
        }

        private Node TaskInTreeExist(string id)
        {
            foreach(Node node in advTreeXml.Nodes)
            {
                TaskBean tb = node.Tag as TaskBean;
                if (tb != null && tb.TaskId == id) return node;
            }
            return null;
        }
        private Node DisconnSInTreeExist(string id,Node nodeT)
        {
            foreach (Node node in nodeT.Nodes)
            {
                SubTaskBean tb = node.Tag as SubTaskBean;
                if (tb != null && tb.Id == id) return node;
            }
            return null;
        }
        private Node AddTaskNode(TaskBean tb)
        {
            Node n;
            if ((n=TaskInTreeExist(tb.TaskId))==null)
            {
                n = new Node(tb.TaskName);
                n.Tag = tb;
                n.DataKeyString = "Task";
                n.ExpandVisibility = eNodeExpandVisibility.Visible;
                advTreeXml.Nodes.Add(n);
            }
            tb.SubTaskBeans = TaskCache.GetSubTaskCache(tb.TaskId);
            foreach(SubTaskBean dsb in tb.SubTaskBeans)
            {
                AddSubTaskNode(dsb, n);
            }
            return n;
        }

        private Node GetTypeNode(int taskType,Node sNode)
        {
            Node node = null;
            foreach(Node n in sNode.Nodes)
            {
                if (n.DataKeyString == taskType.ToString())
                {
                    node = n;
                    break;
                }
            }
            if (node == null)
            {
                node = new Node();
                node.Text = TaskTypeUtil.GetSubTaskS(taskType);
                node.DataKey = taskType;
                sNode.Nodes.Add(node);
            }
            return node;
        }
        private void ExpandNode(Node node)
        {
            if (node == null) return;
            Node n = node.Parent;
            if (n != null)
            {
                n.Expand();
                ExpandNode(n);
            }
        }

        private void AddSubTaskNode(SubTaskBean dsb,Node node)
        {
            node = GetTypeNode(dsb.TaskType,node);
            if (DisconnSInTreeExist(dsb.Id, node) == null)
            {
                Node n = new Node(dsb.FullName());
                n.Tag = dsb;
                n.DataKey = "SubTask" + dsb.TaskType;
                node.Nodes.Add(n);
                foreach(CheckUnit p in dsb.Units)
                {
                    AddCheckUnitNode(p, n);
                }
            }
        }

        private void AddCheckUnitNode(CheckUnit u, Node node)
        {
            Node n = new Node(u.Name);
            n.Tag = u;
            n.DataKey = "Unit";
            node.Nodes.Add(n);
            ExpandNode(n);
        }


        private void buttonInfo_Click(object sender, EventArgs e)
        {
            InfoBean b = InfoBean.Create();
            StringBuilder sb = new StringBuilder();
            sb.Append("仪器厂家：").AppendLine(b.Manufactor)
                .Append("仪器型号：").AppendLine(b.Type)
                .Append("出厂编号：").AppendLine(b.Serial)
                .Append(" 版 本 号：").Append(b.Version);
            MessageBox.Show(sb.ToString(), "仪器信息");
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            //WebAPI.Login("admin", "admin123");
            string path = Application.StartupPath + "\\conf\\数字化仪器小助手-变压器绕组变形测试仪说明书.docx";
            if (File.Exists(path))
                System.Diagnostics.Process.Start(path);
            else
                MessageBox.Show("未找到说明书");
        }

        #region 拖放
        ////可以更改鼠标图案，需要鼠标图案文件
        //private void listBoxAdv1_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        //{
        //    e.UseDefaultCursors = true;
        //}

        ////启动拖动
        //private void listBoxAdv1_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (e.Button != MouseButtons.None)
        //    {
        //        listBoxAdv1.DoDragDrop(listBoxAdv1.SelectedItem, DragDropEffects.All);
        //    }
        //    else
        //    {
        //        var item = listBoxAdv1.HitTest(e.X, e.Y);
        //        if (item != null)
        //            (item as ListBoxItem).IsSelected = true;
        //    }
        //}

        ////离开被拖动控件区
        //private void listBoxAdv1_DragLeave(object sender, EventArgs e)
        //{

        //}

        ////拖动完成
        //private void listBoxAdv2_DragDrop(object sender, DragEventArgs e)
        //{
        //    listBoxAdv2.Items.Add(e.Data);
        //}

        ////进入拖放目标区
        //private void listBoxAdv2_DragEnter(object sender, DragEventArgs e)
        //{
        //    e.Effect = DragDropEffects.Link;
        //}


        ////拖放目标区内移动
        //private void listBoxAdv2_DragOver(object sender, DragEventArgs e)
        //{
        //}
        #endregion
        #region 任务栏
        private FormWindowState historyWindowState = FormWindowState.Normal;
        private void contextMenuStrip_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            //if (WindowState == FormWindowState.Minimized)
            //{
            //    this.ShowInTaskbar = false;
            //    this.Hide();
            //}
            //else
            //{
            //    historyWindowState = WindowState;
            //    this.ShowInTaskbar = true;
            //}
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Visible = true;
            if (this.WindowState != historyWindowState)
                this.WindowState = historyWindowState;
            this.Activate();
        }
        #endregion

        private void buttonCreatTask_Click(object sender, EventArgs e)
        {
            //CreateTask(sender, e);
            GetTask();
        }

        private void advTreeXml_NodeDoubleClick(object sender, TreeNodeMouseEventArgs e)
        {
            //if (e.Node.DataKeyString.StartsWith("SubTask"))
            //{
            //    if (selectedNode != null)
            //    {
            //        selectedNode.Style = nodeDefauleStyle;
            //        selectedNode.StyleSelected = nodeDefauleStyle;
            //    }
            //    selectedNode = e.Node;
            //    selectedNode.Style = nodeSelectedStyle;
            //    selectedNode.StyleSelected = nodeDefauleStyle;
            //    SubTaskBean b = e.Node.Tag as SubTaskBean;
            //    try
            //    {
            //        CheckUnitGrid(b);
            //    }
            //    catch { }
            //}

            if (e.Node.DataKeyString.StartsWith("Unit"))
            {
                if (selectedNode != null)
                {
                    selectedNode.Style = nodeDefauleStyle;
                    selectedNode.StyleSelected = nodeDefauleStyle;
                }
                selectedNode = e.Node;
                selectedNode.Style = nodeSelectedStyle;
                selectedNode.StyleSelected = nodeDefauleStyle;
                CheckUnit ub = e.Node.Tag as CheckUnit;
                SubTaskBean sb = e.Node.Parent.Tag as SubTaskBean;
                CheckPointGrid(ub,sb);
            }
        }

        private DataGridViewColumn GetColumn(string text,bool onlyRead=true,string tag="")
        {
            DataGridViewColumn column = new DataGridViewTextBoxColumn
            {
                HeaderText = text,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                ReadOnly = onlyRead,
                Tag=tag
            };
            return column;
        }
        private DataGridViewColumn GetMaskedColumn(string text)
        {
            DataGridViewMaskedTextBoxAdvColumn column = new DataGridViewMaskedTextBoxAdvColumn
            {
                HeaderText = text,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                ReadOnly = false
            };
            column.ButtonClear.Visible = true;
            column.ButtonCustom.Visible = true;
            return column;
        }
        private DataGridViewColumn GetNumberColumn(string text)
        {
            DataGridViewDoubleInputColumn column = new DataGridViewDoubleInputColumn
            {
                HeaderText = text,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                ReadOnly = false,
                ShowUpDown = true,
                MinValue = 0
            };
            return column;
        }
        private DataGridViewColumn GetCombBoxColumn(string text,object[] items)
        {
            DataGridViewComboBoxExColumn column = new DataGridViewComboBoxExColumn
            {
                HeaderText = text,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                ReadOnly = false,
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                DrawMode=DrawMode.OwnerDrawFixed
            };
            column.Items.AddRange(items);
            column.DropDownStyle = ComboBoxStyle.DropDownList;
            int max = 0;
            Graphics g = CreateGraphics();
            foreach(var item in items)
            {
                SizeF s = g.MeasureString(item.ToString(), grid.DefaultCellStyle.Font);
                if (max < s.Width) max = (int)s.Width;
            }
            column.MinimumWidth = max;
            return column;
        }
        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null)
                return;

            if (e.Value is float)
            {
                float v = (float)e.Value;
                if (float.IsNaN(v))e.Value = "待测";
            }

            DataGridViewColumn c = grid.Columns[e.ColumnIndex];
            if (c.Tag != null && c.Tag.ToString() == "Time" && e.Value != null)
            {
                try
                {
                    e.Value = DateTime.ParseExact(e.Value.ToString(), "yyyyMMddHHmmss", CultureInfo.CurrentCulture).ToString("yyyy/MM/dd HH:mm");
                }
                catch { }
            }
        }
        private void CheckUnitGrid(SubTaskBean b)
        {
            labelSelectedNode.Text = TaskTypeUtil.GetSubTaskS(b.TaskType)+"：" + b.Voltage + " " + b.Manufacturer + " " + b.Type+"";
            labelSelectedNode.Tag = b.TaskType;
            grid.Rows.Clear();
            grid.Columns.Clear();

            grid.Tag = b;

            grid.Columns.Add(GetColumn("样品名",false));
            grid.Columns.Add(GetColumn("电压等级"));
            grid.Columns.Add(GetColumn("厂家"));
            grid.Columns.Add(GetColumn("型号"));
            if (b.Units[0].Points == null) b.Units.Clear();
            int count = b.Units.Count > 0 ? b.Units[0].Points.Count : 5;
            for(int i = 0; i < count; i++)
            {
                grid.Columns.Add(GetColumn("检测点"+i));
            }


            foreach (CheckUnit u in b.Units)
            {
                int index = grid.Rows.Add();
                grid.Rows[index].Tag = u;
                int i = 0;
                grid.Rows[index].Cells[i++].Value = u.Name;
                grid.Rows[index].Cells[i++].Value = b.Voltage;
                grid.Rows[index].Cells[i++].Value = b.Manufacturer;
                grid.Rows[index].Cells[i++].Value = b.Type;
                int id = 0;
                foreach (var point in u.Points)
                {
                    grid.Rows[index].Cells[i].Tag = point;
                    grid.Rows[index].Cells[i++].Value = point.Value;
                }
            }

        }

        private void CheckPointGrid(CheckUnit ub,SubTaskBean sb)
        {
            try
            {
                labelSelectedNode.Text = TaskTypeUtil.GetSubTaskS(sb.TaskType) + "：" + sb.FullName() + "—" + ub.Name;
                labelSelectedNode.Tag = sb.TaskType;
                grid.Rows.Clear();
                grid.Columns.Clear();
                grid.Tag = ub;

                if (sb is SclerometerTaskBean)
                {
                    CheckPointGrid(ub, sb as SclerometerTaskBean);
                    return;
                }
                if (sb is WedgeTaskBean)
                {
                    CheckPointGrid(ub, sb as WedgeTaskBean);
                    return;
                }

                if (sb is GuaranteeTaskBean)
                {
                    CheckPointGrid(ub, sb as GuaranteeTaskBean);
                    return;
                }
                grid.AllowUserToAddRows = true;
                grid.AllowUserToDeleteRows = true;
                grid.Columns.Add(GetColumn("样品名"));
                grid.Columns.Add(GetColumn("电压等级"));
                grid.Columns.Add(GetColumn("厂家"));
                grid.Columns.Add(GetColumn("型号"));
                grid.Columns.Add(GetColumn("测点名", false));
                grid.Columns.Add(GetColumn("检测时间", tag: "Time"));
                grid.Columns.Add(GetColumn("镀银厚度(μm)"));

                foreach (CheckPoint p in ub.Points)
                {
                    CheckPointGridRow(ub, sb, p);
                }
            }
            catch { }
        }

        private void CheckPointGrid(CheckUnit ub, SclerometerTaskBean mb)
        {
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.Columns.Add(GetColumn("样品名"));
            grid.Columns.Add(GetColumn("厂家"));
            grid.Columns.Add(GetColumn("规格"));
            grid.Columns.Add(GetColumn("性能等级"));
            grid.Columns.Add(GetColumn("检测时间", tag: "Time"));
            grid.Columns.Add(GetColumn("硬度HV"));

            foreach (CheckPoint p in ub.Points)
            {
                CheckPointGridRow(ub, mb, p);
            }
        }
        private void CheckPointGrid(CheckUnit ub, WedgeTaskBean mb)
        {
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.Columns.Add(GetColumn("样品名"));
            grid.Columns.Add(GetColumn("厂家"));
            grid.Columns.Add(GetColumn("规格"));
            grid.Columns.Add(GetColumn("性能等级"));
            grid.Columns.Add(GetColumn("最小拉力载荷(kN)"));
            grid.Columns.Add(GetColumn("最大拉力试验力(kN)"));
            grid.Columns.Add(GetColumn("检测时间", tag: "Time"));
            grid.Columns.Add(GetCombBoxColumn("断裂部位",TaskTypeUtil.Breaking()));
            grid.Columns.Add(GetNumberColumn("楔垫角度(°)"));
            grid.Columns.Add(GetNumberColumn("楔垫孔径(mm)"));

            foreach (CheckPoint p in ub.Points)
            {
                CheckPointGridRow(ub as WedgeUnit, mb, p as WedgePoint);
            }
        }
        private void CheckPointGrid(CheckUnit ub, GuaranteeTaskBean mb)
        {
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.Columns.Add(GetColumn("样品名"));
            grid.Columns.Add(GetColumn("厂家"));
            grid.Columns.Add(GetColumn("规格"));
            grid.Columns.Add(GetColumn("性能等级"));
            grid.Columns.Add(GetColumn("保载时间(s)"));
            grid.Columns.Add(GetColumn("保证载荷(N)"));
            grid.Columns.Add(GetColumn("检测时间", tag: "Time"));
            grid.Columns.Add(GetCombBoxColumn("拉伸情况", TaskTypeUtil.Elongating()));
            grid.Columns.Add(GetCombBoxColumn("卸载情况", TaskTypeUtil.AfterLoad()));

            foreach (CheckPoint p in ub.Points)
            {
                CheckPointGridRow(ub as GuaranteeUnit, mb, p as GuaranteePoint);
            }
        }
        private void CheckPointGridRow(CheckUnit ub, SubTaskBean sb, CheckPoint p)
        {
            int index = grid.Rows.Add();
            grid.Rows[index].Tag = p;
            int i = 0;
            grid.Rows[index].Cells[i++].Value = ub.Name;
            grid.Rows[index].Cells[i++].Value = sb.Voltage;
            grid.Rows[index].Cells[i++].Value = sb.Manufacturer;
            grid.Rows[index].Cells[i++].Value = sb.Type;
            grid.Rows[index].Cells[i++].Value = p.Name;
            grid.Rows[index].Cells[i++].Value = p.Time;

            grid.Rows[index].Cells[i].Tag = p;
            grid.Rows[index].Cells[i++].Value = p.Value;
        }

        private void CheckPointGridRow(CheckUnit ub, SclerometerTaskBean mb, CheckPoint p)
        {
            int index = grid.Rows.Add();
            grid.Rows[index].Tag = p;
            int i = 0;
            grid.Rows[index].Cells[i++].Value = ub.Name;
            grid.Rows[index].Cells[i++].Value = mb.Manufacturer;
            grid.Rows[index].Cells[i++].Value = mb.Type;
            grid.Rows[index].Cells[i++].Value = mb.Behavior;
            grid.Rows[index].Cells[i++].Value = p.Time;

            grid.Rows[index].Cells[i].Tag = p;
            grid.Rows[index].Cells[i++].Value = p.Value;
        }

        private void CheckPointGridRow(WedgeUnit ub, WedgeTaskBean mb, WedgePoint p)
        {
            int index = grid.Rows.Add();
            grid.Rows[index].Tag = p;
            int i = 0;
            grid.Rows[index].Cells[i++].Value = ub.Name;
            grid.Rows[index].Cells[i++].Value = mb.Manufacturer;
            grid.Rows[index].Cells[i++].Value = mb.Type;
            grid.Rows[index].Cells[i++].Value = mb.Behavior;
            grid.Rows[index].Cells[i++].Value = mb.MinPullLoad;
            grid.Rows[index].Cells[i++].Value = mb.MaxPullLoad;
            grid.Rows[index].Cells[i++].Value = p.Time;

            grid.Rows[index].Cells[i++].Value = p.Bareaking;
            grid.Rows[index].Cells[i++].Value = p.Angle;
            grid.Rows[index].Cells[i++].Value = p.Aperture;
        }

        private void CheckPointGridRow(GuaranteeUnit ub, GuaranteeTaskBean mb, GuaranteePoint p)
        {
            int index = grid.Rows.Add();
            grid.Rows[index].Tag = p;
            int i = 0;
            grid.Rows[index].Cells[i++].Value = ub.Name;
            grid.Rows[index].Cells[i++].Value = mb.Manufacturer;
            grid.Rows[index].Cells[i++].Value = mb.Type;
            grid.Rows[index].Cells[i++].Value = mb.Behavior;
            grid.Rows[index].Cells[i++].Value = mb.LoadTime;
            grid.Rows[index].Cells[i++].Value = mb.ProofLoad;
            grid.Rows[index].Cells[i++].Value = p.Time;

            grid.Rows[index].Cells[i++].Value = p.Elongating;
            grid.Rows[index].Cells[i++].Value = p.AfterLoad;
        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            DataGridViewRow r = grid.Rows[e.RowIndex];
            DataGridViewCell c = r.Cells[e.ColumnIndex];
            //if (c.Value is float && float.IsNaN((float)c.Value))
            if (c.Tag is CheckPoint)
            {                       
                DataGridViewCell cT = r.Cells[e.ColumnIndex - 1];
                int taskType = (int)labelSelectedNode.Tag;

                if (taskType == TaskTypeUtil.MechanicsBehaviorSclerometer)
                {
                    MechanicsReadData(c, cT);
                }
                else
                {
                    FilmReadData(c, cT);
                }
            }
        }

        private void FilmReadData(DataGridViewCell c, DataGridViewCell cT)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;//该值确定是否可以选择多个文件
            dialog.Title = "请选择文件";
            dialog.Filter = "文件(*.docx;*.doc;*.xlsx;*.xls)|*.docx;*.doc;*.xlsx;*.xls";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FilmBean fb = null;
                if (dialog.FileName.EndsWith(".docx") || dialog.FileName.EndsWith(".doc"))
                    fb = WordUtil.ReadFilm(dialog.FileName);
                else if (dialog.FileName.EndsWith(".xlsx") || dialog.FileName.EndsWith(".xls"))
                    fb = ExcelUtil.ReadFilm(dialog.FileName);
                if (fb == null)
                {
                    MessageBox.Show("文件解析失败");
                    return;
                }
                c.Value = fb.Mean;
                cT.Value = fb.Time.ToString("yyyyMMddHHmmss");
                CheckPoint p = c.Tag as CheckPoint;
                p.Value = fb.Mean;
                p.Time = fb.Time.ToString("yyyyMMddHHmmss");
            }
        }

        private void MechanicsReadData(DataGridViewCell c, DataGridViewCell cT)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;//该值确定是否可以选择多个文件
            dialog.Title = "请选择文件";
            dialog.Filter = "文件(*.docx;*.doc)|*.docx;*.doc";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SclerometerBean fb = WordUtil.ReadSclerometer(dialog.FileName);;
                if (fb == null)
                {
                    MessageBox.Show("文件解析失败");
                    return;
                }
                c.Value = fb.Avg;
                cT.Value = fb.TestTime.ToString("yyyyMMddHHmmss");
                CheckPoint p = c.Tag as CheckPoint;
                p.Value = fb.Avg;
                p.Time = fb.TestTime.ToString("yyyyMMddHHmmss");
            }
        }

        private void buttonUpload_Click(object sender, EventArgs e)
        {
            if (selectedNode == null) return;
            CheckUnit u = selectedNode.Tag as CheckUnit;
            SubTaskBean sb = selectedNode.Parent.Tag as SubTaskBean;
            Node taskNode = selectedNode.Parent;
            while (taskNode.Parent != null) taskNode = taskNode.Parent;
            TaskBean tb = taskNode.Tag as TaskBean;

            if (!sb.IsStandard(u))
            {
                if (MessageBox.Show("存在测点不达标，是否上传？", "提示",MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    return;
            }


            SubTaskBean sbTemp = sb.Clone();
            sbTemp.Units.Clear();
            sbTemp.Units.Add(u);
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("taskId", tb.TaskId);
            d.Add("taskName", tb.TaskName);
            d.Add("createTime", tb.CreateTime);
            d.Add("taskType", sb.TaskType);
            d.Add("taskDetailData", new SubTaskBean[] { sbTemp });
            ResultMode r = WebAPI.UploadData(d);
            if(r.Code=="200")
            {
                //dsb.IsUpload = true;
                MessageBox.Show("上传成功", "提示");
            }
            else
            {
                MessageBox.Show(r.Msg,"后台提示");
            }
        }

        private void grid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.RowIndex<grid.Rows.Count-1)
            //    return;
            //SubTaskBean b = grid.Tag as SubTaskBean;
            //CheckUnit u = b.AddUnit();

            //int index = grid.Rows.Add();
            //int i = 0;
            //grid.Rows[index].Tag = u;
            //grid.Rows[index].Cells[i++].Value = u.Name;
            //grid.Rows[index].Cells[i++].Value = b.Voltage;
            //grid.Rows[index].Cells[i++].Value = b.Manufacturer;
            //grid.Rows[index].Cells[i++].Value = b.Type;
            //int id = 0;
            //foreach (var item in u.Points)
            //{
            //    grid.Rows[index].Cells[i].Tag = item;
            //    grid.Rows[index].Cells[i++].Value = item.Value;
            //}
            if (!grid.AllowUserToAddRows) return;
            if (e.RowIndex < grid.Rows.Count - 1)return;
            SubTaskBean sb = selectedNode.Parent.Tag as SubTaskBean;
            CheckUnit ub = grid.Tag as CheckUnit;
            CheckPoint p = ub.AddPoint();

            CheckPointGridRow(ub, sb, p); 
        }

        private void grid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (grid.Rows.Count <= 2)
            {
                e.Cancel = true;
            }
        }

        private void grid_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            SubTaskBean sb = selectedNode.Parent.Tag as SubTaskBean;
            CheckUnit ub = grid.Tag as CheckUnit;
            CheckPoint p = e.Row.Tag as CheckPoint;
            ub.Points.Remove(p);

            //foreach(DataGridViewRow row in grid.Rows)
            //{
            //    if(row.Cells[0].Value!=null)row.Cells[0].Value = row.Index;
            //}
        }


        private void grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 0)
            //{
            //    CheckUnit u = grid.Rows[e.RowIndex].Tag as CheckUnit;
            //    u.Name = grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            //}
            if (grid.Columns[e.ColumnIndex].HeaderText == "测点名")
            {
                CheckPoint u = grid.Rows[e.RowIndex].Tag as CheckPoint;
                u.Name = grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }

            if(grid.Rows[e.RowIndex].Tag is WedgePoint)
            {
                WedgePoint p = grid.Rows[e.RowIndex].Tag as WedgePoint;
                p.Bareaking = (string)grid.Rows[e.RowIndex].Cells[7].Value;
                p.Angle = float.Parse(grid.Rows[e.RowIndex].Cells[8].Value.ToString());
                p.Aperture = float.Parse(grid.Rows[e.RowIndex].Cells[9].Value.ToString());
                if (string.IsNullOrWhiteSpace(p.Time))
                {
                    p.Time = DateTime.Now.ToString("yyyyMMddHHmmss");
                    grid.Rows[e.RowIndex].Cells[6].Value = p.Time;
                }
            }

            if (grid.Rows[e.RowIndex].Tag is GuaranteePoint)
            {
                GuaranteePoint p = grid.Rows[e.RowIndex].Tag as GuaranteePoint;
                p.Elongating = (string)grid.Rows[e.RowIndex].Cells[7].Value;
                p.AfterLoad = (string)grid.Rows[e.RowIndex].Cells[8].Value;
                if (string.IsNullOrWhiteSpace(p.Time))
                {
                    p.Time = DateTime.Now.ToString("yyyyMMddHHmmss");
                    grid.Rows[e.RowIndex].Cells[6].Value = p.Time;
                }
            }
        }
    }
}   
