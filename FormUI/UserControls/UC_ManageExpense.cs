using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FormUI.Forms;

namespace FormUI.UserControls
{
    public partial class UC_ManageExpense : UserControl
    {
        public UC_ManageExpense()
        {
            InitializeComponent();
        }

        private void btnAddNewBooks_Click(object sender, EventArgs e)
        {
            using (Form_AddExpense ae = new Form_AddExpense())
            {
                ae.ShowDialog();
            }
        }
    }
}
