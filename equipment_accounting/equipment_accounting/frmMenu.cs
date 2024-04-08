using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace equipment_accounting
{
    public partial class frmMenu : Form
    {
        private bool isAdmin = false;

        public frmMenu(bool isAdmin)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            this.isAdmin = isAdmin;

            UpdateFormAccess();
        }

        private void UpdateFormAccess()
        {
            this.Show();

            if (!isAdmin)
            {
                LockForm();
            }
            else
            {
                UnlockForm();
            }
        }

        public void SetAdminAccess(bool isAdmin)
        {
            this.isAdmin = isAdmin;
            администрированиеToolStripMenuItem.Enabled = isAdmin;

            UpdateFormAccess();
        }

        public void LockForm()
        {
            foreach (Control control in Controls)
            {
                if (control.Name != "администрированиеToolStripMenuItem")
                {
                    control.Enabled = true;
                }
                else
                {
                    control.Enabled = false;
                }
            }
        }

        public void UnlockForm()
        {
            foreach (Control control in Controls)
            {
                control.Enabled = true;
            }
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
    }
}
