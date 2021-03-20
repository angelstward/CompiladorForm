using System;
using System.Collections.Generic;
using System.Text;

namespace CompiladorForm.Transversal
{
    public class Linea
    {
        private int NumeroLinea;
        private string Contenido;

        private Linea(int NumeroLinea, string Contenido)
        {
            this.NumeroLinea = NumeroLinea;
            this.Contenido = Contenido;
        }

        public int ObtenerNumeroLinea()
        {
            return NumeroLinea;
        }
        public string ObtenerContenido()
        {
            return Contenido;
        }

        internal static Linea Crear(int v1, string v2)
        {
            throw new NotImplementedException();
        }

        internal bool EsFinArchivo()
        {
            throw new NotImplementedException();
        }
    }
}
