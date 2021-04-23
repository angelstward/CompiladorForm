using System.Collections.Generic;

namespace CompiladorForm.AnalisisLexico
{
    public  class ComponenteLexico

    {
        private string Lexema;
        private Categoria categoria;
        private int NumeroLinea;
        private int PosicionInicial;
        private int PosicionFinal;
        private TipoComponente Tipo;

        protected ComponenteLexico(string Lexema, Categoria Categoria, int NumeroLinea,int PosicionInicial,int PosicionFinal,TipoComponente Tipo)
        {
            this.Lexema = Lexema;
            this.categoria = categoria;
            this.NumeroLinea = NumeroLinea;
            this.PosicionFinal = PosicionFinal;
            this.PosicionInicial = PosicionInicial;
            this.Tipo = Tipo;
        }

        public static ComponenteLexico crearSimbolo(string Lexema, Categoria Categoria, int NumeroLinea, int PosicionInicial, int PosicionFinal)
        {
            return new ComponenteLexico( Lexema,  Categoria,  NumeroLinea,  PosicionInicial,  PosicionFinal,TipoComponente.SIMBOLO)
        }

        public static ComponenteLexico crearDummy(string Lexema, Categoria Categoria, int NumeroLinea, int PosicionInicial, int PosicionFinal)
        {
            return new ComponenteLexico(Lexema, Categoria, NumeroLinea, PosicionInicial, PosicionFinal, TipoComponente.DUMMY)
        }

        public static ComponenteLexico crearPalabraReservada(string Lexema, Categoria Categoria, int NumeroLinea, int PosicionInicial, int PosicionFinal)
        {
            return new ComponenteLexico(Lexema, Categoria, NumeroLinea, PosicionInicial, PosicionFinal, TipoComponente.PALABRA_RESERVADA)
        }

        public static ComponenteLexico crearPalabraReservada(string Lexema, Categoria Categoria)
        {
            return new ComponenteLexico(Lexema, Categoria, 0, 0, 0, TipoComponente.PALABRA_RESERVADA)
        }

        public static ComponenteLexico crearLiteral(string Lexema, Categoria Categoria, int NumeroLinea, int PosicionInicial, int PosicionFinal)
        {
            return new ComponenteLexico(Lexema, Categoria, NumeroLinea, PosicionInicial, PosicionFinal, TipoComponente.LITERAL)
        }

        public TipoComponente ObtenerTipo()
        {
            return Tipo;
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
    }
}
