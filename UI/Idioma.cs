using System;
using System.Collections.Generic;
using BE;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace UI
{
    public partial class Idioma : Form
    {
        public List<IdiomaBE> ListadoIdiomas { get; set; }
        public Pantalla_Principal_C Form_Pantalla_Principal_C;

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

        public Idioma()
        {
            InitializeComponent();
        }

        private void FormIdioma_Load(object sender, EventArgs e)
        {
            //listar idiosmas de la base
            ListadoIdiomas = new List<IdiomaBE>();
            ListadoIdiomas = BLL.IdiomaBLL.GetInstance().ListarIdiomas(ListadoIdiomas);

            cbIdioma.DataSource = null;
            cbIdioma.DataSource = ListadoIdiomas;
            cbIdioma.DisplayMember = "Nombre";
            cbIdioma.DropDownStyle = ComboBoxStyle.DropDownList;

            if (Globales.Idioma != null)
            {
                btnAceptarIdioma.Text = Recursos.Multidioma.CambiarIdioma(btnAceptarIdioma.Text);
                btn_Cancelar_Idioma.Text = Recursos.Multidioma.CambiarIdioma(btn_Cancelar_Idioma.Text);
                lidioma.Text = Recursos.Multidioma.CambiarIdioma(lidioma.Text);
                this.Text = Recursos.Multidioma.CambiarIdioma(this.Text);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //pregunto que la opción no sea nula
            if (cbIdioma.Text == " " || cbIdioma.Text == null)
            {
                MessageBox.Show("Seleccione un idioma");
            }
            else
            {
                //cambiar idioma
                Globales.Idioma = cbIdioma.Text;

                //Cambie el menu principal          
                foreach (ToolStripMenuItem n in Form_Pantalla_Principal_C.MainMenuStrip.Items)
                {
                    string nomb = n.Text;
                    n.Text = Recursos.Multidioma.CambiarIdioma(nomb);
                    foreach (ToolStripItem i in n.DropDownItems)
                    {
                        i.Text = Recursos.Multidioma.CambiarIdioma(i.Text);

                    }
                }
                Form_Pantalla_Principal_C.Text = Recursos.Multidioma.CambiarIdioma(Form_Pantalla_Principal_C.Text);
            }
            this.Close();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Ayuda(object sender, HelpEventArgs hlpevent)
        {
            Help.ShowHelp(this, Path.Combine(Application.StartupPath, "Ayuda.chm"), "Idioma.htm");
        }
    }
}
