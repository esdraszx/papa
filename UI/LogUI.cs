using BE;
using BLL;
using System;


namespace UI
{
    public class LogUI
    {
        private UsuarioBLL UBD = new UsuarioBLL();
        private UsuarioBE _ube = new UsuarioBE();
        private String _user;
        private String _pass;
        private int _intentos;

        public string User { get => _user; set => _user = value; }
        public string Pass { get => _pass; set => _pass = value; }
        public int Intentos { get => _intentos; set => _intentos = value; }
        public UsuarioBE UBE { get => _ube; set => _ube = value; }

        public UsuarioBE Identificarse(bool primerIntento)
        {
            try
            {
                UBE.NombreUsuario = this.User;
                UBE.Contraseña = this.Pass;
                UBE = UBD.Validar(UBE, this.Intentos, primerIntento);
            }
            catch (Exception ex)
            {
                
            }
            return UBE;
        }

    }
}
