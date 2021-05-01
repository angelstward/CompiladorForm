using CompiladorForm.Transversal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CompiladorForm.Tablas
{
	public class TablaDummys{

        private Dictionary<String, List<ComponenteLexico>> DUMMYS = new Dictionary<String, List<ComponenteLexico>>();
        private static TablaDummys INSTANCIA = new TablaDummys();


        private TablaDummys()
        {
        }

        public static void Limpiar()
        {
            INSTANCIA.DUMMYS.Clear();

        }

        private List<ComponenteLexico> ObtenerDummys(String Lexema)
        {
            if (!DUMMYS.ContainsKey(Lexema))
            {
                DUMMYS.Add(Lexema, new List<ComponenteLexico>());
            }
            return DUMMYS[Lexema];


        }

        public static void Agregar(ComponenteLexico componente)
        {
            if (componente != null
                && !componente.ObtenerLexema().Equals("")
                && componente.ObtenerTipo().Equals(TipoComponente.DUMMY))

            {
                INSTANCIA.ObtenerDummys(componente.ObtenerLexema()).Add(componente);

            }
        }

        public static List<ComponenteLexico> ObtenerDummys()
        {
            return INSTANCIA.DUMMYS.Values.SelectMany(componente => componente).ToList();
        }



    }
}
