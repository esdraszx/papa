using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Cache;

namespace Presentation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ///Manage Permissions
            if (UserCache.Position == Positions.Receptionist) {
                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnRemove.Enabled = false;
            }
            if (UserCache.Position == Positions.Accounting) {
                btnRemove.Enabled = false;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
