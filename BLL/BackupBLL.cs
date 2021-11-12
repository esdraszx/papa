
using System.Collections.Generic;


namespace BLL
{
    public class BackupBLL
    {

        private static BackupBLL Instancia;


        public static BackupBLL GetInstance()
        {
            if (Instancia == null)
            {
                Instancia = new BLL.BackupBLL();
            }
            return Instancia;
        }
        //Hacer un BackupBLL de la base
        public void HacerBackupBLL(BE.BackupBE b)
        {
            DAL_Datos.BackupDAL_D.GetInstance().HacerBackup(b);
        }

        public void restaurar(List<string> path)
        {
            DAL_Datos.BackupDAL_D.GetInstance().restaurar(path);
        }
    }
}
