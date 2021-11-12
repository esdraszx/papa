using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using BE;

namespace DAL_Datos
{
    public class UsuarioDAL_D:IUsuario
    {
        private bool _existeUsuario;
        private bool _primerLogin;
        private int _contador;
        public BitacoraBE bit;
        public UsuarioBE usu;
        public List<UsuarioBE> ListaUsuarios { get; set; }
        public List<UsuarioPatenteBE> ListaUsuarioPatente { get; set; }
        public List<UsuarioFamiliaBE> ListaUsuarioFamilia { get; set; }
        //Singleton
        private static UsuarioDAL_D Instancia;
        public static UsuarioDAL_D GetInstance()
        {
            if (Instancia == null)
            {
                Instancia = new UsuarioDAL_D();
            }
            return Instancia;
        }

        SqlConnection Conect = new SqlConnection();
        void Conectar()
        {
            Conect.ConnectionString = DAL_Servicios.Comando.GetInstance().ConexionString();
            Conect.Open();
        }
        void Desconectar()
        {
            Conect.Close();
            Conect.Dispose();
        }
        SqlCommand Comando = new SqlCommand();


        public void Logout(UsuarioBE usuarioBE)
        {          
            try
            {
                DataTable DT = DAL_Servicios.Comando.objDatatable("select * from usuarios where Usuario= '" + usuarioBE.NombreUsuario + "' AND Password='" + usuarioBE.Contraseña + "'");
                if (DT.Rows.Count > 0)
                {
                    DataTable DT0 = DAL_Servicios.Comando.objDatatable("select * from Bitacora");
                    DataRow DR = DT0.NewRow();
                    DR.ItemArray[1] = "Se Deslogueo el usuario " + usuarioBE.NombreUsuario + " ID: " + DT.Rows[0].ItemArray[0];
                    DR.ItemArray[2] = DateAndTime.Now;
                    DT0.Rows.Add(DR);
                    DAL_Servicios.Comando.actualizarBD("select * from Bitacora", DT0);
                    Servicios.DigitosVerificadores.GrabarPorTabla("SELECT TOP 1 * from Bitacora  order by ID_Evento Desc");
                    MVARSDAL_D.PrimerLogueo = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }
        public UsuarioBE Login(UsuarioBE usuarioBE, int intentos)
        {
            int contador = 0 ;
            MVARSDAL_D.contador = contador;
            try
            {
                DataTable DT = DAL_Servicios.Comando.objDatatable("select * from Usuarios where NombreUsuario= '" + usuarioBE.NombreUsuario + "'");
                if (DT.Rows.Count > 0)
                {
                    if (contador <= 2)
                    {
                        _existeUsuario = true;
                        if ((string)DT.Rows[0].ItemArray[0] == usuarioBE.Contraseña)
                        {
                            if ((bool)DT.Rows[0].ItemArray[8] == true)
                            {
                                usuarioBE = CargaUsuario(DT);
                            }
                            else
                            {
                                // Usuario bloqueado
                                MessageBox.Show("USUARIO BLOQUEADO" + Constants.vbCrLf + "Pongase en contacto con el Administrador");
                                MVARSDAL_D.contador = 0;
                                usuarioBE = default;
                            }
                        }
                        else
                        {
                            contador += 1;
                            if (contador == 3)
                            {
                                usuarioBE = BloquearUsuario(usuarioBE);
                            }
                            usuarioBE = default;
                        }
                    }
                }
                else
                {
                    usuarioBE = default;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return usuarioBE;
        }
        public UsuarioBE Login(UsuarioBE usuarioBE, int intentos, bool PrimerLogin)
        {
            int _contador = 0;
            MVARSDAL_D.contador = _contador;
            try
            {
                DataTable DT = DAL_Servicios.Comando.objDatatable("select * from Usuarios where NombreUsuario = '" + usuarioBE.NombreUsuario + "'");
                if (DT.Rows.Count > 0)
                {
                    if (_contador <= 2)
                    {
                        //Existe el usuario
                        _existeUsuario = true;
                        if ((String)DT.Rows[0].ItemArray[2] == usuarioBE.Contraseña)
                        {
                            //Coincide la contraseña
                            if ((bool)DT.Rows[0].ItemArray[8] == true)
                            {
                                _primerLogin = PrimerLogin;
                                usuarioBE = this.CargaUsuario(DT);
                            }
                            else
                            {
                                MessageBox.Show("Usuario bloqueado, pongase en contacto con el administrador");
                                _contador = 0;
                                usuarioBE = null;
                            }
                        }
                        else
                        {
                            _contador += 1;
                            if (_contador == 3)
                            {
                                this.BloquearUsuario(usuarioBE);
                            }
                            usuarioBE = null;
                        }
                    }
                }
                else
                {
                    usuarioBE = null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return usuarioBE;
        }
        public UsuarioBE BloquearUsuario(UsuarioBE usuarioBE)
        {
            usuarioBE.Activo = false;
            MessageBox.Show("El usuario: " + usuarioBE.NombreUsuario + ", ha sido bloqueado." + Constants.vbCrLf + "Pongase en contacto con el administrador");
            ModificarUsuario(ref usuarioBE, usuarioBE.Activo);
            Servicios.DigitosVerificadores.GrabarPorTabla("select * from Usuarios");
            MVARSDAL_D.contador = 0;
            return default;
        }
        public UsuarioBE Validar(UsuarioBE usuarioBE, int intentos)
        {
            usuarioBE.NombreUsuario = usuarioBE.NombreUsuario;
            usuarioBE.Contraseña = usuarioBE.Contraseña;
            usuarioBE = Login(usuarioBE, intentos);
            return usuarioBE;
        }
        public UsuarioBE Validar(UsuarioBE usuarioBE, int intentos,bool PrimerLogin)
        {
            usuarioBE.NombreUsuario = usuarioBE.NombreUsuario;
            usuarioBE.Contraseña = usuarioBE.Contraseña;
            usuarioBE = Login(usuarioBE,intentos,PrimerLogin);
            return usuarioBE;
        }
        public UsuarioBE CargarUsuario( UsuarioBE usuarioBE ,DataTable DT)
        {
            var usu = new UsuarioBE();
            usu.NombreUsuario = usuarioBE.NombreUsuario;
            DataRow DR;
            DR = DT.Rows[0];
            try
            {
                usu.IDUsuario = (int)DR.ItemArray[0];
                usu.NombreUsuario = (String)DR.ItemArray[1];
                usu.Contraseña = (String)DR.ItemArray[2];
                usu.Nombre = (String)DR.ItemArray[3];
                usu.Apellido = (String)DR.ItemArray[4];
                usu.Direccion = (String)DR.ItemArray[5];
                usu.Email = (String)DR.ItemArray[6];
                usu.Telefono = DR.ItemArray[7].ToString();
                usu.Activo = (bool)DR.ItemArray[8];
                usu.PalabraRestitucion = (String)DR.ItemArray[9];
                usu = ObtenerPermisos(usu);
                if (_primerLogin == true)
                {
                    Servicios.Bitacora.GrabarBitacora("Se logueo el usuario: " + usu.NombreUsuario + " ID: " + usu.IDUsuario);
                    Servicios.DigitosVerificadores.GrabarPorTabla("SELECT TOP 1 * from Bitacora  order by ID_Evento Desc");
                }
                else
                {
                    _primerLogin = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "CargarUsuarioDAL");
            }
            return usu;
        }

        public UsuarioBE CargaUsuario(DataTable DT)
        {
            var usu = new UsuarioBE();
            DataRow DR;
            DR = DT.Rows[0];
            try
            {
                usu.IDUsuario = (int)DR.ItemArray[0];
                usu.NombreUsuario = (String)DR.ItemArray[1];
                usu.Contraseña = (String)DR.ItemArray[2];
                //usu.Nombre = (String)DR.ItemArray[3];
                //usu.Apellido = (String)DR.ItemArray[4];
                //usu.Direccion = (String)DR.ItemArray[5];
                //usu.Email = (String)DR.ItemArray[6];
                //usu.Telefono = DR.ItemArray[7].ToString();
                //usu.Activo = (bool)DR.ItemArray[8];
                //usu.PalabraRestitucion = (String)DR.ItemArray[9];
                //usu.Intentos = (int)DR.ItemArray[10];
                //usu.DNI = (String)DR.ItemArray[11];
                //usu.DVH = (String)DR.ItemArray[12];
                usu = ObtenerPermisos(usu);
                
                if (_primerLogin == true)
                {
                    var bit = new BitacoraBE();
                    //bit.ID_Evento = +1;
                    bit.Descripcion = "Se logueo el usuario: " + usu.NombreUsuario + " ID: " + usu.IDUsuario;
                    bit.FechaHora = DateTime.Now;
                    //Servicios.Bitacora.GrabarBitacora("Se logueo el usuario: " + usu.NombreUsuario + " ID: " + usu.IDUsuario);
                    Servicios.Bitacora.GrabarBitacora(bit);
                    Servicios.DigitosVerificadores.GrabarPorTabla("SELECT TOP 1 * from Bitacora  order by ID_Evento Desc");
                }
                else
                {
                    _primerLogin = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "CargaUsuarioDAL");
            }
            return usu;
        }



        public UsuarioBE ObtenerPermisos(UsuarioBE usuarioBE)
        {
            try
            {
                DataTable DT = DAL_Servicios.Comando.objDatatable("select * from Familia, UsuarioFamilia where UsuarioFamilia.ID_Usuario = '" + usuarioBE.IDUsuario + "' and Familia.ID_Familia = UsuarioFamilia.ID_Familia");
                usuarioBE.PerfilAbstracto = PerfilDAL_D.DarPerfil(DT);

                foreach (PatenteBE Pats in PatenteDAL_D.DarPatentes_Usu(usuarioBE.IDUsuario))
                usuarioBE.PerfilAbstracto.Add(Pats);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " ObtenerPermisosDAL");
            }
            return usuarioBE;
        }
        public bool Registro(UsuarioBE usuarioBE)
        {
            return AltaUsuario(ref usuarioBE, 1);
        }
        public DataTable Usuarios(string ID_Usuario)
        {
            DataTable DT = default;
            if (!string.IsNullOrEmpty(ID_Usuario))
            {
                DT = DAL_Servicios.Comando.objDatatable("select ID_Usuario, NombreUsuario, Password, Nombre, Apellido, Direccion, email, Telefono, Activo, DVH from Usuarios where ID_Usuario='" + ID_Usuario + "'");
            }
            else
            {
                DT = DAL_Servicios.Comando.objDatatable("select ID_Usuario, NombreUsuario, Password, Nombre, Apellido, Direccion, email, Telefono, Activo, DVH from Usuarios");
            }
            return DT;
        }
        public DataTable RangoUsuarios(string x)
        {
            DataTable DT;
            if (string.IsNullOrEmpty(x))
            {
                DT = DAL_Servicios.Comando.objDatatable("select Usuarios.ID_Usuario, Usuarios.NombreUsuario, Familia.Nombre_Familia from Usuarios, Familia, UsuarioFamilia where Usuarios.ID_Usuario = UsuarioFamilia.ID_Usuario and Familia.Id_Familia = UsuarioFamilia.Id_Familia");
            }
            else
            {
                DT = DAL_Servicios.Comando.objDatatable("select Usuarios.ID_Usuario, Usuarios.Usuario, Familia.Nombre_Familia from Usuarios, Familia, UsuarioFamilia where Usuarios.ID_Usuario ='" + x + "' and Usuarios.ID_Usuario = UsuarioFamilia.ID_Usuario and Familia.ID_Familia = UsuarioFamilia.Id_Familia");
            }
            return DT;
        }
        public void ModificarFamilia(ref UsuarioBE usuarioBE)
        {
            DataTable DT = DAL_Servicios.Comando.objDatatable("select * from Usuarios where ID_Usuario='" + usuarioBE.IDUsuario + "'");
            DT.Rows[0].ItemArray[1] = usuarioBE.PerfilAbstracto;
            DAL_Servicios.Comando.actualizarBD("select * from Usuarios", DT);
        }
        public DataTable MisBusquedas(ref BE.UsuarioBE usuarioBE)
        {
            DataTable DT = default;
            DataTable DT1 = default;
            try
            {
                DT = DAL_Servicios.Comando.objDatatable("Select ID_Usuario from Usuarios where NombreUsuario ='" + usuarioBE.NombreUsuario + "'");
                DT1 = DAL_Servicios.Comando.objDatatable("Select consulta,fecha from Busquedas where ID_Usuario ='" + DT.Rows[0].ItemArray[0] + "'");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return DT1;
        }
        #region ABM Usuario
        public bool AltaUsuario(ref UsuarioBE usuarioBE, int IDFamilia)
        {
            bool Retorno = true;
            DataTable DT = DAL_Servicios.Comando.objDatatable("select * from Usuarios");
            try
            {
                if (DT.Rows.Count > 0)
                {
                    foreach (DataRow DR in DT.Rows)
                    {
                        if ((string)DR.ItemArray[1] == usuarioBE.NombreUsuario)
                        {
                            MessageBox.Show("el usuario ya existe");
                            Retorno = false;
                        }
                    }

                    if (usuarioBE.NombreUsuario == "" || usuarioBE.DNI == "" || usuarioBE.Contraseña == "" || usuarioBE.Nombre == "" || usuarioBE.Apellido == "" || usuarioBE.Direccion == "" || usuarioBE.Email == "" || usuarioBE.Telefono == "" || usuarioBE.PalabraRestitucion == "")
                    {
                        MessageBox.Show("Falta completar campos");
                        Retorno = false;
                    }
                    else
                    {
                        DataRow DR1 = DT.NewRow();
                        DR1.ItemArray[1] = usuarioBE.NombreUsuario;
                        DR1.ItemArray[2] = usuarioBE.Contraseña;
                        DR1.ItemArray[3] = usuarioBE.Nombre;
                        DR1.ItemArray[4] = usuarioBE.Apellido;
                        DR1.ItemArray[5] = usuarioBE.Direccion;
                        DR1.ItemArray[6] = usuarioBE.Email;
                        DR1.ItemArray[7] = usuarioBE.Telefono;
                        DR1.ItemArray[9] = true;
                        DR1.ItemArray[10] = usuarioBE.PalabraRestitucion;
                        DT.Rows.Add(DR1);
                        DAL_Servicios.Comando.actualizarBD("select * from Usuarios", DT);
                        Servicios.DigitosVerificadores.GrabarPorTabla("SELECT * from Usuarios");
                        DataTable DT1 = DAL_Servicios.Comando.objDatatable("select ID_Usuario from Usuarios where Usuarios.NombreUsuario='" + usuarioBE.NombreUsuario + "'");
                        if (DT1.Rows.Count > 0)
                        {
                            var p = new PerfilDAL_D();
                            p.InsertarUsuarioFamilia((int)DT1.Rows[0].ItemArray[0], IDFamilia);
                            usuarioBE.IDUsuario =(int) DT1.Rows[0].ItemArray[0];
                            Servicios.Bitacora.GrabarBitacora("Se registró el usuario: " + usuarioBE.NombreUsuario + " ID: " + DT1.Rows[0].ItemArray[0]);
                            Servicios.DigitosVerificadores.GrabarPorTabla("SELECT TOP 1 * from Bitacora  order by ID_Evento Desc");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }

            return Retorno;
        }
        public void ModificarUsuario(ref UsuarioBE usuarioBE, bool activo)
        {
            DataTable DT = DAL_Servicios.Comando.objDatatable("select * from Usuarios where NombreUsuario='" + usuarioBE.NombreUsuario + "'");
            try
            {
                if (activo == false)
                {
                    DT.Rows[0].ItemArray[8] = usuarioBE.Activo;
                    Servicios.Bitacora.GrabarBitacora("USUARIO BLOQUEADO: " + usuarioBE.NombreUsuario);
                }
                else
                {
                    DT.Rows[0].ItemArray[1] = usuarioBE.NombreUsuario;
                    DT.Rows[0].ItemArray[2] = usuarioBE.Contraseña;
                    DT.Rows[0].ItemArray[3] = usuarioBE.Nombre;
                    DT.Rows[0].ItemArray[4] = usuarioBE.Apellido;
                    DT.Rows[0].ItemArray[5] = usuarioBE.Direccion;
                    DT.Rows[0].ItemArray[6] = usuarioBE.Email;
                    DT.Rows[0].ItemArray[7] = usuarioBE.Telefono;
                    DT.Rows[0].ItemArray[8] = usuarioBE.Activo;
                    Servicios.Bitacora.GrabarBitacora("USUARIO MODIFICADO: " + usuarioBE.NombreUsuario);
                }

                DAL_Servicios.Comando.actualizarBD("select * from Usuarios", DT);
                Servicios.DigitosVerificadores.GrabarPorTabla("select * from Usuarios");
                Servicios.DigitosVerificadores.GrabarPorTabla("SELECT TOP 1 * from Bitacora  order by ID_Evento Desc");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
        public string RecuperarContraseña(ref UsuarioBE usuarioBE)
        {
            string Contraseña = null;
            try
            {
                DataTable Dt = DAL_Servicios.Comando.objDatatable("select password from Usuarios where NombreUsuario='" + usuarioBE.NombreUsuario + "' and PalabraRestitucion='" + usuarioBE.PalabraRestitucion + "'");
                Contraseña = (string)Dt.Rows[0].ItemArray[2];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Contraseña;
        }
        // Valida que existe el Usuario en la Base 
        public bool Validar(UsuarioBE usuario)
        {
            try
            {
                string query = string.Format("select  NombreUsuario , Password  from Usuarios where  NombreUsuario = '{0}' and  Password = '{1}'",  usuario.NombreUsuario, usuario.Contraseña );
                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = query;
                Comando.ExecuteNonQuery();
                SqlDataReader Leer = Comando.ExecuteReader();
                if (Leer.HasRows)
                {
                    Desconectar();
                    return true;
                }
                else
                {
                    Desconectar();
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        // Valida que existe el Usuario en la Base por IDUsuario
        public bool ValidarUsuario(UsuarioBE usuario)
        {
            try
            {
                string query = string.Format("select * from Usuarios where ID_Usuario = '{0}'", usuario.IDUsuario);
                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = query;
                Comando.ExecuteNonQuery();
                SqlDataReader Leer = Comando.ExecuteReader();
                if (Leer.HasRows)
                {
                    Desconectar();
                    return true;
                }
                else
                {
                    Desconectar();
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool ActualizarUsuario(UsuarioBE usuario)
        {
            try
            {
                string query = string.Format("UPDATE Usuarios SET NombreUsuario = '{1}', Apellido = '{2}', Nombre = '{3}', Direccion = '{4}', DNI = '{5}', Email = '{6}', Telefono = '{7}' , WHERE ID_Usuario = '{0}'", usuario.NombreUsuario, usuario.Apellido, usuario.Nombre, usuario.Direccion, usuario.DNI, usuario.Email, usuario.Telefono, usuario.Activo);
                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = query;
                Comando.ExecuteNonQuery();
                Desconectar();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool bloquearUsuario(UsuarioBE usuario)
        {
            try
            {
                string query = string.Format("UPDATE Usuarios SET Activo = '0'  WHERE ID_Usuario = '{0}'", usuario.IDUsuario);
                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = query;
                Comando.ExecuteNonQuery();
                Desconectar();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Actualizar contraseña y desbloquear usuario
        public bool ActualizarContraseña(UsuarioBE usuario)
        {
            try
            {
                string query = string.Format("UPDATE Usuarios SET  Password ='{1}' WHERE ID_Usuario = '{0}'", usuario.IDUsuario, usuario.Contraseña);
                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = query;
                Comando.ExecuteNonQuery();
                Desconectar();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool EliminarUsuario(string Id)
        {
            try
            {
                BajaUsuarioPatente(Id);
                string query = string.Format("Delete FROM Usuarios  WHERE ID_Usuario = '{0}'", Id);
                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = query;
                Comando.ExecuteNonQuery();
                Desconectar();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Verico que haya otro usuario con patentes para asignar patentes 
        public bool HayUsuariosConPatentes(string id, PatenteBE pat)
        {
            try
            {
                string consulta = string.Format("SELECT COUNT(*) FROM UsuarioPatente WHERE ID_Usuario != '{0}' AND ID_Patente = '{1}' GROUP BY ID_Usuario", id, pat.ID_Patente);
                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = consulta;
                if (Comando.ExecuteScalar() == null)
                {
                    Desconectar();
                    return false;
                }
                else
                {
                    Desconectar();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Buscar las patentes por usuario
        public UsuarioPatenteBE PatentesPorUsuario(UsuarioPatenteBE u)
        {
            try
            {
                string consulta = string.Format("SELECT ID_Patente , ID_Usuario  FROM UsuarioPatente  Where ID_Usuario = '' ", u.ID_Usuario );
                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = consulta;
                SqlDataReader lector = Comando.ExecuteReader();
                while (lector.Read())
                {
                    UsuarioPatenteBE UsuPat = new UsuarioPatenteBE();
                    UsuPat.ID_Patente = int.Parse(lector["ID_Patente"].ToString());
                    UsuPat.ID_Usuario = int.Parse(lector["ID_Usuario"].ToString());
                   
                }
                Desconectar();
                return u;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Buscar las Familias por usuarioID
        public UsuarioFamiliaBE FamiliasPorUsuario(UsuarioFamiliaBE u)
        {
            try
            {
                string consulta = string.Format("SELECT ID_Usuario , ID_Familia  FROM UsuarioFamilia  Where ID_Usuario = '' ", u.ID_Usuario );
                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = consulta;
                SqlDataReader lector = Comando.ExecuteReader();
                while (lector.Read())
                {
                    UsuarioFamiliaBE UsuFam = new UsuarioFamiliaBE();
                    UsuFam.ID_Usuario = int.Parse(lector["ID_Usuario"].ToString());
                    UsuFam.ID_Familia = int.Parse(lector["ID_Familia"].ToString());
                   
                }
                Desconectar();
                return u;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        // Sobrecarga busca las familias por usuarioID
        public UsuarioBE FamiliasPorUsuario(UsuarioBE u)
        {
            try
            {
                string consulta = string.Format("SELECT ID_Usuario , ID_Familia  FROM UsuarioFamilia  Where ID_Usuario = '' ", u.IDUsuario);
                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = consulta;
                SqlDataReader lector = Comando.ExecuteReader();
                while (lector.Read())
                {
                    UsuarioFamiliaBE UsuFam = new UsuarioFamiliaBE();
                    UsuFam.ID_Usuario = int.Parse(lector["ID_Usuario"].ToString());
                    UsuFam.ID_Familia = int.Parse(lector["ID_Familia"].ToString());

                }
                Desconectar();
                return u;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Busca si la patente la tiene algun usuario
        public bool PatenteUsuario(PatenteBE p)
        {
            try
            {
                string consulta = string.Format("SELECT * FROM UsuarioPatente Where ID_Patente = '{0}'", p.ID_Patente);
                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = consulta;
                if (Comando.ExecuteScalar() == null)
                {
                    Desconectar();
                    return false;
                }
                else
                {
                    Desconectar();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Buscar UsuarioFamilia
        public UsuarioBE UsuarioFamilia(UsuarioBE u)
        {
            try
            {
                string consulta = string.Format("SELECT * FROM UsuarioFamilia  Where ID_Usuario = ''", u.IDUsuario);
                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = consulta;
                SqlDataReader lector = Comando.ExecuteReader();
                while (lector.Read())
                {
                    UsuarioFamiliaBE Fam = new UsuarioFamiliaBE();
                    Fam.ID_Usuario = int.Parse(lector["ID_Usuario"].ToString());
                    Fam.ID_Familia = int.Parse(lector["ID_Familia"].ToString());
                    u.IDUsuario = Fam.ID_Usuario;
                    
                }
                Desconectar();
                return u;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Buscar UsuarioPatente
        public UsuarioBE UsuarioPatente(UsuarioBE u)
        {
            try
            {
                string consulta = string.Format("SELECT * FROM UsuarioPatente   Where ID_Usuario = '{0}'", u.IDUsuario);
                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = consulta;
                SqlDataReader lector = Comando.ExecuteReader();
                while (lector.Read())
                {
                    UsuarioPatenteBE Patente = new UsuarioPatenteBE();
                    Patente.ID_Patente = int.Parse(lector["ID_Patente"].ToString());
                    Patente.ID_Usuario = int.Parse(lector["ID_Usuario"].ToString());
                    u.IDUsuario = Patente.ID_Usuario;
                }
                Desconectar();
                return u;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Listar todos los usuarios de la base
        public List<UsuarioBE> ListarUsuarios(List<UsuarioBE> datUsu)
        {
            try
            {
                string consulta = string.Format("SELECT ID_Usuario,NombreUsuario,Nombre,Apellido,email,Activo,DNI  FROM Usuarios");
                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = consulta;
                SqlDataReader lector = Comando.ExecuteReader();
                while (lector.Read())
                {
                    UsuarioBE usu = new UsuarioBE();
                    usu.IDUsuario = int.Parse(lector["ID_Usuario"].ToString());
                    usu.NombreUsuario = lector["NombreUsuario"].ToString();
                    //usu.Contraseña = lector["Password"].ToString();
                    usu.Nombre = lector["Nombre"].ToString();
                    usu.Apellido = lector["Apellido"].ToString();
                    //usu.Direccion = lector["Direccion"].ToString();
                    usu.Email = lector["email"].ToString();
                    //usu.Telefono = lector["Telefono"].ToString();
                    usu.Activo = bool.Parse(lector["Activo"].ToString());
                   // usu.PalabraRestitucion = lector["PalabraRestitucion"].ToString();
                    //usu.Intentos = int.Parse(lector["Intentos"].ToString());
                    usu.DNI = lector["DNI"].ToString();
                   // usu.DVH = lector["DVH"].ToString();
                    datUsu.Add(usu);
                }
                Desconectar();
                return datUsu;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Busco un usuario por Nombre/ID
        public List<UsuarioBE> BuscarunUsuarioID(int ID_usuario)
        {
            try
            {
                string consulta = string.Format("SELECT * FROM Usuarios Where ID_Usuario ='{0}'", ID_usuario);
                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = consulta;
                SqlDataReader lector = Comando.ExecuteReader();
                UsuarioBE usu = new UsuarioBE();
                ListaUsuarios = new List<UsuarioBE>();
                while (lector.Read())
                {
                    usu.IDUsuario = int.Parse(lector["ID_Usuario"].ToString());
                    usu.NombreUsuario = lector["NombreUsuario"].ToString();
                    usu.Contraseña = lector["Password"].ToString();
                    usu.Nombre = lector["Nombre"].ToString();
                    usu.Apellido = lector["Apellido"].ToString();
                    usu.Direccion = lector["Direccion"].ToString();
                    usu.Email = lector["email"].ToString();
                    usu.Telefono = lector["Telefono"].ToString();
                    usu.Activo = bool.Parse(lector["Activo"].ToString());
                    usu.PalabraRestitucion = lector["PalabraRestitucion"].ToString();
                    usu.DVH = lector["DVH"].ToString();
                    //usu.Intentos = int.Parse(lector["Intentos"].ToString());
                    usu.DNI = lector["DNI"].ToString();
                   
                    ListaUsuarios.Add(usu);
                }
                Desconectar();
                return ListaUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Busco un usuario ID sus Patentes
        public List<UsuarioPatenteBE> BuscarUsuarioIDPatentes(int ID_usuario)
        {
            try
            {
                string consulta = string.Format("SELECT * FROM UsuarioPatente Where ID_Usuario ='{0}'", ID_usuario );
                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = consulta;
                SqlDataReader lector = Comando.ExecuteReader();
                ListaUsuarioPatente = new List<UsuarioPatenteBE>();
                while (lector.Read())
                {
                    UsuarioPatenteBE usu = new UsuarioPatenteBE();
                    usu.ID_Usuario = int.Parse(lector["ID_Usuario"].ToString());
                    usu.ID_Patente = int.Parse(lector["ID_Patente"].ToString());
                    ListaUsuarioPatente.Add(usu);
                }
                Desconectar();
                return ListaUsuarioPatente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Busco un usuario ID sus Familias 
        public List<UsuarioFamiliaBE> BuscarUsuarioIDFamilias(int ID_usuario)
        {
            try
            {
                string consulta = string.Format("SELECT * FROM UsuarioFamilia Where ID_Usuario ='{0}'", ID_usuario);
                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = consulta;
                SqlDataReader lector = Comando.ExecuteReader();
                ListaUsuarioFamilia = new List<UsuarioFamiliaBE>();
                while (lector.Read())
                {
                    UsuarioFamiliaBE usu = new UsuarioFamiliaBE();
                    usu.ID_Usuario = int.Parse(lector["ID_Usuario"].ToString());
                    usu.ID_Familia = int.Parse(lector["ID_Familia"].ToString());
                    ListaUsuarioFamilia.Add(usu);
                }
                Desconectar();
                return ListaUsuarioFamilia;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Busco un usuario por Nombre
        public UsuarioBE BuscarUsuarioNombre(UsuarioBE Usu)
        {
            try
            {
                string consulta = string.Format("SELECT * FROM Usuarios Where NombreUsuario = '{0}'", Usu.NombreUsuario);
                //string consulta= DAL_Servicios.Comando.ConsultaSQL("SELECT * FROM Usuarios Where Usuario = '{0}'", Usu.NombreUsuario , (DAL_Servicios.Conexion.ConexionF() ));
                //DAL_Servicios.Conexion.ConexionF();
                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = consulta;
                SqlDataReader lector = Comando.ExecuteReader();
                ListaUsuarios = new List<UsuarioBE>();
                while (lector.Read())
                {
                    usu = new UsuarioBE();
                    usu.IDUsuario = int.Parse(lector["ID_Usuario"].ToString());
                    usu.NombreUsuario = lector["NombreUsuario"].ToString();
                    usu.Contraseña = lector["Password"].ToString();
                    usu.Nombre = lector["Nombre"].ToString();
                    usu.Apellido = lector["Apellido"].ToString();
                    usu.Direccion = lector["Direccion"].ToString();
                    usu.Email = lector["email"].ToString();
                    usu.Telefono = lector["Telefono"].ToString();
                    usu.Activo = bool.Parse(lector["Activo"].ToString());
                    usu.PalabraRestitucion = lector["PalabraRestitucion"].ToString();
                    usu.DVH = lector["DVH"].ToString();
                   // usu.Intentos = int.Parse(lector["Intentos"].ToString());
                    usu.DNI = lector["DNI"].ToString();
                    ListaUsuarios.Add(usu);
                }
                Desconectar();
                return usu;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Busco un usuario por DNI
        public List<UsuarioBE> BuscarunUsuarioDNI(string DNI)
        {
            try
            {
                string consulta = string.Format("SELECT * FROM Usuarios Where DNI = '{0}'", DNI);
                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = consulta;
                SqlDataReader lector = Comando.ExecuteReader();
                UsuarioBE usu = new UsuarioBE();
                ListaUsuarios = new List<UsuarioBE>();
                while (lector.Read())
                {
                    usu.IDUsuario = int.Parse(lector["ID_Usuario"].ToString());
                    usu.NombreUsuario = lector["NombreUsuario"].ToString();
                    usu.Contraseña = lector["Password"].ToString();
                    usu.Nombre = lector["Nombre"].ToString();
                    usu.Apellido = lector["Apellido"].ToString();
                    usu.Direccion = lector["Direccion"].ToString();
                    usu.Email = lector["email"].ToString();
                    usu.Telefono = lector["Telefono"].ToString();
                    usu.Activo = bool.Parse(lector["Activo"].ToString());
                    usu.PalabraRestitucion = lector["PalabraRestitucion"].ToString();
                    usu.DVH = lector["DVH"].ToString();
                   // usu.Intentos = int.Parse(lector["Intentos"].ToString());
                    usu.DNI = lector["DNI"].ToString();
                    ListaUsuarios.Add(usu);
                }

                Desconectar();
                return ListaUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Alta de Usuario
        public bool AltaUsuario(UsuarioBE usu)
        {
            try
            {
                int IDUsuario = usu.IDUsuario;
                string NombreUsuario = usu.NombreUsuario;
                string Contraseña = usu.Contraseña;
                string Nombre = usu.Nombre;
                string Apellido = usu.Apellido;
                string Direccion = usu.Direccion;
                string Email = usu.Email;
                string Telefono = usu.Telefono;
                bool Activo = usu.Activo;
                string PalabraRestitucion = usu.PalabraRestitucion;
                string DVH = usu.DVH;
                int Intentos = usu.Intentos;
                string DNI = usu.DNI;
                string query = string.Format("INSERT INTO Usuarios VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}','{6}', '{7}', '{8}', '{9}','{10}','{11}', '{12}')", IDUsuario, NombreUsuario , Contraseña, Nombre, Apellido, Direccion ,Email ,Telefono, Activo, PalabraRestitucion, DVH, Intentos , DNI);
                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = query;
                Comando.ExecuteNonQuery();
                Desconectar();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Alta de Usuario_Patentes (agrego patentes al usuario)
        public bool AltaUsuarioPatente( PatenteBE Patente , UsuarioBE Usu)
        {
            try
            {
                string query = string.Format("INSERT INTO UsuarioPatente Values ('{0}','{1}','{2}','{3}')",Patente.ID_Patente,Usu.IDUsuario ,Usu.Activo,Usu.DVH);
                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = query;
                Comando.ExecuteNonQuery();
                Desconectar();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool BajaUsuarioPatente(UsuarioBE Usu, PatenteBE Patente)
        {
            try
            {
                string query = string.Format("Delete FROM UsuarioPatente  WHERE ID_Usuario = '{0}' AND ID_Patente = '{1}'", Usu.Nombre, Patente.ID_Patente);
                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = query;
                Comando.ExecuteNonQuery();
                Desconectar();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool BajaUsuarioPatente(string id)
        {
            try
            {
                string query = string.Format("Delete FROM UsuarioPatente  WHERE ID_Usuario = '{0}'", id);
                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = query;
                Comando.ExecuteNonQuery();
                Desconectar();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Eliminar Familia del usuario
        public bool BajaUsuarioFamilia(UsuarioBE Usu, FamiliaBE Fam)
        {
            try
            {
                string query = string.Format("Delete FROM UsuarioFamilia  WHERE ID_Usuario = '{0}' AND ID_Familia = '{1}'", Usu.NombreUsuario , Fam.NombreFamilia);
                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = query;
                Comando.ExecuteNonQuery();
                Desconectar();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Alta de Usuario_Familia (agrego Familia al usuario)
        public bool AltaUsuarioFamilia(UsuarioBE Usu, FamiliaBE Fam)
        {
            try
            {
                string query = string.Format("INSERT INTO UsuarioFamilia  Values('{0}','{1}','{2}')", Usu.IDUsuario, Fam.IDFamilia,  Usu.DVH);
                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = query;
                Comando.ExecuteNonQuery();
                Desconectar();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Buscar que exista la familia en otro usuario que no sea al que le estoy sacando la familia
        //Buscar las Familias por usuario
        public bool BuscarUsuarioConFam(UsuarioBE u)
        {
            try
            {
                string consulta = string.Format("SELECT * FROM UsuarioFamilia Where ID_Usuario != '{0}'", u.IDUsuario);

                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = consulta;

                if (Comando.ExecuteScalar() == null)
                {
                    Desconectar();
                    return false;
                }
                else
                {
                    Desconectar();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Buscar las Familias por usuario
        public bool BuscarUsuarioFam(UsuarioBE u)
        {
            try
            {
                string consulta = string.Format("SELECT * FROM UsuarioFamilia Where ID_Usuario != '{0}'", u.IDUsuario);

                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = consulta;

                if (Comando.ExecuteScalar() == null)
                {
                    Desconectar();
                    return false;
                }
                else
                {
                    Desconectar();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool BuscarUsuarioPat(UsuarioBE u)
        {
            try
            {
                string consulta = string.Format("SELECT * FROM UsuarioPatente Where ID_Usuario = '{0}'", u.IDUsuario);

                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = consulta;

                if (Comando.ExecuteScalar() == null)
                {
                    Desconectar();
                    return false;
                }
                else
                {
                    Desconectar();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Buscar las Familias asignadas al resto de los usuarios
        public bool BuscarUsuarioFam(UsuarioBE u, FamiliaBE Fam)
        {
            try
            {
                string consulta = string.Format("SELECT * FROM UsuarioFamilia Where ID_Usuario != '{0}' and ID_Familia = '{1}'", u.IDUsuario, Fam.NombreFamilia);
                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = consulta;
                if (Comando.ExecuteScalar() == null)
                {
                    Desconectar();
                    return false;
                }
                else
                {
                    Desconectar();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Buscar las Familias asignadas al resto de los usuarios
        public bool Buscartodaslasfamilias(FamiliaBE Fam)
        {
            try
            {
                string consulta = string.Format("SELECT * FROM UsuarioFamilia  Where ID_Familia = '{0}'", Fam.IDFamilia);
                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = consulta;
                if (Comando.ExecuteScalar() == null)
                {
                    Desconectar();
                    return false;
                }
                else
                {
                    Desconectar();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Actualizar DVH
        public bool ActualizarDVH(UsuarioBE usuario)
        {
            try
            {
                string query = string.Format("UPDATE Usuarios SET DVH = {1}  WHERE ID_Usuario = '{0}'", usuario.Nombre, usuario.DVH);
                Conectar();
                Comando.Connection = Conect;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = query;
                Comando.ExecuteNonQuery();
                Desconectar();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       //Buscr Id del Usuario 
        //public UsuarioBE  BuscarIDdelUsuario (UsuarioBE u)
        //{
        //    try
        //    {
        //        string consulta = string.Format("SELECT * FROM Usuarios   Where NombreUsuario = '{0}'", u.NombreUsuario , u.IDUsuario);
        //        Conectar();
        //        Comando.Connection = Conect;
        //        Comando.CommandType = CommandType.Text;
        //        Comando.CommandText = consulta;
        //        SqlDataReader lector = Comando.ExecuteReader();
        //        foreach (u.NombreUsuario in Usuarios u)
        //        {
        //            //Ojo con esto
        //            if (Perfil.GetType() == typeof(PerfilBLL_E))
        //            {
        //                Fam = (PerfilBLL_E)Perfil;
        //            }
        //        }
        //        while (lector.Read())
        //        {
        //            UsuarioBE UsuBe = new UsuarioBE();
        //            UsuBe.IDUsuario = int.Parse(lector["ID_Usuario"].ToString());
        //            UsuBe.NombreUsuario = (lector["NombreUsuario"].ToString());
                    
        //        }
        //        Desconectar();
        //        return U. ;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
    }
}
