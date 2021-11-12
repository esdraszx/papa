
using System;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Nini.Config;


namespace BE
{
    public static class Globales
    {
        public static string UsuarioCacheNomUsu { get; set; }
        public static int UsuarioCacheID{ get; set; }
        public static string Idioma { get; set; }

        public static readonly Encoding Encoder = Encoding.UTF8;
        public static string Encriptar(string TextoPlano, string semilla)
        {
            var des = CreateDes(semilla);
            var ct = des.CreateEncryptor();
            var input = Encoding.UTF8.GetBytes(TextoPlano);
            var output = ct.TransformFinalBlock(input, 0, input.Length);

            return Convert.ToBase64String(output);

        }

        public static string Desencriptar(string TextoEncriptado, string semilla)
        {
            var des = CreateDes(semilla);
            var ct = des.CreateDecryptor();
            var input = Convert.FromBase64String(TextoEncriptado);
            var output = ct.TransformFinalBlock(input, 0, input.Length);
            return Encoding.UTF8.GetString(output);
        }

        public static TripleDES CreateDes(string key)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            TripleDES des = new TripleDESCryptoServiceProvider();
            var desKey = md5.ComputeHash(Encoding.UTF8.GetBytes(key));
            des.Key = desKey;
            des.IV = new byte[des.BlockSize / 8];
            des.Padding = PaddingMode.PKCS7;
            des.Mode = CipherMode.ECB;
            return des;
        }

        public static void CambiarConexion(string cadena)
        {
            try
            {
                string configFileName = AppDomain.CurrentDomain.BaseDirectory + "config.ini";

                if (!File.Exists(configFileName))
                    File.Create(configFileName).Close();

                IniConfigSource configSource = new IniConfigSource(configFileName);

                IConfig demoConfigSection = configSource.Configs["LPPA2"];
                if (demoConfigSection == null)
                {
                    configSource.AddConfig("LPPA2");
                    configSource.Save();
                    demoConfigSection = configSource.Configs["LPPA2"];
                }

                demoConfigSection.Set("connectionString", Convert.ToBase64String(Encoding.UTF8.GetBytes(cadena)));
                configSource.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}

