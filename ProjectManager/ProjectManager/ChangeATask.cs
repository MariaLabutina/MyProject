using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManager
{
    public partial class ChangeATask : Form
    {
        GanttChart form;
        string name;
        DateTime startDate;
        int duration;
        public ChangeATask(GanttChart form, string name, DateTime startDate, int duration)
        {
            InitializeComponent();
            this.name = name;
            this.form = form;
            this.startDate = startDate;
            this.duration = duration;
        }

        private void buttonCansel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            form.ChangeTask(textBoxName.Text, dateTimePicker1.Value, (int)numericUpDownDuration.Value);
            this.Close();
        }

        private void ChangeATask_Load(object sender, EventArgs e)
        {
            textBoxName.Text = name;
            dateTimePicker1.Value = startDate;
            numericUpDownDuration.Value = duration;
        }
    }
}
