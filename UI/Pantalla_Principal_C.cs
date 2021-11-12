using System;
using BE;
using BLL;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;

namespace UI
{
    public partial class Pantalla_Principal_C : Form
    {
        public List<PatenteBE> ListadoPatenteFam { get; set; }
        public List<FamiliaBE> ListadoFamilia { get; set; }
        public List<UsuarioBE> ListadoUsuarios { get; set; }
        public UsuarioFamiliaBE UsuFam { get; set; }
        public UsuarioPatenteBE UsuPat { get; set; }
        public FamiliaPatenteBE FamPat { get; set; }
        public UsuarioBE UsuarioCache = new UsuarioBE();
        //private UsuarioBE UBE;
        private LogUI logUI;
        internal Log Form_Log;

        public Pantalla_Principal_C()
        {
            InitializeComponent();
        }
        #region "FUNCIONALIDADES DEL FORMULARIO// FUNCTIONALITIES OF THE FORM"
        // 'RESIZE DEL FORMULARIO- CAMBIAR TAMAÑO//RESIZE OF THE FORM- CHANGE SIZE------------------------------------------------
        private int tolerance = 12;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        //----------------DIBUJAR RECTANGULO / EXCLUIR ESQUINA PANEL/// DRAW RECTANGLE / EXCLUDE CORNER PANEL
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));

            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);

            region.Exclude(sizeGripRectangle);
            this.panelContenedor.Region = region;
            this.Invalidate();
        }
        //----------------COLOR Y GRIP DE RECTANGULO INFERIOR/ESQUINA//COLOR AND GRIP OF LOWER RECTANGLE/CORNER
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(244, 244, 244));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);

            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }


      //MINIMIZAR, MAXIMIZAR, RESTAURAR EL FORMULARIO
        int lx, ly;
        int sw, sh;
        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
        }
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //ARRASTRAR/ MOVER EL FORMULARIO///DRAG / MOVE THE FORM
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelBarraTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }    

