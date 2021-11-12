using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;


namespace DAL_Datos
{
    public class InicioDAL_D
    {
        //Singleton
        private static InicioDAL_D Instancia;
        public BE.DVBE dv = new BE.DVBE();
        public List<BE.UsuarioBE> ListadoUsuarios { get; set; }

        public static InicioDAL_D GetInstance()
        {
            if (Instancia == null)
            {
                Instancia = new InicioDAL_D();
            }

            return Instancia;
        }
        public bool VerificarDV()
        {
            BE.DVBE dv = new BE.DVBE();
            List<BE.DVBE> ListadoDVV = new List<BE.DVBE>();
            String[] mRegistroSplit;
            ListadoDVV = DVDAL_D.GetInstance().ListarDVV(ListadoDVV);
            int contador = 0;
            int suma = 0;
            int DVHCalculado = 0;
            //
            ListadoUsuarios = new List<BE.UsuarioBE>();
            ListadoUsuarios = UsuarioDAL_D.GetInstance().ListarUsuarios(ListadoUsuarios);

            foreach (BE.DVBE d in ListadoDVV)
            {
                foreach (string mReg in DAL_Datos.DVDAL_D.BuscarDVH(d.Id_Tabla))//Traer los registros
                //foreach (string mReg in DAL_Datos.DVBE.BuscarDVH("USUARIO"))
                {
                    mRegistroSplit = mReg.Split(char.Parse(";"));//split DVH almacenado
                    suma += int.Parse(mRegistroSplit[1]);

                }
                //Solo si es la tabla de usuarios
                if (d.Id_Tabla == "Usuario")
                {
                    foreach (BE.UsuarioBE u in ListadoUsuarios)
                    {
                        CalcualarDVH(u);
                       // DVHCalculado += u.DVH;
                    }
                    if (! DVHCalculado.Equals(d.Valor))
                    {
                        contador += 1;
                    }
                }
                if (!suma.Equals(d.Valor))
                {
                    contador += 1;
                }
                suma = 0;
            }
            if (contador == 0)
            {
                //los DV estan OK
                return true;
            }
            else
            {
                return false;
            }
        }
        public BE.UsuarioBE CalcualarDVH(BE.UsuarioBE usu)
        {
            string cadena = string.Format("{0}{1}{2}{3}", usu.DNI, usu.Email, usu.Nombre, usu.Apellido);
            cadena = cadena.Replace(" ", "");
            string s = cadena;
            byte[] bytes = Encoding.ASCII.GetBytes(s);
            int result = BitConverter.ToInt32(bytes, 0);
            result = int.Parse(usu.DVH);
            return usu;
        }
        SqlConnection Conect = new SqlConnection();
        public bool Conectar()
        {
           
            Conect.ConnectionString = DAL_Servicios.Comando.GetInstance().ConexionString();
            Conect.Open();
            return true;
        }
        public void Desconectar()
        {
            Conect.Close();
            Conect.Dispose();
        }
        SqlCommand Comando = new SqlCommand();
    }
}
