using System;
using BE;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Collections.Generic;
using System.Data;
using DAL_Datos;

namespace UI
{
    public partial class Log : Form
    {
        private Pantalla_Principal_C Form_Pantalla_Principal_C;
        private LogUI logUI;
        private UsuarioBE UBE;
        private UsuarioBE UsuBe;
        public int contador { get; private set; }
        public UsuarioFamiliaBE UsuFam { get; private set; }
        public UsuarioPatenteBE UsuPat { get; private set; }
        public FamiliaPatenteBE FamPat { get; private set; }
        public List<PatenteBE> ListPat { get; set; }
        public List<FamiliaBE> ListFam { get; set; }
        public FamiliaBE Fam { get; private set; }
        public PatenteBE Pat { get; private set; }

        //public DataTable DT { get; set; }
        //DataRow DR;
        public Log()
        {
            InitializeComponent();
        }
        #region Form Methods
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        private void txtuser_Enter(object sender, EventArgs e)
        {
            if (txtuser.Text == "NombreUsuario")
            {
                txtuser.Text = "";
                txtuser.ForeColor = Color.WhiteSmoke;
            }
        }

        private void txtuser_Leave(object sender, EventArgs e)
        {
            if (txtuser.Text == "")
            {
                txtuser.Text = "NombreUsuario";
                txtuser.ForeColor = Color.Silver;
            }
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text == "Contraseña")
            {
                txtpass.Text = "";
                txtpass.ForeColor = Color.WhiteSmoke;
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = "Contraseña";
                txtpass.ForeColor = Color.Silver;
                txtpass.UseSystemPasswordChar = false;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Globales.Idioma != "Espanol" && Globales.Idioma != null)
            {
                txtuser.Text = Recursos.Multidioma.CambiarIdioma(txtuser.Text);
                txtpass.Text = Recursos.Multidioma.CambiarIdioma(txtpass.Text);
            }

            UsuFam = new UsuarioFamiliaBE();
            FamPat = new FamiliaPatenteBE();
            Fam = new FamiliaBE();
            Pat = new PatenteBE();
            logUI = new LogUI();
            UBE = new UsuarioBE();
            //UBE.Familias = new List<FamiliaBE>();
            //UBE.Patentes = new List<PatenteBE>();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {

