namespace metalAssistor
{
    partial class LoginFormNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginFormNew));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.judianFormLabel1 = new DevComponents.DotNetBar.LabelX();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.textBoxX2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.judianCheckBox1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.roundedButton1 = new DevComponents.DotNetBar.ButtonX();
            this.labelTip = new System.Windows.Forms.Label();
            this.panelEx1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.panelEx3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.judianFormLabel1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.MarkupUsesStyleAlignment = true;
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(284, 38);
            this.panelEx1.Style.BackColor1.Alpha = ((byte)(200));
            this.panelEx1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(183)))), ((int)(((byte)(215)))));
            this.panelEx1.Style.BackColor2.Alpha = ((byte)(200));
            this.panelEx1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(183)))), ((int)(((byte)(215)))));
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.Color = System.Drawing.Color.White;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            this.panelEx1.Text = "用户登录";
            this.panelEx1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.form_MouseDown);
            this.panelEx1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.form_MouseMove);
            this.panelEx1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.form_MouseUp);
            // 
            // judianFormLabel1
            // 
            this.judianFormLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.judianFormLabel1.BackgroundImage = global::metalAssistor.Properties.Resources.cuowu2;
            this.judianFormLabel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            // 
            // 
            // 
            this.judianFormLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.judianFormLabel1.Location = new System.Drawing.Point(253, 7);
            this.judianFormLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.judianFormLabel1.Name = "judianFormLabel1";
            this.judianFormLabel1.Size = new System.Drawing.Size(24, 24);
            this.judianFormLabel1.TabIndex = 0;
            this.judianFormLabel1.Click += new System.EventHandler(this.judianFormLabel1_ButtonClick);
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.textBoxX1);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelEx2.Location = new System.Drawing.Point(34, 68);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(217, 39);
            this.panelEx2.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx2.Style.BackColor2.Color = System.Drawing.Color.White;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.Alpha = ((byte)(200));
            this.panelEx2.Style.BorderColor.Color = System.Drawing.Color.LightGray;
            this.panelEx2.Style.BorderWidth = 2;
            this.panelEx2.Style.CornerDiameter = 4;
            this.panelEx2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.panelEx2.Style.ForeColor.Color = System.Drawing.Color.Black;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 1;
            this.panelEx2.Text = "  用户名：";
            // 
            // textBoxX1
            // 
            // 
            // 
            // 
            this.textBoxX1.Border.BorderColor = System.Drawing.Color.Transparent;
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxX1.Location = new System.Drawing.Point(60, 8);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.Size = new System.Drawing.Size(142, 23);
            this.textBoxX1.TabIndex = 0;
            // 
            // panelEx3
            // 
            this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.textBoxX2);
            this.panelEx3.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelEx3.Location = new System.Drawing.Point(34, 131);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(217, 39);
            this.panelEx3.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx3.Style.BackColor2.Color = System.Drawing.Color.White;
            this.panelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx3.Style.BorderColor.Alpha = ((byte)(200));
            this.panelEx3.Style.BorderColor.Color = System.Drawing.Color.LightGray;
            this.panelEx3.Style.BorderWidth = 2;
            this.panelEx3.Style.CornerDiameter = 4;
            this.panelEx3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.panelEx3.Style.ForeColor.Color = System.Drawing.Color.Black;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 2;
            this.panelEx3.Text = "  密  码：";
            // 
            // textBoxX2
            // 
            // 
            // 
            // 
            this.textBoxX2.Border.BorderColor = System.Drawing.Color.Transparent;
            this.textBoxX2.Border.Class = "TextBoxBorder";
            this.textBoxX2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX2.Location = new System.Drawing.Point(60, 8);
            this.textBoxX2.Name = "textBoxX2";
            this.textBoxX2.Size = new System.Drawing.Size(142, 23);
            this.textBoxX2.TabIndex = 1;
            // 
            // judianCheckBox1
            // 
            // 
            // 
            // 
            this.judianCheckBox1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.judianCheckBox1.Location = new System.Drawing.Point(37, 207);
            this.judianCheckBox1.Name = "judianCheckBox1";
            this.judianCheckBox1.Size = new System.Drawing.Size(77, 15);
            this.judianCheckBox1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.judianCheckBox1.TabIndex = 5;
            this.judianCheckBox1.Text = "记住密码";
            this.judianCheckBox1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(168)))), ((int)(((byte)(181)))));
            // 
            // roundedButton1
            // 
            this.roundedButton1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.roundedButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.roundedButton1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.roundedButton1.Location = new System.Drawing.Point(177, 196);
            this.roundedButton1.Name = "roundedButton1";
            this.roundedButton1.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(15);
            this.roundedButton1.Size = new System.Drawing.Size(74, 36);
            this.roundedButton1.TabIndex = 4;
            this.roundedButton1.Text = "登录";
            this.roundedButton1.Click += new System.EventHandler(this.roundedButton1_Click);
            // 
            // labelTip
            // 
            this.labelTip.AutoSize = true;
            this.labelTip.ForeColor = System.Drawing.Color.Red;
            this.labelTip.Location = new System.Drawing.Point(39, 175);
            this.labelTip.Name = "labelTip";
            this.labelTip.Size = new System.Drawing.Size(113, 12);
            this.labelTip.TabIndex = 15;
            this.labelTip.Text = "用户名或密码错误！";
            this.labelTip.Visible = false;
            // 
            // LoginFormNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(284, 244);
            this.Controls.Add(this.labelTip);
            this.Controls.Add(this.judianCheckBox1);
            this.Controls.Add(this.roundedButton1);
            this.Controls.Add(this.panelEx3);
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.panelEx1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(284, 244);
            this.MinimumSize = new System.Drawing.Size(284, 244);
            this.Name = "LoginFormNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panelEx1.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            this.panelEx3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        private DevComponents.DotNetBar.ButtonX roundedButton1;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX2;
        private DevComponents.DotNetBar.Controls.CheckBoxX judianCheckBox1;
        private DevComponents.DotNetBar.LabelX judianFormLabel1;
        private System.Windows.Forms.Label labelTip;
    }
}