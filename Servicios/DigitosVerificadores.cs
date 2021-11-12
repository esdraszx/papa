using System;
using System.Text;
using DAL_Servicios;
using System.Data;
using System.Security.Cryptography;

namespace Servicios
{


    public partial class DigitosVerificadores
    {
        private static bool Digito = true;
        public static String RegMod = "";
        public static string CreateHash(string CadenaParametro)
        {
              var UE = new UnicodeEncoding();
            byte[] miHash;
            string Resumen;
            // ALMACENA LA CADENA INGRESADA EN UNA MATRIZ DE BYTES
            var Cadena = UE.GetBytes(CadenaParametro);
            var s1Service = new SHA1CryptoServiceProvider();
            // CREA EL HASH
            miHash = s1Service.ComputeHash(Cadena);
            // RETORNA COMO UNA CADENA CODIGICADA EN BASE64
            Resumen = Convert.ToBase64String(miHash);
            return Resumen;
        }
        public static bool GrabarDVHdeTodalaBase()
        {
            bool retorno = true;
            try
            {
                // 'CALCULO TODOS LOS DVH
                // ACA TRAIGO UN DATATABLE CON LOS NOMBRES DE TODAS LAS TABLAS DE MI BASE DE DATOS
                DataTable DTTodaslasTablas = Comando.objDatatable("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES  TABLE_NAME");
                // RECORRO TODAS LAS DATAROWS DEL DATATABLE
                for (int a = 0, loopTo = DTTodaslasTablas.Rows.Count - 1; a <= loopTo; a++)
                {
                    // SALVO EN LA TABLA DEL DIGITO VERTICAL RECORRO TODAS
#pragma warning disable CS0252 // Posible comparación de referencias involuntaria: El lado de la mano izquierda necesita conversión
                    if (!(DTTodaslasTablas.Rows[a].ItemArray[0] == "DVV"))
#pragma warning restore CS0252 // Posible comparación de referencias involuntaria: El lado de la mano izquierda necesita conversión
                    {
                        // TRAIGO OTRO DATATABLE CORRESPONDIENTE CON EL NOMBRE DE LA ROW DE DTTodaslasTablas 
                        DataTable Tabla = Comando.objDatatable("select * from " + DTTodaslasTablas.Rows[a].ItemArray[0] + "");
                        // RECORRO TODAS LAS ROWS DEL DATATABLE TRAIDO
                        for (int row = 0, loopTo1 = Tabla.Rows.Count - 1; row <= loopTo1; row++)
                        {
                            // DECLARO UN STRING PARA CONCATENAR TODOS LOS ITEMS DEL DATAROW SALVO EL ULTIMO
                            string CadenaConcatenada = null;
                            for (int columna = 0, loopTo2 = Tabla.Columns.Count - 2; columna <= loopTo2; columna++)
                            {
                                // CONCATENO CADA ITEM DEL DATAROW SALVO EL DVH
                                CadenaConcatenada = CadenaConcatenada + Tabla.Rows[row].ItemArray[columna];
                                // CALCULO EL DVH DEL DATAROW Y SE LO ASIGNO A LA CELDA DEL DATAROW
                                Tabla.Rows[row]["DVH"] = CreateHash(CadenaConcatenada);
                            }
                        }
                        Comando.ActualizarBD("select * from " + DTTodaslasTablas.Rows[a].ItemArray[0] + "", Tabla);
                    }
                }
                // 'CALCULAR EL DVV
                string CadenadeDVH = null;
                for (int r = 0, loopTo3 = DTTodaslasTablas.Rows.Count - 1; r <= loopTo3; r++)
                {
                    // SALVO EN LA TABLA DEL DIGITO VERTICAL RECORRO TODAS
#pragma warning disable CS0252 // Posible comparación de referencias involuntaria: El lado de la mano izquierda necesita conversión
                    if (!(DTTodaslasTablas.Rows[r].ItemArray[0] == "DVV"))
#pragma warning restore CS0252 // Posible comparación de referencias involuntaria: El lado de la mano izquierda necesita conversión
                    {
                        // TRAIGO UN DATATABLE CON TODOS LOS DVH DE LA TABLA ACTUAL
                        DataTable TabladeDVH = Comando.objDatatable("select DVH from " + DTTodaslasTablas.Rows[r].ItemArray[0] + "");
                        for (int rows = 0, loopTo4 = TabladeDVH.Rows.Count - 1; rows <= loopTo4; rows++)
                        {
                            // CONCATENO CADA DVH
                            CadenadeDVH = CadenadeDVH + TabladeDVH.Rows[rows].ItemArray[0];
                        }
                    }
                }
                // CALCULO EL HASH DE TODOS LOS DVH Y SE LO ASIGNO A UN STRING DVV
                string DVV = CreateHash(CadenadeDVH);
                // TRAIGO EL DATATABLE DVV QUE VA A TRAER UN SOLO REGISTRO
                DataTable TablaDVV = Comando.objDatatable("select * from DVV");
                // REEMPLAZO EL DATAROW POR EL STRING DVV
                TablaDVV.Rows[0].ItemArray[0] = DVV;
                // Y ACTUALIZO LA TABLA
                Comando.ActualizarBD("select * from DVV", TablaDVV);
                MVARSERVICIOS.digito = true;
                MVARSERVICIOS.regMod = "";
            }
            catch (Exception ex)
            {
                retorno = false;
                throw new Exception(ex.Message);
            }
            return retorno;
        }

