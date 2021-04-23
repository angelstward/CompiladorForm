using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompiladorForm.Transversal
{
    public class TablaDummies
    {

        private Dictionary<String, List<ComponenteLexico>> DUMMIES = new Dictionary<String, ComponenteLexico>();

        private static TablaDummies INSTANCIA = new TablaDummies();

        private TablaDummies()
        {

        }

        public static void Limpiar()
        {
            INSTANCIA.DUMMIES.Clear();
        }

        private List<ComponenteLexico> obtenerDummies(String Lexema)
        {
            if (DUMMIES.ContainsKey(Lexema))
            {
                DUMMIES.Add(Lexema, new List<ComponenteLexico>());
            }

            return DUMMIES[Lexema];
        }

        public static void Agregar(ComponenteLexico componente)
        {
            if(componente != null && !componente.ObtenerLexema().Equals("")
                && componente.ObtenerTipo().Equals(TipoComponente.DUMMY))
            {
                INSTANCIA.ObtenerDummies(componente.ObtenerLexema()).Add(componente)
            }
        }

        public static List<ComponenteLexico> ObtenerDummies()
        {
            return INSTANCIA.DUMMIES.Values.SelectMany(componente => componente).ToList();
        }
       

    }
}
