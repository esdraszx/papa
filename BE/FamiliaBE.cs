using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class FamiliaBE
    {
        public List<PatenteBE> Patentes { get; set; }
        public List<FamiliaBE> Familias { get; set; }
        public string DVH { get; set; }
        private int _idFamilia;

        public int IDFamilia
        {
            set
            {
                _idFamilia = value;
            }

            get
            {
                return _idFamilia;
            }
        }

        private string _nombreFamilia;

        public string NombreFamilia
        {
            get
            {
                return _nombreFamilia;
            }

            set
            {
                _nombreFamilia = value;
            }
        }
        public FamiliaBE(List<PatenteBE> patentes)
        {
            Patentes = new List<PatenteBE>(patentes);
        }

        public FamiliaBE(List<FamiliaBE> familias)
        {
            Familias = new List<FamiliaBE>(familias);
        }
        public FamiliaBE()
        {

        }
    }
}
