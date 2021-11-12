using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class Sesion
    {
        public static String ComprobarSesion(String UsuarioFamilia, String FamiliaRequerida)
        {
            String Retorno = "";
            switch (UsuarioFamilia)
            {
                case "Administrador":
                    Retorno = SesionA(UsuarioFamilia, FamiliaRequerida);
                    break;
                case "Usuario":
                    Retorno = SesionA(UsuarioFamilia, FamiliaRequerida);
                    break;
                case "UsuarioA":
                    Retorno = SesionA(UsuarioFamilia, FamiliaRequerida);
                    break;
                case "Supervisor":
                    Retorno = SesionA(UsuarioFamilia, FamiliaRequerida);
                    break;
                case "Tecnico":
                    Retorno = SesionA(UsuarioFamilia, FamiliaRequerida);
                    break;
                default:
                    Retorno = "No hay sesion activa";
                    break;
            }
            return Retorno;
        }

        public static String SesionA(String UsuarioFamilia, String FamiliaRequerida)
        {
            String Retorno = "";

            if (UsuarioFamilia != "")
            {
                if (!UsuarioFamilia.Equals(FamiliaRequerida))
                    Retorno = "No posee permiso";
            }
            else
            {
                Retorno = "No hay sesion activa";
            }
            return Retorno;
        }
    }
}
