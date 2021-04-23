using System;

namespace CompiladorForm.Tablas
{
	public class TablaPalabrasReservadas
	{
        private Dictionary<String, ComponenteLexico> PALABRAS_RESERVADAS = new Dictionary<String, ComponenteLexico>();
        private Dictionary<String, List<ComponenteLexico>> PALABRA_RESERVADA = new Dictionary<String, List<ComponenteLexico>>();
        private Dictionary<String, List<ComponenteLexico>> PALABRA_RESERVADA = new Dictionary<String, List<ComponenteLexico>>();
        private static TablaPalabraReservadas INSTANCIA = new TablaPalabraReservadas();


        private TablaPalabrasReservadas()
        {
            PALABRAS_RESERVADAS.Add("A", ComponenteLexico.CrearPalabraReservada("A", Categoria.PALABRA_RESERVADA_A));
            PALABRAS_RESERVADAS.Add("B", ComponenteLexico.CrearPalabraReservada("B", Categoria.PALABRA_RESERVADA_B));
            PALABRAS_RESERVADAS.Add("C", ComponenteLexico.CrearPalabraReservada("C", Categoria.PALABRA_RESERVADA_C));

        }

        public static void Limpiar()
        {
            INSTANCIA.PALABRA_RESERVADA.Clear();

        }

        private List<ComponenteLexico> ObtenerPalabraReservada(String Lexema)
        {
            if (PALABRA_RESERVADA.Containskey(Lexema))
            {
                PALABRA_RESERVADA.Add(Lexema, new List<ComponenteLexico>());
            }

            return PALABRA_RESERVADA[Lexema];


        }

        public static void Agregar(ComponenteLexico componente)
        {
            if (componente != null
                && !componente.ObtenerLexema().Equals("")
                && componente.ObtenerTipo.Equals(TipoComponente.LITERAL))

            {
                INSTANCIA.ObtenerPalabraReservada(componente.ObtenerLexema()).Add(componente);

            }
        }



        public static ComponenteLexico ObtenerPalabraReservada()
        {
            return PALABRAS_RESERVADAS[Lexema];
        }


        public bool EsPalabraReservada(String Lexema)
        {
            return PALABRAS_RESERVADAS.ContainsKey(Lexema);
        }

        public static ComponenteLexico ComprobarPalabraReservada(ComponenteLexico Componente)
        {
            if (Componente != null && INSTANCIA.EsPalabraReservada(Componente.ObtenerLexema()))
            {
                Categoria Categoria = INSTANCIA.ObtenerPalabraReservada(Componente.ObtenerLexema()).ObtenerCategoria();
                ComponenteLexico NuevoComponente = ComponenteLexico
                    .CrearPalabraReservada(NuevoComponente.ObtenerLexema(), Categoria, Componente.ObtenerNumeroLinea(),
                    Componente.ObtenerPosicionInicial(), Componente.ObtenerPosicionFinal()
                    );

                return NuevoComponente;

            }

            return Componente;
        }

    }
}
