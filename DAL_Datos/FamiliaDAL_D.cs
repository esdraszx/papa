using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL_Datos
{
    public class FamiliaDAL_D
    {
        //Singleton
        private static FamiliaDAL_D Instancia;
        public static FamiliaDAL_D GetInstance()
        {
            if (Instancia == null)
            {
                Instancia = new FamiliaDAL_D();
            }
            return Instancia;
        }
        public List<FamiliaBE> ListaFamilias { get; set; }
        public List<FamiliaPatenteBE> ListarFamiliaPatentes { get; set; }

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
        //Listar todos las familias de la base
        public List<FamiliaBE> ListarFamilia(List<FamiliaBE> datFam)
        {
            string consulta = string.Format("SELECT * FROM Familia");
            Conectar();
            Comando.Connection = Conect;
            Comando.CommandType = CommandType.Text;
            Comando.CommandText = consulta;
            SqlDataReader lector = Comando.ExecuteReader();
            while (lector.Read())
            {
                FamiliaBE fam = new FamiliaBE();
                fam.IDFamilia = int.Parse(lector["ID_Familia"].ToString());
                fam.NombreFamilia = lector["Nombre_Familia"].ToString();
                datFam.Add(fam);
            }
            Desconectar();
            return datFam;
        }
        //Alta de Familia
        public bool AltaFamilia(FamiliaBE Fam)
        {
            string query = string.Format("INSERT INTO Familia VALUES('{0}')", Fam.NombreFamilia);
            Conectar();
            Comando.Connection = Conect;
            Comando.CommandType = CommandType.Text;
            Comando.CommandText = query;
            Comando.ExecuteNonQuery();
            Desconectar();
            return true;
        }
        public object ListaFamilia(FamiliaBE datFam)
        {
            string query = string.Format("Familia VALUES('{0}')", datFam.NombreFamilia);
            Conectar();
            Comando.Connection = Conect;
            Comando.CommandType = CommandType.Text;
            Comando.CommandText = query;
            SqlDataReader lector = Comando.ExecuteReader();
            while (lector.Read())
            {
                BE.FamiliaBE fam = new FamiliaBE();
                fam.IDFamilia = int.Parse(lector["ID_Familia"].ToString());
                fam.NombreFamilia = lector["Nombre_Familia"].ToString();
                
            }
            Desconectar();
            return datFam;
        }
        //Borrar Familia
        public bool BorrarFamilia(FamiliaBE Fam)
        {
            string query = string.Format("Delete FROM Familia  WHERE Id_Familia = '{0}'", Fam.NombreFamilia);
            Conectar();
            Comando.Connection = Conect;
            Comando.CommandType = CommandType.Text;
            Comando.CommandText = query;
            Comando.ExecuteNonQuery();
            Desconectar();
            //Borro Usuario_Familia
            BorrarUsuarioFamilia(Fam);
            //Borro Familia_Patentes
            BorrarFamiliaPatente(Fam);
            return true;
        }
        //Eliminar Familia del usuario
        public bool BorrarUsuarioFamilia(FamiliaBE Fam)
        {
            string query = string.Format("Delete FROM UsuarioFamilia  WHERE ID_Familia = '{0}'", Fam.NombreFamilia);
            Conectar();
            Comando.Connection = Conect;
            Comando.CommandType = CommandType.Text;
            Comando.CommandText = query;
            Comando.ExecuteNonQuery();
            Desconectar();
            return true;
        }
        //Eliminar Familia del usuario
        public bool BorrarFamiliaPatente(FamiliaBE Fam)
        {
            string query = string.Format("Delete FROM FamiliaPatente  WHERE ID_Familia = '{0}'", Fam.NombreFamilia);
            Conectar();
            Comando.Connection = Conect;
            Comando.CommandType = CommandType.Text;
            Comando.CommandText = query;
            Comando.ExecuteNonQuery();
            Desconectar();
            return true;
        }
        //Listar todos las patentes de la familia
        public List<PatenteBE> ListarPatentesFamilia(List<PatenteBE> ListPat, FamiliaBE Fam)
        {
            string consulta = string.Format("SELECT * FROM FamiliaPatente  WHERE ID_Familia = '{0}'", Fam.IDFamilia);
            Conectar();
            Comando.Connection = Conect;
            Comando.CommandType = CommandType.Text;
            Comando.CommandText = consulta;
            SqlDataReader lector = Comando.ExecuteReader();
            while (lector.Read())
            {
                PatenteBE pat = new PatenteBE();
                pat.ID_Patente = int.Parse(lector["ID_Patente"].ToString());
                ListPat.Add(pat);
            }
            Desconectar();
            return ListPat;
        }
        //public List<PatenteBE> ListarFamiliaPatentes( FamiliaPatenteBE FamPat)
        //{
        //    //string consulta = string.Format("SELECT * FROM FamiliaPatente  WHERE ID_Familia = '{0}'", FamPat.ID_Familia);
        //    //Conectar();
        //    //Comando.Connection = Conect;
        //    //Comando.CommandType = CommandType.Text;
        //    //Comando.CommandText = consulta;
        //    //SqlDataReader lector = Comando.ExecuteReader();
        //    //while (lector.Read())
        //    //{
        //    //    PatenteBE pat = new PatenteBE();
        //    //    pat.ID_Patente = int.Parse(lector["ID_Patente"].ToString());
        //    //    FamPat.FamiliaPatentes.Add(pat);
        //    //}
        //    //Desconectar();
        //    //return ListPat;
        //}
        //Borrar Familia_Patente
        public bool BorrarFamiliaPatente(FamiliaBE Fam, PatenteBE Pat)
        {
            string query = string.Format("Delete FROM FamiliaPatente  WHERE Id_Familia = '{0}' AND ID_Patente = '{1}'", Fam.NombreFamilia, Pat.ID_Patente);
            Conectar();
            Comando.Connection = Conect;
            Comando.CommandType = CommandType.Text;
            Comando.CommandText = query;
            Comando.ExecuteNonQuery();
            Desconectar();
            return true;
        }
        //Alta de Familia_Patente
        public bool AltaFamiliaPatente(FamiliaBE Fam, PatenteBE Pat)
        {
            string query = string.Format("INSERT INTO FamiliaPatente VALUES('{0}','{1}', '{2}')", Fam.IDFamilia,Pat.ID_Patente,Fam.DVH);
            Conectar();
            Comando.Connection = Conect;
            Comando.CommandType = CommandType.Text;
            Comando.CommandText = query;
            Comando.ExecuteNonQuery();
            Desconectar();
            return true;
        }
        //Buscar una patente dentro de una familia
        public bool BuscarPatentedeFamilia(FamiliaBE Fam, PatenteBE Pat)
        {
            string consulta = string.Format("SELECT * FROM FamiliaPatente  WHERE ID_Familia != '{0}' AND ID_Patente = '{1}'", Fam.IDFamilia, Pat.ID_Patente);
            Conectar();
            Comando.Connection = Conect;
            Comando.CommandType = CommandType.Text;
            Comando.CommandText = consulta;
            if (Comando.ExecuteScalar() == null)
            {
                Desconectar();
                return false;
            }
            else
            {
                Desconectar();
                return true;
            };
        }
        //Buscar Familia Patente
        public FamiliaBE FamiliaPatente(FamiliaBE F)
        {
            try
            {
                string consulta = string.Format("SELECT * FROM FamiliaPatente   Where ID_Familia = '{0}'", F.IDFamilia);
                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = consulta;
                SqlDataReader lector = Comando.ExecuteReader();
                while (lector.Read())
                {
                    FamiliaPatenteBE Patente = new FamiliaPatenteBE();
                    Patente.ID_Patente = int.Parse(lector["ID_Patente"].ToString());
                    Patente.ID_Familia = int.Parse(lector["ID_Familia"].ToString());
                    F.IDFamilia = Patente.ID_Familia;
                }
                Desconectar();
                return F;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Buscar Familia Patente
        public List<FamiliaBE> BuscarunaFamiliaID(int ID_familia)
        {
            try
            {
                string consulta = string.Format("SELECT * FROM Familia Where ID_Familia = '{0}'", ID_familia);
                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = consulta;
                SqlDataReader lector = Comando.ExecuteReader(); 
                ListaFamilias = new List<FamiliaBE>();
                while (lector.Read())
                {
                    FamiliaBE Fam = new FamiliaBE();
                    Fam.IDFamilia = int.Parse(lector["ID_Familia"].ToString());
                    Fam.NombreFamilia = lector["Nombre_Familia"].ToString();

                    ListaFamilias.Add(Fam);
                }
                Desconectar();
                return ListaFamilias;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<FamiliaPatenteBE> BuscarPatentesconIDFamilia(int ID_familia)
        {
            try
            {
                string consulta = string.Format("SELECT * FROM FamiliaPatente  Where ID_Familia = '{0}'", ID_familia);
                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = consulta;
                SqlDataReader lector = Comando.ExecuteReader();
                ListarFamiliaPatentes = new List<FamiliaPatenteBE>(); 
                while (lector.Read())
                {
                    FamiliaPatenteBE FamPat = new FamiliaPatenteBE();
                    FamPat.ID_Familia = int.Parse(lector["ID_Familia"].ToString());
                    FamPat.ID_Patente = int.Parse(lector["ID_Patente"].ToString());

                    ListarFamiliaPatentes.Add(FamPat);
                }
                Desconectar();
                return ListarFamiliaPatentes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Obtengo un listado con todas las familias que tienen una patente especifica
        //Listar todos las patentes de la familia
        public List<FamiliaBE> ListarFamiliaporPatente(List<FamiliaBE> ListFam, PatenteBE Pat)
        {
            string consulta = string.Format("SELECT * FROM FamiliaPatente WHERE ID_Patente = '{0}'", Pat.ID_Patente);
            Conectar();
            Comando.Connection = Conect;
            Comando.CommandType = CommandType.Text;
            Comando.CommandText = consulta;
            SqlDataReader lector = Comando.ExecuteReader();
            while (lector.Read())
            {
                FamiliaBE Fam = new FamiliaBE();
                Fam.NombreFamilia = lector["ID_Familia"].ToString();
                ListFam.Add(Fam);
            }
            Desconectar();
            return ListFam;
        }
        //Listar todos las patentes de la familia
        public List<FamiliaBE> ListarFamiliaporPatente(List<FamiliaBE> ListFam, PatenteBE Pat, FamiliaBE F)
        {
            string consulta = string.Format("SELECT * FROM FamiliaPatente  WHERE ID_Patente = '{0}' AND ID_Familia !='{1}'", Pat.ID_Patente, F.NombreFamilia);
            Conectar();
            Comando.Connection = Conect;
            Comando.CommandType = CommandType.Text;
            Comando.CommandText = consulta;
            SqlDataReader lector = Comando.ExecuteReader();
            while (lector.Read())
            {
                FamiliaBE Fam = new FamiliaBE();
                Fam.NombreFamilia = lector["ID_Familia"].ToString();
                ListFam.Add(Fam);
            }
            Desconectar();
            return ListFam;
        }
        //Valida si ya existe la familia en la BD
        public bool ValidarFamiliaAlta(FamiliaBE FAM)
        {
            try
            {
                string query = string.Format("select * from Familia where Id_Fmilia  = '{0}'", FAM.NombreFamilia);
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
        // Valida si ya existe el Usuario con  familia en la BD
        public bool ValidaFamilia( UsuarioBE Usu , FamiliaBE Fam)
            {
                try
                {
                    string query = string.Format("select * from UsuarioFamilia  where ID_Usuario  = '{0}' and ID_Familia = '{1}'", Usu.IDUsuario ,Fam.IDFamilia);
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

            public bool ValidarFamiliaNombre(FamiliaBE Fam)
            {
                try
                {
                    string query = string.Format("select * from Familia  where ID_Familia  = '{0}' and Nombre_Familia = '{1}'", Fam.IDFamilia ,Fam.NombreFamilia);
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
