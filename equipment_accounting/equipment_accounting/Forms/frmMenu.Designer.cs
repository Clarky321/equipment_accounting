namespace equipment_accounting
{
    partial class frmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.btn_tech1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выйтиИзПриложенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.администрированиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_tech2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_tech1
            // 
            this.btn_tech1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_tech1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btn_tech1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_tech1.Location = new System.Drawing.Point(13, 125);
            this.btn_tech1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_tech1.Name = "btn_tech1";
            this.btn_tech1.Size = new System.Drawing.Size(589, 49);
            this.btn_tech1.TabIndex = 0;
            this.btn_tech1.Text = "Отчёт (утро)";
            this.btn_tech1.UseVisualStyleBackColor = false;
            this.btn_tech1.Click += new System.EventHandler(this.btn_tech1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.администрированиеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(615, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выйтиИзПриложенияToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(69, 29);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // выйтиИзПриложенияToolStripMenuItem
            // 
            this.выйтиИзПриложенияToolStripMenuItem.Name = "выйтиИзПриложенияToolStripMenuItem";
            this.выйтиИзПриложенияToolStripMenuItem.Size = new System.Drawing.Size(294, 34);
            this.выйтиИзПриложенияToolStripMenuItem.Text = "Выйти из приложения";
            this.выйтиИзПриложенияToolStripMenuItem.Click += new System.EventHandler(this.выйтиИзПриложенияToolStripMenuItem_Click);
            // 
            // администрированиеToolStripMenuItem
            // 
            this.администрированиеToolStripMenuItem.Name = "администрированиеToolStripMenuItem";
            this.администрированиеToolStripMenuItem.Size = new System.Drawing.Size(199, 29);
            this.администрированиеToolStripMenuItem.Text = "Администрирование";
            this.администрированиеToolStripMenuItem.Click += new System.EventHandler(this.администрированиеToolStripMenuItem_Click);
            // 
            // btn_tech2
            // 
            this.btn_tech2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_tech2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btn_tech2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_tech2.Location = new System.Drawing.Point(13, 233);
            this.btn_tech2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_tech2.Name = "btn_tech2";
            this.btn_tech2.Size = new System.Drawing.Size(589, 49);
            this.btn_tech2.TabIndex = 2;
            this.btn_tech2.Text = "Отчёт (вечер)";
            this.btn_tech2.UseVisualStyleBackColor = false;
            this.btn_tech2.Click += new System.EventHandler(this.btn_tech2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(367, 564);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(235, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "created by Ryabov Sergay v. 1.0";
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(615, 593);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_tech2);
            this.Controls.Add(this.btn_tech1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMenu";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_tech1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem администрированиеToolStripMenuItem;
        private System.Windows.Forms.Button btn_tech2;
        private System.Windows.Forms.ToolStripMenuItem выйтиИзПриложенияToolStripMenuItem;
        private System.Windows.Forms.Label label3;
    }
}