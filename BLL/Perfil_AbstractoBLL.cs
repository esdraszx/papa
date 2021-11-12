using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BLL
{
    public abstract partial class Perfil_AbstractoBLL_D
    {
        #region Patentes

        public abstract List<BE.PatenteBE> ListarPatentes();
        public abstract void InsertarPatente(BE.PatenteBE Patente);
        public abstract void InsertarPatenteFamilia(int idPat, int idFam);
        public abstract void BorrarPatente(int ID_Patente);
        public abstract void BorrarPatenteFamilia(int idPat, int idFam);

        #endregion

        #region Familias

        public abstract List<BE.FamiliaBE> ListarFamilias();
        public abstract void InsertarFamilia(string nomFam);
        public abstract void InsertarUsuarioFamilia(int idFam, int idUsu);
        public abstract void BorrarFamilia(int idFam);
        public abstract void BorrarUsuarioFamilia(int idFam, int idUsu);

        #endregion
    }
}
