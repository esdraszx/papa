using System;
using System.Collections.Generic;
using System.IO;
using BE;
using System.Windows.Forms;

namespace UI
{
    public partial class Actualizar_Usuario : Form
    {
        public string UsuarioNombre { get; set; }
        public List<UsuarioBE> Usu { get; set; }
        public List<UsuarioBE> ListadoUsuario { get; set; }
        public List<UsuarioBE> ListadoUsuarioID { get; set; }
        // public List<BE.Patente> ListaPatentes { get; set; }
        string Usuario;
        int ID_Usuario;

        public Actualizar_Usuario()
        {
            InitializeComponent();
            //inicializamos los controles de edicion en el contructor/ antes de cargar el evento load
            initializeEditControls();
        }

        private void FormUserProfile_Load(object sender, EventArgs e)
        {
               
        }

        private void loadUserData()
        { //Cargamos los datos a las etiquetas y textboxs
          //Profile view. Vista de perfil
            //lblLastName.Text = UserCache.LastName;
            //lblMail.Text = UserCache.Email;
            //lblUser.Text = UserCache.LoginName;
            //lblName.Text = UserCache.FirstName;
            ////Edit view. vista Editar
            //txtEmail.Text = UserCache.Email;
            //txtFirstName.Text = UserCache.FirstName;
            //txtLastName.Text = UserCache.LastName;
            //txtPassword.Text = UserCache.Password;
            //txtConfirmPass.Text = UserCache.Password;
            //txtUsername.Text = UserCache.LoginName;
        }

        private void initializeEditControls()
        {
            Panel1.Visible = false;
            LinkEditPass.Text = "Edit";
            label13.Visible = false;
            txtTelefono.UseSystemPasswordChar = true;
            txtTelefono.Enabled = false;
            txtPalabraRestitucion.UseSystemPasswordChar = true;
            txtPalabraRestitucion.Visible = false;
        }

        private void reset()
        {
            initializeEditControls();
            loadUserData();
        }
        
        private void linkEditProfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Panel1.Width = 10;
            Panel1.Visible = true;
            Timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Panel1.Width += 20;
            if (Panel1.Width >= 400)
            {
                Timer1.Stop();
            }
        }

