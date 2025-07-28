using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework
{
    public partial class CreatingANewCanvas : Form
    {
        public CreatingANewCanvas()
        {
            InitializeComponent();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if ((int)numericUpDownHeight.Value > 0&& (int)numericUpDownWidth.Value>0)
            {
                DataBank.height = (int)numericUpDownHeight.Value;
                DataBank.width = (int)numericUpDownWidth.Value;
                this.Close();
            }
            else
            {
                MessageBox.Show("Размеры холста не могут быть отрицательными!", "Предупреждение",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
    }
}
