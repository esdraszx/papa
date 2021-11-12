using System;
using System.Security.Cryptography;
using System.Text;


namespace Servicios
{
    public class Encriptado
    {
        private static Encriptado Instancia;

        public static Encriptado GetInstance()
        {
            if (Instancia == null)
            {
                Instancia = new Encriptado();
            }

            return Instancia;
        }



        public static readonly Encoding Encoder = Encoding.UTF8;
        public string Encriptar(string TextoPlano, string semilla)
        {
            var des = CreateDes(semilla);
            var ct = des.CreateEncryptor();
            var input = Encoding.UTF8.GetBytes(TextoPlano);
            var output = ct.TransformFinalBlock(input, 0, input.Length);

            return Convert.ToBase64String(output);

        }

        public string Desencriptar(string TextoEncriptado, string semilla)
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
    }
}
