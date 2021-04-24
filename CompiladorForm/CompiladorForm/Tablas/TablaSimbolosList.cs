using System;
using System.Collections.Generic;
using System.Text;

namespace CompiladorForm.Tablas
{
    public static class TablaSimbolosList
    {
        public static List<string> ColumnasTablaSimbolos = new List<string>()
        {
            "Lexema","Categoria", "NumeroLinea", "PosicionInicial", "PosicionFinal"
        };

        public static List<string> ColumnasTablaErrores = new List<string>()
        {
            "Lexema","Categoria", "NumeroLinea", "PosicionInicial", "PosicionFinal",
            "Falla", "Causa", "Solución"
        };
    }
}
