using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class InicioBLL
    {
        //Singleton
        private static InicioBLL Instancia;
        public static InicioBLL GetInstance()
        {
            if (Instancia == null)
            {
                Instancia = new InicioBLL();
            }
            return Instancia;
        }
        public bool BuscarAPPConfig(string dir)
        {
            try
            {
                return File.Exists(dir);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool VerificarConexion()
        {
            return DAL_Datos.InicioDAL_D.GetInstance().Conectar();
        }
        public bool VerificarDV()
        {
            return DAL_Datos.InicioDAL_D.GetInstance().VerificarDV();
        }
    }
}
