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
    public partial class ChangeGuaranteeTaskForm : Form
    {
        public ChangeGuaranteeTaskForm()
        {
            InitializeComponent();
            InfoBean b = InfoBean.Create();

            foreach (string Behavior in b.BehaviorNut.Split(','))
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
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            comboBoxName.SelectedIndexChanged += (object sender, EventArgs ee) =>
            {
                comboBoxBehavior.Items.Clear(); InfoBean b = InfoBean.Create();
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

        private GuaranteeTaskBean subTaskBean = new GuaranteeTaskBean();

        public GuaranteeTaskBean SubTask
        {
            get => subTaskBean;
            set
            {
                subTaskBean = value;
                this.Text = TaskTypeUtil.GetSubTaskS(value.TaskType) + "-修改";
                comboBoxBehavior.Text = subTaskBean.Behavior.ToString();
                textBoxManufacturer.Text = subTaskBean.Manufacturer;
                comboBoxType.Text = subTaskBean.Type;
                comboBoxName.Text = subTaskBean.Name;
                if (value.TaskType == TaskTypeUtil.MechanicsBehaviorWedge) { comboBoxName.Items.Clear(); comboBoxName.Text = "螺栓"; }
                if (value.TaskType == TaskTypeUtil.MechanicsBehaviorGuarantee) { comboBoxName.Items.Clear(); comboBoxName.Text = "螺母"; }
            }
        }

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
            //subTaskBean.Standard = TaskTypeUtil.GetMechanicsStandard(comboBoxName.Text, comboBoxBehavior.Text, comboBoxType.Text);
            subTaskBean.Behavior = float.Parse(comboBoxBehavior.Text);
            subTaskBean.Manufacturer = textBoxManufacturer.Text;
            subTaskBean.Type = comboBoxType.Text;
            subTaskBean.Name = comboBoxName.Text;
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
