using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompiladorForm.AnalisisLexico
{
    public static class DiccionarioMorseLatino
    {
        private static readonly char comillaDoble = '"';
        public static Dictionary<Transversal.Categoria, string> MorseAlfabeto = new Dictionary<Transversal.Categoria, string>(){

                { Transversal.Categoria.LETRA_A, "A" },
                { Transversal.Categoria.LETRA_B, "B" },
                { Transversal.Categoria.LETRA_C, "C" },
                { Transversal.Categoria.LETRA_D, "D" },
                { Transversal.Categoria.LETRA_E, "E" },
                { Transversal.Categoria.LETRA_F, "F" },
                { Transversal.Categoria.LETRA_G, "G" },
                { Transversal.Categoria.LETRA_H, "H" },
                { Transversal.Categoria.LETRA_I, "I" },
                { Transversal.Categoria.LETRA_J, "J" },
                { Transversal.Categoria.LETRA_K, "K" },
                { Transversal.Categoria.LETRA_L, "L" },
                { Transversal.Categoria.LETRA_M, "M" },
                { Transversal.Categoria.LETRA_N, "N" },
                { Transversal.Categoria.LETRA_O, "O" },
                { Transversal.Categoria.LETRA_P, "P" },
                { Transversal.Categoria.LETRA_Q, "Q" },
                { Transversal.Categoria.LETRA_R, "R" },
                { Transversal.Categoria.LETRA_S, "S" },
                { Transversal.Categoria.LETRA_T, "T" },
                { Transversal.Categoria.LETRA_U, "U" },
                { Transversal.Categoria.LETRA_V, "V" },
                { Transversal.Categoria.LETRA_W, "W" },
                { Transversal.Categoria.LETRA_X, "X" },
                { Transversal.Categoria.LETRA_Y, "Y" },
                { Transversal.Categoria.LETRA_Z, "Z" },
                { Transversal.Categoria.ACENTO_A, "Á" },
                { Transversal.Categoria.ACENTO_E, "É" },
                { Transversal.Categoria.ENIE, "Ñ" },
                { Transversal.Categoria.ACENTO_O, "Ó" },
                { Transversal.Categoria.NUMERO_0, "0" },
                { Transversal.Categoria.NUMERO_1, "1" },
                { Transversal.Categoria.NUMERO_2, "2" },
                { Transversal.Categoria.NUMERO_3, "3" },
                { Transversal.Categoria.NUMERO_4, "4" },
                { Transversal.Categoria.NUMERO_5, "5" },
                { Transversal.Categoria.NUMERO_6, "6" },
                { Transversal.Categoria.NUMERO_7, "7" },
                { Transversal.Categoria.NUMERO_8, "8" },
                { Transversal.Categoria.NUMERO_9, "9" },
                //{"\r\n","/" },
                //{" ","/" }
                { Transversal.Categoria.PUNTO, "." },
                { Transversal.Categoria.COMA, "," },
                { Transversal.Categoria.PREGUNTA_CIERRA, "?" },
                { Transversal.Categoria.COMILLA_SIMPLE, "'" },
                { Transversal.Categoria.ADMIRACION_CIERRA, "!" },
                { Transversal.Categoria.SLASH, "/" },
                { Transversal.Categoria.PARENTESIS_ABRE, "(" },
                { Transversal.Categoria.PARENTESIS_CIERRA, ")" },
                { Transversal.Categoria.AND, "&" },
                { Transversal.Categoria.DOS_PUNTOS, ":" },
                { Transversal.Categoria.PUNTO_COMA, ";" },
                { Transversal.Categoria.IGUAL, "=" },
                { Transversal.Categoria.MAS, "+" },
                { Transversal.Categoria.GUION, "-" },
                { Transversal.Categoria.GUION_BAJO, "_" },
                //ME QUEDA LA DUDA CON ESTE
                { Transversal.Categoria.COMILLA_DOBLE, comillaDoble.ToString() },
                { Transversal.Categoria.SIGNO_PESOS, "$" },
                { Transversal.Categoria.ARROBA, "@" },
                { Transversal.Categoria.PREGUNTA_ENTRA, "¿" },
                { Transversal.Categoria.ADMIRACION_ABRE, "¡" },
        };

        public static Boolean ExisteCategoria(Transversal.Categoria Categoria)
        {
            return MorseAlfabeto.ContainsKey(Categoria);
        }
        public static Transversal.Categoria ValidarCategoria(string lexema)
        {

            return MorseAlfabeto.FirstOrDefault(x => x.Value == lexema.ToUpper()).Key;


        }


    }
}
