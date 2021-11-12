using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Datos
{
    public class EmpleadoDAL_D
    {
        public List<BE.EmpleadoBE> ListadoEmpleados { get; set; }
        //Singleton
        private static EmpleadoDAL_D Instancia;
        public static EmpleadoDAL_D GetInstance()
        {
            if (Instancia == null)
            {
                Instancia = new EmpleadoDAL_D();
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
        //Listar todos los EmpleadoDAL_Des de la base
        public List<BE.EmpleadoBE> ListarEmpleado(List<BE.EmpleadoBE> datEmp)
        {
            try
            {
                string consulta = string.Format("SELECT * FROM EmpleadoDAL_D");
                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = consulta;
                SqlDataReader lector = Comando.ExecuteReader();
                while (lector.Read())
                {
                    BE.EmpleadoBE emp = new BE.EmpleadoBE();
                    emp.Apellido = lector["Apellido"].ToString();
                    emp.DNI = lector["DNI"].ToString();
                    emp.DVH = lector["DVH"].ToString();
                    //emp.DVH = int.Parse(lector["DVH"].ToString());
                    emp.Email = lector["Mail"].ToString();
                    emp.Nombre = lector["Nombre"].ToString();
                    emp.NombreUsuario = lector["NombreUsuario"].ToString();
                    emp.Telefono = lector["Telefono"].ToString();
                    emp.Direccion = lector["Direccion"].ToString();
                    datEmp.Add(emp);
                }
                Desconectar();
                return datEmp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Alta de Empleado
        public bool AltaEmpleado(BE.EmpleadoBE Emp)
        {
            try
            {
                string Apellido = Emp.Apellido;
                string NombreUsuario = Emp.NombreUsuario;
                string DNI = Emp.DNI;
                string DVH = Emp.DVH;
                string Direccion = Emp.Direccion;
                string Mail = Emp.Email;
                string Nombre = Emp.Nombre;
                string Telefono = Emp.Telefono;
                string query = string.Format("INSERT INTO Empleados VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}','{6}', '{7}', '{8}')", Apellido, DNI, DVH, Mail, Nombre, NombreUsuario, Direccion, Telefono);
                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = CommandType.Text;
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
        //Validar si ya existe un EmpleadoDAL_D en la BD
        public bool Validar(BE.EmpleadoBE Emp)
        {
            try
            {
                string query = string.Format("select * from EmpleadoDAL_D where DNI = '{0}' ", Emp.DNI);
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

                throw ex;
            }
        }
        //Buscar un Empleado
        public List<BE.EmpleadoBE> BuscarunEmpleadoDNI(string DNI)
        {
            try
            {
                string consulta = string.Format("SELECT * FROM EmpleadoDAL_D Where DNI = '{0}'", DNI);

                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = consulta;
                SqlDataReader lector = Comando.ExecuteReader();
                ListadoEmpleados = new List<BE.EmpleadoBE>();
                while (lector.Read())
                {
                    BE.EmpleadoBE emp = new BE.EmpleadoBE();
                    emp.Apellido = lector["Apellido"].ToString();
                    emp.DNI = lector["DNI"].ToString();
                    emp.DVH = lector["DVH"].ToString();
                    // emp.DVH = int.Parse(lector["DVH"].ToString());
                    emp.Email = lector["Mail"].ToString();
                    emp.Nombre = lector["Nombre"].ToString();
                    emp.NombreUsuario = lector["NombreUsuario"].ToString();
                    emp.Telefono = lector["Telefono"].ToString();
                    emp.Direccion = lector["Direccion"].ToString();

                    ListadoEmpleados.Add(emp);
                }

                Desconectar();
                return ListadoEmpleados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Delete de EmpleadoDAL_D
        public bool EliminarEmpleado(string Id)
        {
            try
            {
                string query = string.Format("Delete FROM EmpleadoDAL_D  WHERE DNI = '{0}'", Id);
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
        //Update de Empleado
        public bool ActualizarEmpleado(BE.EmpleadoBE emp)
        {
            try
            {
                string query = string.Format("UPDATE EmpleadoDAL_D SET Apellido = '{1}', DNI = '{0}', DVH = '{4}', Direccion = '{5}', Email = '{6}', Nombre = '{7}', NombreUsuario = '{10}', Telefono = '{11}' WHERE DNI = '{0}'" ,emp.DNI, emp.Apellido, emp.DVH, emp.Direccion, emp.Email, emp.Nombre, emp.NombreUsuario, emp.Telefono);
                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = CommandType.Text;
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
    }
}
