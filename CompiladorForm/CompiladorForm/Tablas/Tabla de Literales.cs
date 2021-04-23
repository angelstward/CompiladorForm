using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompiladorForm.Transversal
{
    public class TablaLiterales
    {

        private Dictionary<String, List<ComponenteLexico>> LITERALES = new Dictionary<String, ComponenteLexico>();

        private static TablaLiterales INSTANCIA = new TablaLiterales();

        private TablaLiterales()
        {

        }

        public static void Limpiar()
        {
            INSTANCIA.LITERALES.Clear();
        }

        private List<ComponenteLexico> ObtenerLiteral(String Lexema)
        {
            if (LITERALES.ContainsKey(Lexema))
            {
                LITERALES.Add(Lexema, new List<ComponenteLexico>());
            }

            return LITERALES[Lexema];
        }

        public static void Agregar(ComponenteLexico componente)
        {
            if(componente != null && !componente.ObtenerLexema().Equals("")
                && componente.ObtenerTipo().Equals(TipoComponente.LITERAL))
            {
                INSTANCIA.ObtenerSimbolo(componente.ObtenerLexema()).Add(componente)
            }
        }

        public static List<ComponenteLexico> ObtenerLiterales()
        {
            return INSTANCIA.LITERALES.Values.SelectMany(componente => componente).ToList();
        }
       

    }
}
