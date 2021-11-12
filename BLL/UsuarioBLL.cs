using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;


namespace BLL
{
    public class UsuarioBLL : DAL_Datos.IUsuario
    {
        private string dVH;
        public UsuarioBLL()
        {
            UsuarioDAL_D = new DAL_Datos.UsuarioDAL_D();
        }

        //Llamo a la DAL

        private static UsuarioBLL Instancia;


        public static UsuarioBLL GetInstance()
        {
            if (Instancia == null)
            {
                Instancia = new UsuarioBLL();
            }

            return Instancia;
        }

        // Valido que el usuario sea valido
        public bool Validar(BE.UsuarioBE u)
        {
            return DAL_Datos.UsuarioDAL_D.GetInstance().Validar(u);
        }

        private DAL_Datos.UsuarioDAL_D _usuarioDAL;

        public DAL_Datos.UsuarioDAL_D UsuarioDAL_D
        {
            get
            {
                return _usuarioDAL;
            }

            set
            {
                _usuarioDAL = value;
            }
        }

        public void Logout(BE.UsuarioBE UsuarioBE)
        {
            UsuarioDAL_D.Logout(UsuarioBE);
        }

        public BE.UsuarioBE CargarUsuario(BE.UsuarioBE usuarioBE ,DataTable DT)
        {
            return UsuarioDAL_D.CargarUsuario(usuarioBE , DT);
        }

        public BE.UsuarioBE CargaUsuario( DataTable DT)
        {
            return UsuarioDAL_D.CargaUsuario(DT);
        }
        //buscar el ID del Usuario
        //public BE.UsuarioBE BuscarIDdelUsuario( BE.UsuarioBE usuarioBE ,string NombreUsuario )
        //{
        //    return UsuarioDAL_D.BuscarIDdelUsuario( BE.UsuarioBE usuarioBE , int IDUsuario);
        //}

        public BE.UsuarioBE Validar(BE.UsuarioBE usuarioBE, int intentos)
        {
            return UsuarioDAL_D.Validar(usuarioBE, intentos);
        }
        public BE.UsuarioBE Validar(BE.UsuarioBE usuarioBE, int intentos, bool primerIntento)
        {
            return UsuarioDAL_D.Validar(usuarioBE, intentos,primerIntento);
        }

        public BE.UsuarioBE Login(BE.UsuarioBE usuarioBE, int intentos)
        {
            return UsuarioDAL_D.Login(usuarioBE, intentos);
        }

        public bool Registro(BE.UsuarioBE usuarioBE)
        {
            return UsuarioDAL_D.Registro(usuarioBE);
        }

        public System.Data.DataTable Usuarios(string Usuario)
        {
            return UsuarioDAL_D.Usuarios(Usuario);
        }

        public System.Data.DataTable RangoUsuarios(string x)
        {
            return UsuarioDAL_D.RangoUsuarios(x);
        }

        public void ModificarUsuario(ref BE.UsuarioBE usuarioBE, bool activo)
        {
            UsuarioDAL_D.ModificarUsuario(ref usuarioBE, activo);
        }

        public void ModificarFamilia(ref BE.UsuarioBE usuarioBE)
        {
            UsuarioDAL_D.ModificarFamilia(ref usuarioBE);
        }

        public bool AltaUsuario(ref BE.UsuarioBE usuarioBE, int IDFamilia)
        {
            return UsuarioDAL_D.AltaUsuario(ref usuarioBE, IDFamilia);
        }


        public string RecuperarContraseña(ref BE.UsuarioBE usuarioBE)
        {
            return UsuarioDAL_D.RecuperarContraseña(ref usuarioBE);
        }


        //Validar usuarios repetidos
        public bool ValidarUsuario(BE.UsuarioBE u)
        {
            return DAL_Datos.UsuarioDAL_D.GetInstance().ValidarUsuario(u);
        }

        //Busca si la patente la tiene algun usuario
        public bool PatenteUsuario(BE.PatenteBE p)
        {
            return DAL_Datos.UsuarioDAL_D.GetInstance().PatenteUsuario(p);
        }


        //Listar usuarios (para consulta de patentes)
        public List<BE.UsuarioBE> ListarUsuario(List<BE.UsuarioBE> Usu)
        {
            return DAL_Datos.UsuarioDAL_D.GetInstance().ListarUsuarios(Usu);
        }

        public bool ActualizarUsuario(BE.UsuarioBE usu)
        {
            //usu = CalcualarDVH(usu);
            DAL_Datos.UsuarioDAL_D.GetInstance().ActualizarUsuario(usu);
           // ActualizarDVV();
            GrabarBitacora("Actualización de Usuario", 'M');
            return true;
        }

        // y si el usuario no tiene patentes

