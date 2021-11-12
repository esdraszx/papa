using System;
using System.Security.Cryptography;

namespace BE
{
    public class BitacoraBE
    {
        public int ID_Evento { get; set; }
        public TripleDES DescripciónEnc { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaHora { get; set; }
        public string NombreUsuario { get; set; }
        public char Criticidad { get; set; }
        public string DVH { get; set; }

        public BitacoraBE()
        {

        }

        public BitacoraBE(int _idEvento , string descripcion , DateTime fechaHora)
        {
            ID_Evento = _idEvento;
            Descripcion = descripcion;
            FechaHora = fechaHora;
        }

    }


}
