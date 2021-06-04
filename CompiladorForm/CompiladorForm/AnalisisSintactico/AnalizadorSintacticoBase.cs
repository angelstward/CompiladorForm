using System;
using System.Collections.Generic;
using System.Text;

namespace CompiladorForm.AnalisisSintactico
{
    interface AnalizadorSintacticoBase
    {
        public Dictionary<String, Object> Analizar(bool depurar);
    }
}
