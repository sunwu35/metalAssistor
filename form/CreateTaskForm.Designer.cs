
namespace metalAssistor.form
{
    partial class CreateTaskForm
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.textBoxCompany = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.comboBoxMode = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem6 = new DevComponents.Editors.ComboItem();
            this.comboItem7 = new DevComponents.Editors.ComboItem();
            this.comboItem8 = new DevComponents.Editors.ComboItem();
            this.buttonOK = new DevComponents.DotNetBar.ButtonX();
            this.textBoxStation = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.comboBoxVoltage = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.comboItem5 = new DevComponents.Editors.ComboItem();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(44, 24);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(44, 18);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "公司：";
            // 
            // textBoxCompany
            // 
            // 
            // 
            // 
            this.textBoxCompany.Border.Class = "TextBoxBorder";
            this.textBoxCompany.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxCompany.Location = new System.Drawing.Point(140, 24);
            this.textBoxCompany.Name = "textBoxCompany";
            this.textBoxCompany.PreventEnterBeep = true;
            this.textBoxCompany.Size = new System.Drawing.Size(144, 21);
            this.textBoxCompany.TabIndex = 1;
            this.textBoxCompany.WatermarkText = "xxx电力公司";
            // 
            // comboBoxMode
            // 
            this.comboBoxMode.DisplayMember = "Text";
            this.comboBoxMode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMode.FormattingEnabled = true;
            this.comboBoxMode.ItemHeight = 16;
            this.comboBoxMode.Items.AddRange(new object[] {
            this.comboItem6,
            this.comboItem7,
            this.comboItem8});
            this.comboBoxMode.Location = new System.Drawing.Point(140, 168);
            this.comboBoxMode.Name = "comboBoxMode";
            this.comboBoxMode.Size = new System.Drawing.Size(144, 22);
            this.comboBoxMode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxMode.TabIndex = 2;
            // 
            // comboItem6
            // 
            this.comboItem6.Text = "新建";
            // 
            // comboItem7
            // 
            this.comboItem7.Text = "扩建";
            // 
            // comboItem8
            // 
            this.comboItem8.Text = "改建";
            // 
            // buttonOK
            // 
            this.buttonOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonOK.Location = new System.Drawing.Point(19, 236);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(104, 34);
            this.buttonOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "确定";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // textBoxStation
            // 
            // 
            // 
            // 
            this.textBoxStation.Border.Class = "TextBoxBorder";
            this.textBoxStation.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxStation.Location = new System.Drawing.Point(140, 120);
            this.textBoxStation.Name = "textBoxStation";
            this.textBoxStation.PreventEnterBeep = true;
            this.textBoxStation.Size = new System.Drawing.Size(144, 21);
            this.textBoxStation.TabIndex = 5;
            this.textBoxStation.WatermarkText = "xxx变电站";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(44, 168);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(44, 18);
            this.labelX2.TabIndex = 4;
            this.labelX2.Text = "模式：";
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(44, 120);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(56, 18);
            this.labelX3.TabIndex = 6;
            this.labelX3.Text = "变电站：";
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(44, 72);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(68, 18);
            this.labelX4.TabIndex = 8;
            this.labelX4.Text = "电压等级：";
            // 
            // comboBoxVoltage
            // 
            this.comboBoxVoltage.DisplayMember = "Text";
            this.comboBoxVoltage.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxVoltage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVoltage.FormattingEnabled = true;
            this.comboBoxVoltage.ItemHeight = 16;
            this.comboBoxVoltage.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2,
            this.comboItem3,
            this.comboItem4,
            this.comboItem5});
            this.comboBoxVoltage.Location = new System.Drawing.Point(140, 69);
            this.comboBoxVoltage.Name = "comboBoxVoltage";
            this.comboBoxVoltage.Size = new System.Drawing.Size(144, 22);
            this.comboBoxVoltage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxVoltage.TabIndex = 7;
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "500kV";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "220kV";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "110kV";
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "35kV";
            // 
            // comboItem5
            // 
            this.comboItem5.Text = "10kV";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonX1.Location = new System.Drawing.Point(198, 236);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(104, 34);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 9;
            this.buttonX1.Text = "取消";
            // 
            // CreateTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 287);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.comboBoxVoltage);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.textBoxStation);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.comboBoxMode);
            this.Controls.Add(this.textBoxCompany);
            this.Controls.Add(this.labelX1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "CreateTaskForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "创建主任务";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxCompany;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxMode;
        private DevComponents.DotNetBar.ButtonX buttonOK;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxStation;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxVoltage;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.ComboItem comboItem4;
        private DevComponents.Editors.ComboItem comboItem5;
        private DevComponents.Editors.ComboItem comboItem6;
        private DevComponents.Editors.ComboItem comboItem7;
        private DevComponents.Editors.ComboItem comboItem8;
    }
}