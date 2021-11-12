
using System.Data;

namespace DAL_Datos
{
    public interface IUsuario
    {
        BE.UsuarioBE Login(BE.UsuarioBE usuarioBE, int intentos);
        void Logout(BE.UsuarioBE usuarioBE);
        bool Registro(BE.UsuarioBE usuarioBE);
        void ModificarUsuario(ref BE.UsuarioBE usuarioBE, bool activo);
        void ModificarFamilia(ref BE.UsuarioBE usuarioBE);
        DataTable Usuarios(string ID_Usuario);
        DataTable RangoUsuarios(string x);
        bool AltaUsuario(ref BE.UsuarioBE usuarioBE, int IDFamilia);
        string RecuperarContraseña(ref BE.UsuarioBE usuarioBE);
    }
}