#endregion 
        #region OPEN AND CLOSE FORM METHODS
        //METODO DE ABRIR FORMULARIO EN EL PANEL CONTENEDOR
        //MULTI-WINDOW- ABRIR VARIOS FORMULARIOS DENTRO DE PANEL 
        private void openFormOnPanel<MiForm>() where MiForm : System.Windows.Forms.Form, new()
        {
            Form formulario;
            formulario = panelformularios.Controls.OfType<MiForm>().FirstOrDefault();//Busca el formulario en la colecion.
            //si el formulario/instancia no existe/crea           
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelformularios.Controls.Add(formulario);
                panelformularios.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
                formulario.FormClosed += new FormClosedEventHandler(closedForm);
            }

            else {
                //si la Formulario / instancia existe, lo traemos a frente
                formulario.BringToFront();
            }
        }

        //METODO/EVENTO AL CERRAR FORMS
        private void closedForm(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms["Form1"] == null)
            {
                btnEntradas.BackColor = Color.FromArgb(37, 54, 75);
               
            }
               
            if (Application.OpenForms["Form2"] == null){
                btnPlanillas.BackColor = Color.FromArgb(37, 54, 75);
                
            }
            if (Application.OpenForms["Form3"] == null)
            {
               btnEventos.BackColor = Color.FromArgb(37, 54, 75);
                
            }
            if (Application.OpenForms["FormUserProfile"] == null)
            {
                timer1.Stop();
            //Detenemos el temporizador una vez que el usuario termine de editar su perfil y cierre el formulario
          
            }
        }

        #endregion
        #region LOGOUT AND APPLICATION EXIT

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea cerrar la app?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Application.Exit();
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro de cerrar sesion ?", "Confirmar",
               MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                this.Close();
        }
        #endregion
        //LOAD
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            Seguridad();
            CargoUsuario();

            UsuarioBE Usu = new UsuarioBE(Globales.UsuarioCacheNomUsu, "");
            Permisos();
            //Cargo las patentes del usuario
           // UsuFam = new UsuarioFamiliaBE();
            //FamPat = new FamiliaPatenteBE();
            UsuPat = new UsuarioPatenteBE();
            UsuPat.ID_Usuario = UsuarioCache.IDUsuario;
            UsuarioBLL.GetInstance().CargarPatentesPorUsuario(UsuPat);
            UsuarioCache = UsuarioBLL.GetInstance().UsuarioPatente(UsuarioCache);

            foreach (PatenteBE pat in UsuarioCache.Patentes)
            {
                switch (pat.Detalle)
                {
                    case "PA0001":
                        ConfigToolStripMenuItem.Enabled = false;
                        break;
                    case "PS0001":
                        aBMToolStripMenuItem.Enabled = false;
                        break;
                    case "PS0002":
                        cONSULTASToolStripMenuItem.Enabled = false;
                        break;
                    case "PS0003":
                        rEPORTESToolStripMenuItem.Enabled = false;
                        break;
                    case "PSU0001":
                        bITÁCORAToolStripMenuItem.Enabled = false;
                        break;
                    case "PSU0002":
                        bACKUPToolStripMenuItem.Enabled = false;
                        break;
                    case "SU0003":
                        pERMISOSToolStripMenuItem.Enabled = false;
                        break;
                    case "PU0001":
                        planillaToolStripMenuItem.Enabled = false;
                        break;
                    case "PU0002":
                        diarioToolStripMenuItem.Enabled = false;
                        break;
                    case "PU0003":
                        consultaToolStripMenuItem.Enabled = false;
                        break;
                    case "PU0004":
                        abrirPlanillaToolStripMenuItem.Enabled = false;
                        break;
                }
            }

            //Verificar Familias
            //1- Cargar las familias de usuario (SELECT * FROM USUARIO_FAMILIA WHERE ID_USUARIO = USUARIOACTIVO)
            // public BE.Usuario FamiliasPorUsuario(BE.Usuario u)
            UsuFam = new UsuarioFamiliaBE();
            UsuFam.ID_Usuario = UsuarioCache.IDUsuario;
            UsuarioBLL.GetInstance().CargarFamiliasPorUsuario(UsuFam);
            UsuFam = BLL.UsuarioBLL.GetInstance().CargarFamiliasPorUsuario(UsuFam);

            //2- Cargar todas las patentes de cada familia (SELECT * FROM FAMILIA_PANTENTE WHERE ID_FAMILIA = LISTADO FAMILIAS)
            //public List<BE.Patente> ListarPatentesFamilia(List<BE.Patente> ListPat, BE.Familia Fam)
            ListadoPatenteFam = new List<PatenteBE>();
            foreach (FamiliaBE fam in Usu.Familias)
            {
                ListadoPatenteFam = FamiliaBLL.GetInstance().ListarPatentesFamilia(ListadoPatenteFam, fam);
            }

            foreach (PatenteBE pat in ListadoPatenteFam)
            {
                switch (pat.Detalle)
                {
                    case "PA0001":
                        ConfigToolStripMenuItem.Enabled = false;
                        break;
                    case "PS0001":
                        aBMToolStripMenuItem.Enabled = false;
                        break;
                    case "PS0002":
                        cONSULTASToolStripMenuItem.Enabled = false;
                        break;
                    case "PS0003":
                        rEPORTESToolStripMenuItem.Enabled = false;
                        break;
                    case "PSU0001":
                        bITÁCORAToolStripMenuItem.Enabled = false;
                        break;
                    case "PSU0002":
                        bACKUPToolStripMenuItem.Enabled = false;
                        break;
                    case "SU0003":
                        pERMISOSToolStripMenuItem.Enabled = false;
                        break;
                    case "PU0001":
                        planillaToolStripMenuItem.Enabled = false;
                        break;
                    case "PU0002":
                        diarioToolStripMenuItem.Enabled = false;
                        break;
                    case "PU0003":
                        consultaToolStripMenuItem.Enabled = false;
                        break;
                    case "PU0004":
                        abrirPlanillaToolStripMenuItem.Enabled = false;
                        break;
                }
            }
            
            this.FormClosing += Pantalla_Principal_C_FormClosing;
        }

        private void CargoUsuario()
        {
            lblUserName.Text = UsuarioCache.Apellido;
            lblDNI.Text = UsuarioCache.DNI;
            lblEmail.Text = UsuarioCache.Email;
        }

        private void Seguridad()
        {
            var usuarioBE = new UsuarioBE();
            if (usuarioBE.Activo != false)
            {
                MessageBox.Show("Error Fatal, se detectó que está intentando acceder al sistema sin credenciales, por favor inicie sesion e indetifiquese\n" +
                    "Fatal error, it was detected that you are trying to access the system without credentials, please login and unsubscribe");
                Application.Exit();
            }
        }
        private void Permisos()
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CargoUsuario(); 
                            //actualizar los datos del usuario en el menu de este formulario, cada 1 segundo al momento de la edicion en el formulario perfil de usuario.
        }
        //"Borones para abrir otros formularios "

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void panelformularios_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnEntrada_Click(object sender, EventArgs e)
        {
            openFormOnPanel<Entradas>();
            btnEntradas.BackColor = Color.FromArgb(0, 100, 182);
        }

        private void btnPlanillas_Click(object sender, EventArgs e)
        {
            openFormOnPanel<Apertura_Planilla>();
            btnPlanillas.BackColor = Color.FromArgb(0, 100, 182);
        }

        private void btnEventos_Click(object sender, EventArgs e)
        {
            openFormOnPanel<Registro_Evento>();
            btnEventos.BackColor = Color.FromArgb(0, 100, 182);
        }

        private void Idioma_Click(object sender, EventArgs e)
        {
            openFormOnPanel<Idioma>();
            btnEventos.BackColor = Color.FromArgb(0, 100, 182);
        }

        private void ptbProfile_Click(object sender, EventArgs e)
        {
            openFormOnPanel<Alta_Empleado>();
            btnEventos.BackColor = Color.FromArgb(0, 100, 182);
           // timer1.Start();
        }

        private void recalcularDVToolStripMenuItem_Click(object sender, EventArgs e)
        {

            openFormOnPanel<User.RecalcularDV>();
            btnEventos.BackColor = Color.FromArgb(0, 100, 182);
           // timer1.Start();
            ////Recalcula la integridad de la BD
            ////Usuario
            ////Leer usuario
            ////public List<BE.Usuario> ListarUsuarios(List<BE.Usuario> datUsu)
            //ListadoUsuarios = new List<UsuarioBE>();
            //ListadoUsuarios = UsuarioBLL.GetInstance().ListarUsuario(ListadoUsuarios);
            ////int sumarDVH = 0;
            //string sumaDVH = "";

            ////Calcular DVH
            //foreach (UsuarioBE u in ListadoUsuarios)
            //{
            //    BLL.UsuarioBLL.GetInstance().CalcualarDVH(u);
            //    sumaDVH += u.DVH;
            //    //Regraba DVH
            //    UsuarioBLL.GetInstance().ActualizarDVH(u);

            //}

            //Regraba DVV
            //UsuarioBLL.GetInstance().ActualizarDVV();

            //MessageBox.Show("Los DV han sido recalculados y la BD actualizada");
        }

        private void conexiónABDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFormOnPanel<StringConexion>();
            
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFormOnPanel<Consulta_Bitacora>();
        }

        private void depuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFormOnPanel<Depurar_Bitacora>();
        }

        private void familiaPatentesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openFormOnPanel<Consulta_Familia_Patente>();
        }

        private void UsuarioPatentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
             openFormOnPanel<Consulta_Usuario_Patente>();
        }

        private void ConsultaUsuariosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            openFormOnPanel<Consulta_Usuario>();
        }

        private void restaurarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFormOnPanel<Restaurar_Backup>();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFormOnPanel<Alta_Backup>();
        }

        private void visitantesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openFormOnPanel<Consulta_Visitante>();
        }

        private void empleadosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openFormOnPanel<Consulta_Empleado>();
        }

        private void empresasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openFormOnPanel<Consulta_Empresa>();
        }

        private void actualizarEoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openFormOnPanel<Actualizar_Empleado>();
        }

        private void actualizarZToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            openFormOnPanel<Actualizar_Zona>();
        }

        private void familiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFormOnPanel<Actualizar_Familia>();
        }

        private void actualizarVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFormOnPanel<Actualizar_Visitante>();
        }

        private void actualizarUToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            openFormOnPanel<Actualizar_Usuario>();
        }

        private void actualizarEaToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            openFormOnPanel<Actualizar_Empresa>();
        }

        private void zonasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFormOnPanel<Alta_Zona>();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFormOnPanel<Alta_Usuario>();
        }

        private void empresasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFormOnPanel<Alta_Empresa>();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFormOnPanel<Alta_Empleado>();
        }

        private void visitantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFormOnPanel<Alta_Visitante>();
        }

        private void actualizarFamiliaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFormOnPanel<Registro_Evento>();
        }

        private void diarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFormOnPanel<Apertura_Planilla>();
        }

        private void Pantalla_Principal_C_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form_Log.Close();
        }

        private void btnConsultas_Click(object sender, EventArgs e)
        {

        }

        private void planillaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFormOnPanel<Entradas>();
        }

        private void salidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFormOnPanel<Salidas>();
        }

        private void abrirPlanillaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFormOnPanel<Apertura_Planilla>();
        }

        private void cerrarPlanillaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFormOnPanel<Cerrar_Planilla>();
        }

        private void ConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigToolStripMenuItem.ShowDropDown();
        }

        private void aBMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aBMToolStripMenuItem.ShowDropDown();
        }

        private void rEPORTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            recalcularDVToolStripMenuItem.ShowDropDown();
        }

        private void cONSULTASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigToolStripMenuItem.ShowDropDown();
        }

        private void bITÁCORAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bITÁCORAToolStripMenuItem.ShowDropDown();
        }

        private void bACKUPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bACKUPToolStripMenuItem.ShowDropDown();
        }

        private void pERMISOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pERMISOSToolStripMenuItem.ShowDropDown();
        }

        private void linkProfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFormOnPanel<Entradas>();
            timer1.Start();
        }
        private void Ayuda(object sender, HelpEventArgs hlpevent)
        {

            Help.ShowHelp(this, Path.Combine(Application.StartupPath, "Ayuda.chm"), "PantallaPrincipal.htm");

        }
    }
}
