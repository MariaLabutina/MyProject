using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.IO;

namespace ProjectManager
{
    public partial class GanttChart : Form
    {
        ListOfTask listOfTask;
        public int index;
        public GanttChart()
        {
            InitializeComponent();
            listOfTask = new ListOfTask();
        }

        private void GanttChart_Load(object sender, EventArgs e)
        {
            DrawTask();
        }

        public void AddTask(string nameTask, DateTime startDate, int duration)
        {
            listOfTask.AddATask(nameTask, startDate, duration);
            DrawTask();
        }
        
        public void ChangeTask(string nameTask, DateTime startDate, int duration)
        {
            listOfTask.ChangeTheTask(index, nameTask, startDate, duration);
            DrawTask();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddATask addATask = new AddATask(this);
            addATask.ShowDialog();
        }


        void DrawTask()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            if (listOfTask.Count() != 0)
            {
                dataGridView1.Columns.Add("Title", "Имя задачи");
                dataGridView1.Columns["Title"].Width = 200;
                DateTime date = listOfTask.FirstDate();
                TimeSpan diff = listOfTask.LastDate() - listOfTask.FirstDate();
                int range = diff.Days + 1;
                for (int i = 0; i < range; i++)
                {
                    dataGridView1.Columns.Add($"{date.AddDays(i):d}", $"{date.AddDays(i)}");
                    dataGridView1.Columns[$"{date.AddDays(i):d}"].Width = 50;
                }

                for (int i = 0; i < listOfTask.Count(); i++)
                {
                    dataGridView1.Rows.Add($"{listOfTask[i].Name}", "");
                    int j = dataGridView1.Columns[$"{listOfTask[i].StartDate:d}"].Index;
                    for (int h = 0; h < listOfTask[i].Duration; h++)
                    {
                        dataGridView1[j, i].Style.BackColor = Color.Red;
                        j++;
                    }
                }


            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listOfTask.Count() != 0)
            {
                listOfTask.RemoveATask(dataGridView1.CurrentCell.RowIndex);
            }
            DrawTask();
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (listOfTask.Count() != 0)
            {
                index = dataGridView1.CurrentCell.RowIndex;
                ChangeATask change = new ChangeATask(this, listOfTask[index].Name, listOfTask[index].StartDate, listOfTask[index].Duration);
                change.ShowDialog();
            }
        }

        private void выгрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
            //{
                for(int i=0; i<listOfTask.Count(); i++)
                {
                    string json = JsonSerializer.Serialize<Task>(listOfTask[i]);
                }
            //}
        }
    }
}