            if (txtuser.Text != " " && txtpass.Text != " ")
            {

                if (txtuser.TextLength >= 6 && txtuser.TextLength <= 19 && txtpass.TextLength >= 6 && txtpass.TextLength <= 19)
                {
                    string nombreUsuario = txtuser.Text;
                    string contraseña = txtpass.Text;

                    nombreUsuario = nombreUsuario.Replace("'", " ");
                    contraseña = contraseña.Replace("'", " ");

                    // Validar LOG de Usuario
                    UsuBe = new UsuarioBE(nombreUsuario, BLL.UsuarioBLL.GetMD5(contraseña)); //BLL.UsuarioBLL.GetMD5(contraseña)
                    IniciarSesion();
                    //Si existe el usuario, la contraseña y no esta bloqueado
                    if (BLL.UsuarioBLL.GetInstance().Validar(UsuBe) == true)
                    {
                        //Busco la lista de familias del Usuario 
                        // UsuFam = new UsuarioFamiliaBE();
                        UsuFam.ID_Usuario = UsuBe.IDUsuario;

                        List<UsuarioFamiliaBE> ListUsuFam = new List<UsuarioFamiliaBE>();
                        ListUsuFam = BLL.UsuarioBLL.GetInstance().BuscarUsuarioIDFamilias(UsuFam.ID_Usuario);

                        UsuBe.Familias = new List<UsuarioFamiliaBE>();
                        UsuBe.Patentes = new List<PatenteBE>();

                        foreach (UsuarioFamiliaBE UsuFam in ListUsuFam)
                        {
                            //por cada fila de usuario familia guardamos eso en el objecto de usuario
                            UsuBe.Familias.Add(UsuFam);

                            //por cada familia busco la lista de Patentes de la familia 
                            int ID_Familia = UsuFam.ID_Familia;
                            
                            //patentes es una lista de objetos
                            
                            List<FamiliaPatenteBE> ListFamPat = new List<FamiliaPatenteBE>();
                            
                            ListFamPat = BLL.FamiliaBLL.GetInstance().BuscarPatentesconIDFamilia(ID_Familia);
                            
                            foreach (FamiliaPatenteBE FamPat in ListFamPat)
                            {
                                int patenteId = FamPat.ID_Patente;
                                UsuBe.Patentes.Add(new PatenteBE(patenteId));
                            }

                        }
                        //Busco la lista de Patentes del Usuario
                        
                        List<UsuarioPatenteBE> ListUsuPat = new List<UsuarioPatenteBE>();
                        ListUsuPat = BLL.UsuarioBLL.GetInstance().BuscarUsuarioIDPatentes(UsuBe.IDUsuario);
                        //por cada usuario patente solo agarro los id de las patentes
                        foreach (UsuarioPatenteBE UsuPat in ListUsuPat)
                        {
                            int patenteId = UsuPat.ID_Patente;
                            UsuBe.Patentes.Add(new PatenteBE(patenteId));
                        }

                        PasarPatentes();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Contraseña Erronea");
                        txtpass.Text = null;
                        txtuser.Text = null;
                        contador += 1;
                    }

                    if (contador == 3)
                    {
                        MessageBox.Show("Superó la cantidad de intentos");

                        // Bloquear usuario
                        if (BLL.UsuarioBLL.GetInstance().bloquearUsuario(UsuBe) == true)
                        {
                            MessageBox.Show("El usuario ha sido bloqueado");
                        }
                        Application.Exit();
                    }
                }
                else
                {
                    msgError("Nombre de usuario y pass deben tener igual o mayor a 7 y no mas de 20  ");
                    MessageBox.Show("Nombre de usuario y pass deben tener igual o mayor a 7 y no mas de 20  ");
                }
            }
            else
            {
                MessageBox.Show("ingresar datos ");
            }
        }
        protected void IniciarSesion()
        {
            logUI.User = UsuBe.NombreUsuario ;
            logUI.Pass = UsuBe.Contraseña;
            UBE = logUI.Identificarse(true);

            if (UBE.NombreUsuario != null && UBE.Contraseña != null )
            {
                UsuBe.NombreUsuario = UBE.NombreUsuario;
                UsuBe.Contraseña = UBE.Contraseña;
                UsuBe.IDUsuario = int.Parse(UBE.IDUsuario.ToString());
               
            }
            else
            {
                lblErrorMessage.Text = "Usuario o contraseña incorrectos";
                lblErrorMessage.ForeColor = Color.Red;
               
            }
        }
        void PasarPatentes()
        {
            Form_Pantalla_Principal_C = new Pantalla_Principal_C();
            //Le paso al usuario al UI MDI
            Form_Pantalla_Principal_C.Form_Log = this;
            Form_Pantalla_Principal_C.UsuarioCache = UBE;
            Form_Pantalla_Principal_C.UsuarioCache.Familias = UBE.Familias;
            Form_Pantalla_Principal_C.UsuarioCache.Patentes = UBE.Patentes;
            Form_Pantalla_Principal_C.UsuFam = UsuFam;
            Form_Pantalla_Principal_C.UsuPat = UsuPat;
            Form_Pantalla_Principal_C.FamPat = FamPat;
            Form_Pantalla_Principal_C.ListadoPatenteFam = ListPat;
            Form_Pantalla_Principal_C.ListadoFamilia = ListFam;

            Form_Pantalla_Principal_C.Show();
        }

        private void msgError(string msg)
        {
            lblErrorMessage.Text = "    " + msg;
            lblErrorMessage.Visible = true;
        }

        private void Logout(object sender, FormClosedEventArgs e)
        {
            txtpass.Text = "contraseña";
            txtpass.UseSystemPasswordChar = false;
            txtuser.Text = "nombreUsuario";
            lblErrorMessage.Visible = false;
            this.Show();
        }

        private void linkpass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var recoverPassword = new Recuperar_Contraseña();
            recoverPassword.ShowDialog();

        }
        private void Ayuda(object sender, HelpEventArgs hlpevent)
        {
            Help.ShowHelp(this, Path.Combine(Application.StartupPath, "Ayuda.chm"), "Sesion.htm");
        }

    }
}


        

    

