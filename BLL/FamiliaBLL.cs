using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FamiliaBLL
    {
        //Llamo a la DAL

        private static FamiliaBLL Instancia;

        public static FamiliaBLL GetInstance()
        {
            if (Instancia == null)
            {
                Instancia = new FamiliaBLL();
            }

            return Instancia;
        }
        //Listar familias

        public List<BE.FamiliaBE> ListarFamilia(List<BE.FamiliaBE> Fam)
        {
            return DAL_Datos.FamiliaDAL_D.GetInstance().ListarFamilia(Fam);
        }

        public object  ListaFamilia(BE.FamiliaBE Fam)
        {
            return DAL_Datos.FamiliaDAL_D.GetInstance().ListaFamilia(Fam);
        }

        //Alta Familia
        public bool AltaFamilia(BE.FamiliaBE fam)
        {
            return DAL_Datos.FamiliaDAL_D.GetInstance().AltaFamilia(fam);
        }

        //Borrar Familia 
        public bool BorrarFamilia(BE.FamiliaBE Fam)
        {
            return DAL_Datos.FamiliaDAL_D.GetInstance().BorrarFamilia(Fam);
        }

        //Listar las patentes de la familia (base Familia_Patente)
        public List<BE.PatenteBE> ListarPatentesFamilia(List<BE.PatenteBE> ListPat, BE.FamiliaBE Fam)
        {
            return DAL_Datos.FamiliaDAL_D.GetInstance().ListarPatentesFamilia(ListPat, Fam);
        }

        //Borrar patente de Familia_Patente
        public bool BorrarFamiliaPatente(BE.FamiliaBE Fam, BE.PatenteBE Pat)
        {
            return DAL_Datos.FamiliaDAL_D.GetInstance().BorrarFamiliaPatente(Fam, Pat);
        }


        //Alta Familia_Patente
        public bool AltaFamiliaPatente(BE.FamiliaBE Fam, BE.PatenteBE Pat)
        {
            return DAL_Datos.FamiliaDAL_D.GetInstance().AltaFamiliaPatente(Fam, Pat);
        }

        //Buscar una patente especifica dentro de un grupo de familias

        public bool BuscarPatentedeFamilia(BE.FamiliaBE Fam, BE.PatenteBE Pat)
        {
            return DAL_Datos.FamiliaDAL_D.GetInstance().BuscarPatentedeFamilia(Fam, Pat);
        }
        
        //Listar todos las patentes de la familia
        public List<BE.FamiliaBE> ListarFamiliaporPatente(List<BE.FamiliaBE> ListFam, BE.PatenteBE Pat)
        {
            return DAL_Datos.FamiliaDAL_D.GetInstance().ListarFamiliaporPatente(ListFam, Pat);
        }

        public List<BE.FamiliaBE> ListarFamiliaporPatente(List<BE.FamiliaBE> ListFam, BE.PatenteBE Pat, BE.FamiliaBE F)
        {
            return DAL_Datos.FamiliaDAL_D.GetInstance().ListarFamiliaporPatente(ListFam, Pat, F);
        }

        public bool ValidarFamilia( BE.UsuarioBE Usu , BE.FamiliaBE Fam)
        {
            return DAL_Datos.FamiliaDAL_D.GetInstance().ValidaFamilia(Usu,Fam);

        }
        //// Verifica si ya existe la patente en la BD
        public bool ValidarFamiliaNombre(BE.FamiliaBE Fam)
        {
            return DAL_Datos.FamiliaDAL_D.GetInstance().ValidarFamiliaNombre(Fam);

        }
        //Verifica si ya existe la familia en la BD
        public bool ValidarFamiliaAlta(BE.FamiliaBE FAM)
        {
            return DAL_Datos.FamiliaDAL_D.GetInstance().ValidarFamiliaAlta(FAM);

        }
        // Busco una Familia específica por ID
        public List<BE.FamiliaBE> BuscarunaFamiliaID(int ID_Familia)
        {
            return DAL_Datos.FamiliaDAL_D.GetInstance().BuscarunaFamiliaID(ID_Familia);
        }
        // Busco lista de patenes de la Familia con un IDFamilia
        public List<BE.FamiliaPatenteBE> BuscarPatentesconIDFamilia(int ID_Familia)
        {
            return DAL_Datos.FamiliaDAL_D.GetInstance().BuscarPatentesconIDFamilia(ID_Familia);
        }
    }
}
