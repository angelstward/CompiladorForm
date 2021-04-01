using System.Collections.Generic;

namespace CompiladorForm.AnalisisLexico
{
    public static class DiccionarioToMorse
    {
        public static Dictionary<string, string> MorseAlfabeto = new Dictionary<string, string>(){
                { "A", ".-" },
                { "B", "-..." },
                { "C", "-.-." },
                { "D", "-.." },
                { "E", "." },
                { "F", "..-." },
                { "G", "--." },
                { "H", "...." },
                { "I", ".." },
                { "J", ".---" },
                { "K", "-.-" },
                { "L", ".-.." },
                { "M", "--" },
                { "N", "-." },
                { "O", "---" },
                { "P", ".--." },
                { "Q", "--.-" },
                { "R", ".-." },
                { "S", "..." },
                { "T", "-" },
                { "U", "..-" },
                { "V", "...-" },
                { "W", ".--" },
                { "X", "-..-" },
                { "Y", "-.--" },
                { "Z", "--.." },
                { "Á", ".--.-" },
                { "É", "..-.." },
                { "Ñ", "--.--" },
                { "Ó", "---." },
                {"\r\n","/" },
                {" ","/" }

            };
        public static Dictionary<string, string> MorseaNumeros = new Dictionary<string, string>
            {
                { "0", "-----" },
                { "1", ".----" },
                { "2", "..---" },
                { "3", "...--" },
                { "4", "....-" },
                { "5", "....." },
                { "6", "-...." },
                { "7", "--..." },
                { "8", "---.." },
                { "9", "----." }
            };
        private static readonly char comillaDoble = '"';
        public static Dictionary<string, string> MorseaPuntuacion = new Dictionary<string, string>
            {
                { ".", ".-.-.-" },
                { ",", "--..--" },
                { "?", "..--.." },
                { "'", ".----." },
                { "!", "-.-.--" },
                { "/", "-..-." },
                { "(", "-.--." },
                { ")", "-.--.-" },
                { "&", ".-..." },
                { ":", "---..." },
                { ";", "-.-.-." },
                { "=", "-...-" },
                { "+", ".-.-." },
                { "-", "-....-" },
                { "_", "..--.-" },
                { comillaDoble.ToString(), ".-..-." },
                { "$", "...-..-" },
                { "@", ".--.-." },
                { "¿", "..-.-" },
                { "¡", "--...-" }
            };
    }
}
