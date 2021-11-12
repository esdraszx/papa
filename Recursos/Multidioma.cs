using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;
using System.Threading.Tasks;

namespace Recursos
{
    public static class Multidioma
    {
        public static string CambiarIdioma(string palabra)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-AR");
            string algo = Idioma.ResourceManager.GetString(palabra);
            return algo;

        }
    }
}
