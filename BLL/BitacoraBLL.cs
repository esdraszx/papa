using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BitacoraBLL
    {
        private static BitacoraBLL Instancia;
        public static BitacoraBLL GetInstance()
        {
            if (Instancia == null)
            {
                Instancia = new BitacoraBLL();
            }
            return Instancia;
        }
        //Grabar Bitacora
        public void GrabarBitacora(BE.BitacoraBE bit)
        {
            DAL_Datos.BitacoraDAL_D.GetInstance().GrabarBitacora(bit);
           // Alta en bitacora
            ActualizarDVV();
        }
        //Actualizar DVV
        public void ActualizarDVV()
        {
            //    recalculo DVV
            BE.DVBE dv = new BE.DVBE();
            dv.Id_Tabla = "Bitacora";
                dv.Valor = DVBLL.CalcularDVV(dv);
            //    Lee, si esta en la tabla lo actualiza, sino lo inserta
            if (BLL.DVBLL.Validar(dv) == true)
            {
              //  Actualizo tabla de DVV
                BLL.DVBLL.ActualizarDVV(dv);
            }
            else
            {
                BLL.DVBLL.AltaDVV(dv);
            }
        }
        //Listar bitacora
        public List<BE.BitacoraBE> ListarBitacora(List<BE.BitacoraBE> ListaB)
        {
            return DAL_Datos.BitacoraDAL_D.GetInstance().ListarBitacoraDAL_D(ListaB);
        }
        //Listar bitacora ambos criterios
        public List<BE.BitacoraBE> ListaListarBitacoraAmbosCriterios(List<BE.BitacoraBE> ListaB, string C, string Usu)
        {
            return DAL_Datos.BitacoraDAL_D.GetInstance().ListarBitacoraDAL_DAmbosCriterios(ListaB, C, Usu);
        }
        //Listar bitacora Criticidad
        public List<BE.BitacoraBE> ListarBitacoraCriticidad(List<BE.BitacoraBE> ListaB, string C)
        {
            return DAL_Datos.BitacoraDAL_D.GetInstance().ListarBitacoraDAL_DCriticidad(ListaB, C);
        }
        //Listar bitacora Usuario
        public List<BE.BitacoraBE> ListarBitacoraUsuario(List<BE.BitacoraBE> ListaB, string Usu)
        {
            return DAL_Datos.BitacoraDAL_D.GetInstance().ListarBitacoraDAL_DUsuario(ListaB, Usu);
        }
        //Depurar bitacora segun fecha
        public bool DepurarBitacora(DateTime fecha)
        {
            DAL_Datos.BitacoraDAL_D.GetInstance().DepurarBitacora(fecha);
           // ActualizarDVV();
            return true;
        }
        ////Busqueda por Rango de Fechas
        public List<BE.BitacoraBE> ListarBitacoraFecha(List<BE.BitacoraBE> ListaB, BE.BitacoraBE b1, BE.BitacoraBE b2)
        {
            return DAL_Datos.BitacoraDAL_D.GetInstance().ListarBitacoraFecha(ListaB, b1, b2);
        }
        // Busqueda por rango de fecha y Usuario
        public List<BE.BitacoraBE> ListarBitacoraFechaID(List<BE.BitacoraBE> ListaB, BE.BitacoraBE b1, BE.BitacoraBE b2, string USU)
        {
            return DAL_Datos.BitacoraDAL_D.GetInstance().ListarBitacoraFechaID(ListaB, b1, b2, USU);
        }
        //Buscqueda por rango de fecha, criticidad y Usuario
        public List<BE.BitacoraBE> ListarBitacoraFechaCritID(List<BE.BitacoraBE> ListaB, BE.BitacoraBE b1, BE.BitacoraBE b2, string C, string USU)
        {
            return DAL_Datos.BitacoraDAL_D.GetInstance().ListarBitacoraFechaCritID(ListaB, b1, b2, C, USU);
        }
        //Busqueda por rango de fecha y criticidad
        public List<BE.BitacoraBE> ListarBitacoraFechaCrit(List<BE.BitacoraBE> ListaB, BE.BitacoraBE b1, BE.BitacoraBE b2, string C)
        {
            return DAL_Datos.BitacoraDAL_D.GetInstance().ListarBitacoraFechaCrit(ListaB, b1, b2, C);
        }
    }
}

