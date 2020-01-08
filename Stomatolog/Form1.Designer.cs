namespace Stomatolog
{
    partial class Form1
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
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otwórzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.klienciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.zakończToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.obliczToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.GWuslugi = new System.Windows.Forms.DataGridView();
            this.klienci = new System.Windows.Forms.TabPage();
            this.GWklienci = new System.Windows.Forms.DataGridView();
            this.Harmonogram = new System.Windows.Forms.TabPage();
            this.GWHarmonogram = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GWuslugi)).BeginInit();
            this.klienci.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GWklienci)).BeginInit();
            this.Harmonogram.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GWHarmonogram)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.obliczToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(740, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.otwórzToolStripMenuItem,
            this.klienciToolStripMenuItem,
            this.toolStripMenuItem1,
            this.zakończToolStripMenuItem});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.plikToolStripMenuItem.Text = "Plik";
            this.plikToolStripMenuItem.Click += new System.EventHandler(this.plikToolStripMenuItem_Click);
            // 
            // otwórzToolStripMenuItem
            // 
            this.otwórzToolStripMenuItem.Name = "otwórzToolStripMenuItem";
            this.otwórzToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.otwórzToolStripMenuItem.Text = "otwórz";
            this.otwórzToolStripMenuItem.Click += new System.EventHandler(this.otwórzToolStripMenuItem_Click);
            // 
            // klienciToolStripMenuItem
            // 
            this.klienciToolStripMenuItem.Name = "klienciToolStripMenuItem";
            this.klienciToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.klienciToolStripMenuItem.Text = "klienci";
            this.klienciToolStripMenuItem.Click += new System.EventHandler(this.klienciToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // zakończToolStripMenuItem
            // 
            this.zakończToolStripMenuItem.Name = "zakończToolStripMenuItem";
            this.zakończToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.zakończToolStripMenuItem.Text = "zakończ";
            this.zakończToolStripMenuItem.Click += new System.EventHandler(this.zakończToolStripMenuItem_Click);
            // 
            // obliczToolStripMenuItem
            // 
            this.obliczToolStripMenuItem.Name = "obliczToolStripMenuItem";
            this.obliczToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.obliczToolStripMenuItem.Text = "Oblicz";
            this.obliczToolStripMenuItem.Click += new System.EventHandler(this.obliczToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.klienci);
            this.tabControl1.Controls.Add(this.Harmonogram);
            this.tabControl1.Location = new System.Drawing.Point(12, 36);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(716, 249);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.GWuslugi);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(708, 223);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Usługi";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // GWuslugi
            // 
            this.GWuslugi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GWuslugi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GWuslugi.Location = new System.Drawing.Point(0, 0);
            this.GWuslugi.Name = "GWuslugi";
            this.GWuslugi.Size = new System.Drawing.Size(696, 211);
            this.GWuslugi.TabIndex = 0;
            this.GWuslugi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GWuslugi_CellContentClick);
            // 
            // klienci
            // 
            this.klienci.Controls.Add(this.GWklienci);
            this.klienci.Location = new System.Drawing.Point(4, 22);
            this.klienci.Name = "klienci";
            this.klienci.Padding = new System.Windows.Forms.Padding(3);
            this.klienci.Size = new System.Drawing.Size(708, 223);
            this.klienci.TabIndex = 1;
            this.klienci.Text = "Klienci";
            this.klienci.UseVisualStyleBackColor = true;
            this.klienci.Click += new System.EventHandler(this.Klienci_Click);
            // 
            // GWklienci
            // 
            this.GWklienci.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GWklienci.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GWklienci.Location = new System.Drawing.Point(6, 6);
            this.GWklienci.Name = "GWklienci";
            this.GWklienci.Size = new System.Drawing.Size(699, 214);
            this.GWklienci.TabIndex = 0;
            this.GWklienci.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // Harmonogram
            // 
            this.Harmonogram.Controls.Add(this.GWHarmonogram);
            this.Harmonogram.Location = new System.Drawing.Point(4, 22);
            this.Harmonogram.Name = "Harmonogram";
            this.Harmonogram.Padding = new System.Windows.Forms.Padding(3);
            this.Harmonogram.Size = new System.Drawing.Size(708, 223);
            this.Harmonogram.TabIndex = 2;
            this.Harmonogram.Text = "Harmonogram";
            this.Harmonogram.UseVisualStyleBackColor = true;
            this.Harmonogram.Click += new System.EventHandler(this.Harmonogram_Click);
            // 
            // GWHarmonogram
            // 
            this.GWHarmonogram.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GWHarmonogram.Location = new System.Drawing.Point(6, 0);
            this.GWHarmonogram.Name = "GWHarmonogram";
            this.GWHarmonogram.Size = new System.Drawing.Size(702, 223);
            this.GWHarmonogram.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 317);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GWuslugi)).EndInit();
            this.klienci.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GWklienci)).EndInit();
            this.Harmonogram.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GWHarmonogram)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otwórzToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem zakończToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage klienci;
        private System.Windows.Forms.DataGridView GWuslugi;
        private System.Windows.Forms.DataGridView GWklienci;
        private System.Windows.Forms.ToolStripMenuItem klienciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem obliczToolStripMenuItem;
        private System.Windows.Forms.TabPage Harmonogram;
        private System.Windows.Forms.DataGridView GWHarmonogram;
    }
}

