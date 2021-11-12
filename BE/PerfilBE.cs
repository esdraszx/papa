
using System.Collections.Generic;

namespace BE
{
    public class PerfilBE : PerfilAbstractoBE
    {
        private int _idPerfil;

        public int IDPerfil
        {
            get
            {
                return _idPerfil;
            }

            set
            {
                _idPerfil = value;
            }
        }

        private string _detalle;

        public string Detalle
        {
            get
            {
                return _detalle;
            }

            set
            {
                _detalle = value;
            }
        }

        private List<PerfilAbstractoBE> _famPat;

        public List<PerfilAbstractoBE> FamiliaPatente
        {
            get
            {
                return _famPat;
            }

            set
            {
                _famPat = value;
            }
        }
        private List<PerfilAbstractoBE> _usuPat;

        public List<PerfilAbstractoBE> UsuarioPatente
        {
            get
            {
                return _usuPat;
            }

            set
            {
                _usuPat = value;
            }
        }
        private List<PerfilAbstractoBE> _usuFam;

        public List<PerfilAbstractoBE> UsuarioFamilia
        {
            get
            {
                return _usuFam;
            }

            set
            {
                _usuFam = value;
            }
        }
    }
}
