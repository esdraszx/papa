using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace DAL_Datos
{
    public class BitacoraDAL_D
    {
        private static BitacoraDAL_D Instancia;


        public static BitacoraDAL_D GetInstance()
        {
            if (Instancia == null)
            {
                Instancia = new BitacoraDAL_D();
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

        //Grabar BitacoraDAL_D
        public void GrabarBitacora(BE.BitacoraBE bit)
        {
            int ID_Evento = bit.ID_Evento;
            string Descripcion = bit.Descripcion;
            TripleDES DescripciónEnc = bit.DescripciónEnc;
            DateTime FechaHora = bit.FechaHora;
            char Criticidad = bit.Criticidad;
            string NombreUsuario = bit.NombreUsuario;
            string DVH = bit.DVH;
            string query = string.Format("INSERT INTO BitacoraU VALUES('{0}', '{1}', '{2}', '{3}', '{4}') ,'{5}'", ID_Evento, Descripcion, FechaHora.ToString("yyyy-MM-dd HH:mm:ss"), Criticidad, NombreUsuario, DVH);
            Conectar();
            Comando.Connection = Conect;
            Comando.CommandType = CommandType.Text;
            Comando.CommandText = query;
            Comando.ExecuteNonQuery();
            Desconectar();
        }
        //Carga de bitacora
        public List<BE.BitacoraBE> ListarBitacoraDAL_D(List<BE.BitacoraBE> ListaB)
        {
            string consulta = string.Format("SELECT ID_Evento , Descripcion , Fecha  FROM Bitacora");
            Conectar();
            Comando.Connection = Conect;
            Comando.CommandType = CommandType.Text;
            Comando.CommandText = consulta;
            SqlDataReader lector = Comando.ExecuteReader();
            ListaB = new List<BE.BitacoraBE>();
            while (lector.Read())
            {
               
                BE.BitacoraBE Bit = new BE.BitacoraBE();
                Bit.ID_Evento = int.Parse(lector["ID_Evento"].ToString());
                //Bit.Criticidad = char.Parse(lector["Criticidad"].ToString());
                Bit.Descripcion = lector["Descripcion"].ToString();
                //Bit.NombreUsuario = lector["NombreUsuario"].ToString();
                Bit.FechaHora = DateTime.Parse(lector["Fecha"].ToString());
                //string des = Bit.Descripción;
                //string semilla = "123456";
                //des = BE.Globales.Desencriptar(des, semilla);
                //Bit.Descripción = des;
                ListaB.Add(Bit);
            }
            Desconectar();
            return ListaB;
        }
        //Busqueda por los dos criterios
        public List<BE.BitacoraBE> ListarBitacoraDAL_DAmbosCriterios(List<BE.BitacoraBE> ListaB, string C, string Usu)
        {
            string consulta = string.Format("SELECT * FROM BitacoraU WHERE Criticidad = '{0}' AND NombreUsuario = '{1}'", C, Usu);
            Conectar();
            Comando.Connection = Conect;
            Comando.CommandType = CommandType.Text;
            Comando.CommandText = consulta;
            SqlDataReader lector = Comando.ExecuteReader();
            ListaB = new List<BE.BitacoraBE>();
            while (lector.Read())
            {
                BE.BitacoraBE Bit = new BE.BitacoraBE();
                Bit.ID_Evento = int.Parse(lector["ID_Evento"].ToString());
                Bit.Criticidad = char.Parse(lector["Criticidad"].ToString());
                Bit.Descripcion = lector["Descripcion"].ToString();
                Bit.NombreUsuario = lector["NombreUsuario"].ToString();
                Bit.FechaHora = DateTime.Parse(lector["FechaHora"].ToString());
                string des = Bit.Descripcion;
                string semilla = "123456";
                des = BE.Globales.Desencriptar(des, semilla);
                Bit.Descripcion = des;
                ListaB.Add(Bit);
            }
            Desconectar();
            return ListaB;
        }
        //Busqueda por Criticidad
        public List<BE.BitacoraBE> ListarBitacoraDAL_DCriticidad(List<BE.BitacoraBE> ListaB, string C)
        {
            string consulta = string.Format("SELECT * FROM BitacoraU WHERE Criticidad = '{0}'", C);
            Conectar();
            Comando.Connection = Conect;
            Comando.CommandType = CommandType.Text;
            Comando.CommandText = consulta;
            SqlDataReader lector = Comando.ExecuteReader();
            ListaB = new List<BE.BitacoraBE>();
            while (lector.Read())
            {
                BE.BitacoraBE Bit = new BE.BitacoraBE();
                Bit.ID_Evento = int.Parse(lector["ID_Evento"].ToString());
                Bit.Criticidad = char.Parse(lector["Criticidad"].ToString());
                Bit.Descripcion = lector["Descripcion"].ToString();
                Bit.NombreUsuario = lector["NombreUsuario"].ToString();
                Bit.FechaHora = DateTime.Parse(lector["FechaHora"].ToString());
                string des = Bit.Descripcion;
                string semilla = "123456";
                des = BE.Globales.Desencriptar(des, semilla);
                Bit.Descripcion = des;
                ListaB.Add(Bit);
            }
            Desconectar();
            return ListaB;
        }
        //Busqueda por Usuario
        public List<BE.BitacoraBE> ListarBitacoraDAL_DUsuario(List<BE.BitacoraBE> ListaB, string Usu)
        {
            string consulta = string.Format("SELECT * FROM BitacoraU WHERE NombreUsuario = '{0}'", Usu);
            Conectar();
            Comando.Connection = Conect;
            Comando.CommandType = CommandType.Text;
            Comando.CommandText = consulta;
            SqlDataReader lector = Comando.ExecuteReader();
            ListaB = new List<BE.BitacoraBE>();
            while (lector.Read())
            {
                BE.BitacoraBE Bit = new BE.BitacoraBE();
                Bit.ID_Evento = int.Parse(lector["ID_Evento"].ToString());
                Bit.Criticidad = char.Parse(lector["Criticidad"].ToString());
                Bit.Descripcion = lector["Descripcion"].ToString();
                Bit.NombreUsuario = lector["NombreUsuario"].ToString();
                Bit.FechaHora = DateTime.Parse(lector["FechaHora"].ToString());
                string des = Bit.Descripcion;
                string semilla = "123456";
                des = BE.Globales.Desencriptar(des, semilla);
                Bit.Descripcion = des;
                ListaB.Add(Bit);
            }
            Desconectar();
            return ListaB;
        }
        //Depurar bitacora segun fecha
        public void DepurarBitacora(DateTime fecha)
        {
            string query = string.Format("DELETE FROM Bitacora WHERE Fecha < '{0}'", fecha);
            Conectar();
            Comando.Connection = Conect;
            Comando.CommandType = CommandType.Text;
            Comando.CommandText = query;
            Comando.ExecuteNonQuery();
            Desconectar();
        }
        //Busqueda por Rango de Fechas
        public List<BE.BitacoraBE> ListarBitacoraFecha(List<BE.BitacoraBE> ListaB, BE.BitacoraBE b1, BE.BitacoraBE b2)
        {
            string consulta = string.Format("SELECT * FROM Bitacora WHERE  FechaHora > '{0}' and FechaHora < '{1}'", b1.FechaHora.ToString("yyyy-MM-dd"), b2.FechaHora.ToString("yyyy-MM-dd"));
            Conectar();
            Comando.Connection = Conect;
            Comando.CommandType = CommandType.Text;
            Comando.CommandText = consulta;
            SqlDataReader lector = Comando.ExecuteReader();
            ListaB = new List<BE.BitacoraBE>();
            while (lector.Read())
            {
                BE.BitacoraBE Bit = new BE.BitacoraBE();
                Bit.ID_Evento = int.Parse(lector["ID_Evento"].ToString());
                Bit.Criticidad = char.Parse(lector["Criticidad"].ToString());
                Bit.Descripcion = lector["Descripcion"].ToString();
                Bit.NombreUsuario = lector["NombreUsuario"].ToString();
                Bit.FechaHora = DateTime.Parse(lector["FechaHora"].ToString());
                string des = Bit.Descripcion;
                string semilla = "123456";
                des = BE.Globales.Desencriptar(des, semilla);
                Bit.Descripcion = des;
                ListaB.Add(Bit);
            }
            Desconectar();
            return ListaB;
        }
        //Busqueda por Rango de Fechas y Criticidad
        public List<BE.BitacoraBE> ListarBitacoraFechaCrit(List<BE.BitacoraBE> ListaB, BE.BitacoraBE b1, BE.BitacoraBE b2, string C)
        {
            string consulta = string.Format("SELECT * FROM BitacoraU WHERE  FechaHora > '{0}' and FechaHora < '{1}' and Criticidad = '{2}'", b1.FechaHora.ToString("yyyy-MM-dd"), b2.FechaHora.ToString("yyyy-MM-dd"), C);

            Conectar();
            Comando.Connection = Conect;
            Comando.CommandType = CommandType.Text;
            Comando.CommandText = consulta;
            SqlDataReader lector = Comando.ExecuteReader();
            ListaB = new List<BE.BitacoraBE>();
            while (lector.Read())
            {
                BE.BitacoraBE Bit = new BE.BitacoraBE();
                Bit.ID_Evento = int.Parse(lector["ID_Evento"].ToString());
                Bit.Criticidad = char.Parse(lector["Criticidad"].ToString());
                Bit.Descripcion = lector["Descripcion"].ToString();
                Bit.NombreUsuario = lector["NombreUsuario"].ToString();
                Bit.FechaHora = DateTime.Parse(lector["FechaHora"].ToString());
                string des = Bit.Descripcion;
                string semilla = "123456";
                des = BE.Globales.Desencriptar(des, semilla);
                Bit.Descripcion = des;
                ListaB.Add(Bit);
            }
            Desconectar();
            return ListaB;
        }
        //Busqueda por Rango de Fechas y Criticidad Y ID
        public List<BE.BitacoraBE> ListarBitacoraFechaCritID(List<BE.BitacoraBE> ListaB, BE.BitacoraBE b1, BE.BitacoraBE b2, string C, string USU)
        {
            string consulta = string.Format("SELECT * FROM BitacoraU WHERE  FechaHora > '{0}' and FechaHora < '{1}' and Criticidad = '{2}' and NombreUsuario = '{3}'", b1.FechaHora.ToString("yyyy-MM-dd"), b2.FechaHora.ToString("yyyy-MM-dd"), C, USU);
            Conectar();
            Comando.Connection = Conect;
            Comando.CommandType = CommandType.Text;
            Comando.CommandText = consulta;
            SqlDataReader lector = Comando.ExecuteReader();
            ListaB = new List<BE.BitacoraBE>();
            while (lector.Read())
            {
                BE.BitacoraBE Bit = new BE.BitacoraBE();
                Bit.ID_Evento = int.Parse(lector["ID_Evento"].ToString());
                Bit.Criticidad = char.Parse(lector["Criticidad"].ToString());
                Bit.Descripcion = lector["Descripcion"].ToString();
                Bit.NombreUsuario = lector["NombreUsuario"].ToString();
                Bit.FechaHora = DateTime.Parse(lector["FechaHora"].ToString());
                string des = Bit.Descripcion;
                string semilla = "123456";
                des = BE.Globales.Desencriptar(des, semilla);
                Bit.Descripcion = des;
                ListaB.Add(Bit);
            }
            Desconectar();
            return ListaB;
        }
        //Busqueda por Rango de Fechas Y ID
        public List<BE.BitacoraBE> ListarBitacoraFechaID(List<BE.BitacoraBE> ListaB, BE.BitacoraBE b1, BE.BitacoraBE b2, string USU)
        {
            string consulta = string.Format("SELECT * FROM BitacoraU WHERE  FechaHora > '{0}' and FechaHora < '{1}' and NombreUsuario = '{2}'", b1.FechaHora.ToString("yyyy-MM-dd"), b2.FechaHora.ToString("yyyy-MM-dd"), USU);
            Conectar();
            Comando.Connection = Conect;
            Comando.CommandType = CommandType.Text;
            Comando.CommandText = consulta;
            SqlDataReader lector = Comando.ExecuteReader();
            ListaB = new List<BE.BitacoraBE>();
            while (lector.Read())
            {
                BE.BitacoraBE Bit = new BE.BitacoraBE();
                Bit.ID_Evento = int.Parse(lector["ID_Evento"].ToString());
                Bit.Criticidad = char.Parse(lector["Criticidad"].ToString());
                Bit.Descripcion = lector["Descripcion"].ToString();
                Bit.NombreUsuario = lector["NombreUsuario"].ToString();
                Bit.FechaHora = DateTime.Parse(lector["FechaHora"].ToString());
                string des = Bit.Descripcion;
                string semilla = "123456";
                des = BE.Globales.Desencriptar(des, semilla);
                Bit.Descripcion = des;
                ListaB.Add(Bit);
            }
            Desconectar();
            return ListaB;
        }
        public static void GrabarBitacora(string mensaje)
        {

            // TRAIGO TODA LA BITACORA EN UN DATATABLE
            DataTable DT = DAL_Servicios.Comando.objDatatable("select * from Bitacora");
            // CREO UN NUEVO DATAROW CON EL FORMATO DEL DATATABLE DE BITACORA
            //int i = DT.Rows.Count + 1;
            DataRow DR = DT.NewRow();
                try
                {
                // CARGO TODOS LOS VALORES DEL NUEVO EVENTO A REGISTRAR
                //DR.ItemArray[0] = " "; 
                DR.ItemArray[2] = DateAndTime.Now;
                DR.ItemArray[1] = mensaje;
                   
                    // DR.ItemArray[3] = " ";
                    // LO AGREGO AL DATATABLE
                    DT.Rows.Add(DR);
                    // Y ACTUALIZO LA TABLA BITACORA
                    DAL_Servicios.Comando.ActualizarBD("select * from Bitacora", DT);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
        }
    }
}

