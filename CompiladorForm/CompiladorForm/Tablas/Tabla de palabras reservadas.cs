using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompiladorForm.Transversal
{
    public class TablaPalabrasReservadas
    {
        private Dictionary<String, List<ComponenteLexico>> PALABRAS_RESERVADAS = new Dictionary<String, ComponenteLexico>();


        private Dictionary<String, List<ComponenteLexico>> SIMBOLOS = new Dictionary<String, ComponenteLexico>();

        private static TablaSimbolos INSTANCIA = new TablaSimbolos();

        private TablaPalabrasReservadas()
        {
            PALABRAS_RESERVADAS.Add("A", Categoria.PALABRA_RESERVADA_A);
            PALABRAS_RESERVADAS.Add("B", Categoria.PALABRA_RESERVADA_B);
            PALABRAS_RESERVADAS.Add("C", Categoria.PALABRA_RESERVADA_C);
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

        public Boolean EsPalabraReservada(String Lexema)
        {
            return PALABRAS_RESERVADAS.ContainsKey(Lexema);
        }

        public ComponenteLexico ObtenerPalabraReservada(String Lexema)
        {
            return PALABRAS_RESERVADAS[Lexema];
        }

        public static ComponenteLexico ComrpobarPalabraReservada(ComponenteLexico componente)
        {
            if(componente!=null && INSTANCIA.EsPalabraReservada(componente.ObtenerLexema()))
            {
                String Categoria = INSTANCIA.ObtenerPalabraReservada(componente.ObtenerLexema()).ObtenerCategoria();
                ComponenteLexico NuevoComponente = ComponenteLexico
                    .CrearPalabraReservada(componente.obtenerLexema(),Categoria, componente.obtenerNumeroLinea(),
                    componente.ObtenerPosicionInicial(),componente.ObtenerPosicionFinal())
                    return NuevoComponente;
            }
            return componente;
        }
       

    }
}
