using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Datos
{
    public class IdiomaDAL_D
    {
        //Singleton
        private static IdiomaDAL_D Instancia;


        public static IdiomaDAL_D GetInstance()
        {
            if (Instancia == null)
            {
                Instancia = new IdiomaDAL_D();
            }

            return Instancia;
        }

        //Cargar idioma
        SqlConnection Conect = new SqlConnection();

        void Conectar()
        {
            //Conect.ConnectionString = @"Data Source=DESKTOP-JNJ87EE;Initial Catalog=Remiseria;Integrated Security=True";
            Conect.ConnectionString = DAL_Servicios.Comando.GetInstance().ConexionString();
            Conect.Open();
        }

        void Desconectar()
        {
            Conect.Close();
            Conect.Dispose();
        }

        SqlCommand Comando = new SqlCommand();


        //Listar todos los idiomas de la base
        public List<BE.IdiomaBE> ListarIdiomas(List<BE.IdiomaBE> lidiomas)
        {

            string consulta = string.Format("SELECT * FROM IDIOMA");
            Conectar();
            Comando.Connection = Conect;
            Comando.CommandType = CommandType.Text;
            Comando.CommandText = consulta;

            SqlDataReader lector = Comando.ExecuteReader();
            while (lector.Read())
            {
                BE.IdiomaBE I = new BE.IdiomaBE();
                I.Codigo = lector["codigo"].ToString();
                I.Nombre = lector["Nombre"].ToString();
                lidiomas.Add(I);

            }
            Desconectar();
            return lidiomas;

        }
    }
}
