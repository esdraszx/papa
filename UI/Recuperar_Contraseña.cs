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
using System.IO;

namespace UI
{
    public partial class Recuperar_Contraseña : Form
    {

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

        public Recuperar_Contraseña()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            BE.UsuarioBE Usu = new BE.UsuarioBE();

            if (txtUserRequest.Text == "")
            {
                MessageBox.Show("Ingrese un usuario a recuperar");

            }
            else
            {
                //Apostrofe
                //Quitar los apostrofos del usuario y contraseña
                string nombre = txtUserRequest.Text;
                //string contra = txtNuevoPass.Text;

                nombre = nombre.Replace("'", " ");
                //contra = contra.Replace("'", " ");


                // Voy a la base USUARIOS a recuperar el mail
               Usu.NombreUsuario = nombre;
           
                Usu = BLL.UsuarioBLL.GetInstance().BuscarUsuarioNombre(Usu);
                string correo = Usu.Email;

                //Generar contrasaña automática
                string contraseña;
                contraseña = BLL.UsuarioBLL.GetInstance().GenerarContraseña();

                //Encriptar nueva contraseña
                string contraseñaEnc = BLL.UsuarioBLL.GetMD5(contraseña);

                //Actualizar la contraseña en la BD
                Usu.Contraseña = contraseñaEnc;
                BLL.UsuarioBLL.GetInstance().ActualizarContraseña(Usu);

                if (BLL.UsuarioBLL.GetInstance().enviarEMail(correo, contraseña) == true)
                {
                    MessageBox.Show("La nueva contraseña ha sido enviada a su correo");


                }
            }
            var confirmar_Contraseña = new Confirmar_Contraseña();
            var result = "La nueva contraseña ha sido enviada a su correo";//
            lblResult.Text = result.ToString();
            lblResult.Visible = true;
            confirmar_Contraseña.ShowDialog();
        }

        private void FormRecoverPassword_Load(object sender, EventArgs e)
        {
            lblResult.Visible = false;
            if (BE.Globales.Idioma != "Espanol" && BE.Globales.Idioma != null)
            {
                label1.Text = Recursos.Multidioma.CambiarIdioma(label1.Text);
                label3.Text = Recursos.Multidioma.CambiarIdioma(label3.Text);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Ayuda(object sender, HelpEventArgs hlpevent)
        {
            Help.ShowHelp(this, Path.Combine(Application.StartupPath, "Ayuda.chm"), "Sesion.htm");
        }

        private void txtNuevoPass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