        public static void GrabarPorTabla(string Consulta1)
        {
            // ESTE METODO HACE LO MISMO QUE "GrabarDVHdeTodalaBase" SOLO QUE
            // GRABA POR UNA TABLA ESPECIFICA Y LA TABLA DVV
            try
            {
                // 'CALCULAR DVH NUEVO EVENTO
                DataTable Tabla = Comando.objDatatable(Consulta1);
                for (int row = 0, loopTo = Tabla.Rows.Count - 1; row <= loopTo; row++)
                {
                    string CadenaConcatenada = null;
                    for (int columna = 0, loopTo1 = Tabla.Columns.Count - 2; columna <= loopTo1; columna++)
                    {
                        CadenaConcatenada = CadenaConcatenada + Tabla.Rows[row].ItemArray[columna];
                        Tabla.Rows[row]["DVH"] = CreateHash(CadenaConcatenada);
                        Comando.actualizarBD(Consulta1, Tabla);
                    }
                }

                DataTable TodaslasTablas = Comando.objDatatable("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES  TABLE_NAME");

                // 'CALCULAR EL DVV
                string CadenadeDVH = null;
                for (int r = 0, loopTo2 = TodaslasTablas.Rows.Count - 1; r <= loopTo2; r++)
                {
                    if (!(TodaslasTablas.Rows[r].ItemArray[0] == "DVV"))
                    {
                        DataTable TabladeDVH = Comando.objDatatable("select DVH from " + TodaslasTablas.Rows[r].ItemArray[0] + "");
                        for (int rows = 0, loopTo3 = TabladeDVH.Rows.Count - 1; rows <= loopTo3; rows++)
                        {
                            CadenadeDVH = CadenadeDVH + TabladeDVH.Rows[rows].ItemArray[0];
                        }
                    }
                }

                string DVV = CreateHash(CadenadeDVH);
                DataTable TablaDVV = Comando.objDatatable("select * from DVV");
                TablaDVV.Rows[0].ItemArray[0] = DVV;
                Comando.ActualizarBD("select * from DVV", TablaDVV);
                MVARSERVICIOS.digito = true;
                MVARSERVICIOS.regMod = "";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static string DVVdelaBase()
        {
            // DEVUELVO EL VALOR DEL DVV
            DataTable TablaDVV = Comando.objDatatable("select * from DVV");
            return (string)TablaDVV.Rows[0].ItemArray[0];
        }

        public static bool ValidarBasedeDatos()
        {
            var Retorno = default(bool);
            MVARSERVICIOS.digito = true;
            try
            {
                if (MVARSERVICIOS.digito == true & MVARSERVICIOS.regMod == "")
                {
                    string CadenadeDVH = null;
                    int columna;
                    Retorno = true;

                    // ACA TRAIGO UN DATATABLE CON LOS NOMBRES DE TODAS LAS TABLAS DE MI BASE DE DATOS
                    DataTable DTTodaslasTablas = Comando.objDatatable("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES  TABLE_NAME");
                    // RECORRO TODAS LAS DATAROWS DEL DATATABLE
                    for (int a = 0, loopTo = DTTodaslasTablas.Rows.Count - 1; a <= loopTo; a++)
                    {
                        // SALVO EN LA TABLA DEL DIGITO VERTICAL RECORRO TODAS
#pragma warning disable CS0252 // Posible comparación de referencias involuntaria: El lado de la mano izquierda necesita conversión
                        if (!(DTTodaslasTablas.Rows[a].ItemArray[0] == "DVV"))
#pragma warning restore CS0252 // Posible comparación de referencias involuntaria: El lado de la mano izquierda necesita conversión
                        {
                            // TRAIGO UN DATATABLE CON TODOS LOS DVH DE LA TABLA ACTUAL
                            DataTable Tabla = Comando.objDatatable("select * from " + DTTodaslasTablas.Rows[a].ItemArray[0] + "");
                            // RECORRO TODAS LAS ROWS DEL DATATABLE TRAIDO
                            for (int row = 0, loopTo1 = Tabla.Rows.Count - 1; row <= loopTo1; row++)
                            {
                                string CadenaConcatenada = null;
                                // DECLARO UN STRING PARA CONCATENAR TODOS LOS ITEMS DEL DATAROW SALVO EL ULTIMO
                                var loopTo2 = Tabla.Columns.Count - 2;
                                for (columna = 0; columna <= loopTo2; columna++)
                                    // CONCATENO CADA ITEM DEL DATAROW SALVO EL DVH
                                    CadenaConcatenada = CadenaConcatenada + Tabla.Rows[row].ItemArray[columna];
                                // CALCULO EL DVH DEL DATAROW Y SE LO ASIGNO A LA CELDA DEL DATAROW
                                CadenadeDVH = CadenadeDVH + CreateHash(CadenaConcatenada);
                                if (Tabla.Rows[row]["DVH"].ToString() != CreateHash(CadenaConcatenada).ToString())
                                {
                                    // SI LO QUE HAY EN EL CAMPO DVH ES DISTINTO A LO QUE DEVUELVE CreateHash(CadenaConcatenada) 
                                    // QUIERE DECIR QUE HUBO UNA MODIFICACION DE REGISTRO SIN ACTUALIZACION DEL DVH
                                    MVARSERVICIOS.regMod += "Error de integridad en la tabla " + DTTodaslasTablas.Rows[a].ItemArray[0] + " en el registro " + Tabla.Rows[row].ItemArray[0] + "<br/>";
                                    Retorno = false;
                                    MVARSERVICIOS.digito = false;
                                }
                            }
                        }
                    }
                    if (Retorno == true)
                    {
                        string DVV = CreateHash(CadenadeDVH);
                        string DVVActual = DVVdelaBase();
                        if ((DVV ?? "") == (DVVActual ?? ""))
                        {
                            Retorno = true;
                        }
                        else
                        {
                            Retorno = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            RegistrosCorruptos();
            return Retorno;
        }
        public static bool ValidarBBDD()
        {
            bool Retorno = false;
            Digito = true;
            try
            {
                if (RegMod.Equals(""))
                {
                    String CadenaDeDVH = null;
                    Retorno = true;

                    DataTable DTAllTables = Comando.objDatatable("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES TABLE_NAME");
                     
                    for (int a = 0; a < DTAllTables.Rows.Count; a++)
                    {
                        if (!DTAllTables.Rows[a].ItemArray[0].Equals("DVV"))
                        {
                            DataTable Tabla = Comando.objDatatable("select * from " + DTAllTables.Rows[a].ItemArray[0]);
                            for (int row = 0; row < Tabla.Rows.Count; row++)
                            {
                                Tabla.Rows[row].ToString();
                                String CadenaConcatenada = null;
                                for (int columna = 0; columna < Tabla.Columns.Count - 2; columna++)
                                {
                                    CadenaConcatenada += Tabla.Rows[row].ItemArray[columna];
                                }
                                CadenaDeDVH += CreateHash(CadenaConcatenada);
                                if (!Tabla.Rows[row]["DVH"].ToString().Equals(CreateHash(CadenaConcatenada).ToString()))
                                {
                                    RegMod += "Error de integridad tabla " + DTAllTables.Rows[a].ItemArray[0].ToString() + " registro     " + Tabla.Rows[row].ItemArray[0] + "                     ";
                                    Retorno = false;
                                    Digito = false;
                                }
                            }
                        }
                    }
                    if (Retorno == true)
                    {
                        String DVV = CreateHash(CadenaDeDVH);
                        String DVVActual = DVVBBDD();
                        if (DVV.Equals(DVVActual))
                            Retorno = true;
                        else
                            Retorno = false;
                    }
                }
               
            } 
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            RegistrosCorruptosB();
            return Retorno;
           
        }

        public static string RegistrosCorruptos()
        {
            return MVARSERVICIOS.regMod;
        }
        public static String DVVBBDD()
        {
            DataTable TablaDVV = Comando.objDatatable("select * from DVV");
            return TablaDVV.Rows[0].ItemArray[0].ToString();
        }

        public static String RegistrosCorruptosB()
        {
            //return MVARSERVICIOS.regMod;
            return RegMod;
        }

        public static bool GrabarDVHFull()
        {
            bool retorno = true;
            try
            {
                DataTable DTAllTables = Comando.objDatatable("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES  TABLE_NAME");//select name from sys.tables
                for (int a = 0; a < DTAllTables.Rows.Count; a++)
                {
                    if (!"DVV".Equals(DTAllTables.Rows[a].ItemArray[0]))
                    {
                        DataTable Tabla = Comando.objDatatable("select * from " + DTAllTables.Rows[a].ItemArray[0]);
                        for (int row = 0; row < Tabla.Rows.Count; row++)
                        {
                            String CadenaConcatenada = null;
                            for (int column = 0; column < Tabla.Columns.Count - 2; column++)
                            {
                                CadenaConcatenada += Tabla.Rows[row].ItemArray[column];
                            }
                            Tabla.Rows[row]["DVH"] = CreateHash(CadenaConcatenada);
                        }
                        Comando.ActualizarBD("select * from " + DTAllTables.Rows[a].ItemArray[0], Tabla);
                    }
                }

                String CadenaDVH = null;
                for (int r = 0; r < DTAllTables.Rows.Count; r++)
                {
                    if (!"DVV".Equals(DTAllTables.Rows[r].ItemArray[0]))
                    {
                        DataTable TablaDVH = Comando.objDatatable("select DVH from " + DTAllTables.Rows[r].ItemArray[0]);
                        for (int rows = 0; rows < TablaDVH.Rows.Count; rows++)
                        {
                            CadenaDVH += TablaDVH.Rows[rows].ItemArray[0];
                        }
                    }
                }

                String DVV = CreateHash(CadenaDVH);
                DataTable TablaDVV = Comando.objDatatable("select * from DVV");
                TablaDVV.Rows[0][0] = DVV;
                Comando.ActualizarBD("select * from DVV", TablaDVV);
                Digito = true;
                RegMod = "";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return retorno;
        }
    }
}
