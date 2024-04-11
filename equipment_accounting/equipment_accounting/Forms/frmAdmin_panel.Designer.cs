namespace equipment_accounting
{
    partial class frmAdmin_panel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdmin_panel));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxConsole = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnBaseInfo = new System.Windows.Forms.Button();
            this.btnImportNight = new System.Windows.Forms.Button();
            this.comboBox_year1 = new System.Windows.Forms.ComboBox();
            this.comboBox_month1 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBox_year2 = new System.Windows.Forms.ComboBox();
            this.btnImportDay = new System.Windows.Forms.Button();
            this.comboBox_month2 = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1745, 36);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(69, 32);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // textBoxConsole
            // 
            this.textBoxConsole.Location = new System.Drawing.Point(903, 99);
            this.textBoxConsole.Multiline = true;
            this.textBoxConsole.Name = "textBoxConsole";
            this.textBoxConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxConsole.Size = new System.Drawing.Size(821, 302);
            this.textBoxConsole.TabIndex = 2;
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnConnect.Location = new System.Drawing.Point(1342, 49);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(382, 44);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Подключение к базе данных";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnQuery.Location = new System.Drawing.Point(1522, 407);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(202, 44);
            this.btnQuery.TabIndex = 4;
            this.btnQuery.Text = "Выполнить запрос";
            this.btnQuery.UseVisualStyleBackColor = false;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(21, 99);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(821, 302);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRefresh.Location = new System.Drawing.Point(706, 49);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(136, 44);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnBaseInfo
            // 
            this.btnBaseInfo.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnBaseInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBaseInfo.Location = new System.Drawing.Point(903, 49);
            this.btnBaseInfo.Name = "btnBaseInfo";
            this.btnBaseInfo.Size = new System.Drawing.Size(433, 44);
            this.btnBaseInfo.TabIndex = 8;
            this.btnBaseInfo.Text = "Общая информация о базе данных";
            this.btnBaseInfo.UseVisualStyleBackColor = false;
            this.btnBaseInfo.Click += new System.EventHandler(this.btnBaseInfo_Click);
            // 
            // btnImportNight
            // 
            this.btnImportNight.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnImportNight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnImportNight.Location = new System.Drawing.Point(3, 132);
            this.btnImportNight.Name = "btnImportNight";
            this.btnImportNight.Size = new System.Drawing.Size(312, 40);
            this.btnImportNight.TabIndex = 9;
            this.btnImportNight.Text = "Импорт Excel (вечер)";
            this.btnImportNight.UseVisualStyleBackColor = false;
            this.btnImportNight.Click += new System.EventHandler(this.btnImportNight_Click);
            // 
            // comboBox_year1
            // 
            this.comboBox_year1.FormattingEnabled = true;
            this.comboBox_year1.Location = new System.Drawing.Point(3, 29);
            this.comboBox_year1.Name = "comboBox_year1";
            this.comboBox_year1.Size = new System.Drawing.Size(153, 28);
            this.comboBox_year1.TabIndex = 10;
            // 
            // comboBox_month1
            // 
            this.comboBox_month1.FormattingEnabled = true;
            this.comboBox_month1.Location = new System.Drawing.Point(162, 29);
            this.comboBox_month1.Name = "comboBox_month1";
            this.comboBox_month1.Size = new System.Drawing.Size(153, 28);
            this.comboBox_month1.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.comboBox_month1);
            this.panel1.Controls.Add(this.btnImportNight);
            this.panel1.Controls.Add(this.comboBox_year1);
            this.panel1.Location = new System.Drawing.Point(523, 552);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(319, 189);
            this.panel1.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Controls.Add(this.comboBox_year2);
            this.panel2.Controls.Add(this.btnImportDay);
            this.panel2.Controls.Add(this.comboBox_month2);
            this.panel2.Location = new System.Drawing.Point(21, 552);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(319, 189);
            this.panel2.TabIndex = 13;
            // 
            // comboBox_year2
            // 
            this.comboBox_year2.FormattingEnabled = true;
            this.comboBox_year2.Location = new System.Drawing.Point(3, 30);
            this.comboBox_year2.Name = "comboBox_year2";
            this.comboBox_year2.Size = new System.Drawing.Size(153, 28);
            this.comboBox_year2.TabIndex = 11;
            // 
            // btnImportDay
            // 
            this.btnImportDay.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnImportDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnImportDay.Location = new System.Drawing.Point(3, 132);
            this.btnImportDay.Name = "btnImportDay";
            this.btnImportDay.Size = new System.Drawing.Size(312, 40);
            this.btnImportDay.TabIndex = 9;
            this.btnImportDay.Text = "Импорт Excel (утро)";
            this.btnImportDay.UseVisualStyleBackColor = false;
            this.btnImportDay.Click += new System.EventHandler(this.btnImportDay_Click);
            // 
            // comboBox_month2
            // 
            this.comboBox_month2.FormattingEnabled = true;
            this.comboBox_month2.Location = new System.Drawing.Point(162, 30);
            this.comboBox_month2.Name = "comboBox_month2";
            this.comboBox_month2.Size = new System.Drawing.Size(153, 28);
            this.comboBox_month2.TabIndex = 10;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAdd.Location = new System.Drawing.Point(518, 407);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(136, 44);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDelete.Location = new System.Drawing.Point(660, 407);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(182, 44);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.Text = "Удалить запись";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmAdmin_panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1745, 949);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnBaseInfo);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.textBoxConsole);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmAdmin_panel";
            this.Text = "Админ-панель";
            this.Load += new System.EventHandler(this.frmAdmin_panel_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxConsole;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnBaseInfo;
        private System.Windows.Forms.Button btnImportNight;
        private System.Windows.Forms.ComboBox comboBox_year1;
        private System.Windows.Forms.ComboBox comboBox_month1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBox_year2;
        private System.Windows.Forms.Button btnImportDay;
        private System.Windows.Forms.ComboBox comboBox_month2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
    }
}