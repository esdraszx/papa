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
    public partial class Alta_Backup : Form
    {
        public Alta_Backup()
        {
            InitializeComponent();
        }
        #region Form Methods
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void txtNombreBackupAlta_Enter(object sender, EventArgs e)
        {
            if (txtNombreBackupAlta.Text == "NombreArchivo")
            {
                txtNombreBackupAlta.Text = "";
                txtNombreBackupAlta.ForeColor = Color.WhiteSmoke;
            }
        }
        private void txtNombreBackupAlta_Leave(object sender, EventArgs e)
        {
            if (txtNombreBackupAlta.Text == "")
            {
                txtNombreBackupAlta.Text = "NombreArchivo";
                txtNombreBackupAlta.ForeColor = Color.Silver;
            }
        }

        private void txtDireccion_Enter(object sender, EventArgs e)
        {
            if (txtDireccion.Text == "Ubicación")
            {
                txtDireccion.Text = "";
                txtDireccion.ForeColor = Color.WhiteSmoke;
            }
        }

        private void txtDireccion_Leave(object sender, EventArgs e)
        {
            if (txtDireccion.Text == "")
            {
                txtDireccion.Text = "Ubicación";
                txtDireccion.ForeColor = Color.Silver;
            }
        }

        private void txtVolumenes_Enter(object sender, EventArgs e)
        {
            if (txtVolumenes.Text == "Volúmenes")
            {
                txtVolumenes.Text = "";
                txtVolumenes.ForeColor = Color.WhiteSmoke;
            }
        }

        private void txtVolumenes_Leave(object sender, EventArgs e)
        {
            if (txtVolumenes.Text == "")
            {
                txtVolumenes.Text = "Volúmenes";
                txtVolumenes.ForeColor = Color.Silver;
            }
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        private void AltaBackup_Load(object sender, EventArgs e)
        {
           
        }
        
        private void msgError(string msg)
        {
            lblErrorMessage.Text = "    " + msg;
            lblErrorMessage.Visible = true;
        }
        private void Logout(object sender, FormClosedEventArgs e)
        {
           
            this.Close();
        }

        private void btn_Aceptar_Alta_Backup_Click(object sender, EventArgs e)
        {

            DialogResult Pregunta = MessageBox.Show("Se deben cerrar las conexiones a la Base de Datos. " +
                "Desea continuar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (Pregunta == DialogResult.Yes)
            {
               
                try
                {
                    if (txtNombreBackupAlta.Text == "" || txtVolumenes.Text == "" || txtDireccion.Text == "")
                    {
                        MessageBox.Show("Debe completar todos los campos");

                    }
                    else
                    {
                        int cantidadVol = 0;
                        BE.BackupBE NuevoBackup = new BE.BackupBE();
                        NuevoBackup.Nombre = txtNombreBackupAlta.Text;
                        cantidadVol = int.Parse(txtVolumenes.Text);
                        NuevoBackup.Volumenes = cantidadVol - 1;
                        NuevoBackup.Direccion = txtDireccion.Text;

                        BLL.BackupBLL.GetInstance().HacerBackupBLL(NuevoBackup);
                        if (openFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                           

                        }

                        MessageBox.Show("El Backup se ha realizado correctamente");
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Se produjo un error en tiempo de ejecucion: " + ex.Message);
                }
            }
        }

       

        private void btn_Cancelar_Alta_Backup_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtuser_TextChanged(object sender, EventArgs e)
        {

        }

       


        private void Ayuda(object sender, HelpEventArgs hlpevent)
        {
            Help.ShowHelp(this, Path.Combine(Application.StartupPath, "Ayuda.chm"), "Backup.htm");
        }
    }
}
