using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class PersonaBE
    {
        private int _idUsuario;
        public int IDUsuario
        {
            get
            {
                return _idUsuario;
            }
            set
            {
                _idUsuario = value;
            }
        }
        private string _nombreUsuario;
        public string NombreUsuario
        {
            get
            {
                return _nombreUsuario;
            }
            set
            {
                _nombreUsuario = value;
            }
        }
        private string _Contraseña;
        public string Contraseña
        {
            get
            {
                return _Contraseña;
            }
            set
            {
                _Contraseña = value;
            }
        }
        private string _nom;
        public string Nombre
        {
            get
            {
                return _nom;
            }
            set
            {
                _nom = value;
            }
        }
        private string _ape;
        public string Apellido
        {
            get
            {
                return _ape;
            }
            set
            {
                _ape = value;
            }
        }
        private string _direccion;
        public string Direccion
        {
            get
            {
                return _direccion;
            }
            set
            {
                _direccion = value;
            }
        }
        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }
        private string _tel;
        public string Telefono
        {
            get
            {
                return _tel;
            }
            set
            {
                _tel = value;
            }
        }
        private bool _Activo;
        public bool Activo
        {
            get
            {
                return _Activo;
            }
            set
            {
                _Activo = value;
            }
        }
        private string _PalabraRestitucion;
        public string PalabraRestitucion
        {
            get
            {
                return _PalabraRestitucion;
            }
            set
            {
                _PalabraRestitucion = value;
            }
        }
        private string _DNI;
        public string DNI
        {
            get
            {
                return _DNI;
            }
            set
            {
                _DNI = value;
            }
        }
        private string _DVH;
        public string DVH
        {
            get
            {
                return _DVH;
            }
            set
            {
                _DVH = value;
            }
        }

        public PersonaBE()
        {

        }
        public PersonaBE (int _idUsuario)
        {
            IDUsuario = _idUsuario;
        }
    }
}
