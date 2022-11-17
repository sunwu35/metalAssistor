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
    public partial class CreateSclerometerForm : Form
    {
        public CreateSclerometerForm()
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

            comboBoxName.SelectedIndexChanged += (object sender, EventArgs e) =>
            {
                comboBoxBehavior.Items.Clear();
                string[] bs;
                if (comboBoxName.Text.Contains("螺栓")) bs = b.BehaviorBolt.Split(',');
                else bs = b.BehaviorNut.Split(',');
                foreach (string Behavior in bs)
                {
                    comboBoxBehavior.Items.Add(Behavior);
                }
                if (comboBoxBehavior.Items.Count > 0) comboBoxBehavior.SelectedIndex = 0;
            };
        }

        private TaskBean task;
        private int taskType;
        private SclerometerTaskBean subTaskBean = new SclerometerTaskBean();

        public TaskBean Task { get => task; set => task = value; }
        public int TaskType
        {
            set
            {
                taskType = value;
                this.Text = TaskTypeUtil.GetSubTaskS(value);
            }
        }
        public SclerometerTaskBean SubTask { get => subTaskBean; set => subTaskBean = value; }

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
            float[] standard = TaskTypeUtil.GetSclerometerStabdard(comboBoxName.Text, comboBoxBehavior.Text);
            subTaskBean.MinHV = standard[0];
            subTaskBean.MaxHV = standard[1];
            subTaskBean.Behavior = float.Parse(comboBoxBehavior.Text);
            subTaskBean.Voltage = task.VoltageName;
            subTaskBean.Manufacturer = textBoxManufacturer.Text;
            subTaskBean.Type = comboBoxType.Text;
            subTaskBean.TaskType = taskType;
            subTaskBean.Name = comboBoxName.Text;
            subTaskBean.Count = 3;
            task.SubTaskBeans.Add(subTaskBean);
            this.DialogResult = DialogResult.OK;
        }

        private void CreateMechannicsForm_Load(object sender, EventArgs e)
        {

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
