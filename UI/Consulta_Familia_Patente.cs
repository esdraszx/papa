using BE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace UI
{
    public partial class Consulta_Familia_Patente : Form
    {
        private Alta_Familia Form_Alta_Familia;
        public List<FamiliaBE> ListadoFamilias { get; set; }
        public List<FamiliaBE> ListFam { get; private set; }
        public List<FamiliaBE> ListadoFamiliaUsuario { get; set; }
        public List<FamiliaBE> ListadoFamiliaControlar { get; set; }
        public List<PatenteBE> ListadoPatenteFamilias { get; private set; }
        public List<PatenteBE> ListadoPatente { get; private set; }
        public List<PatenteBE> ListadoPatenteControlar { get; private set; }
        public List<PatenteBE> ListadoPatenteNoEstan { get; private set; }
        public FamiliaPatenteBE ListarFamiliaPatente { get; private set; }
        public List<FamiliaBE> ListaFamiliaPatente { get; private set; }

        string UsuarioNombre;
        string FamiliaNombre;
        string PatenteQuitar;
        string PatenteAgregar;

        public Consulta_Familia_Patente()
        {
            InitializeComponent();
        }

        private void btn_Cancelar_Consulta_Familia_Patente_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptarConsultaFam_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCrearFamilia_Click(object sender, EventArgs e)
        {
            Form_Alta_Familia = new Alta_Familia();
            Form_Alta_Familia.Show();
        }

        private void dgConsultaFamilia_Familias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            FamiliaNombre = dgConsultaFamilia_Familias.Rows[e.RowIndex].Cells["Nombre_Familia"].Value.ToString();
            btnEliminarFamilia.Enabled = true;
            ListarPatentesFamilia();
        }

        private void Consulta_Familia_Patente_Load(object sender, EventArgs e)
        {
            //Idioma de la pantalla 
            if ((BE.Globales.Idioma == "Español                       " && btnAceptarConsultaFam.Text != "Aceptar") || (BE.Globales.Idioma == "Ingles                        " && btnAceptarConsultaFam.Text == "Aceptar"))
            {
                label1.Text = Recursos.Multidioma.CambiarIdioma(label1.Text);
                btbBuscarFamilia.Text = Recursos.Multidioma.CambiarIdioma(btbBuscarFamilia.Text);
                label4.Text = Recursos.Multidioma.CambiarIdioma(label4.Text);
                label2.Text = Recursos.Multidioma.CambiarIdioma(label2.Text);
                label3.Text = Recursos.Multidioma.CambiarIdioma(label3.Text);
                btnEliminarFamilia.Text = Recursos.Multidioma.CambiarIdioma(btnEliminarFamilia.Text);
                btnCrearFamilia.Text = Recursos.Multidioma.CambiarIdioma(btnCrearFamilia.Text);
                btnAceptarConsultaFam.Text = Recursos.Multidioma.CambiarIdioma(btnAceptarConsultaFam.Text);
                btn_Cancelar_Consulta_Familia_Patente.Text = Recursos.Multidioma.CambiarIdioma(btn_Cancelar_Consulta_Familia_Patente.Text);

                this.Text = Recursos.Multidioma.CambiarIdioma(this.Text);
            }

            dgConsultaFamilia_Familias.RowHeadersVisible = false;
            dgConsultaFamilias_Patentes.RowHeadersVisible = false;
            dgConsultaFamilia_PatenteFamilias.RowHeadersVisible = false;
            ListarPatentes();
            ListarFamilias();
        }

        public void ListarPatentes()
        {
            //Listar Patentes
            ListadoPatente = new List<PatenteBE>();

            BLL.PatenteBLL.GetInstance().ListarPatentes(ListadoPatente);

            dgConsultaFamilias_Patentes.DataSource = null;
            dgConsultaFamilias_Patentes.DataSource = ListadoPatente;
            dgConsultaFamilias_Patentes.Columns[0].Visible = false;
        }

        private void btnEliminarFamilia_Click(object sender, EventArgs e)
        {
            if (FamiliaNombre != "")
            {
                BE.FamiliaBE Fam = new BE.FamiliaBE();
                Fam.NombreFamilia = FamiliaNombre;
                ListadoPatenteControlar = new List<PatenteBE>();
                ListadoFamiliaControlar = new List<FamiliaBE>();
                ListadoPatenteNoEstan = new List<PatenteBE>();
                int contador = 0;

                //Busco las patentes de la familia que estoy por borrar 
                //SELECT * FROM FAMILIA_PATENTE WHERE ID_FAMILIA = FAMILIA A BORRAR (DEVUELVE UN LISTADO DE PATENTES) 
                //  public List<BE.Patente> ListarPatentesFamilia(List<BE.Patente> ListPat, BE.Familia Fam)
                ListadoPatenteControlar = BLL.FamiliaBLL.GetInstance().ListarPatentesFamilia(ListadoPatenteControlar, Fam);

                //Con el listado de patentes 
                // 1)busco en USUARIO_PATENTE SI ESTAN TODAS (el cont es si no estan) o
                // SELECT * FROM USUARIO_PATENTE WHERE ID_PATENTE = LISTADO PATENTE
                // public bool PatenteUsuario(BE.Patente p)
                foreach (BE.PatenteBE P in ListadoPatenteControlar)
                {
                    if (BLL.UsuarioBLL.GetInstance().PatenteUsuario(P) == false)
                    {
                        //Guardar la patente que no esta asignada en USUARIO_PATENTE
                        ListadoPatenteNoEstan.Add(P);
                    }
                }

                // 2) si hay una familia_PATENTE con estas patentes y estaa asignada y la familia esta en USUARIO_FAMILIA
                // SELECT * FROM FAMILIA_PATENTE WHERE ID_PATENTE = LISTADO PATENTE AND ID_FAMILIA != FAMILIA A ELIMINAR
                // public List<BE.Familia> ListarFamiliaporPatente(List<BE.Familia> ListFam, BE.Patente Pat)

                if (ListadoPatenteNoEstan.Count > 0)
                {
                    foreach (BE.PatenteBE pat in ListadoPatenteNoEstan)
                    {
                        //La familia tiene que ser distinta a la que voy a eliminar
                        ListadoFamiliaControlar = BLL.FamiliaBLL.GetInstance().ListarFamiliaporPatente(ListadoFamiliaControlar, pat, Fam);

                    }
                    if (ListadoFamiliaControlar.Count > 0)
                    {
                        //Verifico si la familia con la patente a sacar esta con algun usuario asignado
                        //SELECT * FROM USUARIO_FAMILIA WHERE ID_FAMILIA = LISTADO FAMILIA
                        //public bool Buscartodaslasfamilias(BE.Familia Fam)
                        foreach (BE.FamiliaBE Fa in ListadoFamiliaControlar)
                        {
                            if (BLL.UsuarioBLL.GetInstance().Buscartodaslasfamilias(Fa) == true)
                            {
                                contador += 1;
                            }
                        }
                    }
                }

                //si ListadoPatenteNoEstan.Count = 0 todas las patentes asiganadas en USUARIO_PATENTE
                //si istadoPatenteNoEstan.Count =  contador tambien
                if (ListadoPatenteNoEstan.Count == 0 || ListadoPatenteNoEstan.Count == contador)
                {
                    BLL.FamiliaBLL.GetInstance().BorrarFamilia(Fam);

                    ListarFamilias();
                }
                else
                {
                    MessageBox.Show("No se puede eleminar Familia. Quedarían patentes huérfanas");
                }
            }
        }
        public void ListarFamilias()
        {
            ListadoFamilias = new List<FamiliaBE>();
            dgConsultaFamilia_Familias.DataSource = null;
            dgConsultaFamilia_Familias.DataSource = BLL.FamiliaBLL.GetInstance().ListarFamilia(ListadoFamilias);
            dgConsultaFamilia_Familias.Columns[0].Visible = false;
        }

        private void btnQuitarPatenteFamilia_Click(object sender, EventArgs e)
        {
            if (FamiliaNombre == "" || FamiliaNombre == null)
            {
                MessageBox.Show("Seleccione familia");
            }
            else
            {
                //Verifico que no me queden patentes sin asignar
                //La patente que saco la tiene otro usuario
                //SELECT * FROM USUARIO_PATENTE WHERE ID_PATENTE = PATENTE A SACAR HayUsuariosConPatentes (" ",BE.PATENTE) OR
                //La patente que saco la tiene otra familia que tenga un usuario asignado
                //SELECT * FROM FAMILIA_PATENTE WHERE ID_PATENTE = PATENTE A SACAR (esto me deja un listado de familias) ListarFamiliaporPatente(List<BE.Familia> ListFam, BE.Patente Pat)
                //SELECT * FROM USUARIO_FAMILIA WHERE ID_FAMILIA = LISTADO FAMILIA Buscartodaslasfamilias(BE.Familia Fam)
                //Delete de la pantente que se encuentra en Familia_Patente
                if (PatenteQuitar != "" && FamiliaNombre != "")
                {
                    BE.FamiliaBE Fam = new FamiliaBE();
                    BE.PatenteBE Pat = new PatenteBE();
                    Fam.NombreFamilia = FamiliaNombre;
                    Pat.ID_Patente = int.Parse(PatenteQuitar.ToString());
                    ListFam = new List<FamiliaBE>();
                    int contador = 0;
                    ListFam = BLL.FamiliaBLL.GetInstance().ListarFamiliaporPatente(ListFam, Pat);
                    foreach (BE.FamiliaBE F in ListFam)
                    {
                        if (BLL.FamiliaBLL.GetInstance().BuscarPatentedeFamilia(F, Pat) == true)
                        {
                            contador += 1;
                        }
                    }
                    if (BLL.UsuarioBLL.GetInstance().HayUsuariosConPatentes("", Pat) == true || contador > 0)
                    {
                        BLL.FamiliaBLL.GetInstance().BorrarFamiliaPatente(Fam, Pat);
                        ListarPatentesFamilia();
                    }
                    else
                    {
                        MessageBox.Show("No se puede quitar patente de familia. Quedarian patentes huérfanas");
                    }
                }
            }
        }

        private void dgConsultaFamilia_PatenteFamilias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            // Selecciono la patente a quitar
            PatenteQuitar = dgConsultaFamilias_Patentes.Rows[e.RowIndex].Cells["ID_Patente"].Value.ToString();
            btnQuitarPatenteFamilia.Enabled = true;

            //FamiliaNombre = dgConsultaFamilias_Patentes.Rows[e.RowIndex].Cells["ID_Familia"].Value.ToString();
            //FamiliaBE Fam = new FamiliaBE();
            //Fam.IDFamilia = int.Parse(FamiliaNombre.ToString());
            //Fam.IDFamilia = int.Parse(dgConsultaFamilias_Patentes.Rows[e.RowIndex].Cells["ID_Familia"].Value.ToString());
            ////Listar Patentes de la familia  al seleciomar del dg
            //ListaFamiliaPatente();
            ////Listar Patentes de la familia  al seleciconarlo del dg
            //ListarPatentesFamilia();
        }




        public void ListarPatentesFamilia()
        {
            ListadoPatenteFamilias = new List<PatenteBE>();
            FamiliaBE Fam = new FamiliaBE();
            Fam.NombreFamilia = FamiliaNombre;

            ListadoPatenteFamilias = BLL.FamiliaBLL.GetInstance().ListarPatentesFamilia(ListadoPatenteFamilias, Fam);
            dgConsultaFamilia_PatenteFamilias.DataSource = null;
            dgConsultaFamilia_PatenteFamilias.DataSource = ListadoPatenteFamilias;
            dgConsultaFamilia_PatenteFamilias.Columns[0].Visible = false;
            //dgConsultaFamilia_PatenteFamilias.Columns[2].Visible = false;
        }

        private void btnAgregarPatenteFamilia_Click(object sender, EventArgs e)
        {
            if (txtFamiliaID.Text != "" && txtPat.Text != "" && txtFamiliaID != null && txtPat != null)
            {
                //Inser de la pantente que se encuentra en Familia_Patente

                FamiliaBE Fam = new FamiliaBE();
                PatenteBE Pat = new PatenteBE();
                ListarFamiliaPatente  = new FamiliaPatenteBE();
                Fam.IDFamilia = int.Parse(txtFamiliaID.Text);
                Pat.ID_Patente = int.Parse(txtPat.Text);
           
                //Agregar la patente La Familia (grabo en la base Familia_Patente
                BLL.FamiliaBLL.GetInstance().AltaFamiliaPatente(Fam, Pat);

                ////actualizar grilla Patentes de la Familia
                //ListaFamiliaPatente = Fam.Patentes;
                dgConsultaFamilia_PatenteFamilias.DataSource = null;
                dgConsultaFamilia_PatenteFamilias.DataSource = BLL.FamiliaBLL.GetInstance().BuscarPatentesconIDFamilia(int.Parse(txtFamiliaID.Text));
                dgConsultaFamilia_PatenteFamilias.Columns[2].Visible = false;
                btnAgregarPatenteFamilia.Enabled = false;
                
            }
            else
            {
                MessageBox.Show("Seleccione familia");
            }
        }

        private void dgConsultaFamilias_Patentes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //seleccionar patente a agregar
            PatenteAgregar = dgConsultaFamilias_Patentes.Rows[e.RowIndex].Cells["ID_Patente"].Value.ToString();
            btnAgregarPatenteFamilia.Enabled = true;
        }
        private void Ayuda(object sender, HelpEventArgs hlpevent)
        {
            Help.ShowHelp(this, Path.Combine(Application.StartupPath, "Ayuda.chm"), "AsignarPatentesFamilia.htm");
        }

        private void btbBuscarFamilia_Click(object sender, EventArgs e)
        {

            if ( txtFamiliaID.Text != "" && txtFamiliaID.Text != null)
            {
                dgConsultaFamilia_Familias.DataSource = null;
                dgConsultaFamilia_Familias.DataSource = BLL.FamiliaBLL.GetInstance().BuscarunaFamiliaID(int.Parse(txtFamiliaID.Text));
                dgConsultaFamilia_Familias.Columns[0].Visible = false;
            }

            dgConsultaFamilia_PatenteFamilias.DataSource = null;
            dgConsultaFamilia_PatenteFamilias.DataSource = BLL.FamiliaBLL.GetInstance().BuscarPatentesconIDFamilia(int.Parse(txtFamiliaID.Text));
            dgConsultaFamilia_PatenteFamilias.Columns[2].Visible = false;
        }

        public void ListarFamiliasUsuario()
        {
            UsuarioBE Usu2 = new UsuarioBE(UsuarioNombre, " ");
            Usu2 = BLL.UsuarioBLL.GetInstance().CargarFamiliasPorUsuario(Usu2);
            ListadoFamiliaUsuario = Usu2.Familias;

            dgConsultaFamilia_Familias.DataSource = null;
            dgConsultaFamilia_Familias.DataSource = ListadoFamiliaUsuario;

        }

        private void Patente_Click(object sender, EventArgs e)
        {
            if (PatenteAgregar != "")
            {
                dgConsultaFamilias_Patentes.DataSource = null;
               dgConsultaFamilias_Patentes.DataSource = BLL.PatenteBLL.InstanciaR().BuscarunaPatenteID(int.Parse(txtPat.Text));
                dgConsultaFamilias_Patentes.Columns[0].Visible = false;
            }
        }
    }
}