        private void LinkEditPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (LinkEditPass.Text == "Edit")
            {
                LinkEditPass.Text = "Cancel";
                label13.Visible = true;
                txtTelefono.Enabled = true;
                txtTelefono.Text = "";
                txtPalabraRestitucion.Text = "";
                txtPalabraRestitucion.Visible = true;
            }
            else if (LinkEditPass.Text == "Cancel")
            {
                //reiniciamos solo en editar contraseña // We restart only in edit password
                LinkEditPass.Text = "Edit";
                label13.Visible = false;
                txtTelefono.Enabled = false;
                //txtPassword.Text = UserCache.Password;
                //txtConfirmPass.Text =UserCache.Password;
                txtPalabraRestitucion.Visible = false;
            }
        }
        
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Actualizar_Usuario_Load(object sender, EventArgs e)
        {
            loadUserData();
            //Leer el usuario que voy a actualizar y cargar los datos

            Usu = BLL.UsuarioBLL.GetInstance().BuscarunUsuarioID(ID_Usuario);
            
            txtNombreUsuario.Text = Usu[1].NombreUsuario;
            txtNombre.Text = Usu[3].Nombre;
            txtApellido.Text = Usu[4].Apellido;
            txtEmail.Text = Usu[6].Email;
            txtDNI.Text = Usu[11].DNI;
            txtDireccion.Text = Usu[5].Direccion;
            txtPalabraRestitucion.Text = Usu[8].PalabraRestitucion;
            txtTelefono.Text = Usu[7].Telefono;

            //Idioma de la pantalla 
            if ((BE.Globales.Idioma == "Español                       " && btnActualizar_Usuario_Aceptar.Text != "Aceptar") || (BE.Globales.Idioma == "Ingles                        " && btnActualizar_Usuario_Aceptar.Text == "Aceptar"))
            {
                label2.Text = Recursos.Multidioma.CambiarIdioma(label2.Text);
                label3.Text = Recursos.Multidioma.CambiarIdioma(label3.Text);
                Label5.Text = Recursos.Multidioma.CambiarIdioma(Label5.Text);
                Label4.Text = Recursos.Multidioma.CambiarIdioma(Label4.Text);
                label9.Text = Recursos.Multidioma.CambiarIdioma(label9.Text);
                Label11.Text = Recursos.Multidioma.CambiarIdioma(Label11.Text);
                label2.Text = Recursos.Multidioma.CambiarIdioma(label2.Text);
                label10.Text = Recursos.Multidioma.CambiarIdioma(label10.Text);
                
                btnActualizar_Usuario_Aceptar.Text = Recursos.Multidioma.CambiarIdioma(btnActualizar_Usuario_Aceptar.Text);
                btn_Cancelar_Actualizar_Usuario.Text = Recursos.Multidioma.CambiarIdioma(btn_Cancelar_Actualizar_Usuario.Text);


                this.Text = Recursos.Multidioma.CambiarIdioma(this.Text);
            }

            dgConsultaUsuario.RowHeadersVisible = false;
            //Llamo a listar usuarios 
            ListadoUsuario = new List<BE.UsuarioBE>();

            BLL.UsuarioBLL.GetInstance().ListarUsuario(ListadoUsuario);

            dgConsultaUsuario.DataSource = null;
            dgConsultaUsuario.DataSource = ListadoUsuario;

            dgConsultaUsuario.Columns[0].Visible = false;
            dgConsultaUsuario.Columns[13].Visible = false;
        }

        private void btnActualizar_Usuario_Aceptar_Click(object sender, EventArgs e)
        {
            //Aceptar
            //Actualizo los datos 
            //Los campos DNI, NOMBRE y MAIL NO SE PUEDEN ACTUALIZAR

            //Cargo el objeto BE
            UsuarioBE UsuActu = new UsuarioBE();
            UsuActu.NombreUsuario = txtNombreUsuario.Text;
            UsuActu.Nombre = txtNombre.Text;
            UsuActu.Apellido = txtApellido.Text;
            UsuActu.Email = txtEmail.Text ;
            UsuActu.DNI = txtDNI.Text;
            UsuActu.Direccion = txtDireccion.Text;
            UsuActu.PalabraRestitucion = txtPalabraRestitucion.Text;
            UsuActu.Telefono = txtTelefono.Text;

            if (BLL.UsuarioBLL.GetInstance().ActualizarUsuario(UsuActu) == true)
            {
                MessageBox.Show("Actualizacion Realizada");
            }
        }

        private void btn_Cancelar_Actualizar_Usuario_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void dgConsultaUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UsuarioNombre = dgConsultaUsuario.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
            //btn_ConsultaUsuario_Eliminar.Enabled = true;
            //btn_Actualizar_Usuario.Enabled = true;
        }

        private void btn_ConsultarUsuario_Consultar_Click(object sender, EventArgs e)
        {
            //Consulto un usuario específico por ID

            if (txt_ConsultaUsuario_ID.Text != "")
            {
                dgConsultaUsuario.DataSource = null;
                dgConsultaUsuario.DataSource = BLL.UsuarioBLL.GetInstance().BuscarunUsuarioID(int.Parse(txt_ConsultaUsuario_ID.Text));
                dgConsultaUsuario.Columns[0].Visible = false;

            }

            if (txt_ConsultaUsuario_DNI.Text != "")
            {
                dgConsultaUsuario.DataSource = null;
                dgConsultaUsuario.DataSource = BLL.UsuarioBLL.GetInstance().BuscarunUsuarioDNI(txt_ConsultaUsuario_DNI.Text);
                dgConsultaUsuario.Columns[0].Visible = false;

            }

            if (txt_ConsultaUsuario_DNI.Text == "" && txt_ConsultaUsuario_ID.Text == "")
            {
                MessageBox.Show("Ingrese ID o DNI para la búsqueda");
            }
            txt_ConsultaUsuario_ID.Text = null;
            txt_ConsultaUsuario_DNI.Text = null;
        }
    }
}
