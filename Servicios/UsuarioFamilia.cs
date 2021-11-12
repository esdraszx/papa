using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{

    public partial class UsuarioFamilia
    {
        public static string ComprobarSesion(string UsuarioFamilia, string FamiliaRequerida)
        {
            string retorno = "";
            // ACA ENTRA EN LA FAMILIA QUE TRAE
            switch (UsuarioFamilia ?? "")
            {
                case "Administrador":
                    {
                        retorno = sesion(UsuarioFamilia, FamiliaRequerida);
                        break;
                    }

                case "Supervisor":
                    {
                        retorno = sesion(UsuarioFamilia, FamiliaRequerida);
                        break;
                    }

                case "Usuario":
                    {
                        retorno = sesion(UsuarioFamilia, FamiliaRequerida);
                        break;
                    }

                case var @case when @case == "":
                    {
                        retorno = "No hay sesión activa";
                        break;
                    }
            }

            return retorno;
        }

        public static string sesion(string UsuarioFamilia, string FamiliaRequerida)
        {
            string retorno = "";
            // ACA PREGUNTA SI LA FAMILIA QUE TRAE ES LA REQUERIDA
            if (!string.IsNullOrEmpty(UsuarioFamilia))
            {
                if ((UsuarioFamilia ?? "") == (FamiliaRequerida ?? ""))
                {
                    // SI ES LA REQUERIDA DEVUELVE UN STRING VACIO
                    retorno = "";
                }
                else
                {
                    // SI NO ES LA REQUERIDA DEVUELVE UN MENSAJE
                    retorno = "No posee permiso";
                }
            }
            else
            {
                // SI NO TIENE NADA EN EL STRING, QUIERE DECIR QUE NO HAY USUARIO LOGUEADO
                retorno = "No hay sesión activa";
            }

            return retorno;
        }
    }
}
