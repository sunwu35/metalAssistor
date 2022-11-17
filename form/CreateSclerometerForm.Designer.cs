
namespace metalAssistor.form
{
    partial class CreateSclerometerForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateSclerometerForm));
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.comboBoxDeviceNO = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.comboBoxDevcieMode = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.textBoxManufacturer = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.comboBoxType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.buttonOK = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.comboBoxName = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboBoxBehavior = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.superValidator1 = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.customValidator1 = new DevComponents.DotNetBar.Validator.CustomValidator();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX7
            // 
            this.labelX7.AutoSize = true;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(68, 219);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(68, 18);
            this.labelX7.TabIndex = 60;
            this.labelX7.Text = "仪器编号：";
            // 
            // comboBoxDeviceNO
            // 
            this.comboBoxDeviceNO.DisplayMember = "Text";
            this.comboBoxDeviceNO.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxDeviceNO.FormattingEnabled = true;
            this.comboBoxDeviceNO.ItemHeight = 16;
            this.comboBoxDeviceNO.Location = new System.Drawing.Point(187, 215);
            this.comboBoxDeviceNO.Name = "comboBoxDeviceNO";
            this.comboBoxDeviceNO.Size = new System.Drawing.Size(144, 22);
            this.comboBoxDeviceNO.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxDeviceNO.TabIndex = 59;
            // 
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(68, 179);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(68, 18);
            this.labelX6.TabIndex = 58;
            this.labelX6.Text = "仪器型号：";
            // 
            // comboBoxDevcieMode
            // 
            this.comboBoxDevcieMode.DisplayMember = "Text";
            this.comboBoxDevcieMode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxDevcieMode.FormattingEnabled = true;
            this.comboBoxDevcieMode.ItemHeight = 16;
            this.comboBoxDevcieMode.Location = new System.Drawing.Point(187, 175);
            this.comboBoxDevcieMode.Name = "comboBoxDevcieMode";
            this.comboBoxDevcieMode.Size = new System.Drawing.Size(144, 22);
            this.comboBoxDevcieMode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxDevcieMode.TabIndex = 57;
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(68, 19);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(81, 18);
            this.labelX5.TabIndex = 55;
            this.labelX5.Text = "样品类型名：";
            // 
            // textBoxManufacturer
            // 
            // 
            // 
            // 
            this.textBoxManufacturer.Border.Class = "TextBoxBorder";
            this.textBoxManufacturer.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxManufacturer.Location = new System.Drawing.Point(187, 94);
            this.textBoxManufacturer.Name = "textBoxManufacturer";
            this.textBoxManufacturer.PreventEnterBeep = true;
            this.textBoxManufacturer.Size = new System.Drawing.Size(144, 21);
            this.textBoxManufacturer.TabIndex = 53;
            this.superValidator1.SetValidator1(this.textBoxManufacturer, this.customValidator1);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonX1.Location = new System.Drawing.Point(235, 259);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(104, 34);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 51;
            this.buttonX1.Text = "取消";
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(68, 136);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(68, 18);
            this.labelX4.TabIndex = 50;
            this.labelX4.Text = "性能等级：";
            // 
            // comboBoxType
            // 
            this.comboBoxType.DisplayMember = "Text";
            this.comboBoxType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.ItemHeight = 16;
            this.comboBoxType.Location = new System.Drawing.Point(187, 54);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(144, 22);
            this.comboBoxType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxType.TabIndex = 49;
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(68, 58);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(68, 18);
            this.labelX3.TabIndex = 48;
            this.labelX3.Text = "样品规格：";
            // 
            // buttonOK
            // 
            this.buttonOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonOK.Location = new System.Drawing.Point(56, 259);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(104, 34);
            this.buttonOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonOK.TabIndex = 46;
            this.buttonOK.Text = "确定";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(68, 97);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(68, 18);
            this.labelX1.TabIndex = 45;
            this.labelX1.Text = "样品厂家：";
            // 
            // comboBoxName
            // 
            this.comboBoxName.DisplayMember = "Text";
            this.comboBoxName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxName.FormattingEnabled = true;
            this.comboBoxName.ItemHeight = 16;
            this.comboBoxName.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2});
            this.comboBoxName.Location = new System.Drawing.Point(187, 15);
            this.comboBoxName.Name = "comboBoxName";
            this.comboBoxName.Size = new System.Drawing.Size(144, 22);
            this.comboBoxName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxName.TabIndex = 61;
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "地脚螺栓";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "地脚螺母";
            // 
            // comboBoxBehavior
            // 
            this.comboBoxBehavior.DisplayMember = "Text";
            this.comboBoxBehavior.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxBehavior.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBehavior.FormattingEnabled = true;
            this.comboBoxBehavior.ItemHeight = 16;
            this.comboBoxBehavior.Location = new System.Drawing.Point(187, 132);
            this.comboBoxBehavior.Name = "comboBoxBehavior";
            this.comboBoxBehavior.Size = new System.Drawing.Size(144, 22);
            this.comboBoxBehavior.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxBehavior.TabIndex = 62;
            // 
            // superValidator1
            // 
            this.superValidator1.ContainerControl = this;
            this.superValidator1.ErrorProvider = this.errorProvider1;
            this.superValidator1.Highlighter = this.highlighter1;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider1.Icon")));
            // 
            // highlighter1
            // 
            this.highlighter1.ContainerControl = this;
            // 
            // customValidator1
            // 
            this.customValidator1.ErrorMessage = "Your error message here.";
            this.customValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.customValidator1.ValidateValue += new DevComponents.DotNetBar.Validator.ValidateValueEventHandler(this.customValidator_ValidateValue);
            // 
            // CreateSclerometerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 311);
            this.Controls.Add(this.comboBoxBehavior);
            this.Controls.Add(this.comboBoxName);
            this.Controls.Add(this.labelX7);
            this.Controls.Add(this.comboBoxDeviceNO);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.comboBoxDevcieMode);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.textBoxManufacturer);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labelX1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "CreateSclerometerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "输电线路地脚螺栓、螺母硬度检测";
            this.Load += new System.EventHandler(this.CreateMechannicsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxDeviceNO;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxDevcieMode;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxManufacturer;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxType;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.ButtonX buttonOK;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxName;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxBehavior;
        private DevComponents.DotNetBar.Validator.SuperValidator superValidator1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private DevComponents.DotNetBar.Validator.CustomValidator customValidator1;
    }
}