using System;
using System.Collections.Generic;
using System.Data;

namespace DAL_Datos
{
    public class PerfilDAL_D :IFamilia
    {
        public void BorrarFamilia(int idFam)
        {
            DataTable DT = DAL_Servicios.Comando.objDatatable("select * from Familia where ID_Familia = '" + idFam + "'");
            ;
            DAL_Servicios.Comando.actualizarBD("select * from Familia", DT);
        }

        public void InsertarFamilia(string nomFam)
        {
            DataTable DT = DAL_Servicios.Comando.objDatatable("select * from Familia");
            DataRow DR = DT.NewRow();
            DR.ItemArray[1] = nomFam;
            DT.Rows.Add(DR);
            DAL_Servicios.Comando.actualizarBD("select * from Familia", DT);
        }

        public List<BE.FamiliaBE> ListarFamilias()
        {
            var ListaFamilia = new List<BE.FamiliaBE>();
            DataTable DT = DAL_Servicios.Comando.objDatatable("select * from Familia");
            BE.FamiliaBE F;
            foreach (DataRow DR in DT.Rows)
            {
                F = new BE.FamiliaBE();
                F.IDFamilia = (int)DR.ItemArray[0];
                F.NombreFamilia = (string)DR.ItemArray[1];
                ListaFamilia.Add(F);
                F = default;
            }

            return ListaFamilia;
        }

        public void BorrarUsuarioFamilia(int idFam, int idUsu)
        {
            DataTable DT = DAL_Servicios.Comando.objDatatable("select * from UsuarioFamilia,  where ID_Familia = '" + idFam + "' and ID_Usuario = '" + idUsu + "'");
            DT.Rows[0].Delete();
            DAL_Servicios.Comando.actualizarBD("select * from UsuarioFamilia", DT);
        }

        public void InsertarUsuarioFamilia(int idFam, int idUsu)
        {
            DataTable DT = DAL_Servicios.Comando.objDatatable("select * from UsuarioFamilia");
            DataRow DR = DT.NewRow();
            DR.ItemArray[0] = idFam;
            DR.ItemArray[1] = idUsu;
            DT.Rows.Add(DR);
            DAL_Servicios.Comando.ActualizarBD("select * from UsuarioFamilia", DT);
            Servicios.DigitosVerificadores.GrabarPorTabla("SELECT * from UsuarioFamilia");
        }

        public static List<BE.PerfilAbstractoBE> DarPerfil(DataTable DT)
        {
            var ListaPerfil = new List<BE.PerfilAbstractoBE>();
            try
            {
                if (DT.Rows.Count > 0)
                {
                    foreach (DataRow row in DT.Rows)
                        ListaPerfil.Add(CargarPerfil(row));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return ListaPerfil;
        }

        public static BE.PerfilAbstractoBE CargarPerfil(DataRow DR)
        {
            var P = new BE.PerfilBE();
            try
            {
                P.IDPerfil = (int)DR[0];
                P.Detalle = (string)DR[1];
                P.FamiliaPatente = PatenteDAL_D.DarPatentes_Usu(P.IDPerfil);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return P;
        }

        public void ModificarFamilia(int idFam, int idUsu)
        {
            DataTable DT = DAL_Servicios.Comando.objDatatable("select * from UsuarioFamilia where ID_Usuario='" + idUsu.ToString() + "'");
            DT.Rows[0].ItemArray[1] = idFam.ToString();
            DAL_Servicios.Comando.actualizarBD("select * from UsuarioFamilia", DT);
        }
    }
}
