using BE;
using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UI
{
    public partial class Consulta_Usuario : Form
    {
        private Actualizar_Usuario Form_Actualizar_Usuario;
        private Alta_Usuario Form_Alta_Usuario;
        public List<UsuarioBE> ListadoUsuario { get; set; }
        public List<UsuarioBE> ListadoUsuarioID { get; set; }
        public List<PatenteBE> ListaPatentes { get; set; }

        string UsuarioNombre;

        public Consulta_Usuario()
        {
            InitializeComponent();
        }

        private void btn_Actualizar_Usuario_Click(object sender, EventArgs e)
        {
            Form_Actualizar_Usuario = new Actualizar_Usuario();
            Form_Actualizar_Usuario.UsuarioNombre = UsuarioNombre;
            Form_Actualizar_Usuario.Show();
        }

        private void btn_Agregar_Usuario_Click(object sender, EventArgs e)
        {
            Form_Alta_Usuario = new Alta_Usuario();
            Form_Alta_Usuario.Show();
        }

        private void Consulta_Usuario_Load(object sender, EventArgs e)
        {
            //Idioma de la pantalla 
            if ((Globales.Idioma == "Español                       " && btn_ConsultaUsuario_Consultar.Text != "Consultar") || (BE.Globales.Idioma == "Ingles                        " && btn_ConsultaUsuario_Consultar.Text == "Consultar"))
            {
                label2.Text = Recursos.Multidioma.CambiarIdioma(label2.Text);
                label1.Text = Recursos.Multidioma.CambiarIdioma(label1.Text);
                btn_Agregar_Usuario.Text = Recursos.Multidioma.CambiarIdioma(btn_Agregar_Usuario.Text);
                btn_Actualizar_Usuario.Text = Recursos.Multidioma.CambiarIdioma(btn_Actualizar_Usuario.Text);
                btn_ConsultaUsuario_Eliminar.Text = Recursos.Multidioma.CambiarIdioma(btn_ConsultaUsuario_Eliminar.Text);
                btn_ConsultaUsuario_Consultar.Text = Recursos.Multidioma.CambiarIdioma(btn_ConsultaUsuario_Consultar.Text);
                this.Text = Recursos.Multidioma.CambiarIdioma(this.Text);
            }

            dgConsultaUsuario.RowHeadersVisible = false;
            //Llamo a listar usuarios 
            ListadoUsuario = new List<UsuarioBE>();

            BLL.UsuarioBLL.GetInstance().ListarUsuario(ListadoUsuario);

            dgConsultaUsuario.DataSource = null;
            dgConsultaUsuario.DataSource = ListadoUsuario;
            //dgConsultaUsuario.Columns[0].Visible = false;
            //dgConsultaUsuario.Columns[2].Visible = false;
            //dgConsultaUsuario.Columns[12].Visible = false;

        }

        private void btn_ConsultaUsuario_Consultar_Click(object sender, EventArgs e)
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

        private void btn_ConsultaUsuario_Eliminar_Click(object sender, EventArgs e)
        {
            if (UsuarioNombre == "" || UsuarioNombre == " " || UsuarioNombre == null)
            {
                MessageBox.Show("Seleccione el usuario a eliminar");
            }
            else
            {
                //Borrar el usuario y verifico si tengo otro usuario con alguna de las patentes asignadas
                ListaPatentes = new List<PatenteBE>();
                ListaPatentes = BLL.PatenteBLL.GetInstance().ListarPatentes(ListaPatentes);
                int contador = 0;

                foreach (PatenteBE pat in ListaPatentes)
                {
                    if (BLL.UsuarioBLL.GetInstance().HayUsuariosConPatentes(UsuarioNombre, pat) == false)
                    {
                        contador += 1;
                    }
                }

                if (contador != 0)
                {
                    MessageBox.Show("No pueden quedar usuarios sin patentes");
                }
                else
                {
                    if (BLL.UsuarioBLL.GetInstance().EliminarUsuario(UsuarioNombre) == true)
                    {
                        MessageBox.Show("Usuario eliminado");
                    }

                    //Actualizar lista
                    ListadoUsuario = new List<UsuarioBE>();

                    BLL.UsuarioBLL.GetInstance().ListarUsuario(ListadoUsuario);

                    dgConsultaUsuario.DataSource = null;
                    dgConsultaUsuario.DataSource = ListadoUsuario;

                    dgConsultaUsuario.Columns[0].Visible = false;
                }
            }
        }

        private void dgConsultaUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UsuarioNombre = dgConsultaUsuario.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
            btn_ConsultaUsuario_Eliminar.Enabled = true;
            btn_Actualizar_Usuario.Enabled = true;
        }
        private void Ayuda(object sender, HelpEventArgs hlpevent)
        {
            Help.ShowHelp(this, Path.Combine(Application.StartupPath, "Ayuda.chm"), "BajaUsuario.htm");
        }
    }

}
