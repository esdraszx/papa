using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class UsuarioPatenteBE
    {
        public int ID_Patente { get; set; }

        public int ID_Usuario { get; set; }

        public bool Negada { get; set; }

        public string DVH { get; set; }

        public List<UsuarioPatenteBE> UsuPat { get; set; }

        public UsuarioPatenteBE(int _id_Usuario, int _id_Patente)
        {
            ID_Usuario = _id_Usuario;
            ID_Patente = _id_Patente;

        }
        public UsuarioPatenteBE()
        {

        }
    }

   
}
