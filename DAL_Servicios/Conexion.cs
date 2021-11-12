using System;
using System.Data.SqlClient;


namespace DAL_Servicios
{
    public  class Conexion
    {
        private static SqlConnection con;
        SqlConnection Conect = new SqlConnection();
        //private SqlCommand Comando = new SqlCommand();

        private static string strincon = @"Data Source=DESKTOP-2Q8KCH0\SQLEXPRESS;Initial Catalog=LPPA2;Integrated Security=True";
        private static string stringMaster = @"Data Source=DESKTOP-2Q8KCH0\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";

        public static SqlConnection ConexionF()
        {
            try
            {
                con = new SqlConnection(strincon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return con;
        }

        public static SqlConnection ConexionMaster()
        {
            try
            {
                con = new SqlConnection(stringMaster);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return con;
        }

       public void  Conectar()
       {
            Conect.ConnectionString = strincon;
            Conect.ConnectionString = Comando.GetInstance().ConexionString();
            Conect.Open();
       }
        public void Desconectar()
        {
            Conect.Close();
            Conect.Dispose();
        }
      
    }
}