        //Cargar patentes del usuario
        public BE.UsuarioPatenteBE CargarPatentesPorUsuario(BE.UsuarioPatenteBE u)
        {
            return DAL_Datos.UsuarioDAL_D.GetInstance().PatentesPorUsuario(u);
        }


        //Cargar Familias del usuario
        public BE.UsuarioFamiliaBE CargarFamiliasPorUsuario(BE.UsuarioFamiliaBE u)
        {
            return DAL_Datos.UsuarioDAL_D.GetInstance().FamiliasPorUsuario(u);
        }
        public BE.UsuarioBE CargarFamiliasPorUsuario(BE.UsuarioBE u)
        {
            return DAL_Datos.UsuarioDAL_D.GetInstance().FamiliasPorUsuario(u);
        }
        // buscar UsuarioFamilia
        public BE.UsuarioBE UsaurioFamilia(BE.UsuarioBE u)
        {
            return DAL_Datos.UsuarioDAL_D.GetInstance().UsuarioFamilia(u);
        }
        //Buscar UsuarioPatentes
        public BE.UsuarioBE UsuarioPatente(BE.UsuarioBE u)
        {
            return DAL_Datos.UsuarioDAL_D.GetInstance().UsuarioPatente(u);
        }
        //Buscar si la familia esta en otro usuario
        public bool BuscarUsuarioConFam(BE.UsuarioBE u)
        {
            return DAL_Datos.UsuarioDAL_D.GetInstance().BuscarUsuarioConFam(u);
        }
        //Buscar Familias de Usuario
        public bool BuscarUsuarioFam(BE.UsuarioBE u)
        {
            return DAL_Datos.UsuarioDAL_D.GetInstance().BuscarUsuarioFam(u);
        }
        //Buscar Pateness de Usuauio
        public bool BuscarUsuarioPat(BE.UsuarioBE u)
        {
            return DAL_Datos.UsuarioDAL_D.GetInstance().BuscarUsuarioPat(u);
        }

        // Busco un usuario específico por ID
        public List<BE.UsuarioBE> BuscarunUsuarioID(int ID_usuario)
        {
            return DAL_Datos.UsuarioDAL_D.GetInstance().BuscarunUsuarioID(ID_usuario);
        }
        // Busco un usuarioID sus Patentes
        public List<BE.UsuarioPatenteBE> BuscarUsuarioIDPatentes(int ID_usuario)
        {
            return DAL_Datos.UsuarioDAL_D.GetInstance().BuscarUsuarioIDPatentes(ID_usuario);
        }
        // Busco un usuarioID sus Familias
        public List<BE.UsuarioFamiliaBE> BuscarUsuarioIDFamilias(int ID_usuario)
        {
            return DAL_Datos.UsuarioDAL_D.GetInstance().BuscarUsuarioIDFamilias(ID_usuario);
        }
        // Busco un usuario específico por ID
        public BE.UsuarioBE BuscarUsuarioNombre(BE.UsuarioBE Usu)
        {
            return DAL_Datos.UsuarioDAL_D.GetInstance().BuscarUsuarioNombre(Usu);
        }

        //PatentesPorUsuario
        public bool HayUsuariosConPatentes(string id, BE.PatenteBE pat)
        {
            return DAL_Datos.UsuarioDAL_D.GetInstance().HayUsuariosConPatentes(id, pat);
        }

        // Busco un usuario específico por DNI
        public List<BE.UsuarioBE> BuscarunUsuarioDNI(string DNI)
        {
            return DAL_Datos.UsuarioDAL_D.GetInstance().BuscarunUsuarioDNI(DNI);
        }

        public bool EliminarUsuario(string Id)
        {
            DAL_Datos.UsuarioDAL_D.GetInstance().EliminarUsuario(Id);
            //ActualizarDVV();
            GrabarBitacora("Baja de Usuario", 'A');
            return true;
        }

        //Alta de Usuario_Patente
        public bool AltaUsuarioPatente(BE.PatenteBE idpatente ,BE.UsuarioBE idusu )
        {
            return DAL_Datos.UsuarioDAL_D.GetInstance().AltaUsuarioPatente( idpatente , idusu);
        }

        //Baja de Usuario_Patente
        public bool BajaUsuarioPatente(BE.UsuarioBE idusu, BE.PatenteBE idpatente)
        {
            return DAL_Datos.UsuarioDAL_D.GetInstance().BajaUsuarioPatente(idusu, idpatente);
        }

        //Baja de Usuario_Familia
        public bool BajaUsuarioFamilia(BE.UsuarioBE Usu, BE.FamiliaBE Fam)
        {
            return DAL_Datos.UsuarioDAL_D.GetInstance().BajaUsuarioFamilia(Usu, Fam);
        }

