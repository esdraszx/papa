using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using BE;

namespace UI
{
    public partial class Depurar_Bitacora : Form
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

        public Depurar_Bitacora()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            BitacoraBE Bit = new BitacoraBE();
            Bit.FechaHora = dateTimePicker1.Value;
            //Depurar bitacora segun fecha
            if (BLL.BitacoraBLL.GetInstance().DepurarBitacora(Bit.FechaHora) == true)
            {
                MessageBox.Show("Depuración realizada");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormDepurar_Bitacora_Load(object sender, EventArgs e)
        {

        }

        private void Ayuda(object sender, HelpEventArgs hlpevent)
        {
            Help.ShowHelp(this, Path.Combine(Application.StartupPath, "Ayuda.chm"), "DepurarBitacora.htm");
        }
    }
}
