namespace equipment_accounting
{
    partial class frmSign_up
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
            this.btnText_login = new System.Windows.Forms.TextBox();
            this.btnText_password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReg = new System.Windows.Forms.Button();
            this.AccountAuthLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnText_login
            // 
            this.btnText_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnText_login.Location = new System.Drawing.Point(203, 129);
            this.btnText_login.Name = "btnText_login";
            this.btnText_login.Size = new System.Drawing.Size(479, 35);
            this.btnText_login.TabIndex = 4;
            // 
            // btnText_password
            // 
            this.btnText_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnText_password.Location = new System.Drawing.Point(203, 170);
            this.btnText_password.Name = "btnText_password";
            this.btnText_password.Size = new System.Drawing.Size(479, 35);
            this.btnText_password.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 29);
            this.label1.TabIndex = 6;
            this.label1.Text = "Пользователь:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 29);
            this.label2.TabIndex = 7;
            this.label2.Text = "Пароль:";
            // 
            // btnReg
            // 
            this.btnReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnReg.Location = new System.Drawing.Point(203, 294);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(253, 47);
            this.btnReg.TabIndex = 8;
            this.btnReg.Text = "Зарегистрировать";
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // AccountAuthLabel
            // 
            this.AccountAuthLabel.AutoSize = true;
            this.AccountAuthLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.AccountAuthLabel.Location = new System.Drawing.Point(199, 361);
            this.AccountAuthLabel.Name = "AccountAuthLabel";
            this.AccountAuthLabel.Size = new System.Drawing.Size(109, 20);
            this.AccountAuthLabel.TabIndex = 9;
            this.AccountAuthLabel.Text = "Есть аккаунт";
            this.AccountAuthLabel.Click += new System.EventHandler(this.AccountAuthLabel_Click);
            // 
            // frmSign_up
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 390);
            this.Controls.Add(this.AccountAuthLabel);
            this.Controls.Add(this.btnReg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnText_password);
            this.Controls.Add(this.btnText_login);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmSign_up";
            this.Text = "Регистрация";
            this.Load += new System.EventHandler(this.frmSign_up_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox btnText_login;
        private System.Windows.Forms.TextBox btnText_password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.Label AccountAuthLabel;
    }
}