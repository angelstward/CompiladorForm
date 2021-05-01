using CompiladorForm.Transversal;
using System;
using System.Collections.Generic;

namespace CompiladorForm.Tablas
{
    public class TablaPalabrasReservadas
    {
        private readonly Dictionary<string, ComponenteLexico> PALABRAS_RESERVADAS = new Dictionary<string, ComponenteLexico>();
        private readonly Dictionary<string, List<ComponenteLexico>> PALABRA_RESERVADA = new Dictionary<string, List<ComponenteLexico>>();
        private static readonly TablaPalabrasReservadas INSTANCIA = new TablaPalabrasReservadas();


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

        private List<ComponenteLexico> ObtenerPalabrasReservadas(string Lexema)
        {
            if (!PALABRA_RESERVADA.ContainsKey(Lexema))
            {
                PALABRA_RESERVADA.Add(Lexema, new List<ComponenteLexico>());
            }

            return PALABRA_RESERVADA[Lexema];
        }

        public static void Agregar(ComponenteLexico componente)
        {
            if (componente != null
                && !componente.ObtenerLexema().Equals("")
                && componente.ObtenerTipo().Equals(TipoComponente.PALABRA_RESERVADA))

            {
                INSTANCIA.ObtenerPalabraReservada(componente.ObtenerLexema());

            }
        }

        public ComponenteLexico ObtenerPalabraReservada(string Lexema)
        {
            return PALABRAS_RESERVADAS[Lexema];
        }


        public bool EsPalabraReservada(string Lexema)
        {
            return PALABRAS_RESERVADAS.ContainsKey(Lexema);
        }

        public static ComponenteLexico ComprobarPalabraReservada(ComponenteLexico Componente)
        {
            if (Componente != null && INSTANCIA.EsPalabraReservada(Componente.ObtenerLexema()))
            {
                Categoria Categoria = INSTANCIA.ObtenerPalabraReservada(Componente.ObtenerLexema()).ObtenerCategoria();
                ComponenteLexico NuevoComponente = ComponenteLexico
                    .CrearPalabraReservada(Componente.ObtenerLexema(), Categoria, Componente.ObtenerNumeroLinea(),
                    Componente.ObtenerPosicionInicial(), Componente.ObtenerPosicionFinal()
                    );

                return NuevoComponente;
            }

            return Componente;
        }

    }
}
