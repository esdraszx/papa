using BE;
using System;
using System.IO;
using System.Windows.Forms;

namespace UI
{
    public partial class Inicio : Form
    {
        //static string algo;
       // private static Pantalla_Principal_C Form_Pantalla_Principal_C;
        private static  StringConexion Form_String_Conexion;
        private static  User.RecalcularDV Form_RecalcularDV;
        private Log Form_Log;
       // private readonly UsuarioBE  UsuarioBE;

        public Inicio()
        {
            InitializeComponent();
        }
        private void FormWelcome_Load(object sender, EventArgs e)
        {
            this.Show();
            this.Opacity = 0.0;
            circularProgressBar1.Value = 0;
            circularProgressBar1.Minimum = 0;
            circularProgressBar1.Maximum = 100;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1) this.Opacity += 0.05;
            circularProgressBar1.Value += 1;
            circularProgressBar1.Text = circularProgressBar1.Value.ToString();
            if (circularProgressBar1.Value == 100)
            {
                timer1.Stop();
                timer2.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.1;
            if (this.Opacity == 0)
            {
                timer2.Start();
                this.Show();
            }
            
            
        }
        private void btnContinuar_Click(object sender, EventArgs e)
        {
           // this.Show(); 

            try
            {
                if (BuscarAPPConfig() == false)
                {
                    MessageBox.Show("No se encuentra el archivo de configuración. Puede crearlo ahora",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (VerificarConexion() == false)
                {
                    MessageBox.Show("Falló la conexión ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Form_String_Conexion = new StringConexion();
                    Form_String_Conexion.ShowDialog();
                    Form_String_Conexion.Dispose();
                    
                }
                if (VerificarDV())
                {
                    MessageBox.Show(" Los controles estan OK", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Form_Log = new Log();
                    Form_Log.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Falló de digitos verificadores", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Form_RecalcularDV = new User.RecalcularDV();
                    Form_RecalcularDV.ShowDialog();
                }

                //if (!VerificarDV())
                //{
                //    MessageBox.Show("Falló la comprobación de digitos verificadores", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    //this.Close();
                //}
                ////MessageBox.Show("Todos los controles estan OK", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en uno de los checks\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
             //Form_Pantalla_Principal_C.ShowDialog();
           //
           // this.Dispose();
        }
        
        private bool BuscarAPPConfig()
        {
            string configFileName = AppDomain.CurrentDomain.BaseDirectory + "config.ini";

            if (File.Exists(configFileName))
            {
                //this.progressBar1.Increment(33);
                //label2.Text = "Checking config file...OK!";
                lConec.Text = "Verificando conexión a la BD...LISTO";
                return true;
            }
            else
            {

                if (Form_String_Conexion == null)
                {
                    Form_String_Conexion = new StringConexion();
                    Form_String_Conexion.ShowDialog();
                }
                //label2.Text = "Checking config file...ERROR!";
                return false;
            }
        }

        public bool VerificarConexion()
        {
            try
            {
                BLL.InicioBLL.GetInstance().VerificarConexion();
                lConec.Text = "Comprobando conexión OK!";
               
                //this.circularProgressBar1.Increment(50);
               
                return true;

            }
            catch (Exception ex)
            {
                //label3.Text = "Connection to DB...ERROR!";
                //Form_String_Conexion = new StringConexion();
                //Form_String_Conexion.ShowDialog();
                if (Form_String_Conexion == null)
                {
                    Form_String_Conexion = new StringConexion();
                    Form_String_Conexion.ShowDialog();
                    return false;
                }
                throw (ex);
            }
        }

        public bool VerificarDV()
        {
            if (Servicios.DigitosVerificadores.ValidarBBDD() == false)
            {
                lIntegridad.Text = "Comprobando integridad OK! ";
                return true;
               
            }
            else
            {
                lIntegridad.Text = "Error de integridad comunicar al Administrador ";
                return false;

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }

}
