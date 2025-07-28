
namespace Coursework
{
    partial class Palette
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Palette));
            this.dataGridSymbols = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxColorF = new System.Windows.Forms.PictureBox();
            this.pictureBoxColorB = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSymbols)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColorF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColorB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridSymbols
            // 
            this.dataGridSymbols.AllowUserToAddRows = false;
            this.dataGridSymbols.AllowUserToDeleteRows = false;
            this.dataGridSymbols.AllowUserToResizeColumns = false;
            this.dataGridSymbols.AllowUserToResizeRows = false;
            this.dataGridSymbols.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridSymbols.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSymbols.ColumnHeadersVisible = false;
            this.dataGridSymbols.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGridSymbols.EnableHeadersVisualStyles = false;
            this.dataGridSymbols.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridSymbols.Location = new System.Drawing.Point(10, 11);
            this.dataGridSymbols.MultiSelect = false;
            this.dataGridSymbols.Name = "dataGridSymbols";
            this.dataGridSymbols.ReadOnly = true;
            this.dataGridSymbols.RowHeadersWidth = 51;
            this.dataGridSymbols.RowTemplate.Height = 24;
            this.dataGridSymbols.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridSymbols.Size = new System.Drawing.Size(724, 295);
            this.dataGridSymbols.TabIndex = 0;
            this.dataGridSymbols.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridSymbols_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 125;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(10, 368);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(348, 175);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(10, 320);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Цвет символа:";
            // 
            // pictureBoxColorF
            // 
            this.pictureBoxColorF.Location = new System.Drawing.Point(288, 312);
            this.pictureBoxColorF.Name = "pictureBoxColorF";
            this.pictureBoxColorF.Size = new System.Drawing.Size(70, 38);
            this.pictureBoxColorF.TabIndex = 3;
            this.pictureBoxColorF.TabStop = false;
            // 
            // pictureBoxColorB
            // 
            this.pictureBoxColorB.Location = new System.Drawing.Point(664, 311);
            this.pictureBoxColorB.Name = "pictureBoxColorB";
            this.pictureBoxColorB.Size = new System.Drawing.Size(70, 38);
            this.pictureBoxColorB.TabIndex = 6;
            this.pictureBoxColorB.TabStop = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(483, 320);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 28);
            this.label2.TabIndex = 5;
            this.label2.Text = "Цвет фона:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(486, 368);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(248, 175);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseDown);
            // 
            // Palette
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(748, 553);
            this.Controls.Add(this.pictureBoxColorB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBoxColorF);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridSymbols);
            this.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Palette";
            this.Text = "Палитра";
            this.Load += new System.EventHandler(this.Palette_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSymbols)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColorF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColorB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridSymbols;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxColorF;
        private System.Windows.Forms.PictureBox pictureBoxColorB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}