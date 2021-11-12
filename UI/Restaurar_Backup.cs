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
    public partial class Restaurar_Backup : System.Windows.Forms.Form
    {

        private string[] archivos;
        int Cont;
        List<string> ListadoArchivos = new List<string>();

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

        public Restaurar_Backup()
        {
            InitializeComponent();
        }

        //private void btnSend_Click(object sender, EventArgs e)
        //{
        //    //var user = new UserModel();
        //    //var result = user.recoverPassword(txtUserRequest.Text);
        //    //lblResult.Text = result;
        //    //lblResult.Visible = true;        
        //}

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            DialogResult Pregunta = MessageBox.Show("Ha seleccionado " + Cont + " archivos Backup" +
              "Desea continuar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (Pregunta == DialogResult.Yes)
            {
                BLL.BackupBLL.GetInstance().restaurar(ListadoArchivos);
                MessageBox.Show("El backup ha sido restaurado");
            }
        }

        private void FormRestaurarBackup_Load(object sender, EventArgs e)
        {
            //lblResult.Visible = false;
            dgbackups.RowHeadersVisible = false;

            if (BE.Globales.Idioma != "Espanol" && BE.Globales.Idioma != null)
            {
                label1.Text = Recursos.Multidioma.CambiarIdioma(label1.Text);
                btnRestaurar.Text = Recursos.Multidioma.CambiarIdioma(btnRestaurar.Text);
                this.Text = Recursos.Multidioma.CambiarIdioma(this.Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog directorio = new FolderBrowserDialog();
            DialogResult resultado = directorio.ShowDialog();
            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = "Nombre";
            col1.Name = "Nombre";
            dgbackups.Columns.Add(col1);

            if (resultado == DialogResult.OK && !string.IsNullOrWhiteSpace(directorio.SelectedPath))
            {
                archivos = Directory.GetFiles(directorio.SelectedPath);
                foreach (string f in archivos)
                {
                    dgbackups.Rows.Add(f);
                }

                MessageBox.Show("Seleccione uno a uno los archivos a restaurar");
            }
        }

        private void Ayuda(object sender, HelpEventArgs hlpevent)
        {
            Help.ShowHelp(this, Path.Combine(Application.StartupPath, "Ayuda.chm"), "RestaurarBackup.htm");
        }

        private void dgbackups_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ListadoArchivos.Add(dgbackups.Rows[e.RowIndex].Cells["Nombre"].Value.ToString());

            Cont += 1;
        }

        private void btn_Cancelar_Alta_Backup_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
