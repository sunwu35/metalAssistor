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
    public partial class CreateSubTaskForm : Form
    {
        public CreateSubTaskForm()
        {
            InitializeComponent();
            if (comboBoxVoltage.Items.Count > 0) comboBoxVoltage.SelectedIndex = 0;

            InfoBean b = InfoBean.Create();

            foreach(string mode in b.Type.Split(','))
            {
                comboBoxDevcieMode.Items.Add(mode);
            }
            if (comboBoxDevcieMode.Items.Count > 0) comboBoxDevcieMode.SelectedIndex = 0;

            foreach (string no in b.Serial.Split(','))
            {
                comboBoxDeviceNO.Items.Add(no);
            }
            if (comboBoxDeviceNO.Items.Count > 0) comboBoxDeviceNO.SelectedIndex = 0;
        }

        private TaskBean task;
        private int taskType;
        private SubTaskBean subTaskBean = new SubTaskBean();

        public TaskBean Task { get => task; set => task = value; }
        public int TaskType
        {
            set
            {
                taskType = value;
                this.Text = TaskTypeUtil.GetSubTaskS(value);
            }
        }
        public SubTaskBean SubTask { get => subTaskBean; set => subTaskBean = value; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (task != null) comboBoxVoltage.Text = task.VoltageName;
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (!superValidator1.Validate()) return;

            if(string.IsNullOrWhiteSpace(textBoxManufacturer.Text)||
                string.IsNullOrWhiteSpace(textBoxType.Text) ||
                string.IsNullOrWhiteSpace(textBoxName.Text) ||
                string.IsNullOrWhiteSpace(integerInput.Text) )
            {
                MessageBox.Show("存在空字段","提示");
                return;
            }
            subTaskBean.DeviceModel = comboBoxDevcieMode.Text;
            subTaskBean.DeviceNO = comboBoxDeviceNO.Text;
            subTaskBean.Standard = TaskTypeUtil.GetStandard(taskType);
            subTaskBean.Voltage = comboBoxVoltage.Text;
            subTaskBean.Manufacturer = textBoxManufacturer.Text;
            subTaskBean.Type = textBoxType.Text;
            subTaskBean.TaskType = taskType;
            subTaskBean.Name = textBoxName.Text;
            subTaskBean.Count = integerInput.Value;
            task.SubTaskBeans.Add(subTaskBean);
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
