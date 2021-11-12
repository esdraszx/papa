using Microsoft.VisualBasic;
using System.Dynamic;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Windows.Input;
using System.Data.SqlClient;
using DAL_Servicios;
using System;
using BE;


namespace Servicios
{
    public partial class Bitacora
    {
        UsuarioBE usu;
        BitacoraBE bit;

        //SqlConnection Conect = new SqlConnection();
        //void Conectar()
        //{
        //    Conect.ConnectionString = DAL_Servicios.Comando.GetInstance().ConexionString();
        //    Conect.Open();
        //}
        //void Desconectar()
        //{
        //    Conect.Close();
        //    Conect.Dispose();
        //}
        //SqlCommand Comando = new SqlCommand();

        public static string MostrarBitacora()
        {
            // TRAIGO TODA LA BITACORA ORDENADA EN FORMA DESCENDENTE
            DataTable DT = Comando.objDatatable("SELECT * FROM Bitacora ORDER by ID_Evento DESC");
            // CUENTO LA CANTIDAD DE EVENTOS REGISTRADOS EN LA BITACORA Y LOS MUESTRO
            String msg = "Se registraron los siguientes " + DT.Rows.Count + " eventos: ";
            for (int i = 0, loopTo = DT.Rows.Count - 1; i <= loopTo; i++)
                // GUARDO EN UN STRING EVENTO POR EVENTO MAS UN ENTER
                msg = " ID_Evento: " + DT.Rows[i].ItemArray[0] + " | " + " Descripcion: " + DT.Rows[i].ItemArray[1] + " | " + " Fecha: " + DT.Rows[i].ItemArray[2];
            // DEVUELVO EL STRING CARGADO CON TODOS LOS EVENTOS DE LA BITACORA
            return msg;
        }

        public static  void GrabarBitacora(BitacoraBE bit)
        {
            int ID_Evento = bit.ID_Evento;
            string Descripcion = bit.Descripcion;
            //TripleDES DescripciónEnc = bit.DescripciónEnc;
            DateTime FechaHora = bit.FechaHora;

            string query = string.Format("INSERT INTO Bitacora ( Descripcion , Fecha ) VALUES('{0}', '{1}')" ,  Descripcion, FechaHora); //FechaHora.ToString("yyyy-MM-dd HH:mm:ss")
            Comando.objDatatable(string.Copy(query));
            

        }
        public static DataTable MostrarBitacoraDataTable()
        {
            return Comando.objDatatable("select id_evento, descripcion, fecha from bitacora order by id_evento desc");
        }


        public static void GrabarBitacora(String mensaje)
        {
           
            // TRAIGO TODA LA BITACORA EN UN DATATABLE
            DataTable DT = Comando.objDatatable("select * from Bitacora");
            // CREO UN NUEVO DATAROW CON EL FORMATO DEL DATATABLE DE BITACORA
           // int i = DT.Rows.Count + 1;
            DataRow DR = DT.NewRow();
            try
            {
                // CARGO TODOS LOS VALORES DEL NUEVO EVENTO A REGISTRAR
                // DR.ItemArray[0] = mensaje.ToString(); 
                DR.ItemArray[1] = mensaje.ToString();
                DR.ItemArray[2] = DateAndTime.Now;

                // LO AGREGO AL DATATABLE
                DT.Rows.Add(DR);
                // Y ACTUALIZO LA TABLA BITACORA
               Comando.ActualizarBD("select * from Bitacora", DT);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
         
    }
}
