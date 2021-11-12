using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class PatenteBE :PerfilAbstractoBE
    {
        public string DVH { get; set; }

        private int _idPatente;

        public int ID_Patente
        {
            get
            {
                return _idPatente;
            }

            set
            {
                _idPatente = value;
            }
        }

        private string _descripcion;

        public string Descripcion
        {
            get
            {
                return _descripcion;
            }

            set
            {
                _descripcion = value;
            }
        }

        private string _grupo;

        public string Grupo
        {
            get
            {
                return _grupo;
            }

            set
            {
                _grupo = value;
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
        public PatenteBE()
        {}

        public PatenteBE(int patente)
        {
            ID_Patente = patente;
        }

        public PatenteBE(int patente, String descripcion, String detalle, String groupo, String dvh)
        {
            ID_Patente = patente;
            Descripcion = descripcion;
            Detalle = detalle;
            Grupo = groupo;
            DVH = dvh;
        }
    }
}
