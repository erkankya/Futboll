namespace proje
{
    partial class Anasayfa
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.liglerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.süperligToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bundesligaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.premierligToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takımlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oyuncularToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lig1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.laligaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.liglerToolStripMenuItem,
            this.takımlarToolStripMenuItem,
            this.oyuncularToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // liglerToolStripMenuItem
            // 
            this.liglerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.süperligToolStripMenuItem,
            this.bundesligaToolStripMenuItem,
            this.premierligToolStripMenuItem,
            this.laligaToolStripMenuItem,
            this.lig1ToolStripMenuItem});
            this.liglerToolStripMenuItem.Name = "liglerToolStripMenuItem";
            this.liglerToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.liglerToolStripMenuItem.Text = "Ligler";
            // 
            // süperligToolStripMenuItem
            // 
            this.süperligToolStripMenuItem.Name = "süperligToolStripMenuItem";
            this.süperligToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.süperligToolStripMenuItem.Text = "Süperlig";
            this.süperligToolStripMenuItem.Click += new System.EventHandler(this.süperligToolStripMenuItem_Click);
            // 
            // bundesligaToolStripMenuItem
            // 
            this.bundesligaToolStripMenuItem.Name = "bundesligaToolStripMenuItem";
            this.bundesligaToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.bundesligaToolStripMenuItem.Text = "Bundesliga";
            this.bundesligaToolStripMenuItem.Click += new System.EventHandler(this.bundesligaToolStripMenuItem_Click_1);
            // 
            // premierligToolStripMenuItem
            // 
            this.premierligToolStripMenuItem.Name = "premierligToolStripMenuItem";
            this.premierligToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.premierligToolStripMenuItem.Text = "Premierlig";
            this.premierligToolStripMenuItem.Click += new System.EventHandler(this.premierligToolStripMenuItem_Click_1);
            // 
            // takımlarToolStripMenuItem
            // 
            this.takımlarToolStripMenuItem.Name = "takımlarToolStripMenuItem";
            this.takımlarToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.takımlarToolStripMenuItem.Text = "Takımlar";
            this.takımlarToolStripMenuItem.Click += new System.EventHandler(this.takımlarToolStripMenuItem_Click_1);
            // 
            // oyuncularToolStripMenuItem
            // 
            this.oyuncularToolStripMenuItem.Name = "oyuncularToolStripMenuItem";
            this.oyuncularToolStripMenuItem.Size = new System.Drawing.Size(87, 24);
            this.oyuncularToolStripMenuItem.Text = "Oyuncular";
            this.oyuncularToolStripMenuItem.Click += new System.EventHandler(this.oyuncularToolStripMenuItem_Click_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(26, 96);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(718, 325);
            this.dataGridView1.TabIndex = 1;
            // 
            // lig1ToolStripMenuItem
            // 
            this.lig1ToolStripMenuItem.Name = "lig1ToolStripMenuItem";
            this.lig1ToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.lig1ToolStripMenuItem.Text = "Lig 1";
            // 
            // laligaToolStripMenuItem
            // 
            this.laligaToolStripMenuItem.Name = "laligaToolStripMenuItem";
            this.laligaToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.laligaToolStripMenuItem.Text = "Laliga";
            // 
            // Anasayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Anasayfa";
            this.Text = "Anasayfa";
            this.Load += new System.EventHandler(this.Anasayfa_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem liglerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem süperligToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bundesligaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem premierligToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takımlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oyuncularToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem laligaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lig1ToolStripMenuItem;
    }
}