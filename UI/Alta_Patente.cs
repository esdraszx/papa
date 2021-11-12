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
    public partial class Alta_Patente : Form
    {
        public Alta_Patente()
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

        private void FormCrearPatente_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void Ayuda(object sender, HelpEventArgs hlpevent)
        {

        }

        private void btnCancelar_Patente_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, Path.Combine(Application.StartupPath, "Ayuda.chm"), "AltaPatente.htm");
        }

        private void btnAceptar_Patente_Click(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == "" || txtGrupo.Text == ""|| txtDetalle.Text == "")
            {
                MessageBox.Show("Debe ingresar todos los datos para la patente");
            }
            else
            {
                BE.PatenteBE Pate = new BE.PatenteBE();
                Pate.Descripcion = txtDescripcion.Text;
                //Validar que la patente no se encuentre en la base de datos
                if (BLL.PatenteBLL.GetInstance().ValidarPatenteAlta(Pate) == true)
                {
                    MessageBox.Show("Esta Patente ya se encuentra en la BD");
                }
                else
                {
                    if (BLL.PatenteBLL.GetInstance().AltaPatente(Pate) == true)
                    {
                        MessageBox.Show("Nueva Patente creada");
                    }
                }

            }
            this.Close();
        }
    }
}
