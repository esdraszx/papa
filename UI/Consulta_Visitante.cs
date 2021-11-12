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
    public partial class Consulta_Visitante : Form
    {
        public Consulta_Visitante()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //    ///Manage Permissions
            //    if (UserCache.Position == Positions.Receptionist)
            //    {                            
            //        btnRemove.Enabled = false;
            //    }
            //    if (UserCache.Position == Positions.Accounting)
            //    {
            //        btnRemove.Enabled = false;
            //    }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
