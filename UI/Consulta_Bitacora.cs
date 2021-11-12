using System;
using System.Collections.Generic;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.Data;
using System.Linq;
using BE;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Consulta_Bitacora : Form
    {
        public List<BitacoraBE> ListaBitacora { get; set; }
        public List<CriticidadBE> ComboCriticidad { get; set; }
        public Consulta_Bitacora()
        {
            InitializeComponent();
        }

        private void Consulta_Bitacora_Load(object sender, EventArgs e)
        {
            dgBitacora.RowHeadersVisible = false;

            ListaBitacora = new List<BitacoraBE>();
            ListaBitacora = BLL.BitacoraBLL.GetInstance().ListarBitacora(ListaBitacora);
            ListaBitacora = ListaBitacora.OrderByDescending(x => x.FechaHora).ToList();

            dgBitacora.DataSource = null;
            dgBitacora.DataSource = ListaBitacora;
            //dgBitacora.Columns[2].Visible = false;

            //Lleno el combobox
            CriticidadBE Critica = new CriticidadBE();
            CriticidadBE Alta = new CriticidadBE();
            CriticidadBE Media = new CriticidadBE();
            CriticidadBE Baja = new CriticidadBE();
            CriticidadBE Nula = new CriticidadBE();

            Critica.Estado = 'C';
            Alta.Estado = 'A';
            Media.Estado = 'M';
            Baja.Estado = 'B';
            Nula.Estado = ' ';

            ComboCriticidad = new List<CriticidadBE>();
            ComboCriticidad.Add(Nula);
            ComboCriticidad.Add(Critica);
            ComboCriticidad.Add(Alta);
            ComboCriticidad.Add(Media);
            ComboCriticidad.Add(Baja);


            cbCriticidad_Bitacora.DataSource = null;
            cbCriticidad_Bitacora.DataSource = ComboCriticidad;
            cbCriticidad_Bitacora.DisplayMember = "Estado";
            cbCriticidad_Bitacora.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void btnBitacoraBuscar_Click(object sender, EventArgs e)
        {
            //Verifico que alguno de los dos criterios de busqueda este informado
            if (txtIdUsuario_Bitacora.Text == "" && cbCriticidad_Bitacora.Text == " ")
            {
                MessageBox.Show("Debe ingresar algún criterio de búsqueda");
            }
            else
            {
                //Criticidad y ID
                if (txtIdUsuario_Bitacora.Text != "" && cbCriticidad_Bitacora.Text != " ")
                {
                    ListaBitacora = BLL.BitacoraBLL.GetInstance().ListaListarBitacoraAmbosCriterios(ListaBitacora, cbCriticidad_Bitacora.Text, txtIdUsuario_Bitacora.Text);
                }
                //Solo ID
                if (txtIdUsuario_Bitacora.Text != "" && cbCriticidad_Bitacora.Text == " ")
                {
                    ListaBitacora = BLL.BitacoraBLL.GetInstance().ListarBitacoraUsuario(ListaBitacora, txtIdUsuario_Bitacora.Text);
                }
                //Solo Criticidad
                if (txtIdUsuario_Bitacora.Text == "" && cbCriticidad_Bitacora.Text != " ")
                {
                    ListaBitacora = BLL.BitacoraBLL.GetInstance().ListarBitacoraCriticidad(ListaBitacora, cbCriticidad_Bitacora.Text);
                }

            }

            //Acutalizo bitacora

            dgBitacora.DataSource = null;
            dgBitacora.DataSource = ListaBitacora;
            dgBitacora.Columns[2].Visible = false;
        }

        private void btn_ImprimirReporte_Click(object sender, EventArgs e)
        {
            PdfWriter pdfWriter = new PdfWriter("Reporte_Bitacora.pdf");
            PdfDocument pdf = new PdfDocument(pdfWriter);
            Document documento = new Document(pdf, PageSize.LETTER);
            documento.SetMargins(60, 20, 55, 20);

            PdfFont fontColumnas = PdfFontFactory.CreateFont(StandardFonts.TIMES_BOLD);
            PdfFont fontContenido = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);

            string[] columnas = { "Criticidad", "Descripción", "Fecha y Hora", "NombreUsuario" };
            float[] tamaño = { 1, 6, 4, 2 };

            Table tabla = new Table(UnitValue.CreatePercentArray(tamaño));
            tabla.SetWidth(UnitValue.CreatePercentValue(100));

            foreach (string columan in columnas)
            {
                tabla.AddHeaderCell(new Cell().Add(new Paragraph(columan).SetFont(fontColumnas)));

            }

            foreach (BE.BitacoraBE b in ListaBitacora)
            {
                tabla.AddCell(new Cell().Add(new Paragraph(b.Criticidad.ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(b.Descripcion.ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(b.FechaHora.ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(b.NombreUsuario.ToString()).SetFont(fontContenido)));
            }



            documento.Add(tabla);
            documento.Close();
            MessageBox.Show("Se ha generado el reporte. Verifique en la carpeta");
        }

        private void btn_BuscarRango_Click(object sender, EventArgs e)
        {
            //Buscar por rango de fechas
            BitacoraBE b1 = new BitacoraBE();
            BitacoraBE b2 = new BitacoraBE();
            b1.FechaHora = datepi_Desde.Value;
            b2.FechaHora = datepi_Hasta.Value.AddDays(1);

            ListaBitacora = BLL.BitacoraBLL.GetInstance().ListarBitacoraFecha(ListaBitacora, b1, b2);

            // Solo criticidad (y fecha)
            if (txtIdUsuario_Bitacora.Text == "" && cbCriticidad_Bitacora.Text != " ")
            {
                ListaBitacora = BLL.BitacoraBLL.GetInstance().ListarBitacoraFechaCrit(ListaBitacora, b1, b2, cbCriticidad_Bitacora.Text);
            }
            //Criticidad y ID (y fecha)
            if (txtIdUsuario_Bitacora.Text != "" && cbCriticidad_Bitacora.Text != " ")
            {
                ListaBitacora = BLL.BitacoraBLL.GetInstance().ListarBitacoraFechaCritID(ListaBitacora, b1, b2, cbCriticidad_Bitacora.Text, txtIdUsuario_Bitacora.Text);
            }
            //Solo ID (y fecha)
            if (txtIdUsuario_Bitacora.Text != "" && cbCriticidad_Bitacora.Text == " ")
            {
                ListaBitacora = BLL.BitacoraBLL.GetInstance().ListarBitacoraFechaID(ListaBitacora, b1, b2, txtIdUsuario_Bitacora.Text);
            }

            //Acutalizo bitacora

            dgBitacora.DataSource = null;
            dgBitacora.DataSource = ListaBitacora;
            dgBitacora.Columns[2].Visible = false;
        }

        private void Ayuda(object sender, HelpEventArgs hlpevent)
        {
            Help.ShowHelp(this, System.IO.Path.Combine(Application.StartupPath, "Ayuda.chm"), "Bitacora.htm");
        }
    }
    
}
