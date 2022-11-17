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
    public partial class CreateTaskForm : Form
    {
        public CreateTaskForm()
        {
            InitializeComponent();
            if (comboBoxVoltage.Items.Count > 0) comboBoxVoltage.SelectedIndex = 0;
            if (comboBoxMode.Items.Count > 0) comboBoxMode.SelectedIndex = 0;
        }

        private TaskBean task = new TaskBean();

        public TaskBean Task { get => task; set => task = value; }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            task.CompanyName = textBoxCompany.Text;
            task.VoltageName = comboBoxVoltage.Text;
            task.StationName = textBoxStation.Text;
            task.StationStatus = comboBoxMode.Text;
            task.TaskName = textBoxCompany.Text + comboBoxVoltage.Text + textBoxStation.Text + "变电站" + comboBoxMode.Text + "工程" + "金属检测任务";
            this.DialogResult = DialogResult.OK;
        }
    }
}
