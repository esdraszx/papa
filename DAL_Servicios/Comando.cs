
using System;
using System.Data;
using System.Data.SqlClient;
using Nini.Config;

namespace DAL_Servicios
{
    public class Comando
    {
        private static SqlCommand command;
        //private string database = new String(S);
        //public static string S;
        //Singleton
        private static Comando Instancia;
        public static Comando GetInstance()
        {
            if (Instancia == null)
            {
                Instancia = new Comando();
            }
            return Instancia;
        }
        public string getDatabaseName()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = ConexionString();
            var database = conexion.Database.ToString();
            conexion.Close();
            return database;
        }
        public string ConexionString()
        {
            //nuevo
           
 
            string configFileName = AppDomain.CurrentDomain.BaseDirectory + "config.ini";
            IniConfigSource configSource = new IniConfigSource(configFileName);
            IConfig demoConfigSection = configSource.Configs["LPPA2"];
            var database = demoConfigSection.Get("connectionString", string.Empty);
            var connectionString = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(database));
            try
            {
                SqlConnection conexion = new SqlConnection();
                conexion.ConnectionString = connectionString;
                conexion.Database.ToString();
                conexion.Open();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return connectionString;
        }
        public static SqlCommand objComando(String selectcommand, SqlConnection conexion)
        {
            command = new SqlCommand();
            command.CommandText = selectcommand;
            command.CommandType = CommandType.Text;
            command.Connection = conexion;
            return command;
        }
        public static void ConsultaSQL(String selectcommand, SqlConnection conexion)
        {
            if (conexion.State == ConnectionState.Open)
                conexion.Close();

            command = objComando(selectcommand, conexion);
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }
        public static DataTable objDatatable(String selectcommand)
        {
            SqlDataAdapter DA = new SqlDataAdapter(selectcommand, Conexion.ConexionF());
            DataTable DT = new DataTable();
            DA.Fill(DT);
            return DT;
        }
        public static DataTable objDatatable2(String selectcommand)
        {
            SqlDataAdapter DA = new SqlDataAdapter(selectcommand, Conexion.ConexionMaster());
            DataTable DT = new DataTable();
            DA.Fill(DT);
            return DT;
        }
        public static void actualizarBD(String selectcommand, DataTable DT)
        {
            var DA = new SqlDataAdapter(selectcommand, Conexion.ConexionF());
            var CB = new SqlCommandBuilder(DA);
            DA.InsertCommand = CB.GetInsertCommand();
            DA.DeleteCommand = CB.GetDeleteCommand();
            DA.UpdateCommand = CB.GetUpdateCommand();
            DA.Update(DT);
        }
        public static void ActualizarBD(String selectcommand, DataTable DT)
        {
            SqlDataAdapter DA = new SqlDataAdapter(selectcommand, Conexion.ConexionF());
            SqlCommandBuilder CB = new SqlCommandBuilder(DA);
            DA.InsertCommand = CB.GetInsertCommand();
            DA.DeleteCommand = CB.GetDeleteCommand();
            DA.UpdateCommand = CB.GetUpdateCommand();
            DA.Update(DT);
        }
        public static void ConsultasSQL(string selectcommand, SqlConnection conexion)
        {
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
            var command = objComando(selectcommand, conexion);
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }



    }
}
