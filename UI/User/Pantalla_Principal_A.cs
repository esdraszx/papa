using System;
using BE;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace UI
{
    public partial class Pantalla_Principal_A : System.Windows.Forms.Form
    {
        private Consulta_Visitante Form_Consulta_Cliente;
        private Consulta_Empleado Form_Consulta_Choferes;
        private Entradas Form_Consulta_Dueño;
        private Consulta_Empresa Form_Consulta_Auto;
        private Salidas Form_Consulta_Pedido;
        //private FormIdioma Form_Idioma;
        private Restaurar_Backup Form_RestaurarBackup;
        private Alta_Backup Form_AltaBackup;
        private Apertura_Planilla Form_Apertura_Planilla;
        private Cerrar_Planilla Form_Cerrar_Planilla;
        private Consulta_Usuario Form_Consulta_Usuario;
        private Consulta_Usuario_Patente Form_Consulta_Usuarios_y_Patentes;
        private Consulta_Familia_Patente Form_ConsultaFamiliasyPantentes;
        private Depurar_Bitacora Form_Depuración_Bitácora;
        private Consulta_Bitacora Form_Cosulta_Bitacora;
        private StringConexion Form_StringConexion;
        public List<PatenteBE> ListadoPatenteFam { get; set; }
        public List<UsuarioBE> ListadoUsuarios { get; set; }
        internal UsuarioBE UsuarioActivo = new UsuarioBE();
        internal Log Form_Log;

        public Pantalla_Principal_A()
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
        //METODO DE ABRIR FORMULARIO EN EL PANEL CONTENEDOR//METHOD OF OPENING FORM IN THE CONTAINER PANEL
        //MULTI-WINDOW- ABRIR VARIOS FORMULARIOS DENTRO DE PANEL 
        private void openFormOnPanel<MiForm>() where MiForm : System.Windows.Forms.Form, new()
        {
            System.Windows.Forms.Form formulario;
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

        //METODO/EVENTO AL CERRAR FORMS//METHOD / EVENT WHEN CLOSING FORMS
        private void closedForm(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms["Form1"] == null)
            {
                btnPermisos.BackColor = Color.FromArgb(37, 54, 75);
                //More Codes
            }
               
            if (Application.OpenForms["Form2"] == null){
                btnClinicalHistory.BackColor = Color.FromArgb(37, 54, 75);
                //More Codes
            }
            if (Application.OpenForms["Form3"] == null)
            {
               btnCalendar.BackColor = Color.FromArgb(37, 54, 75);
                //More Codes
            }
            if (Application.OpenForms["FormUserProfile"] == null)
            {
                timer1.Stop(); //We stop the timer once the user finishes editing his profile And closes the form
            //Detenemos el temporizador una vez que el usuario termine de editar su perfil y cierre el formulario
            //More Codes
            }
        }

        #endregion
        #region LOGOUT AND APPLICATION EXIT

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to close the application?", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Application.Exit();
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to log out?", "Warning",
               MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                this.Close();
        }
        #endregion
        //LOAD
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            seecurity();
            LoadUserData();
            ManagePermissions();
        }

        private void LoadUserData()
        {
            //lblUserName.Text = UserCache.LoginName;
            //lblPosition.Text = UserCache.Position;
            //lblEmail.Text = UserCache.Email;
        }

        private void seecurity() {
            //var userModel = new UserModel();
            //if (userModel.securityLogin() == false) {
            //    MessageBox.Show("Error Fatal, se detectó que está intentando acceder al sistema sin credenciales, por favor inicie sesion e indetifiquese\n"+
            //        "Fatal error, it was detected that you are trying to access the system without credentials, please login and unsubscribe");
            //    Application.Exit();
            //}
        }
        private void ManagePermissions()
        {
            //Manage Permissions
            //if (UserCache.Position == Positions.Accounting)
            //{
            //    btnPacient.Enabled = false;
            //    btnClinicalHistory.Enabled = false;
            //}
            //if (UserCache.Position == Positions.Receptionist)
            //{
            //    Button2.Enabled = false;
            //}
            //if (UserCache.Position == Positions.Administrator)
            //{
            //    //Codes
            //}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadUserData(); //update the user's data in the menu (in this form), every 1 second at the time of the edition, on user profile form
                            //actualizar los datos del usuario en el menu de este formulario, cada 1 segundo al momento de la edicion en el formulario perfil de usuario.
        }
        //"BUTTONS TO OPEN FORMS "
        private void btnPacient_Click(object sender, EventArgs e)
        {
            openFormOnPanel<Apertura_Planilla>();
            btnPermisos.BackColor = Color.FromArgb(0, 100, 182);
        }

        private void btnClinicalHistory_Click(object sender, EventArgs e)
        {
            openFormOnPanel<Cerrar_Planilla>();
            btnClinicalHistory.BackColor = Color.FromArgb(0, 100, 182);
        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {
            openFormOnPanel<Alta_Usuario>();
            btnCalendar.BackColor = Color.FromArgb(0, 100, 182);
        }

        private void ptbProfile_Click(object sender, EventArgs e)
        {
            openFormOnPanel<Alta_Empleado>();
            timer1.Start();
        }

        private void linkProfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFormOnPanel<Alta_Empleado>();
            timer1.Start();
        }
        private void Ayuda(object sender, HelpEventArgs hlpevent)
        {
            Help.ShowHelp(this, Path.Combine(Application.StartupPath, "Ayuda.chm"), "Sesion.htm");
        }

    }
}
