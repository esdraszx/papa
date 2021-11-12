using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL_Datos
{
    public class PatenteDAL_D : IPatente
    {


        private static PatenteDAL_D patenteDAL_D;
        public static PatenteDAL_D InstanciaR()
        {
            patenteDAL_D = new PatenteDAL_D();

            return patenteDAL_D;
        }

        //Singleton
        private static PatenteDAL_D Instancia;
        public static PatenteDAL_D GetInstance()
        {
            //if (Instancia == null)
            //{
                Instancia = new PatenteDAL_D();
            
            return Instancia;
        }

        public List<PatenteBE> ListaPatentes { get; set;}

        
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

        public void BorrarPatente(int idPat)
        {
            DataTable DT = DAL_Servicios.Comando.objDatatable("select * from Patente where ID_Patente = '" + idPat + "'");
            DT.Rows[0].Delete();
            DAL_Servicios.Comando.actualizarBD("select * from Patente", DT);
        }

        public void InsertarPatente(PatenteBE PatenteBE)
        {
            DataTable DT = DAL_Servicios.Comando.objDatatable("select * from patente");
            DataRow DR = DT.NewRow();
            DR.ItemArray[1] = PatenteBE.Descripcion;
            DR.ItemArray[2] = PatenteBE.Grupo;
            DR.ItemArray[3] = PatenteBE.Detalle;
            DT.Rows.Add(DR);
            DAL_Servicios.Comando.actualizarBD("select * from Patente", DT);
        }
        public List<PatenteBE> ListarPatentes()
        {
            var ListaPatente = new List<PatenteBE>();
            DataTable DT = DAL_Servicios.Comando.objDatatable("select * from Patente");
            PatenteBE P;
            foreach (DataRow DR in DT.Rows)
            {
                P = new PatenteBE();
                P.Descripcion = (string)DR.ItemArray[1];
                P.Grupo = (string)DR.ItemArray[2];
                P.Detalle = (string)DR.ItemArray[3];
                ListaPatente.Add(P);
                P = default;
            }

            return ListaPatente;
        }
        public void BorrarPatenteFamilia(int idPat, int idFam)
        {
            DataTable DT = DAL_Servicios.Comando.objDatatable("select * from PatenteFamilia where ID_Patente = '" + idPat + "' and ID_Familia = '" + idFam + "'");
            DT.Rows[0].Delete();
            DAL_Servicios.Comando.actualizarBD("select * from PatenteFamilia", DT);
        }
        public void InsertarPatenteFamilia(int idPat, int idFam)
        {
            DataTable DT = DAL_Servicios.Comando.objDatatable("select * from PatenteFamilia");
            DataRow DR = DT.NewRow();
            DR.ItemArray[0] = idPat;
            DR.ItemArray[1] = idFam;
            DT.Rows.Add(DR);
            DAL_Servicios.Comando.actualizarBD("select * from PatenteFamilia", DT);
        }
        //Este metodo lo utilizo para obtener  los permisos para  recalcularDV
        public static List<PerfilAbstractoBE> DarPatentes_Usu(int idUsu)
        {
            var ListaPatente = new List<PerfilAbstractoBE>();
            DataTable DT = DAL_Servicios.Comando.objDatatable("select * from Patente, FamiliaPatente, UsuarioFamilia where UsuarioFamilia.ID_Usuario= '" + idUsu + "' and UsuarioFamilia.ID_Familia = FamiliaPatente.ID_Familia and FamiliaPatente.ID_Patente = Patente.ID_Patente");
            try
            {
                if (DT.Rows.Count > 0)
                {
                    foreach (DataRow row in DT.Rows)
                        ListaPatente.Add(CargarPatentes(row));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return ListaPatente;
        }
        public static List<PerfilAbstractoBE> DarPatente_Fam(int idFam)
        {
            var ListaPatente = new List<PerfilAbstractoBE>();
            try
            {
                DataTable DT = DAL_Servicios.Comando.objDatatable("select * from FamiliaPatente where FamiliaPatente.ID_Familia ='" + idFam + "'");
                if (DT.Rows.Count > 0)
                {
                    foreach (DataRow row in DT.Rows)
                        ListaPatente.Add(CargarPatentes(row));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return ListaPatente;
        }
        public static List<PerfilAbstractoBE> DarPatente(int idFamilia)
        {
            List<PerfilAbstractoBE> ListaPatente = new List<PerfilAbstractoBE>();
            try
            {
                DataTable DT = DAL_Servicios.Comando.objDatatable("select * from familia_patente where id_familia = " + idFamilia.ToString());
                if (DT.Rows.Count > 0)
                {
                    foreach (DataRow row in DT.Rows)
                    {
                        ListaPatente.Add(CargarPatentes(row));
                    }
                }
            }
            catch
            {

            }
            return ListaPatente;
        }

        public static PerfilAbstractoBE CargarPatentes(DataRow DR)
        {
            var P = new PatenteBE();
            try
            {
                P.ID_Patente = (int)DR[0];
                P.Descripcion = (string)DR[3];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return P;
        } 
        //Listar todos las patentes de la base
        public List<PatenteBE> ListarPatentes(List<PatenteBE> datPat)
        {
            string consulta = string.Format("SELECT * FROM Patente");
            Conectar();
            Comando.Connection = Conect;
            Comando.CommandType = CommandType.Text;
            Comando.CommandText = consulta;
            SqlDataReader lector = Comando.ExecuteReader();

            while (lector.Read())
            {
                PatenteBE pat = new PatenteBE();
                pat.ID_Patente = int.Parse(lector["ID_Patente"].ToString());
                pat.Grupo = lector["Grupo"].ToString();
                pat.Detalle = lector["Detalle"].ToString();
                pat.Descripcion = lector["Descripcion"].ToString();
                datPat.Add(pat);
            }
            return datPat;
        }

        public bool AltaPatente(PatenteBE pat)
        {
            string query = string.Format("INSERT INTO Familia VALUES('{0}')", pat.ID_Patente);
            Conectar();
            Comando.Connection = Conect;
            Comando.CommandType = CommandType.Text;
            Comando.CommandText = query;
            Comando.ExecuteNonQuery();
            Desconectar();
            return true;
        }
        public List<PatenteBE> BuscarunaPatenteID(int ID_patente)
        {
            try
            {
                string consulta = string.Format("SELECT * FROM Patente Where ID_Patente ='{0}'",ID_patente);
                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = consulta;
                SqlDataReader lector = Comando.ExecuteReader();
                PatenteBE Pat = new PatenteBE();
                ListaPatentes = new List<PatenteBE>();
                while (lector.Read())
                {
                    Pat.ID_Patente = int.Parse(lector["ID_Patente"].ToString());
                    Pat.Descripcion = lector["Descripcion"].ToString();
                    Pat.Grupo = lector["Grupo"].ToString();
                    Pat.Detalle = lector["Detalle"].ToString();
                    ListaPatentes.Add(Pat);
                }
                Desconectar();
                return ListaPatentes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Valida si ya existe el usuario con patentes
        public bool ValidarPatente(  PatenteBE PAT , UsuarioBE Usu)
        {
            try
            {
                string query = string.Format("select * from UsuarioPatente  where ID_Patente  = '{0}' and ID_Usuario = '{1}'", PAT.ID_Patente , Usu.IDUsuario); 
                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = CommandType.Text;
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
        // Valida si ya existe las patentes
        public bool ValidarPatenteDetalle (PatenteBE PAT)
        {
            try
            {
                string query = string.Format("select * from Patente  where ID_Patente  = '{0}' and Detalle = '{1}'", PAT.ID_Patente, PAT.Detalle); 
                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = CommandType.Text;
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
        public bool ValidarPatenteAlta(PatenteBE PAT)
        {
            try
            {
                string query = string.Format("select * from UsuarioPatente  where ID_Patente  = '{0}' and Detalle = '{1}'", PAT.ID_Patente , PAT.Detalle);
                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = CommandType.Text;
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

    }
}
