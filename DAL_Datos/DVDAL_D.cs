using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL_Datos
{
    public class DVDAL_D
    {

        //Singleton
        private static DVDAL_D Instancia;


        public static DVDAL_D GetInstance()
        {
            if (Instancia == null)
            {
                Instancia = new DVDAL_D();
            }

            return Instancia;
        }
        //DataTable table;
        //SqlDataAdapter Adapter;


        static SqlConnection Conect = new SqlConnection();

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


        //Leer DV según tabla
        public string  CalcularDVV(BE.DVBE dvv)
        {
            int contador = 0;
            string contadorS = "";
            String consulta = string.Format("SELECT * FROM {0} ", dvv.Id_Tabla);

            Conectar();
            Comando.Connection = Conect;
            Comando.CommandType = CommandType.Text;
            Comando.CommandText = consulta;

            SqlDataReader lector = Comando.ExecuteReader();

            while (lector.Read())
            {
                contador += int.Parse(lector["DVH"].ToString());
            }

            Desconectar();
            contador = int.Parse(contadorS);
            return contadorS;


        }


        //Actualizar DVV
        public void ActualizarDVV(BE.DVBE dvv)
        {
            //encripto 

            string query = string.Format("UPDATE DVV SET Valor = {0}  WHERE Id_Tabla = '{1}'", dvv.Valor, dvv.Id_Tabla);

            Conectar();
            Comando.Connection = Conect;
            Comando.CommandType = System.Data.CommandType.Text;

            Comando.CommandText = query;
            Comando.ExecuteNonQuery();

            Desconectar();
        }


        //Alta de DVV
        public bool AltaDVV(BE.DVBE d)
        {


            string Id_Tabla = d.Id_Tabla;
            string Valor = d.Valor;

            string query = string.Format("INSERT INTO DVV VALUES('{0}', '{1}')", Id_Tabla, Valor);

            Conectar();
            Comando.Connection = Conect;
            Comando.CommandType = System.Data.CommandType.Text;

            Comando.CommandText = query;
            Comando.ExecuteNonQuery();

            Desconectar();

            return true;
        }


        // Valida que existe el en la base
        public bool Validar(BE.DVBE d)
        {

            try
            {
                string query = string.Format("select * from DVV where Id_TABLA = '{0}' ", d.Id_Tabla);
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


        //Listar tabla de digitos verificadores verticales
        public List<BE.DVBE> ListarDVV(List<BE.DVBE> Lista)
        {

            String consulta = string.Format("SELECT * FROM DVV ");

            Conectar();
            Comando.Connection = Conect;
            Comando.CommandType = CommandType.Text;
            Comando.CommandText = consulta;

            SqlDataReader lector = Comando.ExecuteReader();

            while (lector.Read())
            {
                BE.DVBE D = new BE.DVBE();
                D.Id_Tabla = lector["ID_TABLA"].ToString();
                D.Valor = lector["VALOR"].ToString();
                Lista.Add(D);
            }

            Desconectar();
            return Lista;


        }


        //Buscar los DVH de las tablas que estan en DVV
        static public List<string> BuscarDVH(string tabla)
        {
            List<string> mRegistros = new List<string>();
            string mRecord = "";

            String consulta = string.Format("SELECT * FROM {0} ", tabla);
            DataSet mDataset = new DataSet();

            // cargar un dataset
            mDataset = CargarDataset(consulta);

            if (mDataset.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow mROW in mDataset.Tables[0].Rows)
                {
                    for (int i = 0; i < mDataset.Tables[0].Columns.Count; i++)
                    {
                        string mCol = mDataset.Tables[0].Columns[i].ColumnName.ToString();
                        if (mCol != "DVH")
                            mRecord += mROW[mCol].ToString();
                        if (mCol == "DVH") //Agregamos el DVH con ; para parsear a posterior
                            mRecord += ";" + mROW[mCol].ToString();
                    }
                    mRegistros.Add(mRecord);
                    mRecord = "";
                }
            }
            return mRegistros;
        }



        static public DataSet CargarDataset(string Query)
        {
            try
            {

                Conect.ConnectionString = DAL_Servicios.Comando.GetInstance().ConexionString();
                Conect.Open();
                SqlDataAdapter mAdapter = new SqlDataAdapter(Query, Conect.ConnectionString);
                DataSet mDataset = new DataSet();
                mAdapter.Fill(mDataset);
                return mDataset;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                Conect.Close();
                Conect.Dispose();
            }

        }


    }
}
