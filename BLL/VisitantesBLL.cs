using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class VisitantesBLL
    {
        private static VisitantesBLL Instancia;
        public static VisitantesBLL GetInstance()
        {
            if (Instancia == null)
            {
                Instancia = new VisitantesBLL();
            }
            return Instancia;
        }
        //Listar visitantes de la base de datos
        public List<BE.VisitantesBE> ListarVisitantes(List<BE.VisitantesBE> datVis)
        {
            return DAL_Datos.VisitantesDAL_D.GetInstance().ListarVisitantes(datVis);
        }

        //Validar si ya Existe Visitante
        public bool Validar(BE.VisitantesBE Vis)
        {
            return DAL_Datos.VisitantesDAL_D.GetInstance().Validar(Vis);
        }

        //Alta de Visitante
        public bool AltaVisitante(BE.VisitantesBE vis)
        {
            return DAL_Datos.VisitantesDAL_D.GetInstance().AltaVisitantes(vis);
        }


        //Delete de Cliente
        public bool EliminarVisitantes(string Id)
        {
            return DAL_Datos.VisitantesDAL_D.GetInstance().EliminarVisitantes(Id);
        }


        //Update de Visitantes
        public bool ActualizarVisitantes(BE.VisitantesBE vis)
        {
            return DAL_Datos.VisitantesDAL_D.GetInstance().ActualizarVisitantesDAL_D(vis);
        }


        //Buscar visitantes por DNI
        public List<BE.VisitantesBE> BuscarunVisitanteDNI(string DNI)
        {
            return DAL_Datos.VisitantesDAL_D.GetInstance().BuscarunVisitantesDNI(DNI);
        }

    }
}
