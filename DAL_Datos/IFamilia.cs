
using System.Collections.Generic;


namespace DAL_Datos
{
     public interface IFamilia
     {
        List<BE.FamiliaBE> ListarFamilias();
        void InsertarFamilia(string nomFam);
        void InsertarUsuarioFamilia(int idFam, int idUsu);
        void ModificarFamilia(int idFam, int idUsu);
        void BorrarFamilia(int idFam);
        void BorrarUsuarioFamilia(int idFam, int idUsu);
     }
}
