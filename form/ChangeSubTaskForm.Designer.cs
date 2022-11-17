
namespace metalAssistor.form
{
    partial class ChangeSubTaskForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeSubTaskForm));
            this.textBoxType = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxManufacturer = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.integerInput = new DevComponents.Editors.IntegerInput();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.comboBoxVoltage = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.comboItem5 = new DevComponents.Editors.ComboItem();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.buttonOK = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.textBoxName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.superValidator1 = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.customValidator1 = new DevComponents.DotNetBar.Validator.CustomValidator();
            this.customValidator2 = new DevComponents.DotNetBar.Validator.CustomValidator();
            this.customValidator3 = new DevComponents.DotNetBar.Validator.CustomValidator();
            ((System.ComponentModel.ISupportInitialize)(this.integerInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxType
            // 
            // 
            // 
            // 
            this.textBoxType.Border.Class = "TextBoxBorder";
            this.textBoxType.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxType.Location = new System.Drawing.Point(190, 119);
            this.textBoxType.Name = "textBoxType";
            this.textBoxType.PreventEnterBeep = true;
            this.textBoxType.Size = new System.Drawing.Size(144, 21);
            this.textBoxType.TabIndex = 48;
            this.superValidator1.SetValidator1(this.textBoxType, this.customValidator2);
            // 
            // textBoxManufacturer
            // 
            // 
            // 
            // 
            this.textBoxManufacturer.Border.Class = "TextBoxBorder";
            this.textBoxManufacturer.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxManufacturer.Location = new System.Drawing.Point(190, 76);
            this.textBoxManufacturer.Name = "textBoxManufacturer";
            this.textBoxManufacturer.PreventEnterBeep = true;
            this.textBoxManufacturer.Size = new System.Drawing.Size(144, 21);
            this.textBoxManufacturer.TabIndex = 47;
            this.superValidator1.SetValidator1(this.textBoxManufacturer, this.customValidator1);
            // 
            // integerInput
            // 
            // 
            // 
            // 
            this.integerInput.BackgroundStyle.Class = "DateTimeInputBackground";
            this.integerInput.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.integerInput.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.integerInput.Location = new System.Drawing.Point(190, 204);
            this.integerInput.MinValue = 1;
            this.integerInput.Name = "integerInput";
            this.integerInput.ShowUpDown = true;
            this.integerInput.Size = new System.Drawing.Size(144, 21);
            this.integerInput.TabIndex = 46;
            this.integerInput.Value = 1;
            this.integerInput.WatermarkText = "满足上面3个条件的数量";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonX1.Location = new System.Drawing.Point(235, 249);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(104, 34);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 45;
            this.buttonX1.Text = "取消";
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(69, 39);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(68, 18);
            this.labelX4.TabIndex = 44;
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
            this.comboBoxVoltage.Location = new System.Drawing.Point(190, 36);
            this.comboBoxVoltage.Name = "comboBoxVoltage";
            this.comboBoxVoltage.Size = new System.Drawing.Size(144, 22);
            this.comboBoxVoltage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxVoltage.TabIndex = 43;
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
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(69, 122);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(99, 18);
            this.labelX3.TabIndex = 42;
            this.labelX3.Text = "样品型号/规格：";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(69, 207);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(68, 18);
            this.labelX2.TabIndex = 41;
            this.labelX2.Text = "设备数量：";
            // 
            // buttonOK
            // 
            this.buttonOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonOK.Location = new System.Drawing.Point(56, 249);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(104, 34);
            this.buttonOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonOK.TabIndex = 40;
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
            this.labelX1.Location = new System.Drawing.Point(69, 79);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(68, 18);
            this.labelX1.TabIndex = 39;
            this.labelX1.Text = "样品厂家：";
            // 
            // textBoxName
            // 
            // 
            // 
            // 
            this.textBoxName.Border.Class = "TextBoxBorder";
            this.textBoxName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxName.Location = new System.Drawing.Point(190, 161);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.PreventEnterBeep = true;
            this.textBoxName.Size = new System.Drawing.Size(144, 21);
            this.textBoxName.TabIndex = 50;
            this.superValidator1.SetValidator1(this.textBoxName, this.customValidator3);
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(69, 164);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(81, 18);
            this.labelX5.TabIndex = 49;
            this.labelX5.Text = "样品类型名：";
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
            // customValidator2
            // 
            this.customValidator2.ErrorMessage = "Your error message here.";
            this.customValidator2.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.customValidator2.ValidateValue += new DevComponents.DotNetBar.Validator.ValidateValueEventHandler(this.customValidator_ValidateValue);
            // 
            // customValidator3
            // 
            this.customValidator3.ErrorMessage = "Your error message here.";
            this.customValidator3.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.customValidator3.ValidateValue += new DevComponents.DotNetBar.Validator.ValidateValueEventHandler(this.customValidator_ValidateValue);
            // 
            // ChangeSubTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 301);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.textBoxType);
            this.Controls.Add(this.textBoxManufacturer);
            this.Controls.Add(this.integerInput);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.comboBoxVoltage);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labelX1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "ChangeSubTaskForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ChangeSubTaskForm";
            ((System.ComponentModel.ISupportInitialize)(this.integerInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX textBoxType;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxManufacturer;
        private DevComponents.Editors.IntegerInput integerInput;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxVoltage;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.ComboItem comboItem4;
        private DevComponents.Editors.ComboItem comboItem5;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.ButtonX buttonOK;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxName;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Validator.SuperValidator superValidator1;
        private DevComponents.DotNetBar.Validator.CustomValidator customValidator3;
        private DevComponents.DotNetBar.Validator.CustomValidator customValidator1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private DevComponents.DotNetBar.Validator.CustomValidator customValidator2;
    }
}