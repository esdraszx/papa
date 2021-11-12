using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Datos
{
    public class BackupDAL_D
    {
        private static BackupDAL_D Instancia;
        public List<BE.BackupBE> ListaBackup { get; set; }

        public static BackupDAL_D GetInstance()
        {
            if (Instancia == null)
            {
                Instancia = new BackupDAL_D();
            }
            return Instancia;
        }
        SqlConnection Conect = new SqlConnection();
        void Conectar()
        {
            Conect.ConnectionString = @"Data Source=DESKTOP-2Q8KCH0\SQLEXPRESS;Initial Catalog=LPPA2;Integrated Security=True";
            Conect.Open();
        }
        void Desconectar()
        {
            Conect.Close();
            Conect.Dispose();
        }
        SqlCommand Comando = new SqlCommand();
        //Restaurar backup
        public void restaurar(List<string> path)
        {
            var nombreBaseDeDatos = DAL_Servicios.Comando.GetInstance().getDatabaseName();
            Conectar();
            Comando.Connection = Conect;
            Comando.CommandType = System.Data.CommandType.Text;
            string query = "USE MASTER " + "ALTER DATABASE [" + nombreBaseDeDatos + "]  SET SINGLE_USER WITH ROLLBACK IMMEDIATE" +
                " RESTORE DATABASE [" + nombreBaseDeDatos + "] FROM ";
            foreach (string f in path)
            {
                query += "DISK = '" + f + "',";
            }
            query = query.Substring(0, query.Length - 1);
            query += " WITH REPLACE";
            query += " ALTER DATABASE [" + nombreBaseDeDatos + "] SET MULTI_USER ";
            Comando.CommandText = query;
            Comando.ExecuteNonQuery();
        }
        // Hace backup de la base
        public bool HacerBackup(BE.BackupBE b)
        {
            try
            {
                var nombreBaseDeDatos = DAL_Servicios.Comando.GetInstance().getDatabaseName();
                string query1 = string.Format(@"BACKUP DATABASE LPPA2 TO DISK = '{0}\{1}'", b.Direccion, b.Nombre);
                string query = string.Format(@"BACKUP DATABASE {2} TO DISK = '{0}\{1}'", b.Direccion, b.Nombre, nombreBaseDeDatos);
                int var = b.Volumenes;
                string nom = b.Nombre;
                for (var c = 0; c < var; c++)
                {
                    b.Nombre = nom;
                    b.Nombre += c;
                    query += string.Format(@",DISK = '{0}\{1}'", b.Direccion, b.Nombre);
                }
                query += ("WITH NOFORMAT, NOINIT,SKIP, NOREWIND, NOUNLOAD,  STATS = 10, MEDIANAME = 'SQLServerBackups', NAME = 'Backup'");
                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = System.Data.CommandType.Text;
                Comando.CommandText = query;
                Comando.ExecuteNonQuery();
                Desconectar();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
