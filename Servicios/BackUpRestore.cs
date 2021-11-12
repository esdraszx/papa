using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Servicios;
using Microsoft.VisualBasic;

namespace Servicios
{
    public  class BackUpRestore
    {
        //public static bool BackUp()
        //{
        //    bool retorno = true;
        //    string s = DateAndTime.Now.ToString();
        //    s = s.Replace("/", "-");
        //    s = s.Replace(":", ".");
        //    s = @"USE MASTER BACKUP DATABASE LPPA2 TO DISK = 'E:\Material Universidad\TFI 2021\Catala Nelson\Check_In5\Backup\testing" + s + ".bak'";
        //    try
        //    {
        //        Comando.ConsultaSQL(s, Conexion.ConexionF());
        //    }
        //    catch (Exception ex)
        //    {
        //        retorno = false;
        //        throw new Exception(ex.Message);
        //    }

        //    return retorno;
        //}

        //public static bool Restore(string directorio)
        //{
        //    bool retorno = true;
        //    try
        //    {
        //        string S = "USE MASTER" + Constants.vbCrLf;
        //        S += "ALTER DATABASE LPPA SET SINGLE_USER WITH ROLLBACK IMMEDIATE" + Constants.vbCrLf;
        //        S += "DROP DATABASE LPPA" + Constants.vbCrLf;
        //        S += "RESTORE DATABASE LPPA FROM DISK = '" + directorio + "' WITH REPLACE;";
        //        Comando.ConsultaSQL(S, Conexion.ConexionMaster());
        //    }
        //    catch (Exception ex)
        //    {
        //        retorno = false;
        //        throw new Exception(ex.Message);
        //    }

        //    return retorno;
        //}
    }
}
