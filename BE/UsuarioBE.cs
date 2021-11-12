using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class UsuarioBE:PersonaBE
    {
        public  int Intentos { get; set; }
        private List<PerfilAbstractoBE> _perfilAbstracto;
        public List<PerfilAbstractoBE> PerfilAbstracto
        {
            get
            {
                return _perfilAbstracto;
            }
            set
            {
                _perfilAbstracto = value;
            }
        }
        public List<PatenteBE> Patentes { get; set; }
        public List<UsuarioFamiliaBE> Familias { get; set; }
        public List<UsuarioPatenteBE> UsuarioPatentes { get; set; }
        public List<UsuarioFamiliaBE> UsuarioFamilias { get; set; }

        public UsuarioBE(string nombreUsuario, string contraseña)
        {
            NombreUsuario = nombreUsuario;
            Contraseña = contraseña;
            Patentes = new List<PatenteBE>();
            Familias = new List<UsuarioFamiliaBE>();
        }
        public UsuarioBE(int _idUsuario)
        {
            IDUsuario = _idUsuario;
        }
        //public UsuarioBE( )
        //{ 
        //    UsuarioPatentes = usuarioPatentes; // new List<UsuarioPatenteBE>();
        //    Patentes = new List<PatenteBE>();
        //    Familias = new List<FamiliaBE>();
        //}
        public UsuarioBE()
        {

        }

        public UsuarioBE(string nombreUsuario, string contraseña, int intentos)
        {
            NombreUsuario = nombreUsuario;
            Contraseña = contraseña;
            Intentos = intentos;
 
        }

        public UsuarioBE( List<UsuarioPatenteBE> usuariopatentes)
        {
            UsuarioPatentes = new List<UsuarioPatenteBE>(usuariopatentes); 
        }

        public UsuarioBE(int _idUsuario, List<UsuarioFamiliaBE> usuariofamilias)
        {
            IDUsuario = _idUsuario;
            UsuarioFamilias = new List<UsuarioFamiliaBE>(usuariofamilias);
        }

        public UsuarioBE( List<PatenteBE> patentes)
        {  
            Patentes = new List<PatenteBE>(patentes);
        }

        public UsuarioBE( List<UsuarioFamiliaBE> familias)
        {
            Familias = new List<UsuarioFamiliaBE>(familias);
        }
        public UsuarioBE(int _idUsuario ,List<UsuarioFamiliaBE> familias , List<PatenteBE> patentes)
        {
            IDUsuario = _idUsuario;
            Familias = new List<UsuarioFamiliaBE>(familias);
            Patentes = new List<PatenteBE>(patentes);
        }

    }
}
