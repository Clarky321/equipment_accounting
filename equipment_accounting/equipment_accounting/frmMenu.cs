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
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btn_tech1_Click(object sender, EventArgs e)
        {
            frmAccounting_1 accounting_1 = new frmAccounting_1();
            accounting_1.ShowDialog();
        }
    }
}
