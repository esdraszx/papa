using BE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace UI
{
    public partial class Consulta_Usuario_Patente : Form
    {
        public  List<UsuarioBE> ListadoUsuario { get; set; }

        public List<PatenteBE> ListadoPatente { get; set; }
        public List<PatenteBE> ListaPatentes { get; private set; }
        public List<PatenteBE> ListadoPatentesBuscar { get; private set; }
        public List<PatenteBE> ListadoUsuarioPatente { get; set; }
        public List<UsuarioPatenteBE> ListadoUsuarioPatentes { get; set; }
        public List<FamiliaBE> ListadoUsuarioFamilia { get; private set; }
        public List<UsuarioFamiliaBE> ListadoUsuarioFamilias { get; private set; }
        public List<FamiliaBE> ListadoFamilia { get; set; }
        public List<FamiliaBE> ListadoFamiliaparaPatente { get; set; }
        public List<FamiliaBE> ListadoFamiliaUsuario { get; set; }
        UsuarioBE Usu = new UsuarioBE();
        
        string PatenteAgregar;
        string PatenteQuitar;
        string FamiliaSacar;
        string FamiliaAgregar;
        string UsuarioNombre;
       

        public Consulta_Usuario_Patente()
        {
            InitializeComponent();
        }

        private void btn_Cancelar_Consulta_Usuario_Patente_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Consulta_Usuario_Patente_Load(object sender, EventArgs e)
        {
            //Idioma de la pantalla 
            if ((BE.Globales.Idioma == "Español                       " && btn_Aceptar_Consulta_Usuario_Patente.Text != "Aceptar") || (BE.Globales.Idioma == "Ingles                        " && btn_Aceptar_Consulta_Usuario_Patente.Text == "Aceptar"))
            {
                label1.Text = Recursos.Multidioma.CambiarIdioma(label1.Text);
                label4.Text = Recursos.Multidioma.CambiarIdioma(label4.Text);
                btnBuscarUsuario.Text = Recursos.Multidioma.CambiarIdioma(btnBuscarUsuario.Text);
                label2.Text = Recursos.Multidioma.CambiarIdioma(label2.Text);
                label3.Text = Recursos.Multidioma.CambiarIdioma(label3.Text);
                label6.Text = Recursos.Multidioma.CambiarIdioma(label6.Text);
                label5.Text = Recursos.Multidioma.CambiarIdioma(label5.Text);
                btn_Aceptar_Consulta_Usuario_Patente.Text = Recursos.Multidioma.CambiarIdioma(btn_Aceptar_Consulta_Usuario_Patente.Text);
                btn_Cancelar_Consulta_Usuario_Patente.Text = Recursos.Multidioma.CambiarIdioma(btn_Cancelar_Consulta_Usuario_Patente.Text);


                this.Text = Recursos.Multidioma.CambiarIdioma(this.Text);
            }


            dgFamilias.RowHeadersVisible = false;
            dgFamiliasdeUsuario.RowHeadersVisible = false;
            dgPatentes.RowHeadersVisible = false;
            dgPatentesdeUsuario.RowHeadersVisible = false;
            dgUsuarios.RowHeadersVisible = false;

            //Llamo a listar usuarios 
            ListadoUsuario = new List<UsuarioBE>();
            BLL.UsuarioBLL.GetInstance().ListarUsuario(ListadoUsuario);
            dgUsuarios.DataSource = null;
            dgUsuarios.DataSource = ListadoUsuario;
            dgUsuarios.Columns[3].Visible = false;
            dgUsuarios.Columns[4].Visible = false;
            dgUsuarios.Columns[5].Visible = false; 
            dgUsuarios.Columns[6].Visible = false;
            dgUsuarios.Columns[7].Visible = false;
            dgUsuarios.Columns[8].Visible = false;
            dgUsuarios.Columns[10].Visible = false;
            dgUsuarios.Columns[11].Visible = false;
            dgUsuarios.Columns[12].Visible = false;
            
            //Listar Patentes
            ListadoPatente = new List<PatenteBE>();
            BLL.PatenteBLL.GetInstance().ListarPatentes(ListadoPatente);
            dgPatentes.DataSource = null;
            dgPatentes.DataSource = ListadoPatente;
            dgPatentes.Columns[0].Visible = false;
            dgPatentes.Columns[3].Visible = false;

            //Listar  Usuario Patentes
            ListadoUsuarioPatentes = new List<UsuarioPatenteBE>();
            Usu.UsuarioPatentes = ListadoUsuarioPatentes;
            BLL.UsuarioBLL.GetInstance().BuscarUsuarioPat(Usu);
            dgPatentesdeUsuario.DataSource = null;
            dgPatentesdeUsuario.DataSource = ListadoUsuarioPatentes;
            

            //Listar Familias
            ListadoFamilia = new List<FamiliaBE>();
            BLL.FamiliaBLL.GetInstance().ListarFamilia(ListadoFamilia);
            dgFamilias.DataSource = null;
            dgFamilias.DataSource = ListadoFamilia;
            dgFamilias.Columns[0].Visible = false;

            //Listar Usuario Familia
            ListadoUsuarioFamilias = new List<UsuarioFamiliaBE>();
            Usu.UsuarioFamilias = ListadoUsuarioFamilias;
            BLL.UsuarioBLL.GetInstance().UsaurioFamilia(Usu);
            dgFamiliasdeUsuario.DataSource = null;
            dgFamiliasdeUsuario.DataSource = ListadoUsuarioFamilias;

        }

        private void dgUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UsuarioNombre = dgUsuarios.Rows[e.RowIndex].Cells["IDUsuario"].Value.ToString();

            dgUsuarios.Columns[3].Visible = false;
            dgUsuarios.Columns[4].Visible = false;
            dgUsuarios.Columns[5].Visible = false;
            dgUsuarios.Columns[6].Visible = false;
            dgUsuarios.Columns[7].Visible = false;
            dgUsuarios.Columns[8].Visible = false;
            dgUsuarios.Columns[10].Visible = false;
            dgUsuarios.Columns[11].Visible = false;
            dgUsuarios.Columns[12].Visible = false;

            UsuarioBE Usu = new UsuarioBE();
            Usu.NombreUsuario = UsuarioNombre;
            Usu.IDUsuario = int.Parse(dgUsuarios.Rows[e.RowIndex].Cells["IDUsuario"].Value.ToString());
            //Listar Patentes del Usuario al se;eciomar del dg
            ListarPatentesUsuario();
            //Listar Familias del Usuario al seleciconarlo del dg
            ListarFamiliasUsuario();
        }

        public void ListarPatentesUsuario()
        {
            //Listar Patentes del Usuario al seleccionarlo del dg
            int e = dgUsuarios.Columns[1].Index;
            UsuarioBE Usu = new UsuarioBE(UsuarioNombre, " ");
            Usu.NombreUsuario = UsuarioNombre;
            Usu.IDUsuario = int.Parse(dgUsuarios.Rows[e].Cells["IDUsuario"].Value.ToString());
            ListadoPatente = new List<PatenteBE>();
            Usu = BLL.UsuarioBLL.GetInstance().UsuarioPatente(Usu);
            ListadoUsuarioPatente = Usu.Patentes;
            dgPatentesdeUsuario.DataSource = null;
            dgPatentesdeUsuario.DataSource = ListadoUsuarioPatente;
        }

        public void ListarFamiliasUsuario()
        {
            int e = dgUsuarios.Columns[1].Index;
            UsuarioBE Usu2 = new UsuarioBE(UsuarioNombre, " ");
            Usu2.NombreUsuario = UsuarioNombre;
            Usu2.IDUsuario = int.Parse(dgUsuarios.Rows[e].Cells["IDUsuario"].Value.ToString());
            ListadoFamilia = new List<FamiliaBE>();

            Usu2 = BLL.UsuarioBLL.GetInstance().UsaurioFamilia(Usu2);
            ListadoFamiliaUsuario = Usu2.Familias;

            dgFamiliasdeUsuario.DataSource = null;
            dgFamiliasdeUsuario.DataSource = ListadoFamiliaUsuario;
        }

        private void btnBuscarUsuario_Click(object sender, EventArgs e)
        {
            //Consulto un usuario específico por ID
            
            if (UsuarioNombre != "")
            {
                Usu.IDUsuario = int.Parse(TxtNombreUsuario.Text);
                dgUsuarios.DataSource = null;
                dgUsuarios.DataSource = BLL.UsuarioBLL.GetInstance().BuscarunUsuarioID(int.Parse(TxtNombreUsuario.Text));
                dgUsuarios.Columns[3].Visible = false;
                dgUsuarios.Columns[4].Visible = false;
                dgUsuarios.Columns[5].Visible = false;
                dgUsuarios.Columns[6].Visible = false;
                dgUsuarios.Columns[7].Visible = false;
                dgUsuarios.Columns[8].Visible = false;
                dgUsuarios.Columns[10].Visible = false;
                dgUsuarios.Columns[11].Visible = false;
                dgUsuarios.Columns[12].Visible = false;

                dgPatentesdeUsuario.DataSource = null;
                dgPatentesdeUsuario.DataSource = BLL.UsuarioBLL.GetInstance().BuscarUsuarioIDPatentes(int.Parse(TxtNombreUsuario.Text));
                //dgPatentesdeUsuario.Columns[2].Visible = false;

                dgFamiliasdeUsuario.DataSource = null;
                dgFamiliasdeUsuario.DataSource = BLL.UsuarioBLL.GetInstance().BuscarUsuarioIDFamilias(int.Parse(TxtNombreUsuario.Text));
                //dgFamiliasdeUsuario.Columns[2].Visible = false;

            }
        }

        private void btnAgregar_Patente_Usuario_Click(object sender, EventArgs e)
        {
            if (TxtNombreUsuario.Text != "" && txtId_Pat.Text != "" && TxtNombreUsuario != null && txtId_Pat!= null)
            {
                UsuarioBE Usu = new UsuarioBE();
                PatenteBE Pat = new PatenteBE();
                Pat.ID_Patente = int.Parse(txtId_Pat.Text);
                Usu.IDUsuario = int.Parse(TxtNombreUsuario.Text);

                //Agregar la patente al usuario (grabo en la base Usuario_Patente
               BLL.UsuarioBLL.GetInstance().AltaUsuarioPatente(Pat,Usu);

                //actualizar grilla Patentes de usuario
                Usu = BLL.UsuarioBLL.GetInstance().UsuarioPatente(Usu);
                ListadoUsuarioPatente = Usu.Patentes;

                dgPatentesdeUsuario.DataSource = null;
                dgPatentesdeUsuario.DataSource = ListadoUsuarioPatente;
                btnAgregar_Patente_Usuario.Enabled = false;
            }
        }

        private void dgPatentes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Selecciono la patente 
            PatenteAgregar = dgPatentes.Rows[e.RowIndex].Cells["ID_Patente"].Value.ToString();
            btnAgregar_Patente_Usuario.Enabled = true;
        }

        private void btnSacar_Patente_Usuario_Click(object sender, EventArgs e)
        {
            if (UsuarioNombre != "" && PatenteQuitar != "" && PatenteQuitar != null && UsuarioNombre != null)
            {
                btnSacar_Patente_Usuario.Enabled = true;
                UsuarioBE Usu = new UsuarioBE(UsuarioNombre, " ");
                PatenteBE Pat = new PatenteBE();
                int contador = 0;
                Pat.ID_Patente = int.Parse(PatenteQuitar.ToString());
                Pat.Descripcion = PatenteQuitar;
                ListadoFamiliaparaPatente = new List<FamiliaBE>();
                
                //Verifico si la patente que estoy sacando la tiene algun usuario (listo)
                //Verifico si la patente que estoy sacando esta en alguna familia y que la familia tenga un usuario asigando
                //SELECT ID_FAMILIA FROM FAMILIA_PATENTE WHERE ID_PATENTE = PATENTE_SACAR (obtengo un listado de familias)
                ListadoFamiliaparaPatente = BLL.FamiliaBLL.GetInstance().ListarFamiliaporPatente(ListadoFamiliaparaPatente, Pat);
                //SELECT COUNT(*) FROM Usuario_Patente WHERE Id_Usuario != '{0}' AND Id_Patente = '{1}' GROUP BY Id_Usuario", id, pat.Id_Patente)
                if (ListadoFamiliaparaPatente.Count == 0 && TodaslasPatentesAsignadas(Usu, Pat) == false)
                {
                    MessageBox.Show("No se puede quitar patente. Quedarían patentes huérfanas");
                }
                else
                {
                    //SELECT * FROM USUARIO_FAMILIA WHERE ID_FAMILIA = LISTADO DE FAMILIAS AND ID_USUARIO <> El usuario --> Si encuentra alguno dejo que quite la patente
                    foreach (FamiliaBE f in ListadoFamiliaparaPatente)
                    {
                        //if (BLL.Usuario.GetInstance().BuscarUsuarioFam(Usu, f) == true)
                        if (BLL.UsuarioBLL.GetInstance().Buscartodaslasfamilias(f) == true)
                        {
                            contador += 1;
                        }
                    }
                    if (contador == 0 && TodaslasPatentesAsignadas(Usu, Pat) == false)
                    {
                        MessageBox.Show("No se puede quitar patente. Quedarían patentes huérfanas");
                    }
                    else
                    {
                        //Sacar la patente al usuario (grabo en la base Usuario_Patente
                        BLL.UsuarioBLL.GetInstance().BajaUsuarioPatente(Usu, Pat);
                    }
                }
                if (TodaslasPatentesAsignadas(Usu, Pat) == false)
                {
                    MessageBox.Show("No se puede quitar patente. Quedarían patentes huérfanas");
                }
                else
                {
                    //Sacar la patente al usuario (grabo en la base Usuario_Patente
                    BLL.UsuarioBLL.GetInstance().BajaUsuarioPatente(Usu, Pat);
                }
                //actualizar grilla Patentes de usuario
                Usu = BLL.UsuarioBLL.GetInstance().UsuarioPatente(Usu);
                ListadoUsuarioPatente = Usu.Patentes;
                dgPatentesdeUsuario.DataSource = null;
                dgPatentesdeUsuario.DataSource = ListadoUsuarioPatente;
                //dgPatentesdeUsuario.Columns[1].Visible = false;
                //dgPatentesdeUsuario.Columns[2].Visible = false;

                btnSacar_Patente_Usuario.Enabled = false;
            }
        }

        public bool TodaslasPatentesAsignadas(UsuarioBE Usu, PatenteBE Pat)
        {
            if (BLL.UsuarioBLL.GetInstance().HayUsuariosConPatentes(UsuarioNombre, Pat) == false)
            {
                //Quedaria la patente sin usuario asignado
                return false;
            }
            else
            {
                return true;
            }
        }

        private void dgPatentesdeUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Selecciono la patente a quitar
            PatenteQuitar = dgPatentesdeUsuario.Rows[e.RowIndex].Cells["ID_Usuario"].Value.ToString();
            btnSacar_Patente_Usuario.Enabled = true;
        }

        private void btn_Aceptar_Consulta_Usuario_Patente_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgFamilias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Selecciono la Familia a agregar al usuario
            FamiliaAgregar = dgFamilias.Rows[e.RowIndex].Cells["ID_Familia"].Value.ToString();
            btnAgregar_Familia_Usuario.Enabled = true;
        }

        private void dgFamiliasdeUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Selecciono la Familia a eliminar del usuario
            FamiliaSacar = dgFamiliasdeUsuario.Rows[e.RowIndex].Cells["ID_Usuario"].Value.ToString();
            btnSacar_Familia_Usuario.Enabled = true;
        }
                                                                                                                                                                                                                                                                                                                                    
        private void btnSacar_Familia_Usuario_Click(object sender, EventArgs e)
        {
            //Delete de Usuario_Familia
            if (UsuarioNombre != null && FamiliaSacar != null && UsuarioNombre != "" && FamiliaSacar != "")
            {
                btnSacar_Familia_Usuario.Enabled = true;
                UsuarioBE Usu = new UsuarioBE(UsuarioNombre, " ");
                FamiliaBE Fam = new FamiliaBE();
                int contador = 0;
                ListadoPatentesBuscar = new List<PatenteBE>();
                Fam.IDFamilia = int.Parse(FamiliaSacar.ToString());
                Fam.NombreFamilia = FamiliaSacar;
               

                //1)Usuario_Familia (solo verifico que exista la familia en otro usuario) sino existe veo lo siguiente:
                // SELECT * FROM USUARIO_FAMILIA WHERE IF_FAMILIA = FAMILIA SACAR AND ID_USUARIO != USUARIO  public bool BuscarUsuarioFam(BE.Usuario u, BE.Familia Fam)
                if (BLL.UsuarioBLL.GetInstance().BuscarUsuarioFam(Usu) == false)
                {
                    //Usuario_Patente (verifico si existen las patentes en otro usuario) .. Para esto recupero las patentes de la familia
                    //SELECT ID_PATENTE FROM FAMILIA_PATENTE WHERE ID_FAMILIA = FAMILIA (LISTADO DE PATENTES) public List<BE.Patente> ListarPatentesFamilia(List<BE.Patente> ListPat, BE.Familia Fam)
                    ListadoPatentesBuscar = BLL.FamiliaBLL.GetInstance().ListarPatentesFamilia(ListadoPatentesBuscar, Fam);

                    //SELECT USUARIO_PATENTE FROM ID_PATENTE = LISTADO DE PATENTES   public bool PatenteUsuario(BE.Patente p)
                    foreach (PatenteBE p in ListadoPatentesBuscar)
                    {
                        if (BLL.UsuarioBLL.GetInstance().PatenteUsuario(p) == true)
                        {
                            contador += 1;
                        }
                    }

                }

                //SI ListadoPatentesBuscar.Count == 0 es que la familia no tiene patentes
                if (BLL.UsuarioBLL.GetInstance().BuscarUsuarioFam(Usu) == true || contador > 0 || ListadoPatentesBuscar.Count == 0)
                {
                    //La familia o las patentes de la familia a asignar estan en otro usuario por lo que evito patentes huerfanas
                    BLL.UsuarioBLL.GetInstance().BajaUsuarioFamilia(Usu, Fam);
                    

                    ListarFamiliasUsuario();
                }
                else
                {
                    MessageBox.Show("No se puede quitar la familia. Quedarían patentes huérfanas");
                }
            }
        }

        private void btnAgregar_Familia_Usuario_Click(object sender, EventArgs e)
        {
            //Insert en Usuario_Familia
            if (TxtNombreUsuario.Text != null && txtId_Fam.Text != null && TxtNombreUsuario.Text != "" && txtId_Fam.Text != "")
            {
                UsuarioBE Usu = new UsuarioBE();
                FamiliaBE Fam = new FamiliaBE();
                Usu.IDUsuario = int.Parse(TxtNombreUsuario.Text);
                Fam.IDFamilia = int.Parse(txtId_Fam.Text);

                // Agregar la Familia al usuario(grabo en la base Usuario_Familia
                BLL.UsuarioBLL.GetInstance().AltaUsuarioFamilia(Usu ,Fam);
                btnAgregar_Familia_Usuario.Enabled = false;
               
                //actualizar grilla Patentes de usuario
                Usu = BLL.UsuarioBLL.GetInstance().UsaurioFamilia(Usu);
                ListadoFamiliaUsuario = Usu.Familias;

                dgFamiliasdeUsuario.DataSource = null;
                dgFamiliasdeUsuario.DataSource = ListadoFamiliaUsuario;
                btnAgregar_Familia_Usuario.Enabled = false;
               

            }
        }
        private void Ayuda(object sender, HelpEventArgs hlpevent)
        {
            Help.ShowHelp(this, Path.Combine(Application.StartupPath, "Ayuda.chm"), "FamiliasPatentesUsuarios.htm");
        }

        private void btnPatente_Click(object sender, EventArgs e)
        {
            if (PatenteAgregar != "")
            {
                dgPatentes.DataSource = null;
                dgPatentes.DataSource = BLL.PatenteBLL.InstanciaR().BuscarunaPatenteID(int.Parse(txtId_Pat.Text));
            }
        }
        
        private void btnFamilia_Click(object sender, EventArgs e)
        {
            if (FamiliaAgregar != "")
            {
                dgFamilias.DataSource = null;
                dgFamilias.DataSource = BLL.FamiliaBLL.GetInstance().BuscarunaFamiliaID(int.Parse(txtId_Fam.Text));
            }
        }
    }
}
