
using System.Collections.Generic;

namespace DAL_Datos
{
    public interface IPatente
    {
        void InsertarPatente(BE.PatenteBE PatenteBE);
        void InsertarPatenteFamilia(int idPat, int idFam);
        List<BE.PatenteBE> ListarPatentes();
        void BorrarPatente(int idPat);
        void BorrarPatenteFamilia(int idPat, int idFam);
    }
}
