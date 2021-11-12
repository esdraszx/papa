using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using BE;
using BLL;
using Servicios;
using System.Collections.Generic;

namespace UI.User
{
    public partial class RecalcularDV : Form
    {
        public int contador { get; private set; }
        private UsuarioBE UBE;
        private UsuarioBLL UBLL;
        private LogUI logUI;
        public string ConsultaXT;
        

        //private PerfilBE Fam;

        public RecalcularDV()
        {
            InitializeComponent();
        }
        #region Form Methods
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
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

        
        private void msgError(string msg)
        {
            registros.Text = "    " + msg;
            registros.Visible = true;
        }
       
        private void RecalcularDV_Load(object sender, EventArgs e)
        {
            UBE = new UsuarioBE();
            logUI = new LogUI();
            UBE.IDUsuario = logUI.UBE.IDUsuario;
            UBE.Patentes = new List<PatenteBE>();
            UBLL = new UsuarioBLL();
            UBLL.UsuarioPatente(UBE);

            try
            {
                foreach (PatenteBE pat in UBE.Patentes)
                {
                    switch (pat.Detalle)
                    {
                        case "PA0001":
                            ComprobarDigitos();
                            Panelgeneral.Visible = true;
                            break;
                        case "No posee permiso":
                            registros.Text = "No posee permiso";
                            Panelgeneral.Visible = false;
                            break;
                        case "No hay sesion activa":
                            registros.Text = "No hay sesion activa";
                            Panelgeneral.Visible = false;
                            break;
                            default:
                            registros.Text = "Error";
                            Panelgeneral.Visible = false;
                            break;
                    }
                }
 
            }
            catch
            {
            }
        }

        private void btnRecalcularDV_Click(object sender, EventArgs e)
        {

            if (DigitosVerificadores.GrabarDVHdeTodalaBase())
            {
                registros.Text = "**Se generaron nuevamente los digitos verificadores**";
                registros.Visible = true;
            }  
            else
            {
                registros.Text = "**Ocurrio un error**";
                registros.Visible = true;
            }
        }
            
        protected void ComprobarDigitos()
        {
            if (!DigitosVerificadores.ValidarBBDD())
            {
                registros.Text = DigitosVerificadores.RegistrosCorruptos();
                registros.Visible = true;
               // btnRecalcularDV.Visible = true;
            }
        }

        private void btnVerificarDV_Click(object sender, EventArgs e)
        {
            if (DigitosVerificadores.ValidarBBDD())
            {
                
            }
            if (DigitosVerificadores.RegMod != "")
            {
                registros.Text = DigitosVerificadores.RegMod.ToString();
                registros.Visible = true;
                richDetalle.Text = DigitosVerificadores.RegMod.ToString();
                richDetalle.Visible = true;
            }
        }

        private void txtTablas_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (txtTablas.Text)
            {
                case "Usuarios":
                    ConsultaXT = "select * from Usuarios";
                    break;
                case "Bitacora":
                    ConsultaXT = "select * from Bitacora";
                    break;
                case "UsuarioPatente":
                    ConsultaXT = "select * from UsuarioPatente ";
                    break;
                case "UsuarioFamilia":
                    ConsultaXT = " select * from UsuarioFamilia ";
                    break;
                case "FamiliaPatente":
                    ConsultaXT = " select * from FamiliaPatente ";
                    break;
                case "Familia":
                    ConsultaXT = "select * from Familia  ";
                    break;
                case "Patente":
                    ConsultaXT = " select * from Patente ";
                    break;
                case "DVV":
                    ConsultaXT = "select * from DVV ";
                    break;
                default:
                    registros.Text = "Error al seleccionar Tabla";
                    registros.Visible = false;
                    break;
            }
        }
        private void RecalcularDVxT_Click(object sender, EventArgs e)
        {

            if (ConsultaXT != "")
            {
                DigitosVerificadores.GrabarPorTabla(ConsultaXT);
                registros.Text = "**Se generaron los digitos verificadores de la Tabla **";
                registros.Visible = true;
            }
            else
            {
                registros.Text = "**Ocurrio un error**";
                registros.Visible = true;
            }
        }
    }
}
