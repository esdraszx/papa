using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class FamiliaPatenteBE
    {
        public int ID_Familia { get; set; }
        public int ID_Patente { get; set; }
        public List<FamiliaPatenteBE> FamiliaPatentes { get; set; }
        public string DVH { get; set; }

        public FamiliaPatenteBE(List<FamiliaPatenteBE> familiapatentes)
        {
            FamiliaPatentes = new List<FamiliaPatenteBE>(familiapatentes);
        }

        public FamiliaPatenteBE()
        { }

        public FamiliaPatenteBE(int _id_familia, int _id_Patente)
        {
            ID_Familia = _id_familia;
            ID_Patente = _id_Patente;

        }
    }
}



   

