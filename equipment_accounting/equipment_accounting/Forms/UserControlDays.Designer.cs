namespace equipment_accounting.Forms
{
    partial class UserControlDays
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ibdays = new System.Windows.Forms.Label();
            this.flowLayoutPanelEmployees = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // ibdays
            // 
            this.ibdays.AutoSize = true;
            this.ibdays.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibdays.Location = new System.Drawing.Point(5, 5);
            this.ibdays.Name = "ibdays";
            this.ibdays.Size = new System.Drawing.Size(48, 42);
            this.ibdays.TabIndex = 0;
            this.ibdays.Text = "00";
            // 
            // flowLayoutPanelEmployees
            // 
            this.flowLayoutPanelEmployees.Location = new System.Drawing.Point(3, 50);
            this.flowLayoutPanelEmployees.Name = "flowLayoutPanelEmployees";
            this.flowLayoutPanelEmployees.Size = new System.Drawing.Size(230, 103);
            this.flowLayoutPanelEmployees.TabIndex = 2;
            // 
            // UserControlDays
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.flowLayoutPanelEmployees);
            this.Controls.Add(this.ibdays);
            this.Name = "UserControlDays";
            this.Size = new System.Drawing.Size(236, 156);
            this.Load += new System.EventHandler(this.UserControlDays_Load);
            this.Click += new System.EventHandler(this.UserControlDays_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ibdays;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelEmployees;
    }
}
