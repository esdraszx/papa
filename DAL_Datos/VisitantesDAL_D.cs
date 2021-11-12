using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL_Datos
{
    public class VisitantesDAL_D
    {
        public List<BE.VisitantesBE> ListadoVisitantes { get; set; }
        public BE.VisitantesBE DNI { get; set; }
        //SIngelton
        private static VisitantesDAL_D Instancia;
        public static VisitantesDAL_D GetInstance()
        {
            if (Instancia == null)
            {
                Instancia = new VisitantesDAL_D();
            }
            return Instancia;
        }
        SqlConnection Conect = new SqlConnection();
        void Conectar()
        {
            Conect.ConnectionString = DAL_Servicios.Comando.GetInstance().ConexionString();
            Conect.Open();
        }
        void Desconectar()
        {
            Conect.Close();
            Conect.Dispose();
        }
        SqlCommand Comando = new SqlCommand();
        //Validar si ya Existe Visitantes
        public bool Validar(BE.VisitantesBE vis)
        {
            try
            {
                string query = string.Format("select * from Visitantes where DNI = '{0}' ", vis.DNI);
                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = System.Data.CommandType.Text;
                Comando.CommandText = query;
                Comando.ExecuteNonQuery();
                SqlDataReader Leer = Comando.ExecuteReader();
                if (Leer.HasRows)
                {
                    Desconectar();
                    return true;
                }
                else
                {
                    Desconectar();
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Alta de Visitantes
        public bool AltaVisitantes(BE.VisitantesBE vis)
        {
            try
            {
                string Apellido = vis.Apellido;
                string NombreUsuario = vis.NombreUsuario;
                string Telefono = vis.Telefono;
                string DNI = vis.DNI;
                string DVH = vis.DVH;
                string Direccion = vis.Direccion;
                string Email = vis.Email;
                string Nombre = vis.Nombre;
                string query = string.Format("INSERT INTO VisitantesDAL_D VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}','{6}', '{7}', '{8}','{9}', '{10}', '{11}','{12}','{13}','{14}','{15}','{16}')", Apellido, DNI, DVH, Direccion, Email, Nombre, Telefono, NombreUsuario);
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
                throw new Exception (ex.Message);
            }
        }
        //Delete de Visitantes
        public bool EliminarVisitantes(string Id)
        {
            try
            {
                string query = string.Format("Delete FROM Visitantes  WHERE DNI = '{0}'", Id);
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
                throw new Exception( ex.Message);
            }
        }
        //Update de Visitantes
        public bool ActualizarVisitantesDAL_D(BE.VisitantesBE vis)
        {
            try
            {
                string query = string.Format("UPDATE Visitantes SET Apellido = '{2}', Nombre = '{1}', Cel = '{3}', DVH = '{8}', Direccion = '{4}', Email = '{6}', DNI ='{5}', NombreUsuario = '{3}', Telefono = '{7}',  WHERE IDVisitante = '{0}'", vis.DNI, vis.Apellido, vis.DVH, vis.Direccion, vis.Email, vis.Nombre, vis.NombreUsuario, vis.Telefono);
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
                throw new Exception(ex.Message);
            }
        }
        //Listar todos los Visitantes de la base
        public List<BE.VisitantesBE> ListarVisitantes(List<BE.VisitantesBE> datVis)
        {
            try
            {
                string consulta = string.Format("SELECT * FROM Visitantes");
                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = consulta;
                SqlDataReader lector = Comando.ExecuteReader();
                while (lector.Read())
                {
                    BE.VisitantesBE vis = new BE.VisitantesBE();

                    vis.Apellido = lector["Apellido"].ToString();
                    vis.DNI = lector["DNI"].ToString();
                    vis.DVH = lector["DVH"].ToString();
                    vis.Email = lector["Email"].ToString();
                    vis.Nombre = lector["Nombre"].ToString();
                    vis.NombreUsuario = lector["NombreUsuario"].ToString();
                    vis.Direccion = lector["Direccion"].ToString();
                    vis.Telefono = lector["Telefono"].ToString();
                    datVis.Add(vis);
                }
                Desconectar();
                return datVis;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Busco un usuario por Nombre/ID
        public List<BE.VisitantesBE> BuscarunVisitantesDNI (string DNI)
        {
            try
            {
                string consulta = string.Format("SELECT * FROM Visitantes Where DNI = '{5}'", DNI);
                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = consulta;
                SqlDataReader lector = Comando.ExecuteReader();
                ListadoVisitantes = new List<BE.VisitantesBE>();
                while (lector.Read())
                {
                    this.DNI.Apellido = lector["Apellido"].ToString();
                    this.DNI.DNI = lector["DNI"].ToString();
                    this.DNI.DVH = lector["DVH"].ToString();
                    this.DNI.Email = lector["Email"].ToString();
                    this.DNI.Nombre = lector["Nombre"].ToString();
                    this.DNI.NombreUsuario = lector["NombreUsuario"].ToString();
                    this.DNI.Direccion = lector["Direccion"].ToString();
                    this.DNI.Telefono = lector["Telefono"].ToString();
                    ListadoVisitantes.Add(this.DNI);
                }
                Desconectar();
                return ListadoVisitantes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public VisitantesDAL_D()
        {
        }
    }
}
