using BE;
using DAL_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PatenteBLL : PatenteBE , IPatente 
    {
        //Llamo a la DAL
        private static  PatenteBLL patenteDAL_D;

        public  static PatenteBLL InstanciaR ()
        {
                patenteDAL_D = new PatenteBLL();

            return patenteDAL_D;
        }

            private static PatenteBLL Instancia;
        
        public static PatenteBLL GetInstance()
        {
                if (Instancia == null)
                {
                    Instancia = new PatenteBLL();
                }

                return Instancia;
        }
            //Listar todas las patentes de la base de datos

            public List<PatenteBE> ListarPatentes(List<PatenteBE> pat)
            {
                return PatenteDAL_D.GetInstance().ListarPatentes(pat);
            }
        //validar Patenteen el Alta
        public bool ValidarPatenteAlta(PatenteBE PAT)
        {
            return PatenteDAL_D.GetInstance().ValidarPatenteAlta(PAT);

        }
        // Verifica si  existe  el usuario con patente 
        public bool ValidarPatente(PatenteBE PAT , UsuarioBE Usu)
            {
                return   PatenteDAL_D.GetInstance().ValidarPatente(PAT, Usu);

            }
             //// Verifica si ya existe la patente en la BD
            public bool ValidarPatenteDetalle(PatenteBE PAT)
            {
                return PatenteDAL_D.GetInstance().ValidarPatenteDetalle( PAT);

            }
            public void InsertarPatente(PatenteBE PatenteBE)
            {
                        PatenteDAL_D.GetInstance().InsertarPatente(PatenteBE);
            }

            public void InsertarPatenteFamilia(int idPat, int idFam)
            {
                   PatenteDAL_D.GetInstance().InsertarPatenteFamilia(idPat, idFam);
            }

            public void BorrarPatente(int idPat)
            {
                 PatenteDAL_D.GetInstance().BorrarPatente(idPat);
            }
            public void  BorrarPatenteFamilia(int idPat, int idFam)
            {
                 PatenteDAL_D.GetInstance().BorrarPatenteFamilia(idPat, idFam);
            }
            //Alta Patente
            public bool AltaPatente(PatenteBE pat)
            {
                return PatenteDAL_D.GetInstance().AltaPatente(pat);
            }

            // Busco una Patente específica por ID
            public List<PatenteBE> BuscarunaPatenteID(int ID_patente)
            {
                return PatenteDAL_D.GetInstance().BuscarunaPatenteID(ID_patente);
            }

            public List<PatenteBE> ListarPatentes()
            {
                return ((IPatente)Instancia).ListarPatentes();
            }
    }
    
}
