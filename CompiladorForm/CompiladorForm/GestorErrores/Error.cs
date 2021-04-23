using System;
using System.Collections.Generic;
using System.Text;

namespace CompiladorForm.Transversal
{
    public class Error
    {
        private string Lexema;
        private Categoria categoria;
        private int NumeroLinea;
        private int PosicionInicial;
        private int PosicionFinal;
        private String Falla;
        private String Causa;
        private String Solucion;
        private TipoError Tipo;

        private Error(string Lexema, 
            Categoria Categoria,
            int NumeroLinea, 
            int PosicionInicial,
            int PosicionFinal,String Falla, String Causa, String Solucion,
            TipoError tipo)
        {
            this.Lexema = Lexema;
            this.categoria = categoria;
            this.NumeroLinea = NumeroLinea;
            this.PosicionFinal = PosicionFinal;
            this.PosicionInicial = PosicionInicial;
            this.Falla = Falla;
            this.Causa = Causa;
            this.Solucion = Solucion;
            this.Tipo = Tipo
        }

        public Error CrearErrorLexico(string Lexema,
            Categoria Categoria,
            int NumeroLinea,
            int PosicionInicial,
            int PosicionFinal, String Falla, String Causa, String Solucion)
        {
            return new Error( Lexema,
             Categoria,
             NumeroLinea,
             PosicionInicial,
             PosicionFinal,  Falla,  Causa,  Solucion,
            TipoError.LEXICO);
        }

        public string ObtenerLexema()
        {
            return Lexema;
        }

        public Categoria ObtenerCategoria()
        {
            return categoria;
        }

        public int ObtenerNumeroLinea()
        {
            return NumeroLinea;
        }

        public int ObtenerPosicionInicial()
        {
            return PosicionInicial;
        }

        public int ObtenerPosicionFinal()
        {
            return PosicionFinal;
        }

        public string ObtenerFalla()
        {
            return Falla;
        }

        public string ObtenerCausa()
        {
            return Causa;
        }

        public string ObtenerSolucion()
        {
            return Solucion;
        }

        public TipoError ObtenerTipoError()
        {
            return tipo;
        }
    }
}
