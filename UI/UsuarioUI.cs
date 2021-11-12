using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class UsuarioUI
    {
        public UsuarioUI()
        {
            this.UsuarioBE = new UsuarioBE();
            this.UsuarioBLL = new UsuarioBLL();
        }

        private UsuarioBE _usuarioBE;
        private UsuarioBLL _usuarioBLL;

        public UsuarioBE UsuarioBE { get => _usuarioBE; set => _usuarioBE = value; }
        public UsuarioBLL UsuarioBLL { get => _usuarioBLL; set => _usuarioBLL = value; }
    }
}
