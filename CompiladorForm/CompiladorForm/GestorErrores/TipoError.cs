using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompiladorForm.Transversal
{
    public class ManejadorErrores
    {
        private Dictionary<TipoError, List<Error>> ERRORES = new Dictionary<TipoError, List<Error>>;

        private static ManejadorErrores INSTANCIA = new ManejadorErrores();

        private ManejadorErrores()
        {
            ERRORES.Add(TipoError.LEXICO, new List<Error>());
            ERRORES.Add(TipoError.SINTACTICO, new List<Error>());
            ERRORES.Add(TipoError.SEMANTICO, new List<Error>());

        }

        public static void Limpiar()
        {
            INSTANCIA.ERRORES[TipoError.LEXICO].Clear();
            INSTANCIA.ERRORES[TipoError.SINTACTICO].Clear();
            INSTANCIA.ERRORES[TipoError.SEMANTICO].Clear();

        }

        public static List<Error> ObtenerErrores(TipoError Tipo)
        {
            return INSTANCIA.ERRORES[Tipo];
        }

        public static void Reportar(Error error)
        {
            if(error != null)
            {
                ObtenerErrores(error.ObtenerTipo()).Add(error);
            }
        }

        public static bool HayErrores(TipoError Tipo)
        {
            return ObtenerErrores(Tipo).Count > 0;
        }

        public static bool HayErroresLexicos()
        {
            return HayErrores(TipoError.LEXICO)
        }
        public static bool HayErroresSemanticos()
        {
            return HayErrores(TipoError.SEMANTICO)
        }
        public static bool HayErroresSintacticos()
        {
            return HayErrores(TipoError.SINTACTICO)
        }
        public static bool HayErrores()
        {
            return HayErroresLexicos() || HayErroresSemanticos() || HayErroresSintacticos();
        }

        public static List<Error> ObtenerErrores()
        {
            List<Error> ListaRetorno = new List<Error>();
            ListaRetorno.AddRange(ObtenerErrores(TipoError.LEXICO));
            ListaRetorno.AddRange(ObtenerErrores(TipoError.SINTACTICO));
            ListaRetorno.AddRange(ObtenerErrores(TipoError.SEMANTICO));
            return ListaRetorno;
        }
    }
}
