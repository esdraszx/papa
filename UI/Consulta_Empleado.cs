using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Consulta_Empleado : Form
    {
        public Consulta_Empleado()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /////Manage Permissions
            //if (UserCache.Position == Positions.Receptionist) {
            //    btnAdd.Enabled = false;
            //    btnEdit.Enabled = false;
            //    btnRemove.Enabled = false;
            //}
            //if (UserCache.Position == Positions.Accounting) {
            //    btnRemove.Enabled = false;
            //}
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
