using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using BE;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Alta_Usuario : Form
    {
        BE.UsuarioBE Usu;

        public Alta_Usuario()
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


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // Validar duplicados de clave y encriptar la clave por default (automática)
        private void btn_Aceptar_Alta_Usuario_Click(object sender, EventArgs e)
        {

            Usu = new BE.UsuarioBE();
            Usu.Apellido = txtAltaUsuario_Apellido.Text;
            Usu.Contraseña = null;
            Usu.DNI = txtAltaUsuario_DNI.Text;
            Usu.Activo = true;
            Usu.Direccion = txtAltaUsuario_Direccion.Text;
            Usu.Email = txtAltaUsuario_Email.Text;
            Usu.Nombre = txtAltaUsuario_Nombre.Text;
            Usu.NombreUsuario = txtAltaUsuario_NombreUsuario.Text;
            Usu.Telefono = txtAltaUsuario_Telefono.Text;

            //Quitar los apostrofes
            string nombre = txtAltaUsuario_Nombre.Text;
            string apellido = txtAltaUsuario_Apellido.Text;
            nombre = nombre.Replace("'", " ");
            apellido = apellido.Replace("'", " ");

            Usu.Nombre = nombre;
            Usu.Apellido = apellido;

            if (Usu.Email != "" && Usu.Apellido != "" && Usu.DNI != "" && Usu.Nombre != "")
            {
                if (BLL.UsuarioBLL.GetInstance().ValidarUsuario(Usu) == true)
                {
                    MessageBox.Show("Este usuario ya se encuentra en la BD");
                }
                else
                {
                    // Generar una contraseña automatica y enviar mail 
                    string contraseña;
                    contraseña = BLL.UsuarioBLL.GetInstance().GenerarContraseña();

                    //Encriptar nueva contraseña
                    string contraseñaEnc = BLL.UsuarioBLL.GetMD5(contraseña);
                    Usu.Contraseña = contraseñaEnc;

                    BLL.UsuarioBLL.GetInstance().AltaUsuario(Usu);

                    MessageBox.Show("Alta de Usuario realizada.");

                    string Mail = Usu.Email;
                    if (BLL.UsuarioBLL.GetInstance().enviarEMail(Mail, contraseña) == true)
                    {
                        MessageBox.Show("La nueva contraseña ha sido enviada a su correo");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo enviar el mail");
                    }
                }
            }
            else
            {
                MessageBox.Show("Complete los campos obligatorios");


            }
        }

        private void Alta_Usuario_Load(object sender, EventArgs e)
        {
            if ((BE.Globales.Idioma == "Español                       " && btn_Aceptar_Alta_Usuario.Text != "Aceptar") || (BE.Globales.Idioma == "Ingles                        " && btn_Aceptar_Alta_Usuario.Text == "Aceptar"))
            {
                Label1.Text = Recursos.Multidioma.CambiarIdioma(Label1.Text);
                Label2.Text = Recursos.Multidioma.CambiarIdioma(Label2.Text);
                Label3.Text = Recursos.Multidioma.CambiarIdioma(Label3.Text);
                Label6.Text = Recursos.Multidioma.CambiarIdioma(Label6.Text);
                Label5.Text = Recursos.Multidioma.CambiarIdioma(Label5.Text);
                label8.Text = Recursos.Multidioma.CambiarIdioma(label8.Text);
                Label4.Text = Recursos.Multidioma.CambiarIdioma(Label4.Text);
               
                btn_Aceptar_Alta_Usuario.Text = Recursos.Multidioma.CambiarIdioma(btn_Aceptar_Alta_Usuario.Text);
                btn_Cancelar_Alta_Usuario.Text = Recursos.Multidioma.CambiarIdioma(btn_Cancelar_Alta_Usuario.Text);

                this.Text = Recursos.Multidioma.CambiarIdioma(this.Text);

            }
        }
        private void Ayuda(object sender, HelpEventArgs hlpevent)
        {
            Help.ShowHelp(this, Path.Combine(Application.StartupPath, "Ayuda.chm"), "AltaUsuario.htm");
        }
    }
    
}
