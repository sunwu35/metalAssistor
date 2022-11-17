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
    public partial class CreateWedgeTaskForm : Form
    {
        public CreateWedgeTaskForm()
        {
            InitializeComponent();
            InfoBean b = InfoBean.Create();

            foreach (string mode in b.Type.Split(','))
            {
                comboBoxDevcieMode.Items.Add(mode);
            }
            if (comboBoxDevcieMode.Items.Count > 0) comboBoxDevcieMode.SelectedIndex = 0;

            foreach (string no in b.Serial.Split(','))
            {
                comboBoxDeviceNO.Items.Add(no);
            }
            if (comboBoxDeviceNO.Items.Count > 0) comboBoxDeviceNO.SelectedIndex = 0;

            foreach (string Behavior in b.BehaviorBolt.Split(','))
            {
                comboBoxBehavior.Items.Add(Behavior);
            }
            if (comboBoxBehavior.Items.Count > 0) comboBoxBehavior.SelectedIndex = 0;

            foreach (string Behavior in b.Spec.Split(','))
            {
                comboBoxType.Items.Add(Behavior);
            }
            if (comboBoxType.Items.Count > 0) comboBoxType.SelectedIndex = 0;

            if (comboBoxName.Items.Count > 0) comboBoxName.SelectedIndex = 0;

           
        }

        private TaskBean task;
        private int taskType;
        private WedgeTaskBean subTaskBean = new WedgeTaskBean();

        public TaskBean Task { get => task; set => task = value; }
        public int TaskType
        {
            set
            {
                taskType = value;
                this.Text = TaskTypeUtil.GetSubTaskS(value);
                if (value == TaskTypeUtil.MechanicsBehaviorWedge) { comboBoxName.Items.Clear(); comboBoxName.Text = "螺栓"; }
                if (value == TaskTypeUtil.MechanicsBehaviorGuarantee) { comboBoxName.Items.Clear(); comboBoxName.Text = "螺母"; }
            }
        }
        public WedgeTaskBean SubTask { get => subTaskBean; set => subTaskBean = value; }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (!superValidator1.Validate()) return;
            if (string.IsNullOrWhiteSpace(textBoxManufacturer.Text) ||
                   string.IsNullOrWhiteSpace(comboBoxBehavior.Text) ||
                   string.IsNullOrWhiteSpace(comboBoxName.Text) ||
                   string.IsNullOrWhiteSpace(comboBoxType.Text))
            {
                MessageBox.Show("存在空字段", "提示");
                return;
            }
            subTaskBean.DeviceModel = comboBoxDevcieMode.Text;
            subTaskBean.DeviceNO = comboBoxDeviceNO.Text;
            subTaskBean.Behavior = float.Parse(comboBoxBehavior.Text);
            subTaskBean.Voltage = task.VoltageName;
            subTaskBean.Manufacturer = textBoxManufacturer.Text;
            subTaskBean.Type = comboBoxType.Text;
            subTaskBean.TaskType = taskType;
            subTaskBean.Name = comboBoxName.Text;
            subTaskBean.Count = 3;
            subTaskBean.MinPullLoad = (float)doubleInputMin.Value;
            subTaskBean.MaxPullLoad = (float)doubleInputMax.Value;
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
