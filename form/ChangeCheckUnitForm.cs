using DevComponents.DotNetBar.Controls;
using metalAssistor.entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace metalAssistor.form
{
    public partial class ChangeCheckUnitForm : Form
    {

        private CheckUnit unit;
        public ChangeCheckUnitForm()
        {
            InitializeComponent();
        }

        public CheckUnit Unit
        {
            get => unit;
            set
            {
                unit = value;
                textBoxID.Text = value.Id;
                textBoxName.Text = value.Name;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (!superValidator1.Validate()) return;
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("存在空字段", "提示");
                return;
            }
            unit.Name = textBoxName.Text;
            this.DialogResult = DialogResult.OK;
        }
        private void customValidator_ValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            TextBoxX tb = e.ControlToValidate as TextBoxX;
            if (tb != null)
            {
                if (!string.IsNullOrWhiteSpace(tb.Text)) e.IsValid = true;
            }

        }
    }
}
