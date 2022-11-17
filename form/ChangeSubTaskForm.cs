using DevComponents.DotNetBar.Controls;
using metalAssistor.entity;
using metalAssistor.util;
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
    public partial class ChangeSubTaskForm : Form
    {
        public ChangeSubTaskForm()
        {
            InitializeComponent();
        }

        private SubTaskBean subTaskBean = new SubTaskBean();

        public SubTaskBean SubTask
        {
            get => subTaskBean;
            set
            {
                subTaskBean = value;
                this.Text = TaskTypeUtil.GetSubTaskS(value.TaskType)+"-修改";
                comboBoxVoltage.Text = subTaskBean.Voltage;
                textBoxManufacturer.Text = subTaskBean.Manufacturer;
                textBoxType.Text = subTaskBean.Type;
                integerInput.Value = subTaskBean.Count;
                textBoxName.Text = subTaskBean.Name;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (!superValidator1.Validate()) return;
            if (string.IsNullOrWhiteSpace(textBoxManufacturer.Text) ||
                string.IsNullOrWhiteSpace(textBoxType.Text) ||
                string.IsNullOrWhiteSpace(textBoxName.Text) ||
                string.IsNullOrWhiteSpace(integerInput.Text))
            {
                MessageBox.Show("存在空字段", "提示");
                return;
            }
            subTaskBean.Voltage = comboBoxVoltage.Text;
            subTaskBean.Manufacturer = textBoxManufacturer.Text;
            subTaskBean.Type = textBoxType.Text;
            subTaskBean.Count = integerInput.Value;
            subTaskBean.Name = textBoxName.Text;
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
