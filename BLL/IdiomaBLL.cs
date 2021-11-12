using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class IdiomaBLL
    {
        //Singleton
        private static IdiomaBLL Instancia;


        public static IdiomaBLL GetInstance()
        {
            if (Instancia == null)
            {
                Instancia = new IdiomaBLL();
            }

            return Instancia;
        }

        //Cargar idioma
        public List<BE.IdiomaBE> ListarIdiomas(List<BE.IdiomaBE> lidiomas)
        {
            return DAL_Datos.IdiomaDAL_D.GetInstance().ListarIdiomas(lidiomas);
        }
    }
}
