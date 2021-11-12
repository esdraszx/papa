using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Alta_Familia : Form
    {
        public Alta_Familia()
        {
            InitializeComponent();
        }
        #region Drag Form/ Mover-Arrastrar Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void titleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_CrearFam_Click(object sender, EventArgs e)
        {
            if (txtCrearFam_NombreFamilia.Text == "")
            {
                MessageBox.Show("Debe ingresar un nombre para la Familia");
            }
            else
            {
                BE.FamiliaBE Fam = new BE.FamiliaBE();
                Fam.NombreFamilia = txtCrearFam_NombreFamilia.Text;
                //Validar que la familia no se encuentre en la base de datos
                if (BLL.FamiliaBLL.GetInstance().ValidarFamiliaAlta(Fam) == true)
                {
                    MessageBox.Show("Esta familia ya se encuentra en la BD");
                }
                else
                {
                    if (BLL.FamiliaBLL.GetInstance().AltaFamilia(Fam) == true)
                    {
                        MessageBox.Show("Nueva Familia creada");
                    }
                }

            }
            this.Close();
        }

        private void btnCancelar_CrearFam_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Alta_Familia_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void Ayuda(object sender, HelpEventArgs hlpevent)
        {
            Help.ShowHelp(this, Path.Combine(Application.StartupPath, "Ayuda.chm"), "AltaFamilia.htm");
        }
    }
}
