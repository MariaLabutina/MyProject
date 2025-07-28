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
    public partial class AddATask : Form
    {
        GanttChart form;
        public AddATask(GanttChart form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            form.AddTask(textBoxName.Text,dateTimePicker1.Value, (int)numericUpDownDuration.Value);
            this.Close();
        }

        private void AddATask_Load(object sender, EventArgs e)
        {

        }
    }
}
