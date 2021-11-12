
using System.Collections.Generic;

namespace BE
{
    public class UsuarioFamiliaBE
    {
        public int ID_Familia { get; set; } 
        public int ID_Usuario { get; set; }
        public string DVH { get; set; }
        public List<UsuarioFamiliaBE> UsuFan { get; set; }

        public UsuarioFamiliaBE()
        {

        }
        public UsuarioFamiliaBE(int _id_Usuario , int _id_Familia)
        {
            ID_Usuario = _id_Usuario;
            ID_Familia = _id_Familia;

        }
    }
}