        //Alta de Usuario_Familia
        public bool AltaUsuarioFamilia(BE.UsuarioBE Usu, BE.FamiliaBE Fam)
        {
            return DAL_Datos.UsuarioDAL_D.GetInstance().AltaUsuarioFamilia(Usu, Fam);
        }

        //Buscar las Familias asignadas al resto de los usuarios
        public bool BuscarUsuarioFam(BE.UsuarioBE u, BE.FamiliaBE Fam)
        {
            return DAL_Datos.UsuarioDAL_D.GetInstance().BuscarUsuarioFam(u, Fam);
        }

        //Buscar todas las familias (USUARIO_FAMILIA)
        public bool Buscartodaslasfamilias(BE.FamiliaBE Fam)
        {
            return DAL_Datos.UsuarioDAL_D.GetInstance().Buscartodaslasfamilias(Fam);
        }

        //Alta de Usuario
        public bool AltaUsuario(BE.UsuarioBE usu)
        {
            //calcular DVH 
            //CalcualarDVH(usu);

            if (DAL_Datos.UsuarioDAL_D.GetInstance().AltaUsuario(usu) == true)
            {

                //ActualizarDVV();
                GrabarBitacora("Alta de Usuario", 'M');

            }
            return true;

        }
       // CALCULAR DVH
        public BE.UsuarioBE CalcualarDVH(BE.UsuarioBE usu)
        {

            string cadena = string.Format("{0}{1}{2}{3}", usu.DNI, usu.Email, usu.Nombre, usu.Apellido);
            cadena = cadena.Replace(" ", "");
            usu.DVH = DVBLL.CalcularDVH(cadena);
            return usu;
        }


        //Actualizar DVV
        public void ActualizarDVV()
        {
            // recalculo DVV
            Servicios.DigitosVerificadores.GrabarDVHFull();
           

        }

        //Grabar bitacora
        public void GrabarBitacora(string descrip, char criticidad)
        {
            //Grabo movimiento en bitácora
            BE.BitacoraBE bit = new BE.BitacoraBE();
            bit.Criticidad = criticidad;
            bit.Descripcion = descrip;
            bit.FechaHora = DateTime.Now;

            // Recuperar usuario 
            bit.NombreUsuario = BE.Globales.UsuarioCacheNomUsu;

            //Encriptar 3DES descripcion
            string semilla = "123456";
            bit.Descripcion = Servicios.Encriptado.GetInstance().Encriptar(bit.Descripcion, semilla);

            //Calcular DVH
            string CadenaBitacora = string.Format("{0}{1}{2}{3}",bit.ID_Evento, bit.Descripcion, bit.NombreUsuario, bit.FechaHora);
            dVH = bit.DVH;
            dVH = DVBLL.CalcularDVH(CadenaBitacora);

            BitacoraBLL.GetInstance().GrabarBitacora(bit);
        }




        //Bloquear Usuario
        public bool bloquearUsuario(BE.UsuarioBE usu)
        {
            return DAL_Datos.UsuarioDAL_D.GetInstance().bloquearUsuario(usu);
        }


        //Actualizar Contraseña
        public bool ActualizarContraseña(BE.UsuarioBE usuario)
        {
            return DAL_Datos.UsuarioDAL_D.GetInstance().ActualizarContraseña(usuario);
        }

        //Actualizar DVH
        public bool ActualizarDVH(BE.UsuarioBE usuario)
        {
            return DAL_Datos.UsuarioDAL_D.GetInstance().ActualizarDVH(usuario);
        }

        //Generar una contraseña
        public string GenerarContraseña()
        {
            Random rdn = new Random();
            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890%$#@";
            int longitud = caracteres.Length;
            char letra;
            int longitudContrasenia = 7;
            string contraseniaAleatoria = string.Empty;
            for (int i = 0; i < longitudContrasenia; i++)
            {
                letra = caracteres[rdn.Next(longitud)];
                contraseniaAleatoria += letra.ToString();
            }
            return contraseniaAleatoria;
        }


        //Encriptar contraseña
        public static string GetMD5(string str)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = md5.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        public bool enviarEMail(string correo, string password)
        {
            MailMessage Correo = new MailMessage();
            Correo.From = new MailAddress("Nel01lowen@gmail.com");
            Correo.To.Add(correo);
            Correo.Subject = ("Recuperar Contraseña");
            Correo.Body = "Su nueva contraseña es: " + password;
            Correo.Priority = MailPriority.Normal;

            SmtpClient ServerEmail = new SmtpClient();
            ServerEmail.Credentials = new NetworkCredential("Nel01lowen@gmail.com", "nellowen01");
            ServerEmail.Host = "smtp.gmail.com";
            ServerEmail.Port = 587;
            ServerEmail.EnableSsl = true;
            try
            {
                ServerEmail.Send(Correo);
            }
            catch
            {
                return false;
            }


            Correo.Dispose();
            return true;
        }


    }
}

    

