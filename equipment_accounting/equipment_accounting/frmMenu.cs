﻿using System;
using System.Windows.Forms;

namespace equipment_accounting
{
    public partial class frmMenu : Form
    {
        private bool isAdmin = false;
        private bool isLoggedIn = false;

        public frmMenu(bool isAdmin)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            this.isAdmin = isAdmin;

            //LockForm();
        }

        private void LockForm()
        {
            foreach (Control control in Controls)
            {
                control.Enabled = false;
            }
        }

        private void UnlockForm()
        {
            foreach (Control control in Controls)
            {
                control.Enabled = true;
            }
        }

        private void UpdateFormAccess()
        {
            if (isLoggedIn)
            {
                UnlockForm();
                if (!isAdmin)
                {
                    LockFormForUser();
                }
            }
        }

        public void SetAdminAccess(bool isAdmin)
        {
            this.isAdmin = isAdmin;
            администрированиеToolStripMenuItem.Enabled = isAdmin;

            UpdateFormAccess();
        }

        public void LockFormForUser()
        {
            администрированиеToolStripMenuItem.Enabled = false;
        }

        public void LogIn()
        {
            isLoggedIn = true;
            UpdateFormAccess();
        }

        private void btn_tech1_Click(object sender, EventArgs e)
        {
            frmAccounting_1 accounting_1 = new frmAccounting_1();
            accounting_1.ShowDialog();
        }

        private void btn_tech2_Click(object sender, EventArgs e)
        {
            frmAccounting_2 accounting_2 = new frmAccounting_2();
            accounting_2.ShowDialog();
        }

        private void администрированиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdmin_panel admin_Panel = new frmAdmin_panel();
            admin_Panel.ShowDialog();
        }

        private void выйтиИзПриложенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
