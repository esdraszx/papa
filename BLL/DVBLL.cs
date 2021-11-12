using System;
using System.Text;

namespace BLL
{
    public class DVBLL
    {

        //Calculo de DVH
        public static string CalcularDVH(string cadena)
        {
            string s = cadena;
            byte[] bytes = Encoding.ASCII.GetBytes(s);
            int result = BitConverter.ToInt32(bytes, 0);
            result = int.Parse(cadena);
            return cadena;

        }

        //Calcular DVV (DAL) 
        public static string CalcularDVV(BE.DVBE dv)
        {
            return DAL_Datos.DVDAL_D.GetInstance().CalcularDVV(dv);

        }


        //Verifica si ya se encuentra en la tabla
        public static bool Validar(BE.DVBE d)
        {
            return DAL_Datos.DVDAL_D.GetInstance().Validar(d);
        }

        //Actualizo tabla de DVV
        public static void ActualizarDVV(BE.DVBE dvv)
        {
            //Enciptar

            DAL_Datos.DVDAL_D.GetInstance().ActualizarDVV(dvv);
        }

        //Alta DVV

        public static bool AltaDVV(BE.DVBE d)
        {
            //Encriptar
            return DAL_Datos.DVDAL_D.GetInstance().AltaDVV(d);
        }

    }
}
