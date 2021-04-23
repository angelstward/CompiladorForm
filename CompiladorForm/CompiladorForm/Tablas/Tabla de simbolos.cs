using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompiladorForm.Transversal
{
    public class TablaSimbolos
    {

        private Dictionary<String, List<ComponenteLexico>> SIMBOLOS = new Dictionary<String, ComponenteLexico>();

        private static TablaSimbolos INSTANCIA = new TablaSimbolos();

        private TablaSimbolos()
        {

        }

        public static void Limpiar()
        {
            INSTANCIA.SIMBOLOS.Clear();
        }

        private List<ComponenteLexico> ObtenerSimbolo(String Lexema)
        {
            if (SIMBOLOS.ContainsKey(Lexema))
            {
                SIMBOLOS.Add(Lexema, new List<ComponenteLexico>());
            }

            return SIMBOLOS[Lexema];
        }

        public static void Agregar(ComponenteLexico componente)
        {
            if(componente != null && !componente.ObtenerLexema().Equals("")
                && componente.ObtenerTipo().Equals(TipoComponente.SIMBOLO))
            {
                INSTANCIA.ObtenerSimbolo(componente.ObtenerLexema()).Add(componente)
            }
        }

        public static List<ComponenteLexico> ObtenerSimbolos()
        {
            return INSTANCIA.SIMBOLOS.Values.SelectMany(componente => componente).ToList();
        }
       

    }
}
