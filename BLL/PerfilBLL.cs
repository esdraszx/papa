
using System.Collections.Generic;

namespace BLL
{
    public class PerfilBLL_D :Perfil_AbstractoBLL_D
    {
        public PerfilBLL_D()
        {
            PerfilDAL_D = new DAL_Datos.PerfilDAL_D();
            PatentesDAL_D = new DAL_Datos.PatenteDAL_D();
        }

        private DAL_Datos.PerfilDAL_D _perfil;

        public DAL_Datos.PerfilDAL_D PerfilDAL_D
        {
            get
            {
                return _perfil;
            }

            set
            {
                _perfil = value;
            }
        }

        private DAL_Datos.PatenteDAL_D _patente;

        public DAL_Datos.PatenteDAL_D PatentesDAL_D
        {
            get
            {
                return _patente;
            }

            set
            {
                _patente = value;
            }
        }

        #region Familia
        public override void InsertarFamilia(string nomFam)
        {
            PerfilDAL_D.InsertarFamilia(nomFam);
        }

        public override void BorrarFamilia(int idFam)
        {
            PerfilDAL_D.BorrarFamilia(idFam);
        }

        public override void InsertarUsuarioFamilia(int idFam, int idUsu)
        {
            PerfilDAL_D.InsertarUsuarioFamilia(idFam, idUsu);
        }

        public virtual void modificarFamilia(int idFam, int idUsu)
        {
            PerfilDAL_D.ModificarFamilia(idFam, idUsu);
        }

        public override List<BE.FamiliaBE> ListarFamilias()
        {
            return PerfilDAL_D.ListarFamilias();
        }

        #endregion

        #region Patente
        public override void BorrarPatente(int idPat)
        {
        }

        public override void BorrarPatenteFamilia(int idPat, int idFam)
        {
        }

        public override void BorrarUsuarioFamilia(int idFam, int idUsu)
        {
        }

        public override void InsertarPatente(BE.PatenteBE Patente)
        {
        }

        public override void InsertarPatenteFamilia(int idPat, int idFam)
        {
        }

        public override List<BE.PatenteBE> ListarPatentes()
        {
            return PatentesDAL_D.ListarPatentes();
        }
        #endregion
    }
}
