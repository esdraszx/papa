using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace UI
{
    public partial class StringConexion : Form
    {
        private Log Form_Log;

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

        public StringConexion()
        {
            InitializeComponent();
        }

        private void txtServidor_Enter(object sender, EventArgs e)
        {
            if (txtServidor.Text == "NombreServidor")
            {
                txtServidor.Text = " ";
            }
        }

        private void txtServidor_Leave(object sender, EventArgs e)
        {
            if (txtServidor.Text == " ")
            {
                txtServidor.Text = "NombreServidor";
            }
        }

        private void txtBD_Enter(object sender, EventArgs e)
        {
            if (txtBD.Text == "BD")
            {
                txtBD.Text = " ";
            }
        }

        private void txtBD_Leave(object sender, EventArgs e)
        {
            if (txtBD.Text == " ")
            {
                txtBD.Text = "BD";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormStringConexion_Load(object sender, EventArgs e)
        {
            //Idioma de la pantalla 
            if ((BE.Globales.Idioma == "Español                       " && btnConectar.Text != "Aceptar") || (BE.Globales.Idioma == "Ingles                        " && btnConectar.Text == "Aceptar"))
            {
                txtServidor.Text = Recursos.Multidioma.CambiarIdioma(txtServidor.Text);
                txtBD.Text = Recursos.Multidioma.CambiarIdioma(txtBD.Text);
                btnConectar.Text = Recursos.Multidioma.CambiarIdioma(btnConectar.Text);
                this.Text = Recursos.Multidioma.CambiarIdioma(this.Text);
            }
            lblResult.Visible = false;
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            if (txtServidor.Text != " " && txtBD.Text != " ")
            {
                if (txtBD.TextLength >= 5 && txtServidor.TextLength >= 12)
                {
                    string conexion = "Data Source=" + txtServidor.Text + ";Initial Catalog=" + txtBD.Text + ";Integrated Security=True";
                    BE.Globales.CambiarConexion(conexion);
                    Properties.Settings.Default.Save();
                    if (Form_Log == null)
                    {
                        Form_Log = new Log();
                    }
                    Form_Log.Show();
                }
                else
                {
                    MessageBox.Show("NombreBD  + 5  Nombre Servidor + 12 ");
                    this.Show();
                }
            }
            else
            {
                MessageBox.Show("No ingreso datos validos la aplicacion se va a cerrar");
                Application.Exit();
            }
        }
    }
}
