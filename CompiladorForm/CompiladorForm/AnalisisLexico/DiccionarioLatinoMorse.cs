using System.Collections.Generic;
using System.Linq;

namespace CompiladorForm.AnalisisLexico
{
    public static class DiccionarioLatinoMorse
    {

        public static Dictionary<Transversal.Categoria, string> MorseAlfabeto = new Dictionary<Transversal.Categoria, string>(){
           
                { Transversal.Categoria.LETRA_A,  ".-" },
                { Transversal.Categoria.LETRA_B,  "-..." },
                { Transversal.Categoria.LETRA_C, "-.-." },
                { Transversal.Categoria.LETRA_D, "-.." },
                { Transversal.Categoria.LETRA_E, "." },
                { Transversal.Categoria.LETRA_F, "..-." },
                { Transversal.Categoria.LETRA_G, "--." },
                { Transversal.Categoria.LETRA_H, "...." },
                { Transversal.Categoria.LETRA_I, ".." },
                { Transversal.Categoria.LETRA_J, ".---" },
                { Transversal.Categoria.LETRA_K, "-.-" },
                { Transversal.Categoria.LETRA_L, ".-.." },
                { Transversal.Categoria.LETRA_M, "--" },
                { Transversal.Categoria.LETRA_N, "-." },
                { Transversal.Categoria.LETRA_O, "---" },
                { Transversal.Categoria.LETRA_P, ".--." },
                { Transversal.Categoria.LETRA_Q, "--.-" },
                { Transversal.Categoria.LETRA_R, ".-." },
                { Transversal.Categoria.LETRA_S, "..." },
                { Transversal.Categoria.LETRA_T, "-" },
                { Transversal.Categoria.LETRA_U, "..-" },
                { Transversal.Categoria.LETRA_V, "...-" },
                { Transversal.Categoria.LETRA_W, ".--" },
                { Transversal.Categoria.LETRA_X, "-..-" },
                { Transversal.Categoria.LETRA_Y, "-.--" },
                { Transversal.Categoria.LETRA_Z, "--.." },
                { Transversal.Categoria.ACENTO_A, ".--.-" },
                { Transversal.Categoria.ACENTO_E, "..-.." },
                { Transversal.Categoria.ENIE, "--.--" },
                { Transversal.Categoria.ACENTO_O, "---." },
                { Transversal.Categoria.NUMERO_0, "-----" },
                { Transversal.Categoria.NUMERO_1, ".----" },
                { Transversal.Categoria.NUMERO_2, "..---" },
                { Transversal.Categoria.NUMERO_3, "...--" },
                { Transversal.Categoria.NUMERO_4, "....-" },
                { Transversal.Categoria.NUMERO_5, "....." },
                { Transversal.Categoria.NUMERO_6, "-...." },
                { Transversal.Categoria.NUMERO_7, "--..." },
                { Transversal.Categoria.NUMERO_8, "---.." },
                { Transversal.Categoria.NUMERO_9, "----." },
               { Transversal.Categoria.PUNTO, ".-.-.-" },
                { Transversal.Categoria.COMA, "--..--" },
                { Transversal.Categoria.PREGUNTA_CIERRA, "..--.." },
                { Transversal.Categoria.COMILLA_SIMPLE, ".----." },
                { Transversal.Categoria.ADMIRACION_CIERRA, "-.-.--" },
                { Transversal.Categoria.SLASH, "-..-." },
                { Transversal.Categoria.PARENTESIS_ABRE, "-.--." },
                { Transversal.Categoria.PARENTESIS_CIERRA, "-.--.-" },
                { Transversal.Categoria.AND, ".-..." },
                { Transversal.Categoria.DOS_PUNTOS, "---..." },
                { Transversal.Categoria.PUNTO_COMA, "-.-.-." },
                { Transversal.Categoria.IGUAL, "-...-" },
                { Transversal.Categoria.MAS, ".-.-." },
                { Transversal.Categoria.GUION, "-....-" },
                { Transversal.Categoria.GUION_BAJO, "..--.-" },
                //ME QUEDA LA DUDA CON ESTE
              
                { Transversal.Categoria.COMILLA_DOBLE, ".-..-." },
                { Transversal.Categoria.SIGNO_PESOS, "...-..-" },
                { Transversal.Categoria.ARROBA, ".--.-." },
                { Transversal.Categoria.PREGUNTA_ENTRA, "..-.-" },
                { Transversal.Categoria.ADMIRACION_ABRE, "--...-" },
                //{"\r\n","/" },
                //{" ","/" }

        };

        public static Transversal.Categoria ValidarCategoria(string lexema)
        {
           
           return MorseAlfabeto.FirstOrDefault(x => x.Value == lexema).Key;
           
           
        }

    }
}
