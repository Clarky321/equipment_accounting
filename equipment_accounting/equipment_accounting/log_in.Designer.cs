namespace equipment_accounting
{
    partial class log_in
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
            System.Windows.Forms.Label label1;
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.comboBox_login = new System.Windows.Forms.ComboBox();
            this.btn_log = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label1.Location = new System.Drawing.Point(12, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(186, 32);
            label1.TabIndex = 1;
            label1.Text = "Авторизация";
            // 
            // textBox_password
            // 
            this.textBox_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_password.Location = new System.Drawing.Point(43, 217);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(337, 39);
            this.textBox_password.TabIndex = 2;
            // 
            // comboBox_login
            // 
            this.comboBox_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_login.FormattingEnabled = true;
            this.comboBox_login.Location = new System.Drawing.Point(43, 131);
            this.comboBox_login.Name = "comboBox_login";
            this.comboBox_login.Size = new System.Drawing.Size(337, 40);
            this.comboBox_login.TabIndex = 3;
            // 
            // btn_log
            // 
            this.btn_log.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_log.Location = new System.Drawing.Point(114, 287);
            this.btn_log.Name = "btn_log";
            this.btn_log.Size = new System.Drawing.Size(195, 52);
            this.btn_log.TabIndex = 4;
            this.btn_log.Text = "Войти";
            this.btn_log.UseVisualStyleBackColor = true;
            this.btn_log.Click += new System.EventHandler(this.btn_log_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(144, 380);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "регистрация";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // log_in
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 427);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_log);
            this.Controls.Add(this.comboBox_login);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(label1);
            this.Name = "log_in";
            this.Text = "log_in";
            this.Load += new System.EventHandler(this.log_in_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.ComboBox comboBox_login;
        private System.Windows.Forms.Button btn_log;
        private System.Windows.Forms.Label label2;
    }
}